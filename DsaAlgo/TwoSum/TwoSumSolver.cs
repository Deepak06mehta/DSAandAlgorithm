namespace TestProject;

/// <summary>
/// This class provides four methods to solve the Two Sum problem and its variations.
/// Each method is explained in simple terms for beginners.
/// </summary>
public static class TwoSumSolver
{
    /// <summary>
    /// Finds ALL pairs of indices whose values add up to the target.
    /// Uses brute-force nested loops (O(n^2) time).
    /// </summary>
    /// <param name="nums">Array of integers.</param>
    /// <param name="target">Target sum.</param>
    /// <returns>List of index pairs (each pair is an int[2]).</returns>
    /// <exception cref="InvalidOperationException">Thrown if no pair exists.</exception>
    public static List<int[]> AllTwoSumPairs(int[] nums, int target)
    {
        // List to collect all matching index pairs.
        var pairs = new List<int[]>();

        // Outer loop: first index i from 0 to length-2.
        for (int i = 0; i < nums.Length - 1; i++)
        {
            // Inner loop: second index j from i+1 to length-1.
            // This ensures we don't use the same element twice and each pair is unique.
            for (int j = i + 1; j < nums.Length; j++)
            {
                // Check if the sum of the two elements equals the target.
                if (nums[i] + nums[j] == target)
                {
                    // Add the pair of indices to the list.
                    pairs.Add([i, j]);
                }
            }
        }

        // If no pairs found, throw an exception (as per problem specification).
        if (pairs.Count == 0)
        {
            throw new InvalidOperationException("No valid two sum pair exists for the given input.");
        }

        return pairs;
    }

    /// <summary>
    /// Finds the first pair of indices whose values add up to the target.
    /// Uses brute-force nested loops (O(n^2) time, O(1) space).
    /// </summary>
    /// <param name="nums">Array of integers.</param>
    /// <param name="target">Target sum.</param>
    /// <returns>Array of two indices.</returns>
    /// <exception cref="InvalidOperationException">Thrown if no solution exists.</exception>
    public static int[] TwoSumBruteForce(int[] nums, int target)
    {
        // Check every possible pair (i, j) with i < j.
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                // If the sum matches the target, return the indices immediately.
                if (nums[i] + nums[j] == target)
                {
                    return [i, j];
                }
            }
        }

        // If loops finish without finding a pair, throw exception.
        throw new InvalidOperationException("No valid two sum solution exists for the given input.");
    }

    /// <summary>
    /// Finds a pair of indices in a SORTED array that sum to the target.
    /// Uses the two-pointer technique (O(n) time, O(1) space).
    /// PRECONDITION: The input array must be sorted in ascending order.
    /// </summary>
    /// <param name="nums">Sorted array of integers.</param>
    /// <param name="target">Target sum.</param>
    /// <returns>Array of two indices.</returns>
    /// <exception cref="InvalidOperationException">Thrown if no solution exists.</exception>
    public static int[] TwoSumSorted(int[] nums, int target)
    {
        // Initialize two pointers: left at start, right at end.
        int left = 0;
        int right = nums.Length - 1;

        // Move pointers towards each other until they meet.
        while (left < right)
        {
            int sum = nums[left] + nums[right];

            // If sum equals target, we found the pair.
            if (sum == target)
            {
                return [left, right];
            }

            // If sum is too small, move left pointer right to increase sum.
            if (sum < target)
            {
                left++;
            }
            // If sum is too large, move right pointer left to decrease sum.
            else
            {
                right--;
            }
        }

        // Pointers crossed without finding a pair.
        throw new InvalidOperationException("No valid two sum solution exists for the given input.");
    }

    /// <summary>
    /// Finds a pair of indices that sum to the target using a hash map.
    /// This is the optimal O(n) time, O(n) space solution.
    /// Works on unsorted arrays.
    /// </summary>
    /// <param name="nums">Array of integers (unsorted).</param>
    /// <param name="target">Target sum.</param>
    /// <returns>Array of two indices.</returns>
    /// <exception cref="InvalidOperationException">Thrown if no solution exists.</exception>
    public static int[] TwoSum(int[] nums, int target)
    {
        // Dictionary to store numbers we have seen so far.
        // Key: number value, Value: its index.
        var map = new Dictionary<int, int>();

        // Iterate through the array once.
        for (int i = 0; i < nums.Length; i++)
        {
            int currentNumber = nums[i];
            // The complement is the number needed to reach the target.
            int complement = target - currentNumber;

            // Check if we have already seen the complement.
            if (map.TryGetValue(complement, out int complementIndex))
            {
                // Found the pair: complement index and current index.
                return [complementIndex, i];
            }

            // Store the current number and its index for future checks.
            // If the same number appears later, we keep the first index (which is fine because we only need one solution).
            map[currentNumber] = i;
        }

        // No pair found after scanning entire array.
        throw new InvalidOperationException("No valid two sum solution exists for the given input.");
    }
}
