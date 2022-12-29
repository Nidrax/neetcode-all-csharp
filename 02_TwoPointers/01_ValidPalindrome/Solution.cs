/*
 * https://leetcode.com/problems/valid-palindrome/description/
 *
 * A phrase is a *palindrome* if, after converting all uppercase letters
 * into lowercase letters and removing all non-alphanumeric characters,
 * it reads the same forward and backward.
 * Alphanumeric characters include letters and numbers.
 *
 * Given a string `s`, return `true`
 * _if it is a *palindrome*, or `false` otherwise_.
 *
 * Example 1:
 * Input: s = "A man, a plan, a canal: Panama"
 * Output: true
 * Explanation: "amanaplanacanalpanama" is a palindrome.
 *
 * Example 2:
 * Input: s = "race a car"
 * Output: false
 * Explanation: "raceacar" is not a palindrome.
 *
 * Example 3:
 * Input: s = " "
 * Output: true
 * Explanation: s is an empty string "" after removing non-alphanumeric characters.
 * Since an empty string reads the same forward and backward, it is a palindrome.
 *
 * Constraints:
 * - `1 <= s.length <= 2 * 10^5`
 * - `s` consists only of printable ASCII characters.
 */

using System.Text.RegularExpressions;

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.TwoPointers.ValidPalindrome;

public interface ISolution
{
    bool IsPalindrome(string s);
}

public class Solution : ISolution
{
    private static string Strip(string s)
    {
        var rgx = new Regex("[^a-z0-9]");
        return rgx.Replace(s.ToLower(), "");
    }

    // OJ score: 82 ms, 44 MB
    public bool IsPalindrome(string s)
    {
        // Convert to lowercase and remove non-alphanumeric characters
        s = Strip(s);
        var l = s.Length;
        
        // Check if the characters are the same from both ends
        for(var i=0; i<l/2; ++i)
        {
            if(s[i] != s[l-i-1]) return false;
        }

        return true;
    }
}