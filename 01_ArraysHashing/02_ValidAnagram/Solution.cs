/*
 * https://leetcode.com/problems/valid-anagram/description/
 *
 * Given two strings `s` and `t`, return `true` if `t` is an anagram of `s`,
 * and `false` otherwise.
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

public interface ISolution
{
    bool IsAnagram(string s, string t);
}

public class SolutionStringSort : ISolution
{
    // OJ score: 133 ms, 43.3 MB
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length) return false;

        s = string.Concat(s.OrderBy(c => c));
        t = string.Concat(t.OrderBy(c => c));

        return s == t;
    }
}

public class SolutionDictionary : ISolution
{
    // OJ score: 82 ms, 40.1 MB
    public bool IsAnagram(string s, string t)
    {
        if(s.Length != t.Length) return false;
        
        var dicS = new Dictionary<char, int>();
        var dicT = new Dictionary<char, int>();

        foreach(var c in s)
        {
            if(dicS.ContainsKey(c))
                dicS[c]++;
            else
                dicS.Add(c, 1);
        }
        foreach(var c in t)
        {
            if(dicT.ContainsKey(c))
                dicT[c]++;
            else
                dicT.Add(c, 1);
        }

        return !dicS.Except(dicT).Any();
    }
}