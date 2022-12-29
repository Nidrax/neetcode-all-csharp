/*
 * https://leetcode.com/problems/3sum/description/
 * 
 * Given an integer array nums, return all the triplets
 * `[nums[i], nums[j], nums[k]]` such that `i != j`, `i != k`, and `j != k`,
 * and `nums[i] + nums[j] + nums[k] == 0`.
 *
 * Notice that the solution set must not contain duplicate triplets.
 *
 * Example 1:
 * Input: nums = [-1,0,1,2,-1,-4]
 * Output: [[-1,-1,2],[-1,0,1]]
 * Explanation: 
 *   nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
 *   nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
 *   nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
 *   The distinct triplets are [-1,0,1] and [-1,-1,2].
 *   Notice that the order of the output and the order
 *   of the triplets does not matter.
 *
 * Example 2:
 * Input: nums = [0,1,1]
 * Output: []
 * Explanation: The only possible triplet does not sum up to 0.
 *
 * Example 3:
 * Input: nums = [0, 0, 0]
 * Output: [[0, 0, 0]]
 * Explanation: The only possible triplet sums up to 0.
 *
 * Constraints:
 * - `0 <= nums.length <= 3000`
 * - `-10^5 <= nums[i] <= 10^5`
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.TwoPointers.ThreeSum;

public interface ISolution
{
    IList<IList<int>> ThreeSum(int[] nums);
}

public class Solution : ISolution
{
    //OJ score: 187 ms, 54.2 MB
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var res = new List<IList<int>>();
        if(nums.Length < 3) return res;
        
        // Sort the array to have a similar approach as to the 2Sum problem
        Array.Sort(nums);

        for(var f=0; f<nums.Length-2; ++f)
        {
            // First term has to be greater than 0 to have a chance to sum up to 0
            if(nums[f] > 0)
                break;
            // Skip duplicates
            if(f>0 && nums[f-1] == nums[f])
                continue;

            // Set left pointer to the next element and right pointer to the last element,
            // then proceed to find the remaining terms as in the 2Sum problem
            var l = f+1;
            var r = nums.Length-1;

            while(l<r)
            {
                var sum = nums[f] + nums[l] + nums[r];

                switch (sum)
                {
                    case < 0:
                        l++;
                        break;
                    case > 0:
                        r--;
                        break;
                    default:
                    {
                        res.Add(new List<int>
                        {
                            nums[f], nums[l], nums[r]
                        });

                        // Continue to find the next triplets (skip duplicated lefts)
                        do
                            ++l;
                        while(nums[l] == nums[l-1] && l<r);
                        break;
                    }
                }
            }
        }

        return res;
    }
}