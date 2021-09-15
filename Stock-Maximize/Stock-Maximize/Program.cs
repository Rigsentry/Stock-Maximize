using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Maximize
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> prices = new List<int> { 5, 3, 2 };
            //List<int> prices = new List<int> { 1, 2, 100 };
            //List<int> prices = new List<int> { 1, 3, 1, 2 };
            //List<int> prices = new List<int> { 1, 2, 3, 4 };
            List<int> prices = new List<int> { 5, 4, 3, 4, 5 };

            int profit = GetMaxProfit(prices);
            Console.WriteLine("Profit: $" + profit);
            Console.ReadLine();
        }
        public static int GetMaxProfit(List<int> prices)
        {
            int shares = 0;
            int profit = 0;
            int maxFuturePrice = 0;
            for (int i = 0; i < prices.Count; i++)
            {
                var currentPrice = prices[i];
                maxFuturePrice = 0;
                for (int j = i; j < prices.Count; j++)
                {
                    if (prices[j] > currentPrice)
                    {
                        maxFuturePrice = prices[j];
                    }
                }
                if (maxFuturePrice > currentPrice)
                {
                    shares++;
                    profit -= currentPrice;
                }
                else
                {
                    profit = shares * currentPrice + profit;
                    shares = 0;
                }
            }
            return profit; 
        }

    }
}
