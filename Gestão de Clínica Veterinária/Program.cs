using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Gestão_de_Clínica_Veterinária.Classes;
namespace Gestão_de_Clínica_Veterinária
{
	class Program
	{
		//Instâncias de objetos para ler e escrever ficheiros
		static FileWriter registryWriter = new FileWriter();
		static FileReader registryReader = new FileReader();
		static CustomDateTime dateTime = new CustomDateTime();

		//Listas das instâncias dos objetos
		static List<Owner> Owners;
		static List<Animal> Animals;
		static List<Veterinary> Veterinaries;
		static List<Service> Services;
		static List<ScheduleSlot> DaySchedule;

		static void Main(string[] args)
		{
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentUICulture.Clone();
            culture.NumberFormat.NumberDecimalSeparator = ",";
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
			
			Owners = registryReader.ReadOwner();
            Animals = registryReader.ReadAnimal();
            Veterinaries = registryReader.ReadVeterinary();
            Services = registryReader.ReadService();

            DaySchedule = new List<ScheduleSlot>(); //Falta Corrigir 
			Console.WriteLine(CustomDateTime.CurrentTime() + "  " + CustomDateTime.CurrentDate());
            MainMenu();
        }



		//-----------------Funções auxilares-----------------

		//-----------------Menu-----------------

		/// <summary>
		/// Representação Visual do Menu principal
		/// </summary>
		static void MainMenu()
		{
			bool leave = false;
			int option;

			Console.WriteLine("Bem vindo ao software de Gestão da Clínica.");
			do
			{
				
				Console.WriteLine("Escolha uma das opções:\n");
				Console.WriteLine("1 - Área de Cliente");
				Console.WriteLine("2 - Serviços");
				Console.WriteLine("3 - Área de Administrador");
				Console.WriteLine("0 - Sair");

				if (!int.TryParse(Console.ReadLine(), out option)) { Console.WriteLine("Input inválido. Tente novamente."); }
				else
				{
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
						default:
							Console.WriteLine("Opção inválida. Tente novamente. \n");
							break;
					}
				}
			} while (!leave);
		}

		/// <summary>
		/// Representação Visual do Menu do Cliente
		/// </summary>
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
				Console.WriteLine("5 - Relatório de Cliente"); // falta implementar
				Console.WriteLine("6 - Relatório de Animal"); // falta implementar
				Console.WriteLine("0 - Voltar Atrás");

