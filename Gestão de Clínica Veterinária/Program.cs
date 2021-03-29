﻿using System;
using Gestão_de_Clínica_Veterinária.Classes;
namespace Gestão_de_Clínica_Veterinária
{
    class Program
    {
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

                Animal x;

                option = int.Parse(Console.ReadLine());

                switch(option) 
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

        static void ClientMenu()
        {
            bool leave = false;
            int option;
            do
            {
                Console.WriteLine("Área de cliente:\n");
                Console.WriteLine("1 - Registar Cliente");
                Console.WriteLine("2 - Listar Clientes");
                Console.WriteLine("3 - Registar Animal");
                Console.WriteLine("4 - Listar Animais");
                Console.WriteLine("5 - Relatório de Cliente");
                Console.WriteLine("0 - Sair");

                option = int.Parse(Console.ReadLine());

                Animal x;

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

                Animal x;

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
                }

            } while (!leave);
        }
         
    }
}
