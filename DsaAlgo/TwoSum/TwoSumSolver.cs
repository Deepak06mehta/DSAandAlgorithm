namespace TestProject;

public static class TwoSumSolver
{
    // Returns all index pairs whose values add up to the target.
    public static List<int[]> AllTwoSumPairs(int[] nums, int target)
    {
        var pairs = new List<int[]>();

        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    pairs.Add([i, j]);
                }
            }
        }

        if (pairs.Count == 0)
        {
            throw new InvalidOperationException("No valid two sum pair exists for the given input.");
        }

        return pairs;
    }

    // Checks every possible pair and returns the first pair whose sum matches the target.
    public static int[] TwoSumBruteForce(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return [i, j];
                }
            }
        }

        throw new InvalidOperationException("No valid two sum solution exists for the given input.");
    }

    // Uses two pointers, so the input array must already be sorted in ascending order.
    public static int[] TwoSumSorted(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            int sum = nums[left] + nums[right];

            if (sum == target)
            {
                return [left, right];
            }

            if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        throw new InvalidOperationException("No valid two sum solution exists for the given input.");
    }

    // Stores previously seen numbers in a dictionary to find the complement in O(n) time.
    public static int[] TwoSum(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (map.TryGetValue(complement, out int complementIndex))
            {
                return [complementIndex, i];
            }

            map[nums[i]] = i;
        }

        throw new InvalidOperationException("No valid two sum solution exists for the given input.");
    }
}
