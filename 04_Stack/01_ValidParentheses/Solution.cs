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

public interface ISolution
{
    bool IsValid(string s);
}

public class Solution : ISolution
{
    // OJ score: 86 ms, 37.5 MB
    public bool IsValid(string s)
    {
        if (s == string.Empty)
            return true;
        
        if (s.Length % 2 != 0)
            return false;
        
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (c is '(' or '[' or '{')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0)
                    return false;
                
                var top = stack.Pop();
                switch (c)
                {
                    case ')' when top != '(':
                    case ']' when top != '[':
                    case '}' when top != '{':
                        return false;
                }
            }
        }

        return stack.Count == 0;
    }
}