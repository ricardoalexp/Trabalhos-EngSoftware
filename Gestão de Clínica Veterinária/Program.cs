using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Gestão_de_Clínica_Veterinária.Classes;

namespace Gestão_de_Clínica_Veterinária
{
	public class Program
	{
		# region Instâncias de objetos para ler e escrever ficheiros
        static FileWriter registryWriter = new FileWriter();
		static FileReader registryReader = new FileReader();
		static CustomDateTime dateTime = new CustomDateTime();
        #endregion

        #region Listas das instâncias dos objetos
        static List<Owner> Owners;
		static List<Animal> Animals;
		static List<Veterinary> Veterinaries;
		static List<Service> Services;
		static List<ScheduleSlot> DaySchedule;
		static string CurrentDate;
		#endregion

        public static void Main(string[] args)
		{
            #region Inicializações de Datas
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentUICulture.Clone();
            culture.NumberFormat.NumberDecimalSeparator = ",";
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            #endregion

            #region Inicialização das instancias de objetos para escrita em ficheiros
            Owners = registryReader.ReadOwner();
            Animals = registryReader.ReadAnimal();
            Veterinaries = registryReader.ReadVeterinary();
            Services = registryReader.ReadService();
			DaySchedule = registryReader.ReadScheduleSlot(CurrentDate);
			CurrentDate = CustomDateTime.CurrentDate();
            #endregion

            Console.WriteLine(CustomDateTime.CurrentTime() + "  " + CustomDateTime.CurrentDate());

            MainMenu();
		}

		#region Menu
        
        static void MainMenu()
		{
			bool leave = false;
			int option;

			Console.WriteLine("Bem vindo ao software de Gestão da Clínica.");
			do
			{
				Console.WriteLine("\nEscolha uma das opções:\n");
				Console.WriteLine("1 - Área de Cliente");
				Console.WriteLine("2 - Serviços");
				Console.WriteLine("3 - Área de Administrador");
				Console.WriteLine("0 - Sair");

				if (!int.TryParse(Console.ReadLine(), out option)) { Console.WriteLine("Input inválido. Tente novamente."); }
				else
				{
					switch (option)
					{
						case 1: ClientMenu(); break;
						case 2: ServiceMenu(); break;
						case 3: AdminMenu(); break;
						case 0: leave = true; break;
						default: Console.WriteLine("Opção inválida. Tente novamente. \n"); break;
					}
				}
			} while (!leave);
		}
		
		static void ClientMenu()
		{
			bool leave = false;
			int option;
			do
			{
				Console.WriteLine("\nÁrea de cliente:\n");
				Console.WriteLine("1 - Registar Cliente");
				Console.WriteLine("2 - Registar Animal");
				Console.WriteLine("3 - Listar Clientes");
				Console.WriteLine("4 - Listar Animais de um Cliente");
				Console.WriteLine("5 - Relatório de Cliente"); // falta implementar
				Console.WriteLine("0 - Voltar Atrás");

				if (!int.TryParse(Console.ReadLine(), out option)) { Console.WriteLine("Input inválido. Tente novamente."); }
				else
				{
					switch (option)
					{
						case 1: CreateNewClient() ;break;
						case 2: CreateNewAnimal(); break;
						case 3: ListClients(); break;
						case 4: ListOwnerAnimals(); break;
						case 5: DisplayOwnerReport(); break;
						case 0: leave = true; break;
						default: Console.WriteLine("Opção inválida. Tente novamente. \n"); break;
					}
				}
			} while (!leave);

		}
				
