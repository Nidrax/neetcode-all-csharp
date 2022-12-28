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
 * - `1 <= s.length, t.length <= 5 * 104`
 * - `s` and `t` consist of lowercase English letters.
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.ValidAnagram;

internal class TestCase
{
    public bool Run(ISolution solution)
    {
        var result = solution.IsAnagram(S, T);
        return result == Expected;
    }
    
    public string S { get; init; } = null!;
    public string T { get; init; } = null!;
    public bool Expected { get; init; }
}

public class Test : ITest
{
    public Test(ISolution solution)
    {
        _solution = solution;
        _testCases = new List<TestCase>
        {
            new() {S = "anagram", T = "nagaram", Expected = true},
            new() {S = "rat", T = "car", Expected = false},
            new() {S = "a", T = "ab", Expected = false},
            new() {S = "aacc", T = "ccac", Expected = false}
        };
    }
    public Test() : this(new SolutionStringSort()) { }
    
    public bool Run()
    {
        return _testCases.All(testCase => testCase.Run(_solution));
    }
    
    private readonly ISolution _solution;
    private readonly List<TestCase> _testCases;
}