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

internal class ContainsDuplicateTestCase : ITestCase
{
    public bool Run()
    {
        var result = Solution.ContainsDuplicate(Input);
        return result == Expected;
    }

    public ISolution Solution { get; init; } = null!;
    public int[] Input { get; init; } = null!;
    public bool Expected { get; init; }
}

public class ContainsDuplicateTest : Test
{
    public ContainsDuplicateTest(ISolution solution)
    {
        TestCases = new List<ITestCase>
        {
            new ContainsDuplicateTestCase {Solution = solution, Input = new[] {1, 2, 3, 1}, Expected = true},
            new ContainsDuplicateTestCase {Solution = solution, Input = new[] {1, 2, 3, 4}, Expected = false},
            new ContainsDuplicateTestCase {Solution = solution, Input = new[] {1, 1, 1, 3, 3, 4, 3, 2, 4, 2}, Expected = true}
        };
    }
    public ContainsDuplicateTest() : this(new Solution()) { }
}