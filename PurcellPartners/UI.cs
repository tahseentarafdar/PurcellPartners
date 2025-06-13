using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurcellPartners.Interfaces;

namespace PurcellPartners
{
    public class UI : IUI
    {
        public UI(IFindGaps gapFinder)
        {
            GapFinder = gapFinder;
        }

        public IFindGaps GapFinder { get; }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nPlease provide a list of numbers, or q to quit");
                var listText = Console.ReadLine();
                int[] numbers = null;
                try
                {
                    if (listText?.ToLower().Trim() == "q")
                    {
                        return;
                    }

                    numbers = listText.Split([',', ' '], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
                var missingNumber = GapFinder.Find(numbers);
                if (missingNumber == -1)
                {
                    Console.WriteLine("No missing number found");
                }
                else
                {
                    Console.WriteLine($"Missing number: {missingNumber}");
                }
            }
        }
    }
}
