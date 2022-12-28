using NeetCodeAllCSharp;

var tests = new List<ITest>
{
    new NeetCodeAllCSharp.ArraysHashing.ContainsDuplicate.Test(),
    new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.Test(
        new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.SolutionStringSort()),
    new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.Test(
        new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.SolutionDictionary()),
    new NeetCodeAllCSharp.ArraysHashing.TwoSum.Test()
};

foreach (var test in tests)
{
    Console.WriteLine(test.Run() 
        ? $"{test.GetType()} passed" 
        : $"{test.GetType()} failed");
}