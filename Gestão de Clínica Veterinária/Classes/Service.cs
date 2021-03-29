using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class Service
    {
        private int Id { get; }
        private string Name { get; set; }
        private float Price { get; set; }
        private string[] Medicine { get; set; }
        private int Duration { get; set; }

<<<<<<< HEAD
        public Service(int id, string name, float price, string[] medicine, int duration)
=======

        public Service (int id, string name, float price, string[] medicine, int duration)
>>>>>>> master
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Medicine = medicine;
            this.Duration = duration;
        }

        public void AddVeterinary ()
        {
            ;
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
            string text;

            text = "Serviço: " + this.Name + "\n" + "Preço: " + this.Price + "\n" + "Duração: " + this.Duration + "\n" + "Medicamentos: \n";

            int medicineLength = this.Medicine.Length;

            for (int i = 0; i < medicineLength; i++)
            {
                text += "   " + this.Medicine[i] + "\n";
            }

            return text;
        }
    }
}
