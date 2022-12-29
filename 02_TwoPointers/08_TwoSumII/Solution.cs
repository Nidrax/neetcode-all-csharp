/*
 * https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
 * 
 * Given a *1-indexed* array of integers `numbers` that is already
 * _*sorted in non-decreasing order*_, find two numbers such that they
 * add up to a specific `target` number. Let these two numbers be
 * `numbers[index1]` and `numbers[index2]` where `1 <= index1 < index2 <= numbers.length`.
 *
 * Return _the indices of the two numbers, `index1` and `index2`,
 * *added by one* as an integer array `[index1, index2]` of length 2_.
 *
 * The tests are generated such that there is *exactly one solution*.
 * You *may not* use the same element twice.
 *
 * Your solution must use only constant extra space.
 *
 * Example 1:
 * Input: numbers = [2,7,11,15], target = 9
 * Output: [1,2]
 * Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.
 *
 * Example 2:
 * Input: numbers = [2,3,4], target = 6
 * Output: [1,3]
 * Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3.
 *
 * Example 3:
 * Input: numbers = [-1,0], target = -1
 * Output: [1,2]
 * Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2.
 *
 * Constraints:
 * - `2 <= numbers.length <= 3 * 10^4`
 * - `-1000 <= numbers[i] <= 1000`
 * - `numbers` is sorted in *non-decreasing order*.
 * - `-1000 <= target <= 1000`
 * - The tests are generated such that there is *exactly one solution*.
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.TwoPointers.TwoSumII;

public interface ISolution
{
    int[] TwoSum(int[] numbers, int target);
}

public class Solution : ISolution
{
    // OJ score: 164 ms, 45.9 MB
    public int[] TwoSum(int[] numbers, int target) {
        // Since the array is sorted, we can use two pointers to find the solution.
        var ret = new int[2];
        ret[0] = 0;
        ret[1] = numbers.Length - 1;

        while(ret[0] < ret[1])
        {
            var sum = numbers[ret[0]] + numbers[ret[1]];

            // If the sum is too small, move the left pointer (smaller term) to the right.
            // If the sum is too large, move the right pointer (larger term) to the left.
            if(sum < target)
            {
                ret[0]++;
            }
            else if(target < sum)
            {
                ret[1]--;
            }
            else
            {
                // Increment the indices by 1 to match the problem's requirement.
                ret[0]++;
                ret[1]++;
                return ret;
            }
        }

        return ret;
    }
}