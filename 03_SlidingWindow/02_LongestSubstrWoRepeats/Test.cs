/*
 * https://leetcode.com/problems/longest-substring-without-repeating-characters/
 *
 * Given a string `s`, find the length of the longest substring without
 * repeating characters (a substring is a contiguous non-empty sequence
 * of characters within a string).
 *
 * Example 1:
 * Input: s = "abcabcbb"
 * Output: 3
 * Explanation: The answer is "abc", with the length of 3.
 *
 * Example 2:
 * Input: s = "bbbbb"
 * Output: 1
 * Explanation: The answer is "b", with the length of 1.
 *
 * Example 3:
 * Input: s = "pwwkew"
 * Output: 3
 * Explanation: The answer is "wke", with the length of 3.
 * Notice that the answer must be a substring, "pwke" is a subsequence
 * and not a substring.
 *
 * Constraints:
 * - `0 <= s.length <= 5 * 10^4`
 * - `s` consists of English letters, digits, symbols and spaces.
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.SlidingWindow.LongestSubstrWoRepeats;

public class LongestSubstrWoRepeatsTestCase : ITestCase
{
    public bool Run()
    {
        var result = Solution.LengthOfLongestSubstring(S);
        return result == Expected;
    }
    
    public ISolution Solution { get; init; } = null!;
    public string S { get; init; } = null!;
    public int Expected { get; init; }
}

public class LongestSubstrWoRepeatsTest : Test
{
    public LongestSubstrWoRepeatsTest(ISolution solution)
    {
        TestCases = new List<ITestCase>
        {
            new LongestSubstrWoRepeatsTestCase
            {
                Solution = solution,
                S = "abcabcbb",
                Expected = 3
            },
            new LongestSubstrWoRepeatsTestCase
            {
                Solution = solution,
                S = "bbbbb",
                Expected = 1
            },
            new LongestSubstrWoRepeatsTestCase
            {
                Solution = solution,
                S = "pwwkew",
                Expected = 3
            },
            new LongestSubstrWoRepeatsTestCase
            {
                Solution = solution,
                S = " ",
                Expected = 1
            },
            new LongestSubstrWoRepeatsTestCase
            {
                Solution = solution,
                S = "au",
                Expected = 2
            },
            new LongestSubstrWoRepeatsTestCase
            {
                Solution = solution,
                S = "dvdf",
                Expected = 3
            },
            new LongestSubstrWoRepeatsTestCase
            {
                Solution = solution,
                S = "tmmzuxt",
                Expected = 5
            },
            new LongestSubstrWoRepeatsTestCase
            {
                Solution = solution,
                S = "abba",
                Expected = 2
            },
            new LongestSubstrWoRepeatsTestCase
            {
                Solution = solution,
                S = "aab",
                Expected = 2
            },
            new LongestSubstrWoRepeatsTestCase
            {
                Solution = solution,
                S = "",
                Expected = 0
            }
        };
    }
    public LongestSubstrWoRepeatsTest() : this(new Solution()) { }
}