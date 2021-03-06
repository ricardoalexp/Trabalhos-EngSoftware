using System;
using System.Collections.Generic;
using System.IO;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class FileWriter
    {
        private string filePath;

        public FileWriter()
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            this.filePath = Path.GetFullPath(@"..\..\..\");            
        }
                
        public int WriteToFile(Owner owner)
        {
            int id;
            string relativePath = filePath + @"Resources\Clients\";
            string fileName;
            int i = 1;

            try
            {
                fileName = relativePath + i + "_owner.txt";
                while (File.Exists(fileName))
                {
                    i++;
                    fileName = relativePath + i + "_owner.txt";
                }

                id = i;
                string line = Convert.ToString(id) + ";"
                + owner.Name + ";" + owner.Address + ";"
                + owner.Contact + ";\n";
                File.WriteAllText(fileName, line);
                Console.WriteLine(line);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                id = 0;
            }

            return id;
        }
                
        public int WriteToFile(Animal animal)
        {
            int id;
            string relativePath = filePath + @"Resources\Animals\";
            string fileName;
            int i = 1;

            try
            {
                fileName = relativePath + i + "_animal.txt";
                while (File.Exists(fileName))
                {
                    i++;
                    fileName = relativePath + i + "_animal.txt";
                }
                id = i;
                string line = Convert.ToString(id) + ";"
                    + animal.Name + ";"
                    + animal.Gender + ";"
                    + animal.Category + ";"
                    + animal.Subcategory + ";"
                    + animal.OwnerId + ";\n";

                using (StreamWriter sw = File.AppendText(fileName)) {sw.WriteLine(line); }

                Console.WriteLine(line);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                id = 0;
            }

            return id;
        }
                
        public int WriteToFile(Veterinary veterinary)
        {
            int id;
            string relativePath = filePath + @"Resources\Veterinaries\";
            string fileName;
            int i = 1;

            try
            {
                fileName = relativePath + i + "_veterinary.txt";
                while (File.Exists(fileName))
                {
                    i++;
                    fileName = relativePath + i + "_veterinary.txt";
                }

                id = i;
                string line = Convert.ToString(id) + ";"
               + veterinary.Name + ";\n";

                File.WriteAllText(fileName, line);
                Console.WriteLine(line);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                id = 0;
            }

            return id;
        }
                
        public int WriteToFile(Service service)
        {            
            int id;
            string relativePath = filePath + @"Resources\Services\";
            string fileName;
            int i = 1;

            try
            {
                fileName = relativePath + i + "_service.txt";
                while (File.Exists(fileName))
                {
                    i++;
                    fileName = relativePath + i + "_service.txt";
                }

                id = i;
                string line = Convert.ToString(id) + ";"
                + service.Name + ";"
                + service.Price + ";";

                foreach (string med in service.Medicine)
                {
                    line += med + ":";
                }
                
                line += ";" + Convert.ToString(service.Duration) + ";\n";

                File.WriteAllText(fileName, line);
                Console.WriteLine(line);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                id = 0;
            }

            return id;
        }

        public bool WriteToFile(ScheduleSlot slot)
        {
            string relativePath = filePath + @"Resources\Registry\";
            string fileName;
            string text = "";
            bool success;

            try
            {
                fileName = relativePath + slot.Dia + ".txt";

                text = Convert.ToString(slot.ServiceId) + ";"
                + Convert.ToString(slot.AnimalId) + ";"
                + Convert.ToString(slot.VeterinaryId) + ";"
                + slot.Dia + ";"
                + slot.HoraInicio + ";"
                + slot.HoraFim + ";";

                using (StreamWriter sw = File.AppendText(fileName)) { sw.WriteLine(text); }
                Console.WriteLine(text);
                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                success = false;
            }

            return success;
        }
    }
}
