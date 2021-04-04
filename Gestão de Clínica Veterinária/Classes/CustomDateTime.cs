using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes
{
   
    class CustomDateTime
    {
        private DateTime dateTime;
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

    }

}
