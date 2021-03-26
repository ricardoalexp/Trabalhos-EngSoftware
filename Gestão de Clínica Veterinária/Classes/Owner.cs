using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class Owner
    {
        private int Id { get; }
        private string Name { get; set; }
        private string Address { get; set; }
        private int Contact { get; set; }

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
    }
}
