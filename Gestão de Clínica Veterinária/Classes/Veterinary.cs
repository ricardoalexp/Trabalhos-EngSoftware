using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class Veterinary
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Veterinary (int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Veterinary(string name)
        {
            this.Name = name;
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
            string text = "Id: " + this.Id + "\n" + "Nome: " + this.Name;

            return text;
        }
    }
}
