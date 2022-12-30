/*
 * https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/
 *
 * You are given an array `prices` where `prices[i]` is the price of
 * a given stock on the `i-th` day.
 *
 * You want to maximize your profit by choosing a *single day* to buy
 * one stock and choosing a *different day in the future* to sell that stock.
 *
 * Return _the maximum profit_ you can achieve from this transaction. If you
 * cannot achieve any profit, return `0`.
 *
 * Example 1:
 * Input: prices = [7,1,5,3,6,4]
 * Output: 5
 * Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6),
 * profit = 6-1 = 5.
 * Note that buying on day 2 and selling on day 1 is not allowed because
 * you must buy before you sell.
 *
 * Example 2:
 * Input: prices = [7,6,4,3,1]
 * Output: 0
 * Explanation: In this case, no transactions are done and the max profit = 0.
 *
 * Constraints:
 * - `1 <= prices.length <= 10^5`
 * - `0 <= prices[i] <= 10^4`
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.SlidingWindow.BuySellStock;

public class BuySellStockTestCase : ITestCase
{
    public bool Run()
    {
        var result = Solution.MaxProfit(Prices);
        return result == Expected;
    }
    
    public ISolution Solution { get; init; } = null!;
    public int[] Prices { get; init; } = null!;
    public int Expected { get; init; }
}

public class BuySellStockTest : Test
{
    public BuySellStockTest(ISolution solution)
    {
        TestCases = new List<ITestCase>
        {
            new BuySellStockTestCase
            {
                Solution = solution,
                Prices = new[] {7, 1, 5, 3, 6, 4},
                Expected = 5
            },
            new BuySellStockTestCase
            {
                Solution = solution,
                Prices = new[] {7, 6, 4, 3, 1},
                Expected = 0
            },
            new BuySellStockTestCase
            {
                Solution = solution,
                Prices = new[] {1, 2},
                Expected = 1
            },
            new BuySellStockTestCase
            {
                Solution = solution,
                Prices = new[] {2, 1, 2, 1, 0, 1, 2},
                Expected = 2
            },
            new BuySellStockTestCase
            {
                Solution = solution,
                Prices = new[] {3, 3, 5, 0, 0, 3, 1, 4},
                Expected = 4
            },
            new BuySellStockTestCase
            {
                Solution = solution,
                Prices = new[] {1, 2, 4, 2, 5, 7, 2, 4, 9, 0},
                Expected = 8
            },
            new BuySellStockTestCase
            {
                Solution = solution,
                Prices = new[] {1},
                Expected = 0
            }
        };
    }
    public BuySellStockTest() : this(new Solution()) { }
}