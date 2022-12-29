using NeetCodeAllCSharp;

var tests = new List<Test>
{
    new NeetCodeAllCSharp.ArraysHashing.ContainsDuplicate.ContainsDuplicateTest(),
    new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.ValidAnagramTest(
        new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.SolutionStringSort()),
    new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.ValidAnagramTest(
        new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.SolutionDictionary()),
    new NeetCodeAllCSharp.ArraysHashing.TwoSum.TwoSumTest(),
    new NeetCodeAllCSharp.ArraysHashing.GroupAnagrams.GroupAnagramsTest(),
    new NeetCodeAllCSharp.ArraysHashing.ArrayProductExceptSelf.ArrayProductTest()
};

foreach (var test in tests)
{
    Console.WriteLine(test.Run() 
        ? $"{test.GetType()} [PASSED]" 
        : $"{test.GetType()} [FAILED]");
}