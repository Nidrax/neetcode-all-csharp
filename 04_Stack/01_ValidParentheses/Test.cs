/*
 * Given a string `s` containing just the characters '(', ')', '{', '}',
 * '[' and ']', determine if the input string is valid.
 *
 * An input string is valid if:
 * - Open brackets must be closed by the same type of brackets.
 * - Open brackets must be closed in the correct order.
 * - Every close bracket has a corresponding open bracket of the same type.
 *
 * Example 1:
 * Input: s = "()"
 * Output: true
 *
 * Example 2:
 * Input: s = "()[]{}"
 * Output: true
 *
 * Example 3:
 * Input: s = "(]"
 * Output: false
 *
 * Constraints:
 * - `1 <= s.length <= 10^4`
 * - `s` consists of parentheses only '()[]{}'.
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.Stack.ValidParentheses;

public class ValidParenthesesTestCase : ITestCase
{
    public ISolution Solution { get; init; } = null!;
    public string S { get; init; } = null!;
    public bool Expected { get; init; }
    
    public bool Run()
    {
        var result = Solution.IsValid(S);
        return result == Expected;
    }
}

public class ValidParenthesesTest : Test
{
    public ValidParenthesesTest(ISolution solution)
    {
        TestCases = new List<ITestCase>
        {
            new ValidParenthesesTestCase
            {
                Solution = solution,
                S = "()",
                Expected = true
            },
            new ValidParenthesesTestCase
            {
                Solution = solution,
                S = "()[]{}",
                Expected = true
            },
            new ValidParenthesesTestCase
            {
                Solution = solution,
                S = "(]",
                Expected = false
            },
            new ValidParenthesesTestCase
            {
                Solution = solution,
                S = "([)]",
                Expected = false
            },
            new ValidParenthesesTestCase
            {
                Solution = solution,
                S = "{[]}",
                Expected = true
            },
            new ValidParenthesesTestCase
            {
                Solution = solution,
                S = "){",
                Expected = false
            },
            new ValidParenthesesTestCase
            {
                Solution = solution,
                S = "",
                Expected = true
            }
        };
    }
    public ValidParenthesesTest() : this(new Solution()) { }
}