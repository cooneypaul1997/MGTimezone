using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timezone.Properties;

namespace Timezone
{
    class Reader : IReader, IDisposable
    {
        public List<Tuple<string, string>> Read()
        {
            List<Tuple<string, string>> lReturn = new List<Tuple<string, string>>();

            string[] fileParts;

            try
            {
                fileParts = Resources.Timezone.Replace("\n", "\r\n").Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception whilst trying to read Timezone.txt " + ex.ToString());
                return lReturn;
            }

            if(fileParts.Length > 0)
            {
                foreach (string part in fileParts)
                {
                    string[] sLineParts = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    Tuple<string, string> timeZone = new Tuple<string, string>(sLineParts.First(), sLineParts.Last());

                    lReturn.Add(timeZone);
                }
            }

            return lReturn;
        }
        public void Dispose()
        {
        }
    }
}
