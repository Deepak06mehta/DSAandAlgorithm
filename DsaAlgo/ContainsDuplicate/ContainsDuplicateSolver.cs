namespace ContainsDuplicate;

/// <summary>
/// This class contains three methods that solve variations of the "Contains Duplicate" problem.
/// Each method is explained in simple terms so that even someone new to programming can understand.
/// </summary>
public static class ContainsDuplicateSolver
{
    /// <summary>
    /// Checks if the array contains any duplicate values.
    /// Uses a HashSet to remember numbers we have already seen.
    /// HashSet provides O(1) average time for checking if a number exists.
    /// </summary>
    /// <param name="nums">Array of integers to check for duplicates.</param>
    /// <returns>True if any value appears at least twice, false if all elements are distinct.</returns>
    public static bool ContainsDuplicate(int[] nums)
    {
        // Create a HashSet to store numbers we have encountered.
        // A HashSet only stores unique values, so adding a duplicate returns false.
        var seen = new HashSet<int>();

        // Loop through each number in the input array.
        foreach (int num in nums)
        {
            // Try to add the current number to the set.
            // If the number is already in the set, Add returns false.
            if (!seen.Add(num))
            {
                // We found a duplicate! Return true immediately.
                return true;
            }
            // If Add returns true, the number was not seen before, continue loop.
        }

        // If we finish the loop without finding duplicates, return false.
        return false;
    }

    /// <summary>
    /// Checks if there are two duplicate numbers such that their indices differ by at most k.
    /// Uses a Dictionary to remember the last index where each number appeared.
    /// </summary>
    /// <param name="nums">Array of integers.</param>
    /// <param name="k">Maximum allowed index difference between duplicates.</param>
    /// <returns>True if there exists i and j with nums[i] == nums[j] and |i - j| <= k.</returns>
    public static bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        // Dictionary to store the most recent index of each number.
        // Key: number value, Value: last index where this number was seen.
        var lastSeenIndex = new Dictionary<int, int>();

        // Iterate through the array with index i.
        for (int i = 0; i < nums.Length; i++)
        {
            int currentNumber = nums[i];

            // Check if we have seen this number before.
            // TryGetValue attempts to get the previous index; returns true if key exists.
            if (lastSeenIndex.TryGetValue(currentNumber, out int previousIndex))
            {
                // Calculate the distance between current index and previous index.
                int distance = i - previousIndex;

                // If the distance is within the allowed range k, we found a valid pair.
                if (distance <= k)
                {
                    return true;
                }
            }

            // Update the dictionary with the current index for this number.
            // This ensures we always have the most recent index for future checks.
            lastSeenIndex[currentNumber] = i;
        }

        // No pair found within distance k.
        return false;
    }

    /// <summary>
    /// Checks if there are two distinct indices i and j such that:
    /// - The absolute difference between nums[i] and nums[j] is at most t.
    /// - The absolute difference between i and j is at most k.
    /// Uses a SortedSet to maintain a sliding window of the last k numbers in sorted order.
    /// </summary>
    /// <param name="nums">Array of integers.</param>
    /// <param name="k">Maximum allowed index difference.</param>
    /// <param name="t">Maximum allowed value difference.</param>
    /// <returns>True if such a pair exists, false otherwise.</returns>
    public static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
    {
        // Edge cases: k must be positive (window size) and t must be non-negative (value difference).
        if (k <= 0 || t < 0)
        {
            return false;
        }

        // SortedSet keeps numbers in sorted order and allows efficient range queries.
        // We use long to avoid integer overflow when computing current +/- t.
        var window = new SortedSet<long>();

        // Iterate through the array.
        for (int i = 0; i < nums.Length; i++)
        {
            // Convert current number to long for safe arithmetic.
            long current = nums[i];

            // Define the acceptable value range: [current - t, current + t].
            long lowerBound = current - t;
            long upperBound = current + t;

            // GetViewBetween returns a view of elements within the range [lowerBound, upperBound].
            // If there is any number in the window within this range, we found a valid pair.
            if (window.GetViewBetween(lowerBound, upperBound).Count > 0)
            {
                return true;
            }

            // Add the current number to the window.
            window.Add(current);

            // Maintain window size of at most k elements.
            // When i >= k, the element at index i - k is now out of the allowed index range.
            if (i >= k)
            {
                // Remove the element that is now too far behind (index i - k).
                // We must remove by value; note that nums[i - k] is an int, but SortedSet contains long.
                window.Remove(nums[i - k]);
            }
        }

        // No valid pair found after checking all elements.
        return false;
    }
}
