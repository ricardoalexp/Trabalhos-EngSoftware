using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gestão_de_Clínica_Veterinária.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_Clínica_Veterinária.Classes.Tests
{
    [TestClass()]
    public class CustomDateTimeTests
    {
        [TestMethod()]
        public void AppointmentDateValidateTest() //DONE
        {
            string validTestDate = "12 05 2021";
            string notValidTestDate = "12 05 2019";

            bool result = CustomDateTime.AppointmentDateValidate(validTestDate);
            Assert.IsTrue(result);

            result = CustomDateTime.AppointmentDateValidate(notValidTestDate);
            Assert.IsFalse(result);            
        }

        [TestMethod()]
        public void CheckDateTimeFormatTest() //DONE
        {
            string validTestDate = "2013 05 30";
            string notvalidTestDate = "1500 08 32";

            bool result = CustomDateTime.CheckDateTimeFormat(validTestDate);
            Assert.IsTrue(result);

            result = CustomDateTime.CheckDateTimeFormat(notvalidTestDate);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void CurrentDateTest() //DONE
        {
            string validTestDate = DateTime.UtcNow.ToString("dd-MM-yyyy");
            string result = CustomDateTime.CurrentDate();

            Assert.AreEqual(result, validTestDate);
        }

        [TestMethod()]
        public void FormatDateTest() //DONE
        {
            var validTestDate = "12 07 2021";
            var resultValid = CustomDateTime.FormatDate(validTestDate);
            var expectedValid = "12-07-2021";
            Assert.AreEqual(resultValid, expectedValid);


            var notValidTestDate = "12sas07sx2021";
            var resultNotValid = "";
            bool threwException = false;

            try{ resultNotValid  = CustomDateTime.FormatDate(notValidTestDate); }
            catch{ threwException = true; }

            Assert.IsTrue(threwException);




        }

        [TestMethod()]
        public void MinutesDurationFormatTest() //DONE
        {
            var valid = 90;
            var resultValid = CustomDateTime.MinutesDurationFormat(valid);
            var expectedValid = "01:30";
            Assert.AreEqual(resultValid, expectedValid);

            var notValid = 200;
            var resultNotValid = CustomDateTime.MinutesDurationFormat(notValid);
            var expectedNotValid = "03:30";
            Assert.AreNotEqual(resultNotValid, expectedNotValid);
        }

        [TestMethod()]
        public void GetAppointmentEndTimeTest() //DONE
        {
            var validInicio = "14:00"; var validDuracao =  90;
            var expectedValid = "15:30";
            var resultValid = CustomDateTime.GetAppointmentEndTime(validInicio, validDuracao);

            Assert.AreEqual(resultValid, expectedValid);


            var expectedNotValid = "14:30";
            var resultNotValid = CustomDateTime.GetAppointmentEndTime(validInicio, validDuracao);

            Assert.AreNotEqual(resultNotValid, expectedNotValid);
        }

        [TestMethod()]
        public void StringTimeFormatTest() //DONE
        {
            int[] validTimes = { 2359, 0359, 0059, 0009, 0000 };
            string[] expectedvalidTimes = { "23:59", "03:59", "00:59", "00:09", "00:00" };
            for (int i = 0; i<validTimes.Length; i++)
            {
                var resultValid = CustomDateTime.StringTimeFormat(validTimes[i]);
                Assert.AreEqual(resultValid, expectedvalidTimes[i]);
            }


            int[] notValidTimes = { 2478,  };
            string[] expectedNotvalidTimes = { "24:78", "03:23", "00:59", "00:09", "00:00" };
            for (int i = 0; i < notValidTimes.Length; i++)
            {
                var resultValid = CustomDateTime.StringTimeFormat(validTimes[i]);
                try { Assert.AreNotEqual(resultValid, expectedNotvalidTimes[i]); }
                catch { Assert.Fail();}
            }
        }

        [TestMethod()]
        public void IntegerTimeFormatTest()
        {
            Assert.Fail();
        }
    }
}