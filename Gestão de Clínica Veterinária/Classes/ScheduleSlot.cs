using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class Schedule_Slot
    {
        public int Id { get; }
        public Service Service { get; set; }
        public Animal Animal { get; set; }
        public Veterinary Veterinary { get; set; }
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        
        public Schedule_Slot(int id, Service service, Animal animal, Veterinary veterinary, string dia, string horaInicio, string horaFim)
        {
            this.Id = id;
            this.Dia = dia;
            this.Service = service;
            this.Dia = dia;
            this.HoraInicio = horaInicio;
            this.HoraFim = horaFim;
        }

        public bool Equals(Owner owner)
        {
            bool resultado;

            if (owner == null) { resultado = false; }
            else { resultado = Id.Equals(owner.Id) ? true : false; }

            return resultado;
        }

        public override string ToString()
        {
            string text = "";

            text += "Id: " + this.Id + "\n";
            text += "Nome: " + this.Name + "\n";
            text += "Contacto: " + this.Contact + "\n";
            text += "Endereço: " + this.Address + "\n";

            return text;
        }
    }
}
