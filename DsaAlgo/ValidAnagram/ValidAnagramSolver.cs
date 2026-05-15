namespace ValidAnagram;

public static class ValidAnagramSolver
{
    // Brute force: remove one matching character from t for every character in s.
    public static bool IsAnagramBruteForce(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        List<char> remainingCharacters = t.ToList();

        foreach (char character in s)
        {
            if (!remainingCharacters.Remove(character))
            {
                return false;
            }
        }

        return true;
    }

    // Sorts both strings and compares characters at the same positions.
    public static bool IsAnagramSorted(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        return s.OrderBy(character => character)
            .SequenceEqual(t.OrderBy(character => character));
    }

    // Counts each lowercase English letter in both strings in O(n) time.
    public static bool IsAnagram(string s, string t)
    {
        return IsAnagramFrequencyCount(s, t);
    }

    // Optimal approach for lowercase English letters: O(n) time and O(1) space.
    public static bool IsAnagramFrequencyCount(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var letterCounts = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            letterCounts[s[i] - 'a']++;
            letterCounts[t[i] - 'a']--;
        }

        return letterCounts.All(count => count == 0);
    }
}