		static void ServiceMenu()
		{
			bool leave = false;
			int option;

			do
			{
				Console.WriteLine("\nServiços:\n");
				Console.WriteLine("1 - Listar Serviços"); 
				Console.WriteLine("2 - Listar Profissionais");
				Console.WriteLine("3 - Listar Marcações do Dia !!!NÃO IMPLEMENTADO!!!");
				Console.WriteLine("4 - Fazer Marcação");
				Console.WriteLine("0 - Voltar Atrás");


				if (!int.TryParse(Console.ReadLine(), out option)) { Console.WriteLine("Input inválido. Tente novamente."); }
				else
				{
					switch (option)
					{
						case 1:	ListServices(); break;
						case 2: ListVeterinaries(); break;
						case 3: ListCurrentDaySchedule(); break;
						case 4: CreateAppointment(); break;
						case 0: leave = true; break;
						default: Console.WriteLine("Opção inválida. Tente novamente. \n"); break;
					}
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
				Console.WriteLine("0 - Voltar Atrás");

				if (!int.TryParse(Console.ReadLine(), out option)) { Console.WriteLine("Input inválido. Tente novamente."); }
				else
				{
					switch (option)
					{
						case 1: Console.WriteLine("Escolheu Opção 1\n"); RegisterService(); break;
						case 2: Console.WriteLine("Escolheu Opção 2\n"); RegisterVeterinary(); break;
						case 0: leave = true; break;
						default: Console.WriteLine("Opção inválida. Tente novamente. \n"); break;
					}
				}
			} while (!leave);
		}
        #endregion

        #region Finds
		        
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
			
		static Animal FindAnimalById(int id)
		{
			foreach(Animal animal in Animals)
            {
                if (animal.Id.Equals(id)) { return animal; }
            }

			return null;			
		}

		static Service FindServiceById(int id)
        {
			foreach (Service service in Services)
			{
				if (service.Id.Equals(id)) { return service; }
			}

			return null;
		}
				
		static Veterinary FindVeterinaryById(int id)
		{
			foreach (Veterinary veterinary in Veterinaries)
			{
				if (veterinary.Id.Equals(id)) { return veterinary; }
			}

			return null;
		}
        #endregion

        #region Creates
        
        static void CreateAppointment()

        {
			bool leaveInputState = false;
			bool inputValidated = false;
			string input = "";
			int idInput = 0;
			Owner person;
			List<Animal> ownerAnimals;
			Console.WriteLine("\nFazer marcação: ");
			Console.WriteLine("\nIntroduza o ID do cliente: ");

			#region Introduzir o nº de cliente
			while (!inputValidated && !leaveInputState)
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
								inputValidated = true;
							}
							else { Console.WriteLine("O Cliente selecionado não tem nenhum animal registado."); }
						}
					}
					else { Console.WriteLine("Input inválido. Por favor tente novamente."); }
				}
			}
			#endregion

			#region Introduzir o id do animal
			if (!leaveInputState)
            {
				inputValidated = false;
				Animal animal;
				while (!inputValidated && !leaveInputState)
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
							else { inputValidated = true; }
						}
						else { Console.WriteLine("Input inválido. Por favor tente novamente."); }
					}
				}
			}
			#endregion

			#region Introduzir Id do Serviço
			int animalId = idInput;
			int serviceDuration = 0;

			if (!leaveInputState)
			{
				inputValidated = false;
				ListServicesShort();
				Service service;
				
				while (!inputValidated && !leaveInputState)
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
							else { inputValidated = true; serviceDuration = service.Duration; }
						}
						else { Console.WriteLine("Input inválido. Por favor tente novamente."); }
					}
				}
			}
			#endregion

			#region Introduzir Data  e hora de agendamento
			int serviceId = idInput;
			bool validDate = false;

            if (!leaveInputState)
            {
				inputValidated = false;
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
				while (!inputValidated && !leaveInputState)
				{
					Console.WriteLine("Por favor insira a hora a agendar:");
					Console.WriteLine(@"(Ou insira 'LEAVE' para voltar ao menu");
					Console.WriteLine("Note que o serviço escolhido tem a seguinte duração: " + CustomDateTime.MinutesDurationFormat(serviceDuration) + "\n");

					input = Console.ReadLine();
					if (input.Equals("LEAVE")) { leaveInputState = true; }
					else
					{
						if (CustomDateTime.CheckDateTimeFormat(input)) { timeInput = input; inputValidated = true; }
						else { Console.WriteLine("Input inválido. Por favor tente novamente.\n"); }
					}
				}
			}
			#endregion

			#region Registo do ScheduleSlot
			int vetId = 0;

            if (!leaveInputState)
            {
				inputValidated = false;
				List<ScheduleSlot> schedule = registryReader.ReadScheduleSlot(date);
				Service serv = FindServiceById(serviceId);
				List<int> vetIdList = new List<int>();
				int horainicio = CustomDateTime.IntegerTimeFormat(timeInput);
				int horafim = CustomDateTime.IntegerTimeFormat(CustomDateTime.GetAppointmentEndTime(timeInput, serv.Duration));

				foreach (Veterinary vet in Veterinaries)
                {
					if(vet.CheckAvailability(schedule, horainicio, horafim))
                    {
						vetIdList.Add(vet.Id);
						Console.WriteLine(vet.Id + " - "  + vet.Name);
                    }
                }

				while (!inputValidated && !leaveInputState)
				{
					if (!vetIdList.Count.Equals(0))
					{
						Console.WriteLine("Por favor insira o id do profissional:");
						Console.WriteLine(@"(Ou insira 'LEAVE' para voltar ao menu");

						input = Console.ReadLine();
						if (input.Equals("LEAVE")) { leaveInputState = true; }
						else
						{
							if (vetIdList.Contains(int.Parse(input))) { vetId = int.Parse(input); inputValidated = true; }
							else { Console.WriteLine("Input inválido. Por favor tente novamente.\n"); }
						}
					}
					else
					{
						Console.WriteLine("Não existe nenhum veterinário disponivél na hora indicada");
					}
				}
                #endregion

                #region Dados inseridos
                if (!leaveInputState)
				{
					Console.WriteLine("Os dados introduzidos foram os seguintes:\n");
					Animal animal = FindAnimalById(animalId);
					Veterinary veterinary = FindVeterinaryById(vetId);

					string horas = CustomDateTime.StringTimeFormat(horainicio) + " - " + CustomDateTime.StringTimeFormat(horafim);

					Console.WriteLine("Dia: " + date + "\nHora: " + horas + "\n");
					Console.WriteLine("Animal: " + animal.Id + " - " + animal.Name);
					Console.WriteLine("Serviço: " + serv.ToShortString());
					Console.WriteLine("Veterinário: " + veterinary.Id + " - " + veterinary.Name + "\n");

					ScheduleSlot slot = new ScheduleSlot(serviceId, animalId, vetId, date, horainicio, horafim);

					if (!registryWriter.WriteToFile(slot)) { Console.WriteLine("Ocorreu um erro. Por favor tente novamente."); }
					else { if (slot.Dia.Equals(CurrentDate)){ DaySchedule.Add(slot); }	}
				}
                #endregion
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
        #endregion

        #region Lists        
        static void ListClients()
		{
			Console.WriteLine("Clientes Registados no Sistema:\n");
			foreach (Owner persona in Owners)
			{
				Console.WriteLine(persona.ToString());
			}
		}
		
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
		
		static void ListServices()
		{
			if (Services.Count != 0)
			{
				foreach (Service service in Services) { Console.WriteLine(service); }
			}
			else  Console.WriteLine("Não existem serviços no sistema"); 
		}
				
		static void ListServicesShort()
		{
			Console.WriteLine("");
			if (Services.Count != 0)
			{
				foreach (Service service in Services) { Console.WriteLine(service.ToShortString()); }
			}
			else
			{
				CustomDateTime.CurrentDate();
				Console.WriteLine("Não existem serviços no sistema");
			}
		}
				
		static void ListVeterinaries()
		{
			if (Veterinaries.Count != 0)
			{
				foreach (Veterinary veterinary in Veterinaries) { Console.WriteLine(veterinary); }
			}
			else { Console.WriteLine("Não existem Veterinários no sistema"); }
		}

		static void ListCurrentDaySchedule()
        {
			Service serviceAuxiliar;
			Veterinary vetAuxiliar;
			Animal animalAuxiliar;

			if (DaySchedule.Count.Equals(0)) { Console.WriteLine("Não há marcações agendadas para o dia atual."); }
			else
			{
				Console.WriteLine("\n //-----------------// " + CurrentDate + " //-----------------//\n");
				foreach (ScheduleSlot slot in DaySchedule)
				{
					serviceAuxiliar = FindServiceById(slot.ServiceId);
					vetAuxiliar = FindVeterinaryById(slot.VeterinaryId);
					animalAuxiliar = FindAnimalById(slot.AnimalId);
					string horaInicio = CustomDateTime.StringTimeFormat(slot.HoraInicio);
					string horaFim = CustomDateTime.StringTimeFormat(slot.HoraFim);

					Console.WriteLine(horaInicio + " - " + horaFim + " >> O animal " + animalAuxiliar.Name + " tem agendado " + serviceAuxiliar.Name + " com o vet. " + vetAuxiliar.Name + ".");
				}
			}
		}

		static void DisplayOwnerReport()
		{
			bool leaveInputState = false;
			bool idFound = false;
			string input;
			int idInput = 0;
			Owner person;
			List<int> ownerAnimalIds = new List<int>();
			List<Animal> ownerAnimals = new List<Animal>();
			List<ScheduleSlot> ownerAppointmentList = new List<ScheduleSlot>();
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
							foreach (Animal bicho in ownerAnimals) { ownerAnimalIds.Add(bicho.Id); }

							ownerAppointmentList = registryReader.GetSortedOwnerAppointments(ownerAnimalIds);
							idFound = true;
						}
					}
					else { Console.WriteLine("Input inválido. Por favor tente novamente."); }
				}
			}

			if (!leaveInputState)
			{
				person = FindOwnerById(idInput);
				Console.WriteLine("Relatório de Cliente:\n");
				Console.WriteLine(person.ToString());
				Console.WriteLine("Animais Registados:\n");
				foreach (Animal animal in ownerAnimals) { Console.WriteLine(animal.ToString()); }

				string displayDate = "";
				Service serviceAuxiliar;
				Veterinary vetAuxiliar;
				Animal animalAuxiliar;

				foreach (ScheduleSlot slot in ownerAppointmentList)
				{
					serviceAuxiliar = FindServiceById(slot.ServiceId);
					vetAuxiliar = FindVeterinaryById(slot.VeterinaryId);
					animalAuxiliar = FindAnimalById(slot.AnimalId);

					if (!slot.Dia.Equals(displayDate))
					{
						displayDate = slot.Dia;
						Console.WriteLine("\n //-----------------// " + displayDate + " //-----------------//\n");
					}

					string horaInicio = CustomDateTime.StringTimeFormat(slot.HoraInicio);
					string horaFim = CustomDateTime.StringTimeFormat(slot.HoraFim);Console.WriteLine(horaInicio + " - " + horaFim + " >> O animal " + animalAuxiliar.Name + " efetuou " + serviceAuxiliar.Name + " com o vet. " + vetAuxiliar.Name + ".");
				}
			}
		}
		#endregion

		#region Registers
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
				if (!input.Equals("DONE")) { serviceMedicines.Add(input); }

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
		#endregion
	}

}