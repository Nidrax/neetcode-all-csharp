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

internal class ArrayProductTestCase : ITestCase
{
    public bool Run()
    {
        var result = Solution.ProductExceptSelf(Nums);
        return result.SequenceEqual(Expected);
    }
    
    public ISolution Solution { get; init; } = null!;
    public int[] Nums { get; init; } = null!;
    public int[] Expected { get; init; } = null!;
}

internal class ArrayProductTest : Test
{
    public ArrayProductTest(ISolution solution)
    {
        TestCases = new List<ITestCase>
        {
            new ArrayProductTestCase
            {
                Solution = solution, 
                Nums = new[] {1, 2, 3, 4}, 
                Expected = new[] {24, 12, 8, 6}
            },
            new ArrayProductTestCase
            {
                Solution = solution, 
                Nums = new[] {-1, 1, 0, -3, 3}, 
                Expected = new[] {0, 0, 9, 0, 0}
            }
        };
    }

    public ArrayProductTest() : this(new Solution()) { }
}