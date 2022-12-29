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

public class IntArrayComparer : IComparer<int[]>
{
    public int Compare(int[]? x, int[]? y)
    {
        if (x is null && y is null)
            return 0;
        if (x is null)
            return 1;
        if (y is null)
            return -1;
        
        return x.Length != y.Length 
            ? x.Length.CompareTo(y.Length) 
            : x.Select((t, i) => t.CompareTo(y[i]))
                .FirstOrDefault(c => c != 0);
    }
}

public class IntArrayEqualityComparer : IEqualityComparer<int[]>
{
    public bool Equals(int[]? x, int[]? y)
        => new IntArrayComparer().Compare(x, y) == 0;

    public int GetHashCode(int[] obj)
    {
        return obj.Aggregate(0, (current, s) => current ^ s.GetHashCode());
    }
}

public class ThreeSumTestCase : ITestCase
{
    public bool Run()
    {
        var result = Solution.ThreeSum(Nums);
        
        if(result.Count != Expected.Length)
            return false;

        foreach(var array in Expected)
        {
            Array.Sort(array);
        }

        var resultArray = new int[result.Count][];
        for(var i=0; i<result.Count; i++)
        {
            resultArray[i] = result[i].ToArray();
            Array.Sort(resultArray[i]);
        }
        
        Array.Sort(Expected, new IntArrayComparer());
        Array.Sort(resultArray, new IntArrayComparer());
        
        return resultArray.SequenceEqual(Expected, new IntArrayEqualityComparer());
    }
    
    public ISolution Solution { get; init; } = null!;
    public int[] Nums { get; init; } = null!;
    public int[][] Expected { get; init; } = null!;
}

public class ThreeSumTest : Test
{
    public ThreeSumTest(ISolution solution)
    {
        TestCases = new List<ITestCase>
        {
            new ThreeSumTestCase
            {
                Solution = solution,
                Nums = new[] {-1, 0, 1, 2, -1, -4},
                Expected = new[]
                {
                    new[] {-1, -1, 2},
                    new[] {-1, 0, 1}
                }
            },
            new ThreeSumTestCase
            {
                Solution = solution,
                Nums = new[] {0, 1, 1},
                Expected = Array.Empty<int[]>()
            },
            new ThreeSumTestCase
            {
                Solution = solution,
                Nums = new[] {0, 0, 0},
                Expected = new[]
                {
                    new[] {0, 0, 0}
                }
            }
        };
    }
    public ThreeSumTest() : this(new Solution()) { }
}