using TestProject;

/// <summary>
/// This program tests all Four TwoSum solving methods with various test cases.
/// It demonstrates:
/// 1. TwoSumBruteForce - O(n^2) time, works on unsorted arrays.
/// 2. TwoSumSorted - O(n) time, requires sorted array.
/// 3. TwoSum (HashMap) - O(n) time, works on unsorted arrays.
/// 4. AllTwoSumPairs - finds all pairs, O(n^2) time.
/// Each test prints input, output, and handles exceptions.
/// </summary>

// --- Test Data Definitions ---

// Valid test cases: each has exactly one correct answer (as per classic TwoSum problem).
var validNames = new[]
{
    "Example 1",
    "Example 2",
    "Example 3",
    "Negative Numbers 1",
    "Negative Numbers 2",
    "Negative Numbers 3"
};

var validArrays = new[]
{
    new[] { 2, 7, 15, 11 },          // 2+7=9
    new[] { 3, 2, 4 },               // 2+4=6
    new[] { 3, 3 },                  // 3+3=6
    new[] { -3, 4, 3, 90 },          // -3+3=0
    new[] { -10, 7, 19, -2, 5 },     // 7+(-12?) wait target -5: -10+5=-5? Actually -10+5=-5 yes.
    new[] { -1, -2, -3, -4, -5 }     // -3+-5=-8? target -8: -3+-5=-8
};

var validTargets = new[] { 9, 6, 6, 0, -5, -8 };

// Invalid test cases: no pair adds up to the target.
var invalidNames = new[]
{
    "Negative Test 1",
    "Negative Test 2",
    "Negative Test 3"
};

var invalidArrays = new[]
{
    new[] { 1, 2, 3 },               // target 10 impossible
    new[] { -1, -2, -3 },            // target 5 impossible
    new[] { 0, 1, 2, 3 }             // target -1 impossible
};

var invalidTargets = new[] { 10, 5, -1 };

// Multiple-pair test cases: more than one index pair gives the same target.
// Used to test AllTwoSumPairs method.
var multiplePairNames = new[]
{
    "Multiple Pairs 1",
    "Multiple Pairs 2",
    "Multiple Pairs 3"
};

var multiplePairArrays = new[]
{
    new[] { 1, 5, 7, -1, 5 },        // target 6: pairs (0,1) 1+5, (0,4) 1+5, (2,3) 7+(-1)
    new[] { 2, 4, 3, 3, 6, 0 },      // target 6: many pairs
    new[] { -1, -2, 3, 4, 5, 0, 1, 2 } // target 3: many pairs
};

var multiplePairTargets = new[] { 6, 6, 3 };

/// <summary>
/// Helper method to run a single test case for a solver that returns one pair.
/// </summary>
/// <param name="testName">Descriptive name for the test.</param>
/// <param name="nums">Input array.</param>
/// <param name="target">Target sum.</param>
/// <param name="solver">The solver function to test.</param>
/// <param name="sortBeforeRunning">If true, sorts the array before calling solver (required for TwoSumSorted).</param>
static void PrintResult(
    string testName,
    int[] nums,
    int target,
    Func<int[], int, int[]> solver,
    bool sortBeforeRunning)
{
    // If sorting is required, create a sorted copy; otherwise use original array.
    int[] input = sortBeforeRunning ? [.. nums.Order()] : nums;

    Console.WriteLine(testName);

    // Print input (sorted or original).
    if (sortBeforeRunning)
    {
        Console.WriteLine($"Sorted Input: nums = [{string.Join(", ", input)}], target = {target}");
    }
    else
    {
        Console.WriteLine($"Input: nums = [{string.Join(", ", input)}], target = {target}");
    }

    try
    {
        // Call the solver function.
        int[] result = solver(input, target);
        // Print the resulting indices.
        Console.WriteLine($"Output: [{string.Join(", ", result)}]");
    }
    catch (InvalidOperationException ex)
    {
        // Solver throws exception when no solution exists.
        Console.WriteLine($"Output: {ex.Message}");
    }

    Console.WriteLine(); // blank line for readability
}

/// <summary>
/// Helper method to run a test case for AllTwoSumPairs (returns all pairs).
/// </summary>
static void PrintAllPairsResult(string testName, int[] nums, int target)
{
    Console.WriteLine(testName);
    Console.WriteLine($"Input: nums = [{string.Join(", ", nums)}], target = {target}");

    try
    {
        List<int[]> pairs = TwoSumSolver.AllTwoSumPairs(nums, target);
        Console.WriteLine($"Output: {FormatPairs(pairs)}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Output: {ex.Message}");
    }

    Console.WriteLine();
}

/// <summary>
/// Formats a list of index pairs into a readable string.
/// Example: [[0, 1], [2, 3]]
/// </summary>
static string FormatPairs(List<int[]> pairs)
{
    var formattedPairs = new List<string>();

    foreach (int[] pair in pairs)
    {
        formattedPairs.Add($"[{pair[0]}, {pair[1]}]");
    }

    return $"[{string.Join(", ", formattedPairs)}]";
}

// --- Main Test Execution ---

Console.WriteLine("TwoSumBruteForce Valid Test Cases");
Console.WriteLine("---------------------------------");
for (int i = 0; i < validNames.Length; i++)
{
    PrintResult(validNames[i], validArrays[i], validTargets[i], TwoSumSolver.TwoSumBruteForce, false);
}

Console.WriteLine("TwoSumBruteForce Invalid Test Cases");
Console.WriteLine("-----------------------------------");
for (int i = 0; i < invalidNames.Length; i++)
{
    PrintResult(invalidNames[i], invalidArrays[i], invalidTargets[i], TwoSumSolver.TwoSumBruteForce, false);
}

Console.WriteLine("TwoSumSorted Valid Test Cases");
Console.WriteLine("-----------------------------");
for (int i = 0; i < validNames.Length; i++)
{
    // TwoSumSorted requires sorted input, so sortBeforeRunning = true.
    PrintResult(validNames[i], validArrays[i], validTargets[i], TwoSumSolver.TwoSumSorted, true);
}

Console.WriteLine("TwoSumSorted Invalid Test Cases");
Console.WriteLine("-------------------------------");
for (int i = 0; i < invalidNames.Length; i++)
{
    PrintResult(invalidNames[i], invalidArrays[i], invalidTargets[i], TwoSumSolver.TwoSumSorted, true);
}

Console.WriteLine("TwoSum HashMap Valid Test Cases");
Console.WriteLine("-------------------------------");
for (int i = 0; i < validNames.Length; i++)
{
    PrintResult(validNames[i], validArrays[i], validTargets[i], TwoSumSolver.TwoSum, false);
}

Console.WriteLine("TwoSum HashMap Invalid Test Cases");
Console.WriteLine("---------------------------------");
for (int i = 0; i < invalidNames.Length; i++)
{
    PrintResult(invalidNames[i], invalidArrays[i], invalidTargets[i], TwoSumSolver.TwoSum, false);
}

Console.WriteLine("AllTwoSumPairs Multiple Pair Test Cases");
Console.WriteLine("---------------------------------------");
for (int i = 0; i < multiplePairNames.Length; i++)
{
    PrintAllPairsResult(multiplePairNames[i], multiplePairArrays[i], multiplePairTargets[i]);
}

Console.WriteLine("AllTwoSumPairs Invalid Test Cases");
Console.WriteLine("---------------------------------");
for (int i = 0; i < invalidNames.Length; i++)
{
    PrintAllPairsResult(invalidNames[i], invalidArrays[i], invalidTargets[i]);
}
