/*
 * https://leetcode.com/problems/group-anagrams/description/
 *
 * Given an array of strings `strs`, group *the anagrams* together.
 * You can return the answer in *any order*.
 *
 * An *Anagram* is a word or phrase formed by rearranging the letters
 * of a different word or phrase, typically using all the original letters
 * exactly once.
 *
 * Example 1:
 * Input: strs = ["eat","tea","tan","ate","nat","bat"]
 * Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
 *
 * Example 2:
 * Input: strs = [""]
 * Output: [[""]]
 *
 * Example 3:
 * Input: strs = ["a"]
 * Output: [["a"]]
 *
 * Constraints:
 * - `1 <= strs.length <= 10^4`
 * - `0 <= strs[i].length <= 100`
 * - `strs[i]` consists of lower-case English letters.
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.GroupAnagrams;

public class StringArrayComparer : IComparer<string[]>
{
    public int Compare(string[]? x, string[]? y)
    {
        if (x is null && y is null)
            return 0;
        if (x is null)
            return 1;
        if (y is null)
            return -1;
        
        return x.Length != y.Length 
            ? x.Length.CompareTo(y.Length) 
            : x.Select((t, i) => string.Compare(
                t, y[i], StringComparison.Ordinal))
                .FirstOrDefault(result => result != 0);
    }

    public int GetHashCode(string[] obj)
    {
        return obj.Aggregate(0, (current, s) => current ^ s.GetHashCode());
    }
}

public class StringArrayEqualityComparer : IEqualityComparer<string[]>
{
    public bool Equals(string[]? x, string[]? y)
        => new StringArrayComparer().Compare(x, y) == 0;

    public int GetHashCode(string[] obj)
        => new StringArrayComparer().GetHashCode(obj);
}

internal class GroupAnagramsTestCase : ITestCase
{
    public bool Run()
    {
        var result = Solution.GroupAnagrams(Strs);

        if(result.Count != Expected.Length)
            return false;

        foreach(var array in Expected)
        {
            Array.Sort(array);
        }

        var resultArray = new string[result.Count][];
        for(var i=0; i<result.Count; i++)
        {
            resultArray[i] = result[i].ToArray();
            Array.Sort(resultArray[i]);
        }
        
        Array.Sort(Expected, new StringArrayComparer());
        Array.Sort(resultArray, new StringArrayComparer());
        
        return resultArray.SequenceEqual(Expected, new StringArrayEqualityComparer());
    }

    public ISolution Solution { get; init; } = null!;
    public string[] Strs { get; init; } = null!;
    public string[][] Expected { get; init; } = null!;
}

public class GroupAnagramsTest : Test
{
    public GroupAnagramsTest(ISolution solution)
    {
        TestCases = new List<ITestCase>
        {
            new GroupAnagramsTestCase
            {
                Solution = solution,
                Strs = new[] {"eat", "tea", "tan", "ate", "nat", "bat"}, 
                Expected = new[] {new[] {"bat"}, new[] {"nat", "tan"}, new[] {"ate", "eat", "tea"}}
            },
            new GroupAnagramsTestCase
            {
                Solution = solution,
                Strs = new[] {""}, 
                Expected = new[] {new[] {""}}
            },
            new GroupAnagramsTestCase
            {
                Solution = solution,
                Strs = new[] {"a"}, 
                Expected = new[] {new[] {"a"}}
            }
        };
    }
    public GroupAnagramsTest() : this(new Solution()) { }
}