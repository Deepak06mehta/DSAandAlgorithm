using ValidAnagram;

var testNames = new[]
{
    "Example 1",
    "Example 2",
    "Different Lengths",
    "Same Letters Different Counts"
};

var sValues = new[]
{
    "anagram",
    "rat",
    "a",
    "aacc"
};

var tValues = new[]
{
    "nagaram",
    "car",
    "ab",
    "ccac"
};

PrintResults("Brute Force", ValidAnagramSolver.IsAnagramBruteForce);
PrintResults("Sorting", ValidAnagramSolver.IsAnagramSorted);
PrintResults("Frequency Count", ValidAnagramSolver.IsAnagramFrequencyCount);

void PrintResults(string approachName, Func<string, string, bool> solver)
{
    Console.WriteLine($"{approachName} Approach");
    Console.WriteLine(new string('-', approachName.Length + 9));

    for (int i = 0; i < testNames.Length; i++)
    {
        bool result = solver(sValues[i], tValues[i]);

        Console.WriteLine(testNames[i]);
        Console.WriteLine($"Input: s = \"{sValues[i]}\", t = \"{tValues[i]}\"");
        Console.WriteLine($"Output: {result.ToString().ToLower()}");
        Console.WriteLine();
    }
}
