using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class ScheduleSlot
    {
        public int Id { get; }
        public int ServiceId { get; set; }
        public int AnimalId { get; set; }
        public int VeterinaryId { get; set; }
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }

        public ScheduleSlot(int id, int serviceId, int animalId, int veterinaryId, string dia, string horaInicio, string horaFim)
        {
            this.Id = id;
            this.ServiceId = serviceId;
            this.AnimalId = animalId;
            this.VeterinaryId = veterinaryId;
            this.Dia = dia;
            this.HoraInicio = horaInicio;
            this.HoraFim = horaFim;
        }

        public ScheduleSlot(int id, int veterinaryId, string dia, string horaInicio, string horaFim)
        {
            this.Id = id;
            this.ServiceId = 0;
            this.AnimalId = 0;
            this.VeterinaryId = veterinaryId;
            this.Dia = dia;
            this.HoraInicio = horaInicio;
            this.HoraFim = horaFim;
        }

        public void AddAnimalId(ScheduleSlot scheduleSlot) //Marcos: Alterei este método. Está certo?? 
        {
            if (scheduleSlot.AnimalId == 0)
            {
                Console.WriteLine("Adicione o Id do animal: \n");
                scheduleSlot.AnimalId = int.Parse(Console.ReadLine());
            }
        }

        public void AddServiceId(ScheduleSlot scheduleSlot) //Marcos: Alterei este método. Está certo?? 
        {
            if (scheduleSlot.ServiceId == 0)
            {
                Console.WriteLine("Adicione o Id do Serviço: \n");
                scheduleSlot.ServiceId = int.Parse(Console.ReadLine());
            }
        }

        public bool Equals(ScheduleSlot scheduleSlot)
        {
            bool resultado;

            if (scheduleSlot == null) { resultado = false; }
            else { resultado = Id.Equals(scheduleSlot.Id) ? true : false; }

            return resultado;
        }

        public override string ToString()
        {
            string text = "Id: " + this.Id + "\n";
            text += "Serviço Id: " + this.ServiceId + "\n";
            text += "Animal Id: " + this.AnimalId + "\n";
            text += "Veterinário Id: " + this.VeterinaryId + "\n";
            text += "Dia: " + this.Dia + "\n";
            text += "Hora de início: " + this.HoraInicio + "\n";
            text += "Hora de fim: " + this.HoraFim + "\n";

            return text;
        }
    }
}
