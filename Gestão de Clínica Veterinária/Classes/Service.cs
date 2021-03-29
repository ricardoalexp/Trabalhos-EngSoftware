using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class Service
    {
        public int Id { get; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string[] Medicine { get; set; }
        public int Duration { get; set; }

        public Service(int id, string name, float price, string[] medicine, int duration)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Medicine = medicine;
            this.Duration = duration;
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

            int medicineLength = this.Medicine.Length;

            for (int i = 0; i < medicineLength; i++)
            {
                text += "   " + this.Medicine[i] + "\n";
            }

            return text;
        }
    }
}
