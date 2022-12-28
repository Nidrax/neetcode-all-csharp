// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.ContainsDuplicate;

internal class TestCase
{
    public bool Run(ISolution solution)
    {
        var result = solution.ContainsDuplicate(Input);
        return result == Expected;
    }
    
    public int[] Input { get; init; } = null!;
    public bool Expected { get; init; }
}

public class Test : ITest
{
    public Test(ISolution solution)
    {
        _solution = solution;
        _testCases = new List<TestCase>
        {
            new() {Input = new[] {1, 2, 3, 1}, Expected = true},
            new() {Input = new[] {1, 2, 3, 4}, Expected = false},
            new() {Input = new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, Expected = true}
        };
    }
    public Test() : this(new Solution()) { }
    
    public bool Run()
    {
        return _testCases.All(testCase => testCase.Run(_solution));
    }
    
    private readonly ISolution _solution;
    private readonly List<TestCase> _testCases;
}