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

public interface ISolution
{
    int Trap(int[] height);
}

// O(n) time, O(n) space
public class SolutionArray : ISolution
{
    // OJ score: 109 ms, 43.1 MB
    public int Trap(int[] height)
    {
        var l = height.Length;
        var leftMax = new int[l];
        var rightMax = new int[l];
        
        leftMax[0] = 0;
        rightMax[l-1] = 0;
        
        // Max height is always the max of the previous max and the current height
        for (var i = 1; i < l; i++)
        {
            leftMax[i] = Math.Max(leftMax[i-1], height[i-1]);
            rightMax[l-i-1] = Math.Max(rightMax[l-i], height[l-i]);
        }
        
        var sum = 0;
        // The amount of water stored at a given index is the min of the left
        // and right max minus the current height (non-negative)
        for (var i = 0; i < l; i++)
        {
            var h = Math.Min(leftMax[i], rightMax[i]);
            if (h > height[i]) sum += h - height[i];
        }

        return sum;
    }
}

// O(n) time, O(1) space
public class SolutionTwoPointers : ISolution
{
    // OJ score: 93 ms, 42.3 MB
    public int Trap(int[] height)
    {
        var left = 0;
        var right = height.Length - 1;
        var leftMax = height[0];
        var rightMax = height[right];
        var sum = 0;
        
        while (left < right)
        {
            if (height[left] < height[right])
            {
                left++;
                // If the current height is greater than the left max,
                // no water can be stored - update the left max
                if (height[left] > leftMax) leftMax = height[left];
                // Otherwise, the amount of water stored is the left max
                // minus the current height
                else sum += leftMax - height[left];
            }
            else
            {
                right--;
                // Same rules apply for the right side
                if (height[right] > rightMax) rightMax = height[right];
                else sum += rightMax - height[right];
            }
        }
        
        return sum;
    }
}