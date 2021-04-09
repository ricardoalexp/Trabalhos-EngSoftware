using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
   
    class CustomDateTime
    {
        private string Date { get; set; }

        public static bool AppointmentDateValidate(string date)
        {
            if (!CheckDateTimeFormat(date)){ return false; }

            DateTime dateTime = DateTime.Parse(date);
            int appointmentDate = int.Parse(dateTime.ToString("yyyyMMdd"));

            dateTime = DateTime.Parse(CurrentDate());
            int currentDate = int.Parse(dateTime.ToString("yyyyMMdd"));

            return appointmentDate >= currentDate ? true : false;
        }

        public static bool CheckDateTimeFormat(string dateTime)
        {
            try
            {
                DateTime dt = DateTime.Parse(dateTime);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string CurrentDate()
        {
            string date = DateTime.UtcNow.ToString("dd-MM-yyyy");
            return date;
        }

        public static string FormatDate(string date)
        {
            DateTime dateTime = DateTime.Parse(date);
            string formattedDate = dateTime.ToString("dd-MM-yyyy");
            return formattedDate;
        }

        public static string CurrentTime()
        {
            string date = DateTime.UtcNow.ToLocalTime().ToString("HH:mm");

            return date;
        }

        public static string MinutesDurationFormat(int minutes)
        {
            DateTime time = DateTime.Parse("00:00");
            time = time.AddMinutes(minutes);

            return time.ToString("HH:mm");
        }

        public static string GetAppointmentEndTime(string inicio, int duracao)
        {
            int init = IntegerTimeFormat(inicio);

            init += (duracao / 60) * 100 + (duracao % 60);

            int minutes = init % 100;

            if(minutes >= 60) { init += 40; }

            return StringTimeFormat(init);
        }

        public static string StringTimeFormat(int time)
        {
            string hora = Convert.ToString(time);
            string horaEditada;
            if (hora.Length.Equals(3))
            {
                horaEditada = "0" + hora[0].ToString() + ":" + hora[1].ToString() + hora[2].ToString();
            }
            else if (hora.Length.Equals(2))
            {
                horaEditada = "00:" + hora[0].ToString() + hora[1].ToString();
            }
            else if (hora.Length.Equals(1))
            {
                horaEditada = "00:0" + hora;
            }
            else if (hora.Length.Equals(0))
            {
                horaEditada = "00:00";
            }
            else
            {
                horaEditada = hora[0].ToString() + hora[1].ToString() + ":" + hora[2].ToString() + hora[3].ToString();
            }

            DateTime stringTime = DateTime.Parse(horaEditada);
            return stringTime.ToString("HH:mm");
        }

        public static int IntegerTimeFormat(string time)
        {
            DateTime intTime = DateTime.Parse(time);
            return int.Parse(intTime.ToString("HHmm"));
        }

    }

}
