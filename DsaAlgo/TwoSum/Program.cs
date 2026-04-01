using TestProject;

var validTestCases = new (string name, int[] nums, int target)[]
{
    ("Example 1", [2, 7, 11, 15], 9),
    ("Example 2", [3, 2, 4], 6),
    ("Example 3", [3, 3], 6),
    ("Negative Numbers 1", [-3, 4, 3, 90], 0),
    ("Negative Numbers 2", [-10, 7, 19, -2, 5], -5),
    ("Negative Numbers 3", [-1, -2, -3, -4, -5], -8)
};

foreach (var testCase in validTestCases)
{
    int[] nums = testCase.nums;
    int target = testCase.target;
    int[] bruteForceResult = TwoSumSolver.TwoSumBruteForce(nums, target);
    int[] optimalResult = TwoSumSolver.TwoSum(nums, target);

    Console.WriteLine(testCase.name);
    Console.WriteLine($"Input: nums = [{string.Join(", ", nums)}], target = {target}");
    Console.WriteLine($"Brute Force Output: [{string.Join(", ", bruteForceResult)}]");
    Console.WriteLine($"Optimal Output: [{string.Join(", ", optimalResult)}]");
    Console.WriteLine();
}

var negativeTestCases = new (string name, int[] nums, int target)[]
{
    ("Negative Test 1", [1, 2, 3], 10),
    ("Negative Test 2", [-1, -2, -3], 5),
    ("Negative Test 3", [0, 1, 2, 3], -1)
};

foreach (var testCase in negativeTestCases)
{
    Console.WriteLine(testCase.name);
    Console.WriteLine($"Input: nums = [{string.Join(", ", testCase.nums)}], target = {testCase.target}");

    try
    {
        int[] bruteForceResult = TwoSumSolver.TwoSumBruteForce(testCase.nums, testCase.target);
        Console.WriteLine($"Brute Force Output: [{string.Join(", ", bruteForceResult)}]");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Brute Force Output: {ex.Message}");
    }

    try
    {
        int[] optimalResult = TwoSumSolver.TwoSum(testCase.nums, testCase.target);
        Console.WriteLine($"Optimal Output: [{string.Join(", ", optimalResult)}]");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Optimal Output: {ex.Message}");
    }

    Console.WriteLine();
}
