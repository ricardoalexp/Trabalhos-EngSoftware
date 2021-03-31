﻿using System;
using System.Collections.Generic;
using Gestão_de_Clínica_Veterinária.Classes;
namespace Gestão_de_Clínica_Veterinária
{
    class Program
    {
        static FileWriter regWriter = new FileWriter();
        static FileReader regReader = new FileReader();

        static List<Owner> Owners;
        static List<Animal> Animals;
        static List<Veterinary> Veterinaries;
        static List<Service> Services;
        static List<ScheduleSlot> DaySchedule;

        static FileReader test = new FileReader();

        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            bool leave = false;
            int option;

            Owners = regReader.ReadOwner();
            Animals = regReader.ReadAnimal();
            Veterinaries = regReader.ReadVeterinary();
            Services = regReader.ReadService();
            DaySchedule = new List<ScheduleSlot>();

            do
            {
                Console.WriteLine("Bem vindo ao software de Gestão da Clínica.");
                Console.WriteLine("Escolha uma das opções:\n");
                Console.WriteLine("1 - Área de Cliente");
                Console.WriteLine("2 - Serviços");
                Console.WriteLine("3 - Área de Administrador");
                Console.WriteLine("0 - Sair");
                test.ReadVeterinary();

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        ClientMenu();
                        break;
                    case 2:
                        ServiceMenu();
                        break;
                    case 3:
                        AdminMenu();
                        break;
                    case 0:
                        leave = true;
                        break;
                }

            } while (!leave);
        }

        static void ClientMenu()
        {
            bool leave = false;
            int option;
            do
            {
                Console.WriteLine("Área de cliente:\n");
                Console.WriteLine("1 - Registar Cliente");
                Console.WriteLine("2 - Registar Animal");
                Console.WriteLine("3 - Listar Clientes");
                Console.WriteLine("4 - Listar Animais");
                Console.WriteLine("5 - Relatório de Cliente");
                Console.WriteLine("6 - Relatório de Animal");
                Console.WriteLine("0 - Sair");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        Console.WriteLine("Novo Cliente: \n");
                        Console.WriteLine("Introduza o nome do cliente: \n");
                        string ownerName = Console.ReadLine();

                        Console.WriteLine("Introduza a morada do cliente: \n");
                        string ownerAddress = Console.ReadLine();

                        Console.WriteLine("Introduza o contacto do cliente: \n");
                        long ownerContact = long.Parse(Console.ReadLine());

                        Owner owner = new Owner(ownerName, ownerAddress, ownerContact);

                        regWriter.WriteToFile(owner);

                        break;

                    case 2:
                        Console.WriteLine("Introduza um Animal:\n");
                        Console.WriteLine("Introduza o Nome \n");
                        string animalName = Console.ReadLine();

                        Console.WriteLine("Introduza o Género \n");
                        string animalGender = Console.ReadLine();

                        Console.WriteLine("Introduza a Categoria \n");
                        string animalCategory = Console.ReadLine();

                        Console.WriteLine("Introduza a subcategoria \n");
                        string animalSubcategory = Console.ReadLine();

                        Console.WriteLine("Introduza o ID do Dono \n");
                        int ownerId = int.Parse(Console.ReadLine());

                        Animal animal = new Animal(animalName, animalGender, animalCategory, animalSubcategory, ownerId);
                        animal.Id = regWriter.WriteToFile(animal);

                        Console.WriteLine("Adicionou:\n" + animal.ToString());
                        break;

                    case 3:
                        Console.WriteLine("Escolheu Opçao 3\n");
                        break;
                
                    case 0:
                        leave = true;
                        break;
                }

            } while (!leave);

        }
        static void ServiceMenu()
        {
            bool leave = false;
            int option;

            do
            {
                Console.WriteLine("Serviços:\n");
                Console.WriteLine("1 - Listar Serviços");
                Console.WriteLine("2 - Listar Profissionais");
                Console.WriteLine("3 - Listar Marcações do Dia");
                Console.WriteLine("4 - Fazer Marcação");
                Console.WriteLine("0 - Sair");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Escolheu Opçao 1\n");
                        break;
                    case 2:
                        Console.WriteLine("Escolheu Opçao 2\n");
                        break;
                    case 3:
                        Console.WriteLine("Escolheu Opçao 3\n");
                        break;
                    case 0:
                        leave = true;
                        break;
                }

            } while (!leave);

        }

        static void AdminMenu()
        {
            bool leave = false;
            int option;
            do
            {
                Console.WriteLine("Área de Administrador:\n");
                Console.WriteLine("1 - Registar novo serviço");
                Console.WriteLine("2 - Registar novo veterinário");
                Console.WriteLine("0 - Sair");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:                        
                        Console.WriteLine("Novo Serviço:\n");
                        Console.WriteLine("Introduza o Nome do Serviço:\n");
                        string serviceName = Console.ReadLine();

                        Console.WriteLine("Introduza o Preço (utilizar ponto) do Serviço: \n");
                        float servicePrice = float.Parse(Console.ReadLine());

                        Console.WriteLine("Introduza a Duração do Serviço: \n");
                        Console.WriteLine("(formato hhmm)\n");
                        int serviceDuration = int.Parse(Console.ReadLine());

                        List<string> serviceMedicines = new List<string>();
                        Console.WriteLine("Introduza os medicamentos um a um:\n");
                        Console.WriteLine("(após inserir todos, escreva DONE para terminar):\n");
                        string input;
                        do
                        {
                            input = Console.ReadLine();
                            serviceMedicines.Add(input);

                        } while (!input.Equals("DONE"));

                        Service newService = new Service(serviceName,servicePrice,serviceMedicines,serviceDuration);
                        newService.Id = regWriter.WriteToFile(newService);
                        
                        break;
                    case 2:
                        Console.WriteLine("Escolheu Opçao 2\n");
                        break;
                    case 3:
                        Console.WriteLine("Escolheu Opçao 3\n");
                        break;
                    case 0:
                        leave = true;
                        break;
                }

            } while (!leave);
        }
         
    }
}
