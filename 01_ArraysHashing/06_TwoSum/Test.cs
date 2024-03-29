/*
 * https://leetcode.com/problems/two-sum/description/
 *
 * Given an array of integers `nums` and an integer `target`, return _indices of
 * the two numbers such that they add up to `target`_.
 *
 * You may assume that each input would have *_exactly_ one solution*,
 * and you may not use the _same_ element twice.
 *
 * You can return the answer in any order.
 *
 * Example 1:
 * Input: nums = [2,7,11,15], target = 9
 * Output: [0,1]
 * Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
 *
 * Example 2:
 * Input: nums = [3,2,4], target = 6
 * Output: [1,2]
 *
 * Example 3:
 * Input: nums = [3,3], target = 6
 * Output: [0,1]
 * 
 * Constraints:
 * - `2 <= nums.length <= 10^4`
 * - `-10^9 <= nums[i] <= 10^9`
 * - `-10^9 <= target <= 10^9`
 * - *Only one valid answer exists.*
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.TwoSum;

internal class TwoSumTestCase : ITestCase
{
    public bool Run()
    {
        var result = Solution.TwoSum(Nums, Target);
        Array.Sort(result);
        Array.Sort(Expected);
        return result.SequenceEqual(Expected);
    }

    public ISolution Solution { get; init; } = null!;
    public int[] Nums { get; init; } = null!;
    public int Target { get; init; }
    public int[] Expected { get; init; } = null!;
}

public class TwoSumTest : Test
{
    public TwoSumTest(ISolution solution)
    {
        TestCases = new List<ITestCase>
        {
            new TwoSumTestCase
            {
                Solution = solution, 
                Nums = new[] { 2, 7, 11, 15 }, 
                Target = 9, 
                Expected = new[] { 0, 1 }
            },
            new TwoSumTestCase
            {
                Solution = solution, 
                Nums = new[] { 3, 2, 4 }, 
                Target = 6, 
                Expected = new[] { 1, 2 }
            },
            new TwoSumTestCase
            {
                Solution = solution, 
                Nums = new[] { 3, 3 }, 
                Target = 6, 
                Expected = new[] { 0, 1 }
            }
        };
    }
    public TwoSumTest() : this(new Solution()) { }
}