using System;
using Gestão_de_Clínica_Veterinária.Classes;
namespace Gestão_de_Clínica_Veterinária
{
    class Program
    {
        static FileWriter register = new FileWriter();
        static FileReader test = new FileReader();
        static void Main(string[] args)
        {
            bool leave = false;
            int option;

            do
            {
                Console.WriteLine("Bem vindo ao software de Gestão da Clínica.");
                Console.WriteLine("Escolha uma das opções:\n");
                Console.WriteLine("1 - Área de Cliente");
                Console.WriteLine("2 - Serviços");
                Console.WriteLine("0 - Sair");
                test.ReadVeterinary();

                option = int.Parse(Console.ReadLine());

                switch(option) 
                {
                    case 1:
                        ClientMenu();
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

                        register.WriteToFile(owner);

                        break;
                    case 2:
                        Console.WriteLine("Introduza um Animal \n");

                        Console.WriteLine("Introduza o ID \n");
                        int idAnimal = int.Parse(Console.ReadLine());

                        Console.WriteLine("Introduza o Nome \n");
                        string nameAnimal = Console.ReadLine();

                        Console.WriteLine("Introduza o Género \n");
                        string genderAnimal = Console.ReadLine();

                        Console.WriteLine("Introduza a Categoria \n");
                        string categoryAnimal = Console.ReadLine();

                        Console.WriteLine("Introduza a subcategoria \n");
                        string subcategoryAnimal = Console.ReadLine();

                        Console.WriteLine("Introduza o ID do Dono \n");
                        int ownerId = int.Parse(Console.ReadLine());

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
                        Console.WriteLine("asdadaw\n");
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
