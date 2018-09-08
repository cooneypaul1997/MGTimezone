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
            DateTime UTCTime = new DateTime();
            UTCTime = UTCTime.AddHours(Convert.ToDouble(splitTime[0]));
            UTCTime = UTCTime.AddMinutes(Convert.ToDouble(splitTime[1]));

            // Get all system timezones
            var allSystemTZI = TimeZoneInfo.GetSystemTimeZones();

            // Find the ID of the specified TZI
            var tziid = from tzi in allSystemTZI
                         where tzi.DisplayName.Contains(timezone)
                         select tzi.Id;

            // Get the TZI of the ID
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(tziid.FirstOrDefault());

            // Convert specified UTC time into requested timezone
            DateTime convertedTime = TimeZoneInfo.ConvertTimeFromUtc(UTCTime, timeZoneInfo);

            return convertedTime;
        }
    }
}
