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

public interface ISolution
{
    int MaxProfit(int[] prices);
}

public class Solution : ISolution
{
    // OJ score: 247 ms, 49.8 MB
    public int MaxProfit(int[] prices)
    {
        if (prices.Length < 2) return 0;

        var l = 0;
        var r = 1;
        var max = Math.Max(0, prices[r] - prices[l]);

        while (r < prices.Length)
        {
            if (prices[l] > prices[r])
            {
                l = r;
                r = l + 1;
                continue;
            }
            
            var profit = prices[r] - prices[l];
            max = Math.Max(max, profit);
            r++;
        }

        return max;
    }
}