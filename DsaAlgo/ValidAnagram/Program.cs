using ValidAnagram;

/// <summary>
/// This program tests three different anagram-checking approaches with the same set of test cases.
/// It demonstrates:
/// 1. Brute Force - O(n^2) time, O(n) space.
/// 2. Sorting - O(n log n) time.
/// 3. Frequency Count - O(n) time, O(1) space (optimal for lowercase letters).
/// Each approach is run against all test cases and results are printed.
/// </summary>

// --- Test Data ---

// Descriptive names for each test case.
var testNames = new[]
{
    "Example 1",                     // anagram vs nagaram -> true
    "Example 2",                     // rat vs car -> false
    "Different Lengths",             // a vs ab -> false
    "Same Letters Different Counts"  // aacc vs ccac -> false (counts differ)
};

// First string (s) for each test case.
var sValues = new[]
{
    "anagram",
    "rat",
    "a",
    "aacc"
};

// Second string (t) for each test case.
var tValues = new[]
{
    "nagaram",
    "car",
    "ab",
    "ccac"
};

/// <summary>
/// Runs all test cases for a given solver method and prints results.
/// </summary>
/// <param name="approachName">Name of the approach (e.g., "Brute Force").</param>
/// <param name="solver">Function that takes two strings and returns bool.</param>
void PrintResults(string approachName, Func<string, string, bool> solver)
{
    // Print a header for this approach.
    Console.WriteLine($"{approachName} Approach");

    // Print an underline matching the header length for visual separation.
    Console.WriteLine(new string('-', approachName.Length + 9));

    // Iterate over each test case by index.
    for (int i = 0; i < testNames.Length; i++)
    {
        // Call the solver with the corresponding s and t values.
        bool result = solver(sValues[i], tValues[i]);

        // Print test case name.
        Console.WriteLine(testNames[i]);
        // Print input strings.
        Console.WriteLine($"Input: s = \"{sValues[i]}\", t = \"{tValues[i]}\"");

        // Print result as lowercase true/false (common format).
        Console.WriteLine($"Output: {result.ToString().ToLower()}");

        // Blank line for readability.
        Console.WriteLine();
    }
}

// --- Execute Tests ---

// Run test suite for each approach.
PrintResults("Brute Force", ValidAnagramSolver.IsAnagramBruteForce);
PrintResults("Sorting", ValidAnagramSolver.IsAnagramSorted);
PrintResults("Frequency Count", ValidAnagramSolver.IsAnagramFrequencyCount);
