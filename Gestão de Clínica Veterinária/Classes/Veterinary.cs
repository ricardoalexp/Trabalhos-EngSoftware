using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class Veterinary
    {
        private int Id { get; }
        private string Name { get; set; }
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }

        public Veterinary (int id, string name, string dia, string horaInicio, string horaFim)
        {
            this.Id = id;
            this.Name = name;
            this.Dia = dia;
            this.HoraInicio = horaInicio;
            this.HoraFim = horaFim;
        }

        public bool Equals (Veterinary veterinary)
        {
            bool result;

            if (veterinary == null){ result = false;}
            else{ result = Id.Equals(veterinary.Id) ? true : false; }

            return result;
        }

        public override String ToString()
        {
            string text;

            text = "Id: " + this.Id + "\n" + "Nome: " + this.Name;

            return text;
        }
    }
}
