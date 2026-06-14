using ContainsDuplicate;

/// <summary>
/// This program demonstrates the three Contains Duplicate problem variations.
/// It runs predefined test cases and prints the results to the console.
/// Each test case shows the input, the expected output, and the actual output.
/// </summary>

// --- Test data for ContainsDuplicate (basic duplicate detection) ---
// Names for each test case to make output readable.
var testNames = new[]
{
    "Example 1",
    "Example 2",
    "Example 3"
};

// Input arrays for each test case.
// Example 1 has a duplicate (1), Example 2 has all unique, Example 3 has many duplicates.
var testArrays = new[]
{
    new[] { 1, 2, 3, 1 },
    new[] { 1, 2, 3, 4 },
    new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }
};

/// <summary>
/// Run the basic ContainsDuplicate tests.
/// For each test case, call the solver and print the result.
/// </summary>
for (int i = 0; i < testNames.Length; i++)
{
    // Call the ContainsDuplicate method with the current test array.
    bool result = ContainsDuplicateSolver.ContainsDuplicate(testArrays[i]);

    // Print test name.
    Console.WriteLine(testNames[i]);
    // Print the input array in a readable format.
    Console.WriteLine($"Input: nums = [{string.Join(", ", testArrays[i])}]");
    // Print the result as lowercase true/false (like typical coding challenge output).
    Console.WriteLine($"Output: {result.ToString().ToLower()}");
    // Blank line for readability.
    Console.WriteLine();
}

// --- Test data for ContainsNearbyDuplicate (duplicate within distance k) ---
var nearbyDuplicateNames = new[]
{
    "Contains Duplicate II Example 1",
    "Contains Duplicate II Example 2",
    "Contains Duplicate II Example 3"
};

var nearbyDuplicateArrays = new[]
{
    new[] { 1, 2, 3, 1 },      // duplicate 1 at indices 0 and 3, distance 3 <= k=3 -> true
    new[] { 1, 0, 1, 1 },      // duplicate 1 at indices 0 and 2, distance 2 > k=1? Actually k=1, distance 2 >1 -> but there is also duplicate at indices 2 and 3 distance 1 <=1 -> true
    new[] { 1, 2, 3, 1, 2, 3 } // duplicates but distances? k=2, check: 1 at 0 and 3 distance 3>2, 2 at 1 and 4 distance 3>2, 3 at 2 and 5 distance 3>2 -> false
};

var nearbyDuplicateKValues = new[] { 3, 1, 2 };

/// <summary>
/// Run ContainsNearbyDuplicate tests.
/// Each test case has an array and a k value.
/// </summary>
for (int i = 0; i < nearbyDuplicateNames.Length; i++)
{
    bool result = ContainsDuplicateSolver.ContainsNearbyDuplicate(
        nearbyDuplicateArrays[i],
        nearbyDuplicateKValues[i]);

    Console.WriteLine(nearbyDuplicateNames[i]);
    Console.WriteLine(
        $"Input: nums = [{string.Join(", ", nearbyDuplicateArrays[i])}], k = {nearbyDuplicateKValues[i]}");
    Console.WriteLine($"Output: {result.ToString().ToLower()}");
    Console.WriteLine();
}

// --- Test data for ContainsNearbyAlmostDuplicate (value difference <= t and index difference <= k) ---
var nearbyAlmostDuplicateValidNames = new[]
{
    "Contains Duplicate III Valid Example 1",
    "Contains Duplicate III Valid Example 2",
    "Contains Duplicate III Valid Example 3"
};

var nearbyAlmostDuplicateValidArrays = new[]
{
    new[] { 1, 2, 3, 1 },      // k=3, t=0 -> duplicate 1 at distance 3, value diff 0 <=0 -> true
    new[] { 1, 0, 1, 1 },      // k=1, t=2 -> indices 2 and 3 have values 1 and 1 diff 0 <=2, distance 1 <=1 -> true
    new[] { -3, -1, -4, -2 }   // k=2, t=1 -> check pairs: -3 and -1 diff 2>1, -3 and -4 diff 1<=1 distance 2<=2 -> true
};

var nearbyAlmostDuplicateValidKValues = new[] { 3, 1, 2 };
var nearbyAlmostDuplicateValidTValues = new[] { 0, 2, 1 };

Console.WriteLine("Contains Duplicate III Valid Test Cases");
Console.WriteLine("---------------------------------------");
for (int i = 0; i < nearbyAlmostDuplicateValidNames.Length; i++)
{
    bool result = ContainsDuplicateSolver.ContainsNearbyAlmostDuplicate(
        nearbyAlmostDuplicateValidArrays[i],
        nearbyAlmostDuplicateValidKValues[i],
        nearbyAlmostDuplicateValidTValues[i]);

    Console.WriteLine(nearbyAlmostDuplicateValidNames[i]);
    Console.WriteLine(
        $"Input: nums = [{string.Join(", ", nearbyAlmostDuplicateValidArrays[i])}], k = {nearbyAlmostDuplicateValidKValues[i]}, t = {nearbyAlmostDuplicateValidTValues[i]}");
    Console.WriteLine($"Output: {result.ToString().ToLower()}");
    Console.WriteLine();
}

// Invalid test cases (expected false)
var nearbyAlmostDuplicateInvalidNames = new[]
{
    "Contains Duplicate III Invalid Example 1",
    "Contains Duplicate III Invalid Example 2",
    "Contains Duplicate III Invalid Example 3"
};

var nearbyAlmostDuplicateInvalidArrays = new[]
{
    new[] { 1, 5, 9, 1, 5, 9 }, // k=2, t=3 -> no pair within distance 2 with value diff <=3? Let's trust expected false.
    new[] { 1, 2, 3, 1 },       // k=2, t=0 -> duplicate 1 at distance 3 >2 -> false
    new[] { -10, 0, 10, 20 }    // k=1, t=5 -> adjacent differences: 10,10,10 all >5 -> false
};

var nearbyAlmostDuplicateInvalidKValues = new[] { 2, 2, 1 };
var nearbyAlmostDuplicateInvalidTValues = new[] { 3, 0, 5 };

Console.WriteLine("Contains Duplicate III Invalid Test Cases");
Console.WriteLine("-----------------------------------------");
for (int i = 0; i < nearbyAlmostDuplicateInvalidNames.Length; i++)
{
    bool result = ContainsDuplicateSolver.ContainsNearbyAlmostDuplicate(
        nearbyAlmostDuplicateInvalidArrays[i],
        nearbyAlmostDuplicateInvalidKValues[i],
        nearbyAlmostDuplicateInvalidTValues[i]);

    Console.WriteLine(nearbyAlmostDuplicateInvalidNames[i]);
    Console.WriteLine(
        $"Input: nums = [{string.Join(", ", nearbyAlmostDuplicateInvalidArrays[i])}], k = {nearbyAlmostDuplicateInvalidKValues[i]}, t = {nearbyAlmostDuplicateInvalidTValues[i]}");
    Console.WriteLine($"Output: {result.ToString().ToLower()}");
    Console.WriteLine();
}
