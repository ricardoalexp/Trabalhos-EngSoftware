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
        public void CheckDateTimeFormatTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CurrentDateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FormatDateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CurrentTimeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MinutesDurationFormatTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAppointmentEndTimeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void StringTimeFormatTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IntegerTimeFormatTest()
        {
            Assert.Fail();
        }
    }
}