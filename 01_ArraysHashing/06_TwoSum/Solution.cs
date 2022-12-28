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

public interface ISolution
{
    int[] TwoSum(int[] nums, int target);
}

public class Solution : ISolution
{
    // OJ score: 148 ms, 44.3 MB
    public int[] TwoSum(int[] nums, int target) {
        var dic = new Dictionary<int,int>();
        for(var i=0; i < nums.Length; ++i){
            var rest = target - nums[i];
            
            if(dic.ContainsKey(rest))
                return new[]{i, dic[rest]};
            
            if(!dic.ContainsKey(nums[i]))
                dic.Add(nums[i], i);
        }
        return new int[2];
    }
}