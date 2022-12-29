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

public class TopKFrequentTestCase : ITestCase
{
    public bool Run()
    {
        var result = Solution.TopKFrequent(Nums, K);
        Array.Sort(result);
        Array.Sort(Expected);
        return result.SequenceEqual(Expected);
    }
    
    public ISolution Solution { get; init; } = null!;
    public int[] Nums { get; init; } = null!;
    public int K { get; init; }
    public int[] Expected { get; init; } = null!;
}

public class TopKFrequentTest : Test
{
    public TopKFrequentTest(ISolution solution)
    {
        TestCases = new List<ITestCase>
        {
            new TopKFrequentTestCase
            {
                Solution = solution,
                Nums = new[] {1, 1, 1, 2, 2, 3},
                K = 2,
                Expected = new[] {1, 2}
            },
            new TopKFrequentTestCase
            {
                Solution = solution,
                Nums = new[] {1},
                K = 1,
                Expected = new[] {1}
            },
            new TopKFrequentTestCase
            {
                Solution = solution,
                Nums = new[] {1, 2},
                K = 2,
                Expected = new[] {1, 2}
            },
            new TopKFrequentTestCase
            {
                Solution = solution,
                Nums = new[] {1, 1, 1, 2, 2, 3},
                K = 1,
                Expected = new[] {1}
            },
            new TopKFrequentTestCase
            {
                Solution = solution,
                Nums = new[] {1, 1, 1, 2, 2, 3},
                K = 3,
                Expected = new[] {1, 2, 3}
            }
        };
    }
    public TopKFrequentTest() : this(new Solution()) { }
}