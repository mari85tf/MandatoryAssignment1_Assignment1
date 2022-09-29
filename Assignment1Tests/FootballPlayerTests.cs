using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment1.Tests
{
    [TestClass()]
    public class FootballPlayerTests
    {
        private FootballPlayer player = new FootballPlayer() { Id = 1, Name = "John Johnson", Age = 18, ShirtNumber = 18 };
        [TestMethod()]
        public void ValidateNameTest()
        {
            player.ValidateName();

            FootballPlayer shortName = new FootballPlayer() { Id = 1, Name = "J", Age = 18, ShirtNumber = 18 };
            Assert.ThrowsException<ArgumentException>(() => shortName.ValidateName());

            FootballPlayer twoCharName = new FootballPlayer() { Id = 1, Name = "Yu", Age = 18, ShirtNumber = 18 };
            twoCharName.ValidateName();

            FootballPlayer noName = new FootballPlayer() { Id = 1, Age = 18, ShirtNumber = 18 };
            Assert.ThrowsException<ArgumentNullException>(() => noName.ValidateName());
        }

        [TestMethod()]
        public void ValidateAgeTest()
        {
            player.ValidateAge();

            FootballPlayer negativeAge = new FootballPlayer() { Id = 1, Name = "John Johnson", Age = -3, ShirtNumber = 18 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => negativeAge.ValidateAge());

            FootballPlayer oneYearOld = new FootballPlayer() { Id = 1, Name = "John Johnson", Age = 1, ShirtNumber = 18 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => oneYearOld.ValidateAge());

            FootballPlayer twoYearsOld = new FootballPlayer() { Id = 1, Name = "John Johnson", Age = 2, ShirtNumber = 18 };
            twoYearsOld.ValidateAge();
        }

        [TestMethod()]
        public void ValidateShirtNumberTest()
        {
            player.ValidateShirtNumber();

            FootballPlayer negativeNumber = new FootballPlayer() { Id = 1, Name = "John Johnson", Age = 18, ShirtNumber = -18 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => negativeNumber.ValidateShirtNumber());

            FootballPlayer greaterNumber = new FootballPlayer() { Id = 1, Name = "John Johnson", Age = 18, ShirtNumber = 100 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => greaterNumber.ValidateShirtNumber());

            FootballPlayer lowerLimit = new FootballPlayer() { Id = 1, Name = "John Johnson", Age = 18, ShirtNumber = 1 };
            lowerLimit.ValidateShirtNumber();

            FootballPlayer upperLimit = new FootballPlayer() { Id = 1, Name = "John Johnson", Age = 18, ShirtNumber = 99 };
            upperLimit.ValidateShirtNumber();

            FootballPlayer numberZero = new FootballPlayer() { Id = 1, Name = "John Johnson", Age = 18, ShirtNumber = 0 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => numberZero.ValidateShirtNumber());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            string str = player.ToString();
            string expect = player.Id + " " + player.Name + " " + player.Age + " " + player.ShirtNumber;
            Assert.AreEqual(expect,str);
        }
    }
}