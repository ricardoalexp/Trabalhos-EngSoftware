using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class ScheduleSlot
    {
        public int ServiceId { get; set; }
        public int AnimalId { get; set; }
        public int VeterinaryId { get; set; }
        public string Dia { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFim { get; set; }

        public ScheduleSlot(int serviceId, int animalId, int veterinaryId, string dia, int horaInicio, int horaFim)
        {
            this.ServiceId = serviceId;
            this.AnimalId = animalId;
            this.VeterinaryId = veterinaryId;
            this.Dia = dia;
            this.HoraInicio = horaInicio;
            this.HoraFim = horaFim;
        }
        public static int CompareSlots(ScheduleSlot A, ScheduleSlot B)
        {
            string[] firstDate = A.Dia.Split("-");
            string[] secondDate = B.Dia.Split("-");

            DateTime day1 = new DateTime(int.Parse(firstDate[2]), int.Parse(firstDate[1]), int.Parse(firstDate[0]), A.HoraInicio / 100, A.HoraInicio % 100, 0);
            DateTime day2 = new DateTime(int.Parse(secondDate[2]), int.Parse(secondDate[1]), int.Parse(secondDate[0]), B.HoraInicio / 100, B.HoraInicio % 100, 0);

            if (day1 <= day2) { return -1; }
            else { return 1; }

        }

        public string ToShortString()
        {
            string text = "aID" + this.AnimalId + " - sID" + this.ServiceId + " - vID" + this.VeterinaryId;
            text += " - Dia: " + this.Dia + "ini: " + this.HoraInicio + " - fim: " + this.HoraFim;

            return text;
        }
        public bool Equals(ScheduleSlot scheduleSlot)
        {
            bool resultado = true;
            return resultado;
        }

        public override string ToString()
        {
            string text = "Serviço Id: " + this.ServiceId + "\n";
            text += "Animal Id: " + this.AnimalId + "\n";
            text += "Veterinário Id: " + this.VeterinaryId + "\n";
            text += "Dia: " + this.Dia + "\n";
            text += "Hora de início: " + this.HoraInicio + "\n";
            text += "Hora de fim: " + this.HoraFim + "\n";

            return text;
        }
    }
}
