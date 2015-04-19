using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace MaterialAnagram.Service
{
    public class AnagramService
    {
        public Dictionary<string, string> Read()
        {
            var d = new Dictionary<string, string>();
            WebRequest req = WebRequest.Create("http://www-01.sil.org/linguistics/wordlists/english/wordlist/wordsEn.txt");
            WebResponse response = req.GetResponse();
            // Read each line
            //using (StreamReader r = new StreamReader("entries.txt"))
            using (StreamReader r = new StreamReader(response.GetResponseStream()))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    // Alphabetize the line for the key
                    // Then add to the value string
                    string a = Alphabetize(line);
                    string v;
                    if (d.TryGetValue(a, out v))
                    {
                        d[a] = v + "," + line;
                    }
                    else
                    {
                        d.Add(a, line);
                    }
                }
            }
            response.Close();
            
            return d;
        }

        private string Alphabetize(string s)
        {
            // Convert to char array, then sort and return
            char[] a = s.ToCharArray();
            Array.Sort(a);
            return new string(a);
        }

        public String getResults(String given)
        {
            Dictionary<string, string> d = Read();
            String result = "",temp;

            if (d.Count < 1)
                return "Empty";

            if (d.TryGetValue(Alphabetize(given), out temp))
            {
                result += temp;
            }
            else result += ("-");
            return result;
        }

    }
}