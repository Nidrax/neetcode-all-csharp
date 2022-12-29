/*
 * https://leetcode.com/problems/product-of-array-except-self/description/
 * 
 * Given an integer array `nums`, return an _array_ `answer` _such that_
 * `answer[i]` _is equal to the product of all the elements of_ `nums`
 * _except_ `nums[i]`.
 *
 * The product of any prefix or suffix of `nums` is *guaranteed* to fit
 * in a *32-bit* integer.
 *
 * You must write an algorithm that runs in `O(n)` time and without using
 * the division operation.
 *
 * Example 1:
 * Input: nums = [1,2,3,4]
 * Output: [24,12,8,6]
 *
 * Example 2:
 * Input: nums = [-1,1,0,-3,3]
 * Output: [0,0,9,0,0]
 *
 * Constraints:
 * - `2 <= nums.length <= 10^5`
 * - `-30 <= nums[i] <= 30`
 * - The product of any prefix or suffix of `nums` is *guaranteed* to fit
 *   in a *32-bit* integer.
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.ArrayProductExceptSelf;

public interface ISolution
{
    int[] ProductExceptSelf(int[] nums);
}

public class Solution : ISolution
{
    // OJ score: 169 ms, 54.3 MB
    public int[] ProductExceptSelf(int[] nums)
    {
        var l = nums.Length;
        var answer = new int[l];
        var leftProduct = new int[l];
        var rightProduct = new int[l];

        leftProduct[0] = nums[0];
        rightProduct[l-1] = nums[l-1];

        for(var i=1; i<l; ++i)
        {
            leftProduct[i] = nums[i] * leftProduct[i-1];
            rightProduct[l-1-i] = nums[l-1-i] * rightProduct[l-i];
        }

        answer[0] = rightProduct[1];
        answer[l-1] = leftProduct[l-2];

        for(var i=1; i<l-1; ++i)
        {
            answer[i] = leftProduct[i-1] * rightProduct[i+1];
        }

        return answer;
    }
}