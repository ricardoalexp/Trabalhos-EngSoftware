using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public List<string> Medicine { get; set; }
        public int Duration { get; set; }

        public Service(string name, float price, List<string> medicine, int duration)
        {
            this.Name = name;
            this.Price = price;
            this.Medicine = medicine;
            this.Duration = duration;
        }
        
        public Service(int id, string name, float price, List<string> medicine, int duration)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Medicine = medicine;
            this.Duration = duration;
        }

        
        public String ToShortString()
        {
            string text = this.Id + " - " + this.Name;
            return text;
        }

        public bool Equals (Service service)
        {
            bool result;

            if (service == null){ result = false;}
            else{ result = Id.Equals(service.Id) ? true : false; }

            return result;
        }

        public override String ToString()
        {
            string text = "Serviço: " + this.Name + "\n" + "Preço: " + this.Price + "\n" + "Duração: " + this.Duration + "\n" + "Medicamentos: \n";
            int medicineLength = this.Medicine.Count;

            for (int i = 0; i < medicineLength; i++){ text += "   " + this.Medicine[i] + "\n"; }

            return text;
        }
    }
}
