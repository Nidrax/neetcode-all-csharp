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

public interface ISolution
{
    int LengthOfLongestSubstring(string s);
}

public class Solution : ISolution
{
    // OJ score: 70ms, 39.3 MB
    public int LengthOfLongestSubstring(string s)
    {
        // return 0 for empty string and 1 for single character string
        if (s.Length < 2) return s.Length;
        
        var charset = new HashSet<char>();
        var l = 0;
        var r = 0;
        var max = 0;

        while (r < s.Length)
        {
            while (charset.Contains(s[r]))
            {
                charset.Remove(s[l]);
                l++;
            }
            
            charset.Add(s[r]);
            max = Math.Max(max, r - l + 1);
            r++;
        }

        return max;
    }
}