using NeetCodeAllCSharp;

var tests = new List<Test>
{
    new NeetCodeAllCSharp.ArraysHashing.ContainsDuplicate.ContainsDuplicateTest(),
    new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.ValidAnagramTest(
        new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.SolutionStringSort()),
    new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.ValidAnagramTest(
        new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.SolutionCharArraySort()),
    new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.ValidAnagramTest(
        new NeetCodeAllCSharp.ArraysHashing.ValidAnagram.SolutionDictionary()),
    new NeetCodeAllCSharp.ArraysHashing.TwoSum.TwoSumTest(),
    new NeetCodeAllCSharp.ArraysHashing.GroupAnagrams.GroupAnagramsTest(),
    new NeetCodeAllCSharp.ArraysHashing.TopKFrequent.TopKFrequentTest(),
    new NeetCodeAllCSharp.ArraysHashing.ArrayProductExceptSelf.ArrayProductTest(),
    new NeetCodeAllCSharp.ArraysHashing.ValidSudoku.ValidSudokuTest(),
    new NeetCodeAllCSharp.ArraysHashing.LongestConsecutiveSequence.LongestConsecutiveSequenceTest(
        new NeetCodeAllCSharp.ArraysHashing.LongestConsecutiveSequence.SolutionSortedList()),
    new NeetCodeAllCSharp.ArraysHashing.LongestConsecutiveSequence.LongestConsecutiveSequenceTest(
        new NeetCodeAllCSharp.ArraysHashing.LongestConsecutiveSequence.SolutionHashSet()),
    new NeetCodeAllCSharp.TwoPointers.ValidPalindrome.ValidPalindromeTest(),
    new NeetCodeAllCSharp.TwoPointers.TwoSumII.TwoSumIITest(),
    new NeetCodeAllCSharp.TwoPointers.ThreeSum.ThreeSumTest(),
    new NeetCodeAllCSharp.TwoPointers.ContainerWithMostWater.ContainerWithMostWaterTest(),
    new NeetCodeAllCSharp.TwoPointers.TrappingRainWater.TrappingRainWaterTest(
        new NeetCodeAllCSharp.TwoPointers.TrappingRainWater.SolutionArray()),
    new NeetCodeAllCSharp.TwoPointers.TrappingRainWater.TrappingRainWaterTest(
        new NeetCodeAllCSharp.TwoPointers.TrappingRainWater.SolutionTwoPointers()),
};

foreach (var test in tests)
{
    Console.WriteLine(test.Run() 
        ? $"{test.GetType()} [PASSED]" 
        : $"{test.GetType()} [FAILED]");
}