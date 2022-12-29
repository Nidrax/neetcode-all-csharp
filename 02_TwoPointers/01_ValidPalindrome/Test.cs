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

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.TwoPointers.ValidPalindrome;

public class ValidPalindromeTestCase : ITestCase
{ 
    public bool Run()
    {
        var result = Solution.IsPalindrome(S);
        return result == Expected;
    }
    
    public ISolution Solution { get; init; } = null!;
    public string S { get; init; } = null!;
    public bool Expected { get; init; }
}

public class ValidPalindromeTest : Test
{
    public ValidPalindromeTest(ISolution solution)
    {
        TestCases = new List<ITestCase>
        {
            new ValidPalindromeTestCase
            {
                Solution = solution,
                S = "A man, a plan, a canal: Panama",
                Expected = true
            },
            new ValidPalindromeTestCase
            {
                Solution = solution,
                S = "Race a car",
                Expected = false
            },
            new ValidPalindromeTestCase
            {
                Solution = solution,
                S = " ",
                Expected = true
            },
            new ValidPalindromeTestCase
            {
                Solution = solution,
                S = "A Toyota! Race fast... safe car: a Toyota!",
                Expected = true
            },
            new ValidPalindromeTestCase
            {
                Solution = solution,
                S = "A Toyota! Race fast... safe car: a Toyota – Toyota!",
                Expected = false
            },
            new ValidPalindromeTestCase
            {
                Solution = solution,
                S = "Si nummi immunis.",
                Expected = true
            }
        };
    }
    public ValidPalindromeTest() : this(new Solution()) { }
}