// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.ContainsDuplicate;

public interface ISolution
{
    bool ContainsDuplicate(int[] nums);
}

public class Solution : ISolution
{
    public bool ContainsDuplicate(int[] nums) {
        var dic = new HashSet<int>();
        foreach(var num in nums)
        {
            if(dic.Contains(num))
                return true;

            dic.Add(num);
        }
        return false;
    }
}