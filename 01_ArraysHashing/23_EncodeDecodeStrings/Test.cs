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

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.EncodeDecodeStrings;

public class EncodeDecodeStringsTestCase : ITestCase
{
    public bool Run()
    {
        var encoded = Solution.Encode(Strs);
        var decoded = Solution.Decode(encoded);
        
        return decoded.SequenceEqual(Strs);
    }
    
    public ISolution Solution { get; init; } = null!;
    public IList<string> Strs { get; init; } = null!;
}

public class EncodeDecodeStringsTest : Test
{
    public EncodeDecodeStringsTest(ISolution solution)
    {
        TestCases = new List<ITestCase>
        {
            new EncodeDecodeStringsTestCase
            {
                Solution = solution,
                Strs = new List<string> {"lint", "code", "love", "you"}
            },
            new EncodeDecodeStringsTestCase
            {
                Solution = solution,
                Strs = new List<string> {"we", "say", ":", "yes"}
            },
            new EncodeDecodeStringsTestCase
            {
                Solution = solution,
                Strs = new List<string> {"zażółć", "gęślą", "jaźń"}
            },
            new EncodeDecodeStringsTestCase
            {
                Solution = solution,
                Strs = new List<string> {"coding", "made", "\u001E", "easy"}
            }
        };
    }
    public EncodeDecodeStringsTest() : this(new Solution()) { }
}