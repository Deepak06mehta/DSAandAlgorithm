namespace ValidAnagram;

/// <summary>
/// This class provides four methods to check if two strings are anagrams.
/// An anagram means both strings contain exactly the same characters with the same frequencies.
/// The methods range from simple (brute force) to optimal (frequency count).
/// All methods assume the strings contain only lowercase English letters ('a'-'z').
/// </summary>
public static class ValidAnagramSolver
{
    /// <summary>
    /// Brute-force approach: For each character in s, try to find and remove a matching character from t.
    /// Time Complexity: O(n^2) because Remove searches the list each time.
    /// Space Complexity: O(n) for the list copy of t.
    /// </summary>
    /// <param name="s">First string.</param>
    /// <param name="t">Second string.</param>
    /// <returns>True if t is an anagram of s, false otherwise.</returns>
    public static bool IsAnagramBruteForce(string s, string t)
    {
        // Quick check: if lengths differ, they cannot be anagrams.
        if (s.Length != t.Length)
        {
            return false;
        }

        // Convert t to a List<char> because strings are immutable in C#.
        // A List allows us to remove characters as we match them.
        List<char> remainingCharacters = t.ToList();

        // Iterate through each character in s.
        foreach (char character in s)
        {
            // Try to remove the current character from the remaining characters of t.
            // Remove returns true if the character was found and removed.
            // If Remove returns false, the character is not present (or not enough copies).
            if (!remainingCharacters.Remove(character))
            {
                // Missing character means not anagrams.
                return false;
            }
        }

        // All characters in s were matched and removed from t's characters.
        return true;
    }

    /// <summary>
    /// Sorting approach: Sort both strings and compare the sorted sequences.
    /// Time Complexity: O(n log n) due to sorting.
    /// Space Complexity: Depends on sorting algorithm (typically O(n) or O(log n)).
    /// </summary>
    /// <param name="s">First string.</param>
    /// <param name="t">Second string.</param>
    /// <returns>True if t is an anagram of s, false otherwise.</returns>
    public static bool IsAnagramSorted(string s, string t)
    {
        // Length check first.
        if (s.Length != t.Length)
        {
            return false;
        }

        // Sort both strings character by character.
        // OrderBy returns an IEnumerable<char> sorted ascending.
        // SequenceEqual compares the two sorted sequences element by element.
        // Example: "listen" -> "eilnst", "silent" -> "eilnst" => equal.
        return s.OrderBy(character => character)
            .SequenceEqual(t.OrderBy(character => character));
    }

    /// <summary>
    /// Default public method: Uses the optimal frequency-count approach.
    /// </summary>
    /// <param name="s">First string.</param>
    /// <param name="t">Second string.</param>
    /// <returns>True if t is an anagram of s, false otherwise.</returns>
    public static bool IsAnagram(string s, string t)
    {
        return IsAnagramFrequencyCount(s, t);
    }

    /// <summary>
    /// Frequency-count approach (optimal for lowercase English letters).
    /// Uses a fixed-size array of 26 counters (one per letter).
    /// Time Complexity: O(n) - each character visited once.
    /// Space Complexity: O(1) - array size is always 26 regardless of input size.
    /// </summary>
    /// <param name="s">First string (lowercase a-z).</param>
    /// <param name="t">Second string (lowercase a-z).</param>
    /// <returns>True if t is an anagram of s, false otherwise.</returns>
    public static bool IsAnagramFrequencyCount(string s, string t)
    {
        // Anagrams must have the same length.
        if (s.Length != t.Length)
        {
            return false;
        }

        // Array of 26 integers, each representing count of a letter.
        // Index 0 = 'a', 1 = 'b', ..., 25 = 'z'.
        var letterCounts = new int[26];

        // Loop through both strings simultaneously using index i.
        for (int i = 0; i < s.Length; i++)
        {
            // Convert character to array index: 'a' -> 0, 'b' -> 1, etc.
            // s[i] - 'a' gives the position in the alphabet.
            // Increment count for character in s.
            letterCounts[s[i] - 'a']++;

            // Decrement count for character in t.
            // If both strings have same characters same times, net change is zero.
            letterCounts[t[i] - 'a']--;
        }

        // After processing, if all counts are zero, strings are anagrams.
        // All(count => count == 0) checks every element in the array.
        return letterCounts.All(count => count == 0);
    }
}
