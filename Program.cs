using NeetCodeAllCSharp;

var tests = new List<ITest>
{
    new NeetCodeAllCSharp.ArraysHashing.ContainsDuplicate.Test()
};

foreach (var test in tests)
{
    Console.WriteLine(test.Run() 
        ? $"{test.GetType()} passed" 
        : $"{test.GetType()} failed");
}