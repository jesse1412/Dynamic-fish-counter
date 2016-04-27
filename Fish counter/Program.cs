using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_counter
{

    class Program
    {

        //Parses strings into integers safely.
        public static int safeParseInt(string inputString)
        {

            int outputInt;

            do
            {

                try
                {

                    outputInt = int.Parse(inputString);
                    break;

                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid value, please try again and only use numbers.");

                }

            }
            while (true);

            return outputInt;

        }

        static void Main(string[] args)
        {

            string fishName, printString;
            string mostCommonFish = "";
            int fishMass;
            int highestFishCount = 0;
            Dictionary<string, List<int>> fishes = new Dictionary<string, List<int>>();

            do
            {

                Console.WriteLine("Please enter the name of your fish. Type finished to finalize:");
                fishName = Console.ReadLine();

                if (fishName.ToLower() == "finished")
                {

                    break;

                }
                else
                {

                    Console.WriteLine("\nPlease enter the mass of your fish in grams:");
                    fishMass = safeParseInt(Console.ReadLine());

                    Console.Clear();

                    try
                    {

                        fishes[fishName].Add(fishMass);

                    }
                    catch(Exception)
                    {

                        fishes.Add(fishName, new List<int>());
                        fishes[fishName].Add(fishMass);

                    }

                }

            }
            while (true);

            Console.Clear();

            foreach(KeyValuePair<string, List<int>> lists in fishes)
            {

                if(highestFishCount < lists.Value.Count())
                {

                    mostCommonFish = lists.Key;
                    highestFishCount = lists.Value.Count();

                }

                printString = (lists.Key + "s: ");

                foreach(int values in lists.Value)
                {

                    printString += (values + "g, ");

                }

                Console.WriteLine(printString + "\n");

            }

            Console.WriteLine("\n\nThe most popular fish is the " + mostCommonFish + ", " + highestFishCount + " " + mostCommonFish + "s were entered.");

            Console.ReadKey();

        }

    }

}