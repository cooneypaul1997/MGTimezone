using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Reader : IReader, IDisposable
    {
        public List<Tuple<string, string>> Read()
        {
            List<Tuple<string, string>> lReturn = new List<Tuple<string, string>>();

            if(!File.Exists("Timezone.txt"))
            {
                return lReturn;
            }

            string[] fileParts = File.ReadAllText("Timezone.txt").Replace("\n", "\r\n").Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in fileParts)
            {
                string[] sLineParts = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Tuple<string, string> timeZone = new Tuple<string, string>(sLineParts.First(), sLineParts.Last());

                lReturn.Add(timeZone);
            }

            return lReturn;
        }
        public void Dispose()
        {
        }
    }
}
