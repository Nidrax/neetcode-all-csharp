/*
 * https://leetcode.com/problems/contains-duplicate/description/
 * 
 * Given an integer array `nums`, return `true` if any value appears *at least
 * twice* in the array, and return `false` if every element is distinct.
 *
 * Example 1:
 * Input: nums = [1,2,3,1]
 * Output: true
 *
 * Example 2:
 * Input: nums = [1,2,3,4]
 * Output: false
 *
 * Example 3:
 * Input: nums = [1,1,1,3,3,4,3,2,4,2]
 * Output: true
 *
 * Constraints:
 * - `1 <= nums.length <= 10^5`
 * - `-10^9 <= nums[i] <= 10^9`
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.ContainsDuplicate;

public interface ISolution
{
    bool ContainsDuplicate(int[] nums);
}

public class Solution : ISolution
{
    //OJ score: 176 ms, 52.7 MB
    public bool ContainsDuplicate(int[] nums) {
        var dic = new HashSet<int>();
        foreach(var num in nums)
        {
            if(dic.Contains(num))
                return true;

            dic.Add(num);
        }
        return false;
    }
}