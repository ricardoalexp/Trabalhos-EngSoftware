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
            this.Dia = dia;
            this.Service = service;
            this.Dia = dia;
            this.HoraInicio = horaInicio;
            this.HoraFim = horaFim;
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
            string text = "";

            text += "Id: " + this.Id + "\n";
            text += "Serviço: " + this.Service + "\n";
            text += "Animal: " + this.Animal + "\n";
            text += "Veterinário: " + this.Veterinary + "\n";
            text += "Dia: " + this.Dia + "\n";
            text += "Hora de início: " + this.HoraInicio + "\n";
            text += "Hora de fim: " + this.HoraFim + "\n";

            return text;
        }
    }
}
