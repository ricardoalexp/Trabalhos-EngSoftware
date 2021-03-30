using System;
using System.IO;
using System.Collections.Generic;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class FileReader
    {
       
        public List<Veterinary> ReadVeterinary()
        {
            string[] dirs = Directory.GetFiles(@"Resources\Clients\*.txt");
            List<Veterinary> vetList = new List<Veterinary>();

            foreach (string dir in dirs)
            {
                string text = File.ReadAllText(dir);
                string[] atributes = text.Split(';');
                
                Veterinary vet = new Veterinary(int.Parse(atributes[0]), atributes[1]);

                vetList.Add(vet);
            }
            return vetList;
        }
       
    }
}
