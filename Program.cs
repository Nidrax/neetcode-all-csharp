using NeetCodeAllCSharp;

var tests = new List<Test>
{
    new NeetCodeAllCSharp.ArraysHashing.ContainsDuplicate.ContainsDuplicateTest(),
    new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.ValidAnagramTest(
        new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.SolutionStringSort()),
    new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.ValidAnagramTest(
        new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.SolutionDictionary()),
    new NeetCodeAllCSharp.ArraysHashing.TwoSum.TwoSumTest(),
    new NeetCodeAllCSharp.ArraysHashing.GroupAnagrams.GroupAnagramsTest()
};

foreach (var test in tests)
{
    Console.WriteLine(test.Run() 
        ? $"{test.GetType()} passed" 
        : $"{test.GetType()} failed");
}