using ContainsDuplicate;

var testNames = new[]
{
    "Example 1",
    "Example 2",
    "Example 3"
};

var testArrays = new[]
{
    new[] { 1, 2, 3, 1 },
    new[] { 1, 2, 3, 4 },
    new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }
};

for (int i = 0; i < testNames.Length; i++)
{
    bool result = ContainsDuplicateSolver.ContainsDuplicate(testArrays[i]);

    Console.WriteLine(testNames[i]);
    Console.WriteLine($"Input: nums = [{string.Join(", ", testArrays[i])}]");
    Console.WriteLine($"Output: {result.ToString().ToLower()}");
    Console.WriteLine();
}

var nearbyDuplicateNames = new[]
{
    "Contains Duplicate II Example 1",
    "Contains Duplicate II Example 2",
    "Contains Duplicate II Example 3"
};

var nearbyDuplicateArrays = new[]
{
    new[] { 1, 2, 3, 1 },
    new[] { 1, 0, 1, 1 },
    new[] { 1, 2, 3, 1, 2, 3 }
};

var nearbyDuplicateKValues = new[] { 3, 1, 2 };

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

var nearbyAlmostDuplicateValidNames = new[]
{
    "Contains Duplicate III Valid Example 1",
    "Contains Duplicate III Valid Example 2",
    "Contains Duplicate III Valid Example 3"
};

var nearbyAlmostDuplicateValidArrays = new[]
{
    new[] { 1, 2, 3, 1 },
    new[] { 1, 0, 1, 1 },
    new[] { -3, -1, -4, -2 }
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

var nearbyAlmostDuplicateInvalidNames = new[]
{
    "Contains Duplicate III Invalid Example 1",
    "Contains Duplicate III Invalid Example 2",
    "Contains Duplicate III Invalid Example 3"
};

var nearbyAlmostDuplicateInvalidArrays = new[]
{
    new[] { 1, 5, 9, 1, 5, 9 },
    new[] { 1, 2, 3, 1 },
    new[] { -10, 0, 10, 20 }
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
