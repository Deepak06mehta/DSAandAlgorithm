namespace TestProject;

public static class TwoSumSolver
{
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
