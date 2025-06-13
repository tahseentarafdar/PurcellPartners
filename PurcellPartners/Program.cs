namespace PurcellPartners
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nPlease provide a comma separated list of numbers, or q to quit");
                var listText = Console.ReadLine();
                int[] numbers = null;
                try
                {
                    if(listText?.ToLower().Trim() == "q")
                    {
                        return;
                    }

                    numbers = listText.Split(',').Select(int.Parse).ToArray();
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
                var missingNumber = GapFinder.Find(numbers);
                if(missingNumber == -1)
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
