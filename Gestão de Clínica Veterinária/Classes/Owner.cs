using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long Contact { get; set; }

        public Owner(int id, string name, string address, long contact)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Contact = contact;
        }

        public Owner(string name, string address, long contact)
        {
            this.Name = name;
            this.Address = address;
            this.Contact = contact;
        }
        
        public List<Animal> getAnimals(List<Animal> animals)
        {
            List<Animal> ownerAnimals = new List<Animal>();
            foreach(Animal animal in animals)
            {
                if (animal.OwnerId.Equals(this.Id)) { ownerAnimals.Add(animal); }
            }
            return ownerAnimals;
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