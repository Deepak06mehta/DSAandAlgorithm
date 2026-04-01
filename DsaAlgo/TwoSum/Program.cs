using TestProject;

// Valid test cases: each input has one correct answer.
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
    new[] { 2, 7, 15, 11 },
    new[] { 3, 2, 4 },
    new[] { 3, 3 },
    new[] { -3, 4, 3, 90 },
    new[] { -10, 7, 19, -2, 5 },
    new[] { -1, -2, -3, -4, -5 }
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
    new[] { 1, 2, 3 },
    new[] { -1, -2, -3 },
    new[] { 0, 1, 2, 3 }
};

var invalidTargets = new[] { 10, 5, -1 };

// Multiple-pair test cases: more than one index pair gives the same target.
var multiplePairNames = new[]
{
    "Multiple Pairs 1",
    "Multiple Pairs 2",
    "Multiple Pairs 3"
};

var multiplePairArrays = new[]
{
    new[] { 1, 5, 7, -1, 5 },
    new[] { 2, 4, 3, 3, 6, 0 },
    new[] { -1, -2, 3, 4, 5, 0, 1, 2 }
};

var multiplePairTargets = new[] { 6, 6, 3 };

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

// This helper prints one test case. If needed, it sorts the array before calling the solver.
static void PrintResult(
    string testName,
    int[] nums,
    int target,
    Func<int[], int, int[]> solver,
    bool sortBeforeRunning)
{
    int[] input = sortBeforeRunning ? [.. nums.Order()] : nums;

    Console.WriteLine(testName);

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
        int[] result = solver(input, target);
        Console.WriteLine($"Output: [{string.Join(", ", result)}]");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Output: {ex.Message}");
    }

    Console.WriteLine();
}

// This helper prints every matching pair for the "multiple pairs exist" version.
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

static string FormatPairs(List<int[]> pairs)
{
    var formattedPairs = new List<string>();

    foreach (int[] pair in pairs)
    {
        formattedPairs.Add($"[{pair[0]}, {pair[1]}]");
    }

    return $"[{string.Join(", ", formattedPairs)}]";
}
