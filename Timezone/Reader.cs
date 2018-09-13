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
            string fileName = "Timezone.txt";

            List<Tuple<string, string>> lReturn = new List<Tuple<string, string>>();

            if(!File.Exists(fileName))
            {
                return lReturn;
            }

            string[] fileParts;

            try
            {
                fileParts = File.ReadAllText(fileName).Replace("\n", "\r\n").Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("Can't find file {0} with exception " + ex.ToString(), fileName);
                return lReturn;
            }
            catch(DirectoryNotFoundException ex)
            {
                Console.WriteLine("Can't find directory containing file {0} with exception " + ex.ToString(), fileName);
                return lReturn;
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
