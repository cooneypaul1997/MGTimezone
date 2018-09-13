using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Program
    {        
        static void Main(string[] args)
        {
            Parser timeZoneParser = new Parser();
            using (Reader fileReader = new Reader())
            {
                List<Tuple<string, string>> lTimes = fileReader.Read();

                if (lTimes.Count > 0)
                {
                    foreach (var t in lTimes)
                    {
                        // Ensure that {time} or t.Item1 is a valid double or do not process it
                        string originalTime = t.Item1.Replace(":", ".");
                        double time;
                        bool isDouble = Double.TryParse(originalTime, out time);

                        if (isDouble)
                        {
                            Console.WriteLine("The time in the UK is {0} and the time in {1} is {2}", t.Item1, t.Item2, timeZoneParser.DisplayTime(t.Item1, t.Item2).TimeOfDay);
                        }
                        else
                        {
                            Console.WriteLine("Invalid data for timezone {0}", t.Item2);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Timezone.txt file is empty or invalid");
                }
            }
        }
    }
}
