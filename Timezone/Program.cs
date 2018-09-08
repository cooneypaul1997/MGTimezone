﻿using System;
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

                foreach (var t in lTimes)
                {
                    Console.WriteLine("The time in the UK is {0} and the time in {1} is {2}", t.Item1, t.Item2, timeZoneParser.DisplayTime(t.Item1, t.Item2).TimeOfDay);
                }
            }
        }
    }
}
