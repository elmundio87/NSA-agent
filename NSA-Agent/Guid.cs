using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSA_Agent
{
    class Guid
    {

        static Random random = new Random();
        String fileLocation = @"guid.txt";

        public Guid()
        {
            
        }

        public string generate()
        {
            String guid = GetRandomHexNumber(64);
            System.IO.File.WriteAllText(@"guid.txt", guid);
            return guid;
        }

        public string getGUID()
        {
            if (guidFileExists())
            {
                return System.IO.File.ReadAllText(@"guid.txt");
            }

            return generate();
      
        }

        private Boolean guidFileExists()
        {
            string fileName = @"guid.txt";
            return (File.Exists(fileName));
        }
        
        public static string GetRandomHexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }
    }
}
