using System;
using System.IO;
using System.Collections.Generic;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class FileReader
    {
        /// <summary>
        /// Lê os ficheiros do veterinários e retorna uma lista dos mesmos 
        /// </summary>
        /// <returns>Lista de "Veterinary"</returns>
        public List<Veterinary> ReadVeterinary()
        {
            string[] dirs = Directory.GetFiles(@"..\..\..\Resources\Veterinaries");
            List<Veterinary> vetList = new List<Veterinary>();

            foreach (string dir in dirs)
            {
                if (Path.GetFileName(dir) != "não apagar.txt")
                {
                    string text = File.ReadAllText(dir);
                    string[] atributes = text.Split(';');

                    Veterinary vet = new Veterinary(int.Parse(atributes[0]), atributes[1]);
                    //Console.WriteLine(vet.ToString());

                    vetList.Add(vet);
                }
            }
            return vetList;
        }

        /// <summary>
        /// Lê os ficheiros dos "Veterinary" e retorna uma lista dos mesmos 
        /// </summary>
        /// <returns>Lista de "Veterinary"</returns>
        public List<Owner> ReadOwner()
        {
            string[] dirs = Directory.GetFiles(@"..\..\..\Resources\Clients");
            List<Owner> ownerList = new List<Owner>();

            foreach (string dir in dirs)
            {
                if (Path.GetFileName(dir) != "não apagar.txt")
                {
                    string text = File.ReadAllText(dir);
                    string[] atributes = text.Split(';');

                    Owner owner = new Owner(int.Parse(atributes[0]), atributes[1], atributes[2], long.Parse(atributes[3]));
                    //Console.WriteLine(owner.ToString());

                    ownerList.Add(owner);
                }
            }
            return ownerList;
        }

        /// <summary>
        /// Lê os ficheiros dos "Owner" e retorna uma lista dos mesmos 
        /// </summary>
        /// <returns>Lista de "Owner"</returns>
        public List<Animal> ReadAnimal()
        {
            string[] dirs = Directory.GetFiles(@"..\..\..\Resources\Animals");
            List<Animal> animalList = new List<Animal>();

            foreach (string dir in dirs)
            {
                if (Path.GetFileName(dir) != "não apagar.txt")
                {
                    string text = File.ReadAllText(dir);
                    string[] atributes = text.Split(';');

                    Animal animal = new Animal(int.Parse(atributes[0]), atributes[1], atributes[2], atributes[3], atributes[4], int.Parse(atributes[5]));
                    //Console.WriteLine(animal.ToString());

                    animalList.Add(animal);
                }
            }
            return animalList;
        }

        /// <summary>
        /// Lê os ficheiros dos "Animal" e retorna uma lista dos mesmos 
        /// </summary>
        /// <returns>Lista de "Animal"</returns>
        public List<Service> ReadService()
        {
            string[] dirs = Directory.GetFiles(@"..\..\..\Resources\Services");
            List<Service> serviceList = new List<Service>();
            List<string> medicines;

            foreach (string dir in dirs)
            {
                if (Path.GetFileName(dir) != "não apagar.txt")
                {
                    string text = File.ReadAllText(dir);
                    string[] atributes = text.Split(';');

                    string[] meds = atributes[3].Split(':');
                    medicines = new List<string>();
                                        
                        foreach (string med in meds)
                        {
                            medicines.Add(med);
                        }

                    atributes[2] = atributes[2].Replace('.', ',');
                  
                    Service service = new Service(int.Parse(atributes[0]), atributes[1], float.Parse(atributes[2]), medicines, int.Parse(atributes[4]));
                    //Console.WriteLine(service.ToString());

                    serviceList.Add(service);
                }
            }
            return serviceList;
        }

        /// <summary>
        /// Lê os ficheiros dos "ScheduleSlot" e retorna uma lista dos mesmos 
        /// </summary>
        /// <returns>Lista de "ScheduleSlot"</returns>
        public List<ScheduleSlot> ReadScheduleSlot(string date)
        {
            string[] dirs = Directory.GetFiles(@"..\..\..\Resources\Registry");
            List<ScheduleSlot> scheduleSlotList = new List<ScheduleSlot>();

            foreach (string file in dirs)
            {
                if (Path.GetFileName(file).Equals(date + ".txt"))
                {
                    string[] lines = File.ReadAllLines(file);

                    foreach (string line in lines)
                    {
                        string[] atributes = line.Split(';');

                        ScheduleSlot scheduleSlot = new ScheduleSlot(int.Parse(atributes[0]), int.Parse(atributes[1]), int.Parse(atributes[2]), int.Parse(atributes[3]), atributes[4], int.Parse(atributes[5]), int.Parse(atributes[6]));

                        scheduleSlotList.Add(scheduleSlot);

                        //Console.WriteLine(scheduleSlot.ToString());
                    }
               
                }

            }

            return scheduleSlotList;
        }

    }
}