				if (!int.TryParse(Console.ReadLine(), out option)) { Console.WriteLine("Input inválido. Tente novamente."); }
				else
				{
					switch (option)
					{
						case 1:
							CreateNewClient();
							break;
						case 2:
							CreateNewAnimal();
							break;
						case 3:
							ListClients();
							break;
						case 4:
							ListOwnerAnimals();
							break;
						case 0:
							leave = true;
							break;
						default:
							Console.WriteLine("Opção inválida. Tente novamente. \n");
							break;
					}
				}
			} while (!leave);

		}

		/// <summary>
		/// Representação Visual do Menu dos Serviços
		/// </summary>
		static void ServiceMenu()
		{
			bool leave = false;
			int option;

			do
			{
				Console.WriteLine("Serviços:\n");
				Console.WriteLine("1 - Listar Serviços"); 
				Console.WriteLine("2 - Listar Profissionais");
				Console.WriteLine("3 - Listar Marcações do Dia"); // falta implementar
				Console.WriteLine("4 - Fazer Marcação"); // falta implementar
				Console.WriteLine("0 - Voltar Atrás");


				if (!int.TryParse(Console.ReadLine(), out option)) { Console.WriteLine("Input inválido. Tente novamente."); }
				else
				{
					switch (option)
					{
						case 1:
							Console.WriteLine("Escolheu Opção 1\n");
							ListServices();
							break;
						case 2:
							Console.WriteLine("Escolheu Opção 2\n");
							ListVeterinaries();
							break;
						case 3:
							Console.WriteLine("Escolheu Opção 3\n");
							//Falta fazer!!!
							break;
						case 4:
							CreateAppointment();
							break;
						case 0:
							leave = true;
							break;
						default:
							Console.WriteLine("Opção inválida. Tente novamente. \n");
							break;
					}
				}
			} while (!leave);

		}

		/// <summary>
		/// Representação Visual do Menu do Administrador
		/// </summary>
		static void AdminMenu()
		{
			bool leave = false;
			int option;
			do
			{
				Console.WriteLine("Área de Administrador:\n");
				Console.WriteLine("1 - Registar novo serviço");
				Console.WriteLine("2 - Registar novo veterinário");
				Console.WriteLine("0 - Voltar Atrás");

				if (!int.TryParse(Console.ReadLine(), out option)) { Console.WriteLine("Input inválido. Tente novamente."); }
				else
				{
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
						default:
							Console.WriteLine("Opção inválida. Tente novamente. \n");
							break;
					}
				}
			} while (!leave);
		}

		//-----------------Find-----------------

		/// <summary>
		/// Devolve o Objeto da classe "Owner" que tem o id introduzido
		/// </summary>
		static Owner FindOwnerById(int id)
		{
			Owner owner;

			foreach (Owner person in Owners)
			{
				if (person.Id.Equals(id)) { owner = person; return owner; }
				if (person.Id.Equals(id)) { return person; }
			}

			return null;

		}

		/// <summary>
		/// Devolve o Objeto da classe "Animal" que tem o id introduzido
		/// </summary>
		static Animal FindAnimalById(int id)
		{
			foreach(Animal animal in Animals)
            {
                if (animal.Id.Equals(id)) { return animal; }
            }
			return null;			
		}

		/// <summary>
		/// Devolve o Objeto da classe "Service" que tem o id introduzido
		/// </summary>
		static Service FindServiceById(int id)
        {
			foreach (Service service in Services)
			{
				if (service.Id.Equals(id)) { return service; }
			}
			return null;
		}

		/// <summary>
		/// Devolve o Objeto da classe "Veterinary" que tem o id introduzido
		/// </summary>
		static Veterinary FindVeterinaryById(int id)
		{
			foreach (Veterinary veterinary in Veterinaries)
			{
				if (veterinary.Id.Equals(id)) { return veterinary; }
			}
			return null;
		}

		//-----------------Create-----------------

		/// <summary>
		/// Falta descrição!!!
		/// </summary>
		static void CreateAppointment() //Falta acabar!!!
        {
			bool leaveInputState = false;
			bool idFound = false;
			string input = "";
			int idInput = 0;
			Owner person;
			List<Animal> ownerAnimals;
			Console.WriteLine("\nFazer marcação: ");
			Console.WriteLine("\nIntroduza o ID do cliente: ");

			while (!idFound && !leaveInputState)
			{
				Console.WriteLine("Por favor insira o seu número de cliente:");
				Console.WriteLine(@"(Ou insira 'LEAVE' para voltar ao menu");

				input = Console.ReadLine();
				if (input.Equals("LEAVE")) { leaveInputState = true; }
				else
				{
					if (int.TryParse(input, out idInput))
					{
						person = FindOwnerById(idInput);
						if (person == null) { Console.WriteLine("Id de cliente não encontrado. Por favor tente novamente."); }
						else
						{
							ownerAnimals = person.getAnimals(Animals);
							if (ownerAnimals.Count != 0)
							{
								Console.WriteLine("Cliente selecionado:");
								Console.WriteLine(" " + person.Id + " - " + person.Name  + "\n");
								Console.WriteLine("Animais Registados:");
								foreach (Animal animal in ownerAnimals)
								{
									Console.WriteLine(" " + animal.Id + " - " + animal.Name);
								}
								idFound = true;
							}
							else { Console.WriteLine("O Cliente selecionado não tem nenhum animal registado."); }
						}
					}
					else { Console.WriteLine("Input inválido. Por favor tente novamente."); }
				}
			}
			
			if (!leaveInputState)
            {
				idFound = false;
				Animal animal;
				while (!idFound && !leaveInputState)
				{
					Console.WriteLine("Por favor insira o ID do animal a usar:");
					Console.WriteLine(@"(Ou insira 'LEAVE' para voltar ao menu");

					input = Console.ReadLine();
					if (input.Equals("LEAVE")) { leaveInputState = true; }
					else
					{
						if (int.TryParse(input, out idInput))
						{
							animal = FindAnimalById(idInput);
							if (animal == null) { Console.WriteLine("Id de animal não encontrado. Por favor tente novamente."); }
							else { idFound = true; }
						}
						else { Console.WriteLine("Input inválido. Por favor tente novamente."); }
					}
				}
			}
			int animalId = idInput;
			int serviceDuration = 0;
			if (!leaveInputState)
			{
				idFound = false;
				ListServicesShort();
				Service service;
				
				while (!idFound && !leaveInputState)
				{
					Console.WriteLine("Por favor insira o ID do serviço a agendar:");
					Console.WriteLine(@"(Ou insira 'LEAVE' para voltar ao menu");

					input = Console.ReadLine();
					if (input.Equals("LEAVE")) { leaveInputState = true; }
					else
					{
						if (int.TryParse(input, out idInput))
						{
							service = FindServiceById(idInput);
							if (service == null) { Console.WriteLine("Id de serviço não encontrado. Por favor tente novamente."); }
							else { idFound = true; serviceDuration = service.Duration; }
						}
						else { Console.WriteLine("Input inválido. Por favor tente novamente."); }
					}
				}
			}
			int serviceId = idInput;
			bool validDate = false;
            if (!leaveInputState)
            {
				idFound = false;
				while (!validDate && !leaveInputState)
				{
					Console.WriteLine("Por favor insira a data a agendar:");
					Console.WriteLine(@"(Ou insira 'LEAVE' para voltar ao menu");

					input = Console.ReadLine();
					if (input.Equals("LEAVE")) { leaveInputState = true; }
					else
					{
						if (CustomDateTime.AppointmentDateValidate(input)){validDate = true;}
						else { Console.WriteLine("Data inválida. Por favor tente novamente."); }
					}
				}
			}
			string date = "";
			string timeInput = "";
			if (!leaveInputState) {
				date = CustomDateTime.FormatDate(input);
				Console.WriteLine("Data inserida: " + date);
				while (!idFound && !leaveInputState)
				{
					Console.WriteLine("Por favor insira a hora a agendar:");
					Console.WriteLine(@"(Ou insira 'LEAVE' para voltar ao menu");
					Console.WriteLine("Note que o serviço escolhido tem a seguinte duração: " + CustomDateTime.MinutesDurationFormat(serviceDuration));

					input = Console.ReadLine();
					if (input.Equals("LEAVE")) { leaveInputState = true; }
					else
					{
						if (CustomDateTime.CheckDateTimeFormat(input)) { timeInput = input; }
						else { Console.WriteLine("Input inválido. Por favor tente novamente."); }
					}
				}
			}
		}

		/// <summary>
		/// Cria um novo cliente através de dados que o utilizador introduz. Guarda no ficheiro e adiciona à lista dos clientes em memória.
		/// </summary>
		static void CreateNewClient()
		{
			Console.WriteLine("\nNovo Cliente: ");
			Console.WriteLine("\nIntroduza o nome do cliente: ");
			string ownerName = Console.ReadLine();

			Console.WriteLine("\nIntroduza a morada do cliente: ");
			string ownerAddress = Console.ReadLine();

			Console.WriteLine("\nIntroduza o contacto do cliente: ");
			long ownerContact = long.Parse(Console.ReadLine());

			Owner owner = new Owner(ownerName, ownerAddress, ownerContact);

			owner.Id = registryWriter.WriteToFile(owner);

			if (owner.Id.Equals(0)) { Console.WriteLine("Ocorreu um erro. Por favor tente novamente."); }
			else { Owners.Add(owner); }
		}

		/// <summary>
		/// Cria um novo animal através de dados que o utilizador introduz. Guarda no ficheiro e adiciona à lista dos clientes em memória.
		/// </summary>
		static void CreateNewAnimal()
		{
			Console.WriteLine("\nIntroduza um Animal:");
			Console.WriteLine("\nIntroduza o Nome:");
			string animalName = Console.ReadLine();

			Console.WriteLine("\nIntroduza o Género:");
			string animalGender = Console.ReadLine();

			Console.WriteLine("\nIntroduza a Categoria:");
			string animalCategory = Console.ReadLine();

			Console.WriteLine("\nIntroduza a subcategoria:");
			string animalSubcategory = Console.ReadLine();

			Console.WriteLine("");
			string input;
			int ownerId = 0;
			bool validId = false;
			bool leaveInputState = false;
			while (!validId && !leaveInputState)
			{
				Console.WriteLine("Introduza o ID de cliente:");
				Console.WriteLine(@"Ou introduza 'LEAVE' para voltar ao menu)");
				input = Console.ReadLine();
				if (input.Equals("LEAVE")) { leaveInputState = true; }
				else
				{
					if (int.TryParse(input, out ownerId))
					{
						if (FindOwnerById(ownerId) == null) { Console.WriteLine("\nId de cliente não encontrado. Por favor tente novamente."); }
						else { validId = true; }
					}
					else { Console.WriteLine("\nInput inválido. Por favor tente novamente."); }
				}
			}
			if (!leaveInputState)
			{
				Animal animal = new Animal(animalName, animalGender, animalCategory, animalSubcategory, ownerId);
				animal.Id = registryWriter.WriteToFile(animal);
				if (animal.Id.Equals(0)) { Console.WriteLine("Ocorreu um erro. Por favor tente novamente."); }
				else { Animals.Add(animal); }
			}
		}

		/// <summary>
		/// Mostra a lista dos clientes em memória
		/// </summary>

		//-----------------Lists-----------------

		static void ListClients()
		{
			Console.WriteLine("Clientes Registados no Sistema:\n");
			foreach (Owner persona in Owners)
			{
				Console.WriteLine(persona.ToString());
			}
		}
		/// <summary>
		/// Mostra a lista dos animais de um owner em memória introduzido pelo user
		/// </summary>
		static void ListOwnerAnimals()
		{
			bool leaveInputState = false;
			bool idFound = false;
			string input;
			int idInput;
			Owner person;
			List<Animal> ownerAnimals;
			while (!idFound && !leaveInputState)
			{
				Console.WriteLine("Por favor insira o seu número de cliente:");
				Console.WriteLine(@"(Ou insira 'LEAVE' para voltar ao menu");

				input = Console.ReadLine();
				if (input.Equals("LEAVE")) { leaveInputState = true; }
				else
				{
					if (int.TryParse(input, out idInput))
					{
						person = FindOwnerById(idInput);
						if (person == null) { Console.WriteLine("Id de cliente não encontrado. Por favor tente novamente."); }
						else
						{
							ownerAnimals = person.getAnimals(Animals);
							if (ownerAnimals.Count != 0)
							{
								Console.WriteLine(person.ToString() + "\n");
								foreach (Animal bicho in ownerAnimals)
								{
									Console.WriteLine(bicho.ToString() + "\n");
								}
								idFound = true;
							}
							else { Console.WriteLine("O Cliente selecionado não tem nenhum animal registado."); }
						}
					}
					else { Console.WriteLine("Input inválido. Por favor tente novamente."); }
				}
			}
		}

		/// <summary>
		/// Mostra a lista dos serviços em memória
		/// </summary>
		static void ListServices()
		{
			if (Services.Count != 0)
			{
				foreach (Service service in Services)
				{
					Console.WriteLine(service);
				}
			}
			else
			{
				Console.WriteLine("Não existem serviços no sistema");
			}
		}

		/// <summary>
		/// Mostra a versão simplificada da lista dos serviços em memória
		/// </summary>
		static void ListServicesShort()
		{
			Console.WriteLine("");
			if (Services.Count != 0)
			{
				foreach (Service service in Services)
				{
					Console.WriteLine(service.ToShortString());
				}
			}
			else
			{
				CustomDateTime.CurrentDate();
				Console.WriteLine("Não existem serviços no sistema");
			}
		}

		/// <summary>
		/// Mostra a lista dos veterinários em memória
		/// </summary>
		static void ListVeterinaries()
		{
			if (Veterinaries.Count != 0)
			{
				foreach (Veterinary veterinary in Veterinaries)
				{
					Console.WriteLine(veterinary);
				}
			}
			else
			{
				Console.WriteLine("Não existem Veterinários no sistema");
			}
		}

		/// <summary>
		/// Pede ao utilizador os dados de um serviço e guarda o mesmo em memória e em ficheiro
		/// </summary>

		//-----------------Register-----------------

		/// <summary>
		/// Pede ao utilizador os dados de um serviço e guarda o mesmo em memória e em ficheiro
		/// </summary>
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
			newService.Id = registryWriter.WriteToFile(newService);

			if (newService.Id.Equals(0)) { Console.WriteLine("Ocorreu um erro. Por favor tente novamente."); }
			else { Services.Add(newService); }

		}

		/// <summary>
		/// Pede ao utilizador os dados de um veterinário e guarda o mesmo em memória e em ficheiro
		/// </summary>
		static void RegisterVeterinary()
        {

          Console.WriteLine("Novo Veterinário\n");
          Console.WriteLine("Introduza o nome do Veterinário\n");
          string nameVeterinary = Console.ReadLine();

          Veterinary newVeterinary = new Veterinary(nameVeterinary);
          registryWriter.WriteToFile(newVeterinary);
        }
	}
}
