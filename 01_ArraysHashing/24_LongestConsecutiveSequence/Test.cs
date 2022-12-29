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

public class LongestConsecutiveSequenceTestCase : ITestCase
{
    public bool Run()
    {
        var result = Solution.LongestConsecutive(Nums);
        return result == Expected;
    }
    
    public ISolution Solution { get; init; } = null!;
    public int[] Nums { get; init; } = null!;
    public int Expected { get; init; }
}

public class LongestConsecutiveSequenceTest : Test
{
    public LongestConsecutiveSequenceTest(ISolution solution)
    {
        TestCases = new List<ITestCase>
        {
            new LongestConsecutiveSequenceTestCase
            {
                Solution = solution,
                Nums = new[] {100, 4, 200, 1, 3, 2},
                Expected = 4
            },
            new LongestConsecutiveSequenceTestCase
            {
                Solution = solution,
                Nums = new[] {0, 3, 7, 2, 5, 8, 4, 6, 0, 1},
                Expected = 9
            }
        };
    }
    public LongestConsecutiveSequenceTest() : this(new SolutionSortedList()) { }
}