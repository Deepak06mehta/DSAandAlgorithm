namespace ContainsDuplicate;

public static class ContainsDuplicateSolver
{
    // Stores seen values in a HashSet so we can detect a duplicate in O(n) time.
    public static bool ContainsDuplicate(int[] nums)
    {
        var seen = new HashSet<int>();

        foreach (int num in nums)
        {
            if (!seen.Add(num))
            {
                return true;
            }
        }

        return false;
    }

    // Stores the last index of each number and checks whether the duplicate is within distance k.
    public static bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var lastSeenIndex = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (lastSeenIndex.TryGetValue(nums[i], out int previousIndex) && i - previousIndex <= k)
            {
                return true;
            }

            lastSeenIndex[nums[i]] = i;
        }

        return false;
    }

    // Keeps the last k values in sorted order and checks whether any value differs by at most t.
    public static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
    {
        if (k <= 0 || t < 0)
        {
            return false;
        }

        var window = new SortedSet<long>();

        for (int i = 0; i < nums.Length; i++)
        {
            long current = nums[i];
            long lowerBound = current - t;
            long upperBound = current + t;

            if (window.GetViewBetween(lowerBound, upperBound).Count > 0)
            {
                return true;
            }

            window.Add(current);

            if (i >= k)
            {
                window.Remove(nums[i - k]);
            }
        }

        return false;
    }
}
