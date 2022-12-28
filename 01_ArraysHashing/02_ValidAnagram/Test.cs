/*
 * https://leetcode.com/problems/valid-anagram/description/
 *
 * Given two strings `s` and `t`, return `true` _if `t` is an anagram of `s`,
 * and `false` otherwise_.
 *
 * An *Anagram* is a word or phrase formed by rearranging the letters
 * of a different word or phrase, typically using all the original letters
 * exactly once.
 *
 * Example 1:
 * Input: s = "anagram", t = "nagaram"
 * Output: true
 * 
 * Example 2:
 * Input: s = "rat", t = "car"
 * Output: false
 * 
 * Constraints:
 * - `1 <= s.length, t.length <= 5 * 10^4`
 * - `s` and `t` consist of lowercase English letters.
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.ValidAnagram;

internal class ValidAnagramTestCase : ITestCase
{
    public bool Run()
    {
        var result = Solution.IsAnagram(S, T);
        return result == Expected;
    }

    public ISolution Solution { get; init; } = null!;
    public string S { get; init; } = null!;
    public string T { get; init; } = null!;
    public bool Expected { get; init; }
}

public class ValidAnagramTest : Test
{
    public ValidAnagramTest(ISolution solution)
    {
        TestCases = new List<ITestCase>
        {
            new ValidAnagramTestCase {Solution = solution, S = "anagram", T = "nagaram", Expected = true},
            new ValidAnagramTestCase {Solution = solution, S = "rat", T = "car", Expected = false},
            new ValidAnagramTestCase {Solution = solution, S = "a", T = "ab", Expected = false},
            new ValidAnagramTestCase {Solution = solution, S = "aacc", T = "ccac", Expected = false}
        };
    }
    public ValidAnagramTest() : this(new SolutionStringSort()) { }
}