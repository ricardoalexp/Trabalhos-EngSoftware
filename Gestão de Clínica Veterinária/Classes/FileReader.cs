using System;
using System.IO;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class FileReader
    {
       
        public Veterinary[] ReadVeterinary()
        {
            string[] dirs = Directory.GetFiles(@"C:\Temp\", "*.csv");
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }
        }
       
    }
}
