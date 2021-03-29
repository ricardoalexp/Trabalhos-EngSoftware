using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class ScheduleSlot
    {
        public int Id { get; }
        public Service Service { get; set; }
        public Animal Animal { get; set; }
        public Veterinary Veterinary { get; set; }
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }

        public ScheduleSlot(int id, Service service, Animal animal, Veterinary veterinary, string dia, string horaInicio, string horaFim)
        {
            this.Id = id;
            this.Service = service;
            this.Animal = animal;
            this.Veterinary = veterinary;
            this.Dia = dia;
            this.HoraInicio = horaInicio;
            this.HoraFim = horaFim;
        }

        public ScheduleSlot(int id, Veterinary veterinary, string dia, string horaInicio, string horaFim)
        {
            this.Id = id;
            this.Veterinary = veterinary;
            this.Dia = dia;
            this.HoraInicio = horaInicio;
            this.HoraFim = horaFim;
        }

        public void AddAnimal() 
        {
            if (this.Animal == null)
            {
                Console.WriteLine("Adicione o animal: ");
                //TODO this.Animal = ler do ficheiro;
            }
        }

        public void AddService()
        {
            if (this.Service == null) 
            {
                Console.WriteLine("Introduza o serviço desejado: ");
                //TODO this.Service = ler do ficheiro;
            }
        }
        public bool Equals(ScheduleSlot scheduleSlot)
        {
            bool resultado;

            if (scheduleSlot == null) { resultado = false; }
            else { resultado = Id.Equals(scheduleSlot.Id) ? true : false; }

            return resultado;
        }

        public override string ToString()
        {
            string text = "Id: " + this.Id + "\n";
            text += "Serviço: " + this.Service.Name + "\n";
            text += "Animal: " + this.Animal.Name + "\n";
            text += "Veterinário: " + this.Veterinary.Name + "\n";
            text += "Dia: " + this.Dia + "\n";
            text += "Hora de início: " + this.HoraInicio + "\n";
            text += "Hora de fim: " + this.HoraFim + "\n";

            return text;
        }
    }
}
