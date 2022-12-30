/*
 * https://www.lintcode.com/problem/659/description
 *
 * Design an algorithm to encode a list of strings to a string.
 * The encoded string is then sent over the network and is decoded
 * back to the original list of strings.
 *
 * Implement the `Encode` and `Decode` methods.
 *
 * Example 1:
 * Input: ["lint","code","love","you"]
 * Output: ["lint","code","love","you"]
 * Explanation: One possible encode method is: "lint:;code:;love:;you"
 *
 * Example 2:
 * Input: ["we","say",":", "yes"]
 * Output: ["we","say",":", "yes"]
 * Explanation: One possible encode method is: "we:;say:;:::;yes"
 *
 * Note:
 * The string may contain any possible characters out of 256 valid
 * ascii characters. Your algorithm should be generalized enough to
 * work on any possible characters.
 * Do not use class member/global/static variables to store states.
 * Your encode and decode algorithms should be stateless.
 * Do not rely on any library method such as eval or serialize methods.
 * You should implement your own encode/decode algorithm.
 */

using System.Text;

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.EncodeDecodeStrings;

public interface ISolution
{
    string Encode(IList<string> strs);
    IList<string> Decode(string str);
}

public class Solution : ISolution
{
    private const char Separator = '\u001E';
    
    public string Encode(IList<string> strs)
    {
        if(strs.Count == 0)
            return string.Empty;
        
        var builder = new StringBuilder();
        
        // To avoid the case when the string contains the separator
        // we encode the length of the string and then the string itself
        foreach (var str in strs)
        {
            builder.Append(str.Length);
            builder.Append(Separator);
            builder.Append(str);
            builder.Append(Separator);
        }
        
        return builder.ToString();
    }

    public IList<string> Decode(string str)
    {
        if(str == string.Empty)
            return new List<string>();
        
        var result = new List<string>();
        
        var i = 0;
        while (i < str.Length)
        {
            var len = 0;
            
            while (str[i] != Separator)
            {
                // Shift current decimal value one digit to the left and append the new digit
                len = len * 10 + str[i] - '0';
                ++i;
            }
            
            ++i;
            result.Add(str.Substring(i, len));
            i += len + 1;
        }

        return result;
    }
}