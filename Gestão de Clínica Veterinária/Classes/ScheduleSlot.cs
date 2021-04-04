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
        public int HoraInicio { get; set; }
        public int HoraFim { get; set; }

        public ScheduleSlot(int id, int serviceId, int animalId, int veterinaryId, string dia, int horaInicio, int horaFim)
        {
            this.Id = id;
            this.ServiceId = serviceId;
            this.AnimalId = animalId;
            this.VeterinaryId = veterinaryId;
            this.Dia = dia;
            this.HoraInicio = horaInicio;
            this.HoraFim = horaFim;
        }

        public ScheduleSlot(int serviceId, int animalId, int veterinaryId, string dia, int horaInicio, int horaFim)
        {
            this.ServiceId = serviceId;
            this.AnimalId = animalId;
            this.VeterinaryId = veterinaryId;
            this.Dia = dia;
            this.HoraInicio = horaInicio;
            this.HoraFim = horaFim;
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
