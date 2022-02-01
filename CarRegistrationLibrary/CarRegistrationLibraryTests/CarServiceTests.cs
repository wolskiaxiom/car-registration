using NUnit.Framework;
using CarRegistrationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRegistrationLibrary.Services;

namespace CarRegistrationLibrary.Tests
{
    [TestFixture]
    public class CarServiceTests
    {

        private CarService service;

        [SetUp]
        public void SetUp()
        {
            service = new CarService();
        }

        [TearDown]
        public void TearDown()
        {
            service.Clear();
        }

        [Test]
        public void AddNewCarTest()
        {
            var vin = RandomString();
            var userName = RandomString();
            service.AddNewCar(new Domain.Car(vin, RandomString()), userName);

            var history = service.GetHistoryForVin(vin);
            Assert.AreEqual(history.Count, 1);
            Assert.AreEqual(history[0].OwnerName, userName);
        }

        [Test]
        public void AddTwoCarsAndGetAllHistoryTest()
        {
            service.AddNewCar(new Domain.Car("vin1", RandomString()), RandomString());
            service.AddNewCar(new Domain.Car("vin2", RandomString()), RandomString());


            var wholeHistory = service.GetAllCarsWithHistory();
            Console.WriteLine("AAAAAAA:");
            Console.WriteLine(wholeHistory[0].Item1.Vin);
        
            Assert.AreEqual(2, wholeHistory.Count);
            Assert.AreEqual(1, wholeHistory[0].Item2.Count);
            Assert.AreEqual(1, wholeHistory[1].Item2.Count);
        }

        private string RandomString()
        {
            return Guid.NewGuid().ToString("n").Substring(0, 8);
        }
    }
}