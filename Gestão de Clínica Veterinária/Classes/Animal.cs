using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class Animal
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public Owner Owner { get; set; }

        public Animal(int id, string name, string gender, string category, Owner owner)
        {
            this.Id = id;
            this.Name = name;
            this.Gender = gender;
            this.Category = category;
            this.Subcategory = "---";
            this.Owner = owner;
        }
        public Animal(int id, string name, string gender, string category, string subcategory, Owner owner)
        {
            this.Id = id;
            this.Name = name;
            this.Gender = gender;
            this.Category = category;
            this.Subcategory = subcategory;
            this.Owner = owner;
        }

        public bool Equals(Animal animal)
        {
            bool resultado;

            if (animal == null) { resultado = false; }
            else { resultado = Id.Equals(animal.Id) ? true : false; }

            return resultado;
        }

        public override string ToString()
        {
            string text = "Dono: " + this.Owner.Name + "\n";
            text += "Id: " + this.Id + "\n";
            text += "Nome: " + this.Name + "\n";
            text += "Género: " + this.Gender + "\n";
            text += "Espécie: " + this.Category + "\n";
            text += "Subespécie: " + this.Subcategory + "\n";
            return text;
        }
    }
}