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
            var prices1 = new List<int>() { 5, 3, 2 };
            var prices2 = new List<int>() { 1, 2, 100 };
            var prices3 = new List<int>() { 1, 3, 1, 2 };
            var prices4 = new List<int>() { 1, 2, 3, 4 };
            var prices5 = new List<int>() { 5, 4, 3, 4, 5 };

            Console.WriteLine(stockmax(prices1));
            Console.WriteLine(stockmax(prices2));
            Console.WriteLine(stockmax(prices3));
            Console.WriteLine(stockmax(prices4));
            Console.WriteLine(stockmax(prices5));

            Console.ReadKey();
        }

        static int stockmax1(List<int> prices)
        {
            int spend = 0;
            int amountBuyed = 0;
            int profit = 0;
            for (int i = 0; i < prices.Count - 1; i++)
            {
                int current = prices[i];
                int tomorrow = prices[i + 1];
                if (current < tomorrow) // Buy
                {
                    spend += current;
                    amountBuyed++;
                }
                else if(current > tomorrow && amountBuyed > 0) //Sell
                {
                    profit += amountBuyed * current;
                    amountBuyed = 0;
                }
            }

            if(amountBuyed > 0)
            {
                profit += amountBuyed * prices[prices.Count - 1];
            }

            return profit - spend;
        }

        static int stockmax(List<int> prices)
        {
            int spend = 0;
            int profit = 0;
            for (int i = 0; i < prices.Count - 1; i++)
            {
                int current = prices[i];
                int biggestFuture = current;

                for (int j = i + 1; j < prices.Count; j++)
                {
                    int future = prices[j];
                    if(future > biggestFuture)
                    {
                        biggestFuture = future;
                    }
                }
                if(biggestFuture > current)
                {
                    profit += biggestFuture;
                    spend += current;
                }
            }

            return profit - spend;
        }
    }
}
