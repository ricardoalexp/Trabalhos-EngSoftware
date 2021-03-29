using System;
using System.IO;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class FileRegister
    {
        private string filePath;
        public FileRegister()
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

            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                id = 0;
            }

            return id;
        }

        public void WriteToFile(Animal animal)
        {
            
            string line = Convert.ToString(animal.Id) + ";"
                + animal.Name + ";"
                + animal.Gender + ";"
                + animal.Category + ";"
                + animal.Subcategory + ";"
                + animal.Owner.Id + ";\n";

            string fileName = + animal.Id + "_animal.txt";

            File.WriteAllText(fileName, line);
            Console.WriteLine("Foi criado o ficheiro " + fileName + " na pasta " + filePath);
        }

        public void WriteToFile(Veterinary veterinary)
        {
            string line = Convert.ToString(veterinary.Id) + ";"
                + veterinary.Name + ";\n";

            string fileName = + veterinary.Id + "_veterinary.txt";

            File.WriteAllText(fileName, line);
            Console.WriteLine("Foi criado o ficheiro " + fileName + " na pasta " + filePath);
        }

        public void WriteToFile(Service service)
        {
            string line = Convert.ToString(service.Id) + ";"
                + service.Name + ";"
                + service.Price + ";"
                + service.Medicine + ";"
                + Convert.ToString(service.Duration) + ";\n";

            string fileName = +service.Id + "_service.txt";

            File.WriteAllText(fileName, line);
            Console.WriteLine("Foi criado o ficheiro " + fileName + " na pasta " + filePath);
        }

        public void WriteToFile(ScheduleSlot scheduleSlot)
        {
            string line = Convert.ToString(scheduleSlot.Id) + ";"
                + scheduleSlot.Service.Id + ";"
                + scheduleSlot.Animal.Id + ";"
                + scheduleSlot.Veterinary.Id + ";"
                + scheduleSlot.Dia + ";"
                + scheduleSlot.HoraInicio + ";"
                + scheduleSlot.HoraFim + ";\n";

            string fileName = +scheduleSlot.Id + "_scheduleSlot.txt";

            File.WriteAllText(fileName, line);
            Console.WriteLine("Foi criado o ficheiro " + fileName + " na pasta " + filePath);
        }
    }
}
