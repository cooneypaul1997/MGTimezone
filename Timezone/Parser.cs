using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Parser : IParser
    {
        public DateTime DisplayTime(string time, string timezone)
        {
            // Split time into hours and minutes
            string[] splitTime = time.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

            // Add the Hours and Minutes into a 00:00 DateTime 
            DateTime UTCTime = new DateTime(1900, 01, 01); // If Date is 01/01/0001, any timezones < base UTC e.g -7 will not calculate correctly as this is the lowest DateTime can be. Should potentially be changed if DST should be accounted for
            UTCTime = UTCTime.AddHours(Convert.ToDouble(splitTime[0]));
            UTCTime = UTCTime.AddMinutes(Convert.ToDouble(splitTime[1]));

            // Find the TZI of the request timezone
            TimeZoneInfo requestedTZI = TimeZoneInfo.FindSystemTimeZoneById((from tzi in TimeZoneInfo.GetSystemTimeZones()
                                                                            where tzi.DisplayName.Contains(timezone)
                                                                            select tzi.Id).FirstOrDefault());

            // Convert specified UTC time into requested timezone
            DateTime convertedTime = TimeZoneInfo.ConvertTimeFromUtc(UTCTime, requestedTZI);

            return convertedTime;
        }

        // Ensure that {time} is a valid double
        public bool ValidateTime(string time)
        {
            bool isDouble = Double.TryParse(time.Replace(":", "."), out double processedTime);

            return isDouble;
        }
    }
}
