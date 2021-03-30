﻿using System;
using System.IO;
using System.Collections.Generic;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class FileReader
    {       
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
                    Console.WriteLine(vet.ToString());

                    vetList.Add(vet);
                }
            }
            return vetList;
        }

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
                    Console.WriteLine(owner.ToString());

                    ownerList.Add(owner);
                }
            }
            return ownerList;
        }

        public List<Owner> ReadAnimal()
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
                    Console.WriteLine(animal.ToString());

                    animalList.Add(animal);
                }
            }
            return animalList;
        }

    }
}
