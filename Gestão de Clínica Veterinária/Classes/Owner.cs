using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class Owner
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Contact { get; set; }

        public Owner(int id, string name, string address, int contact)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Contact = contact;
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
            string text = "Id: " + this.Id + "\n";
            text += "Nome: " + this.Name + "\n";
            text += "Contacto: " + this.Contact + "\n";
            text += "Endereço: " + this.Address + "\n";

            return text;
        }
    }
}