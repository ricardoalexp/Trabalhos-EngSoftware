using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    enum Gender {
        Male,Female,Other
    }
    class Animal
    {
        private int Id { get; }
        private string Name { get; set; }
        private Gender Gender { get; set; }
        private string Category { get; set; }
        private string Subcategory { get; set; }
        private Owner Owner { get; set; }

        public Animal(int id, string name, Gender gender, string category, Owner owner)
        {
            this.Id = id;
            this.Name = name;
            this.Gender = gender;
            this.Category = category;
            this.Subcategory = "---";
            this.Owner = owner;
        }
        public Animal(int id, string name, Gender gender, string category, string subcategory, Owner owner)
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

            if (animal == null){ resultado = false;}
            else{ resultado = Id.Equals(animal.Id) ? true : false; }

            return resultado;
        }

        public override String ToString()
        {
            string text;

            text = "";
            return text;
        }
    }
}
