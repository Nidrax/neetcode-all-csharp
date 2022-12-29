/*
 * https://leetcode.com/problems/trapping-rain-water/description/
 *
 * Given `n` non-negative integers representing an elevation map where the
 * width of each bar is `1`, compute how much water it can trap after raining.
 *
 * Example 1:
 * [img](https://assets.leetcode.com/uploads/2018/10/22/rainwatertrap.png)
 * Input: `height = [0,1,0,2,1,0,1,3,2,1,2,1]`
 * Output: `6`
 * Explanation: The above elevation map (black section) is represented by
 * array `[0,1,0,2,1,0,1,3,2,1,2,1]`. In this case, `6` units of rain water
 * (blue section) are being trapped.
 *
 * Example 2:
 * Input: `height = [4,2,0,3,2,5]`
 * Output: `9`
 *
 * Constraints:
 * - `n == height.length`
 * - `0 <= n <= 3 * 10^4`
 * - `0 <= height[i] <= 10^5`
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.TwoPointers.TrappingRainWater;

public class TrappingRainWaterTestCase : ITestCase
{
    public bool Run()
    {
        var result = Solution.Trap(Height);
        return result == Expected;
    }
    
    public ISolution Solution { get; init; } = null!;
    public int[] Height { get; init; } = null!;
    public int Expected { get; init; }
}

public class TrappingRainWaterTest : Test
{
    public TrappingRainWaterTest(ISolution soultion)
    {
        TestCases = new List<ITestCase>
        {
            new TrappingRainWaterTestCase
            {
                Solution = soultion,
                Height = new[] {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1},
                Expected = 6
            },
            new TrappingRainWaterTestCase
            {
                Solution = soultion,
                Height = new[] {4, 2, 0, 3, 2, 5},
                Expected = 9
            },
            new TrappingRainWaterTestCase
            {
                Solution = soultion,
                Height = new[] {4, 2, 3},
                Expected = 1
            },
            new TrappingRainWaterTestCase
            {
                Solution = soultion,
                Height = new[] {5, 4, 1, 2},
                Expected = 1
            },
            new TrappingRainWaterTestCase
            {
                Solution = soultion,
                Height = new[] {5, 2, 1, 2, 1, 5},
                Expected = 14
            }
        };
    }
    public TrappingRainWaterTest() : this(new SolutionTwoPointers()) { }
}