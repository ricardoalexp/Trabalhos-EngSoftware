using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
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
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentUICulture.Clone();
            culture.NumberFormat.NumberDecimalSeparator = ",";
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            Owners = regReader.ReadOwner();
            Animals = regReader.ReadAnimal();
            Veterinaries = regReader.ReadVeterinary();
            Services = regReader.ReadService();
            DaySchedule = new List<ScheduleSlot>();

            MainMenu();


            //test.ReadScheduleSlot("20210331");
            //Console.WriteLine(GetCurrentDateString());

        }

        static void MainMenu()
		{
			bool leave = false;
			int option;

			do
			{
				Console.WriteLine("Bem vindo ao software de Gestão da Clínica.");
				Console.WriteLine("Escolha uma das opções:\n");
				Console.WriteLine("1 - Área de Cliente");
				Console.WriteLine("2 - Serviços");
				Console.WriteLine("3 - Área de Administrador");
				Console.WriteLine("0 - Sair");

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
				Console.WriteLine("4 - Listar Animais de um Cliente");
				Console.WriteLine("5 - Relatório de Cliente");
				Console.WriteLine("6 - Relatório de Animal");
				Console.WriteLine("0 - Sair");

				option = int.Parse(Console.ReadLine());

				switch (option)
				{
					case 1:
						Console.WriteLine("\nNovo Cliente: ");
						Console.WriteLine("\nIntroduza o nome do cliente: ");
						string ownerName = Console.ReadLine();

						Console.WriteLine("\nIntroduza a morada do cliente: ");
						string ownerAddress = Console.ReadLine();

						Console.WriteLine("\nIntroduza o contacto do cliente: ");
						long ownerContact = long.Parse(Console.ReadLine());

						Owner owner = new Owner(ownerName, ownerAddress, ownerContact);

						regWriter.WriteToFile(owner);

						break;

					case 2:
						Console.WriteLine("\nIntroduza um Animal:");
						Console.WriteLine("\nIntroduza o Nome:");
						string animalName = Console.ReadLine();

						Console.WriteLine("\nIntroduza o Género:");
						string animalGender = Console.ReadLine();

						Console.WriteLine("\nIntroduza a Categoria:");
						string animalCategory = Console.ReadLine();

						Console.WriteLine("\nIntroduza a subcategoria:");
						string animalSubcategory = Console.ReadLine();

						Console.WriteLine("\nIntroduza o ID do Dono:");
						int ownerId = int.Parse(Console.ReadLine());

						Animal animal = new Animal(animalName, animalGender, animalCategory, animalSubcategory, ownerId);
						animal.Id = regWriter.WriteToFile(animal);

						Console.WriteLine("Adicionou:\n" + animal.ToString());
						break;

					case 3:
						Console.WriteLine("Clientes Registados no Sistema:\n");
						foreach(Owner person in Owners)
						{
							Console.WriteLine(person.ToString());
						}
						break;
					case 4:
						Console.WriteLine("Por favor insira o seu número de cliente:");
						int idInput = int.Parse(Console.ReadLine());

						
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
						Console.WriteLine("Escolheu Opção 1\n");
						ListService();					
						break;
					case 2:
						Console.WriteLine("Escolheu Opção 2\n");
						ListVeterinaries();                        
						break;
					case 3:
						Console.WriteLine("Escolheu Opção 3\n");
						//Falta fazer!!!
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
						Console.WriteLine("Escolheu Opção 1\n");
						RegisterService();
						break;
					case 2:
						Console.WriteLine("Escolheu Opção 2\n");
						RegisterVeterinary();
						break;
					case 0:
						leave = true;
						break;
				}

			} while (!leave);
		}

		static Owner FindOwnerById(int id)
		{
			Owner owner;

			foreach(Owner person in Owners)
			{
				if(person.Id.Equals(id)) { owner = person; return owner; }
			}

			return null;
			
		}

		static Animal FindAnimalById(int id)
		{
			return null;
		}

		static string GetCurrentDateString()
		{
			string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
			date = date.Replace("-", "");
			return date;
		}

		static void ListService()
		{
			if (Services != null)
			{
				foreach (Service service in Services)
				{
					service.ToString();
				}
			}
			else
			{
				Console.WriteLine("Não existem serviços no sistema");
			}
		}

		static void ListVeterinaries()
		{
			if (Veterinaries != null)
			{
				foreach (Veterinary veterinary in Veterinaries)
				{
					veterinary.ToString();
				}
			}
			else
			{
				Console.WriteLine("Não existem Veterinários no sistema");

			}
		}

		static void RegisterService()
		{
			Console.WriteLine("Novo Serviço:\n");
			Console.WriteLine("Introduza o Nome do Serviço:\n");
			string serviceName = Console.ReadLine();

			Console.WriteLine("Introduza o Preço do Serviço: \n");
			float servicePrice = float.Parse(Console.ReadLine().Replace('.', ','));

			Console.WriteLine("Introduza a Duração do Serviço: \n");
			Console.WriteLine("(formato hhmm)\n");
			int serviceDuration = int.Parse(Console.ReadLine());

			List<string> serviceMedicines = new List<string>();
			Console.WriteLine("Introduza os medicamentos um a um:\n");
			Console.WriteLine("(Após inserir todos, escreva DONE para terminar):\n");
			string input;
			do
			{
				input = Console.ReadLine();
				if (!input.Equals("DONE"))
				{
					serviceMedicines.Add(input);
				}

			} while (!input.Equals("DONE"));

			Service newService = new Service(serviceName, servicePrice, serviceMedicines, serviceDuration);
			newService.Id = regWriter.WriteToFile(newService);
		}

		static void RegisterVeterinary()
                        {
							Console.WriteLine("Novo Veterinário\n");
							Console.WriteLine("Introduza o nome do Veterinário\n");
							string nameVeterinary = Console.ReadLine();

							Veterinary newVeterinary = new Veterinary(nameVeterinary);
							regWriter.WriteToFile(newVeterinary);
						}



	}
}
