/*
 * https://leetcode.com/problems/group-anagrams/description/
 *
 * Given an array of strings `strs`, group *the anagrams* together.
 * You can return the answer in *any order*.
 *
 * An *Anagram* is a word or phrase formed by rearranging the letters
 * of a different word or phrase, typically using all the original letters
 * exactly once.
 *
 * Example 1:
 * Input: strs = ["eat","tea","tan","ate","nat","bat"]
 * Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
 *
 * Example 2:
 * Input: strs = [""]
 * Output: [[""]]
 *
 * Example 3:
 * Input: strs = ["a"]
 * Output: [["a"]]
 *
 * Constraints:
 * - `1 <= strs.length <= 10^4`
 * - `0 <= strs[i].length <= 100`
 * - `strs[i]` consists of lower-case English letters.
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.GroupAnagrams;

public interface ISolution
{
    IList<IList<string>> GroupAnagrams(string[] strs);
}

public class Solution : ISolution
{
    // OJ score: 217 ms, 58.2 MB
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var ret = new List<IList<string>>();
        var dic = new Dictionary<string,int>();

        foreach(var s in strs)
        {
            var k = string.Concat(s.OrderBy(c => c));
            if(dic.ContainsKey(k))
            {
                ret[dic[k]].Add(s);
            }
            else
            {
                dic.Add(k, ret.Count);
                ret.Add(new List<string>{s});
            }
        }

        return ret;
    }
}