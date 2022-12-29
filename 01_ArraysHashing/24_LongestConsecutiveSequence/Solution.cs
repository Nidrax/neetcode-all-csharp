/*
 * https://leetcode.com/problems/longest-consecutive-sequence/description/
 *
 * Given an unsorted array of integers `nums`, return _the length of the
 * longest consecutive elements sequence_.
 *
 * You must write an algorithm that runs in `O(n)` time.
 *
 * Example 1:
 * Input: nums = [100,4,200,1,3,2]
 * Output: 4
 * Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
 *
 * Example 2:
 * Input: nums = [0,3,7,2,5,8,4,6,0,1]
 * Output: 9
 *
 * Constraints:
 * - `0 <= nums.length <= 10^5`
 * - `-10^9 <= nums[i] <= 10^9`
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.LongestConsecutiveSequence;

public interface ISolution
{
    int LongestConsecutive(int[] nums);
}

public class SolutionSortedList : ISolution
{
    // OJ score: 156 ms, 49.4 MB
    public int LongestConsecutive(int[] nums) {
        // Handle edge cases
        if(nums.Length == 0)
            return 0;

        // Apparently converting the HashSet back to a list and sorting it,
        // then running a single iteration through it is twice as fast as the
        // HashSet.Contains() solution below suggested on NeetCode.io
        var n = new HashSet<int>(nums).ToList();
        n.Sort();
        
        int longest = 1, length = 1;
        for(var i=1; i<n.Count; ++i)
        {
            // If the current number is one more than the previous number,
            // increment the length of the current sequence.
            // Otherwise, reset the length of the current sequence and
            // set the longest sequence length to the max of the two.
            if(n[i] == n[i-1] + 1)
            {
                ++length;
            }
            else
            {
                longest = Math.Max(length, longest);
                length = 1;
            }
        }
        longest = Math.Max(length, longest);

        return longest;
    }
}

// Based on NeetCode.io solution
public class SolutionHashSet : ISolution
{
    // OJ score: 311 ms, 49.4 MB
    public int LongestConsecutive(int[] nums) {
        if(nums.Length == 0)
            return 0;

        var numSet = new HashSet<int>(nums);
        
        var longest = 0;
        foreach (var n in nums)
        {
            // Find the start of the sequence
            if(numSet.Contains(n - 1)) continue;
            
            var length = 1;
            
            // While the next number in the sequence is in the set,
            // increment the length of the sequence.
            while(numSet.Contains(n + length))
                length++;

            longest = Math.Max(longest,length);
        }

        return longest;
    }
}