// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp;

public interface ITestCase
{
    bool Run();
}

public abstract class Test
{
    public bool Run()
    {
        return TestCases.All(testCase => testCase.Run());
    }

    protected IEnumerable<ITestCase> TestCases { get; init; } = null!;
}