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
 * - `1 <= s.length, t.length <= 5 * 10^4`
 * - `s` and `t` consist of lowercase English letters.
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.ValidAnagram;

public interface ISolution
{
    bool IsAnagram(string s, string t);
}

// Easier, but less efficient
public class SolutionStringSort : ISolution
{
    // OJ score: 133 ms, 43.3 MB
    public bool IsAnagram(string s, string t) {
        // Strings must be of the same length
        if(s.Length != t.Length) return false;

        // Sort characters in string and then compare
        s = string.Concat(s.OrderBy(c => c));
        t = string.Concat(t.OrderBy(c => c));

        return s == t;
    }
}

// Same as above, but using char arrays instead of strings, which is
// comparable in performance to NeetCode solution, but simpler to implement
public class SolutionCharArraySort : ISolution
{
    // OJ score: 84 ms, 40.4 MB
    public bool IsAnagram(string s, string t) {
        var sChars = s.ToCharArray();
        var tChars = t.ToCharArray();

        // Skip sorting and comparison if strings are of different length
        if(sChars.Length != tChars.Length) return false;
        
        Array.Sort(sChars);
        Array.Sort(tChars);
        
        return sChars.SequenceEqual(tChars);
    }
}

// Solution suggested on NeetCode
public class SolutionDictionary : ISolution
{
    // OJ score: 82 ms, 40.1 MB
    public bool IsAnagram(string s, string t)
    {
        // Strings must be of the same length
        if(s.Length != t.Length) return false;
        
        var dicS = new Dictionary<char, int>();
        var dicT = new Dictionary<char, int>();

        // Create dictionaries of characters and their counts
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

        // Compare dictionaries
        return !dicS.Except(dicT).Any();
    }
}