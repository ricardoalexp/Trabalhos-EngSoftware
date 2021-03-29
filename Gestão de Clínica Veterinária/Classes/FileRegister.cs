using System;
using System.IO;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class FileRegister
    {
        public void WriteToFile(Owner owner)
        {
            string line = Convert.ToString(owner.Id) + "; "
                + owner.Name + "; " + owner.Address + "; "
                + owner.Contact + ";\n";

            string fileName = + owner.Id + "_owner.txt";

            File.WriteAllText(fileName, line);
            Console.WriteLine("Foi criado o ficheiro " + fileName + " na pasta " + Directory.GetCurrentDirectory());
        }

        public void WriteToFile(Animal animal)
        {
            string line = Convert.ToString(animal.Id) + "; "
                + animal.Name + "; "
                + animal.Gender + "; "
                + animal.Category + "; "
                + animal.Subcategory + "; "
                + animal.Owner.Id + ";\n";

            string fileName = + animal.Id + "_animal.txt";

            File.WriteAllText(fileName, line);
            Console.WriteLine("Foi criado o ficheiro " + fileName + " na pasta " + Directory.GetCurrentDirectory());
        }

        public void WriteToFile(Veterinary veterinary)
        {
            string line = Convert.ToString(veterinary.Id) + "; "
                + veterinary.Name + ";\n";

            string fileName = + veterinary.Id + "_veterinary.txt";

            File.WriteAllText(fileName, line);
            Console.WriteLine("Foi criado o ficheiro " + fileName + " na pasta " + Directory.GetCurrentDirectory());
        }

        public void WriteToFile(Service service)
        {
            string line = Convert.ToString(service.Id) + "; "
                + service.Name + "; "
                + service.Price + "; "
                + service.Medicine + "; "
                + Convert.ToString(service.Duration) + ";\n";

            string fileName = +service.Id + "_service.txt";

            File.WriteAllText(fileName, line);
            Console.WriteLine("Foi criado o ficheiro " + fileName + " na pasta " + Directory.GetCurrentDirectory());
        }

        public void WriteToFile(ScheduleSlot scheduleSlot)
        {
            string line = Convert.ToString(scheduleSlot.Id) + "; "
                + scheduleSlot.Service.Id + "; "
                + scheduleSlot.Animal.Id + "; "
                + scheduleSlot.Veterinary.Id + "; "
                + scheduleSlot.Dia + "; "
                + scheduleSlot.HoraInicio + "; "
                + scheduleSlot.HoraFim + ";\n";

            string fileName = +scheduleSlot.Id + "_scheduleSlot.txt";

            File.WriteAllText(fileName, line);
            Console.WriteLine("Foi criado o ficheiro " + fileName + " na pasta " + Directory.GetCurrentDirectory());
        }
    }
}
