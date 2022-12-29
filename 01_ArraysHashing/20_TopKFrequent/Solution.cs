/*
 * https://leetcode.com/problems/top-k-frequent-elements/description/
 *
 * Given an integer array `nums` and an integer `k`, return the `k`
 * _most frequent elements_. You may return the answer in *any order*.
 *
 * Example 1:
 * Input: nums = [1,1,1,2,2,3], k = 2
 * Output: [1,2]
 * 
 * Example 2:
 * Input: nums = [1], k = 1
 * Output: [1]
 *
 * Constraints:
 * - `1 <= nums.length <= 10^5`
 * - `k` is in the range `[1, the number of unique elements in the array]`.
 * - It is guaranteed that the answer is unique.
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.TopKFrequent;

public interface ISolution
{
    int[] TopKFrequent(int[] nums, int k);
}

public class Solution : ISolution
{
    // OJ score: 173 ms, 46 MB
    public int[] TopKFrequent(int[] nums, int k)
    {
        // For counting the frequency of each number
        var priorityDic = new Dictionary<int, int>();
        // Priority queue allows us to get k elements with the
        // lowest priority value from it.
        var numQueue = new PriorityQueue<int, int>();

        foreach(var n in nums)
        {
            // Same could be achieved by adding (n,1) for any new key and
            // incrementing the value instead, and then using the
            // `nums.Length - value` or simply the `value * -1` as the priority
            // value for the queue. Each way is just as fine.
            if(priorityDic.ContainsKey(n))
                priorityDic[n]--;
            else
                priorityDic.Add(n,nums.Length);
        }

        foreach(var kv in priorityDic)
        {
            numQueue.Enqueue(kv.Key, kv.Value);
        }
        
        var ret = new int[k];
        for(var i=0; i<k; ++i)
        {
            ret[i] = numQueue.Dequeue();
        }

        return ret;
    }
}