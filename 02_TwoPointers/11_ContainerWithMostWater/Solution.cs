/*
 * https://leetcode.com/problems/container-with-most-water/description/
 *
 * You are given an integer array `height` of length `n`.
 * There are `n` vertical lines drawn such that the two endpoints
 * of the `ith` line are `(i, 0)` and `(i, height[i])`.
 *
 * Find two lines that together with the x-axis form a container,
 * such that the container contains the most water.
 *
 * Return _the maximum amount of water a container can store_.
 *
 * *Notice* that you may not slant the container.
 *
 * Example 1:
 * [img](https://s3-lc-upload.s3.amazonaws.com/uploads/2018/07/17/question_11.jpg)
 * Input: height = [1,8,6,2,5,4,8,3,7]
 * Output: 49
 * Explanation: The above vertical lines are represented by array
 * [1,8,6,2,5,4,8,3,7]. In this case, the max area of water
 * (blue section) the container can contain is 49.
 *
 * Example 2:
 * Input: height = [1,1]
 * Output: 1
 *
 * Example 3:
 * Input: height = [4,3,2,1,4]
 * Output: 16
 *
 * Example 4:
 * Input: height = [1,2,1]
 * Output: 2
 *
 * Constraints:
 * - `n == height.length`
 * - `2 <= n <= 10^5`
 * - `0 <= height[i] <= 10^4`
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.TwoPointers.ContainerWithMostWater;

public interface ISolution
{
    int MaxArea(int[] height);
}

public class Solution : ISolution
{
    public int MaxArea(int[] height)
    {
        var l = 0;
        var r = height.Length-1;
        var ret = 0;
        
        while(l<r)
        {
            var ar = (r-l) * Math.Min(height[l], height[r]);
            ret = Math.Max(ret, ar);

            if(height[l]<height[r])
                ++l;
            else
                --r;
        }

        return ret;
    }
}