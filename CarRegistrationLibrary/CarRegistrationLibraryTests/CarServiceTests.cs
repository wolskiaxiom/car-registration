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

        [Test]
        public void ChangeCarNameTest()
        {
            service.AddNewCar(new Domain.Car("vin5", RandomString()), RandomString());

            service.ChangeCarName("vin5", "New Name");

            var name = service.GetAllCarsWithHistory().Find(car => car.Item1.Vin == "vin5").Item1.Name;
            Assert.AreEqual("New Name", name);
        }

        [Test]
        public void ReplaceHistoryTest()
        {
            service.AddNewCar(new Domain.Car("vin6", RandomString()), RandomString());

            var middleEntry = new Domain.HistoryEntry("vin6", "Owner", 15);
            service.AddHistoryEntry(middleEntry);
            service.AddHistoryEntry(new Domain.HistoryEntry("vin6", "Owner", 150));

            service.ReplaceHistoryEntry(middleEntry, new Domain.HistoryEntry("vin6", "Owner", 50));

            var result = service.GetHistoryForVin("vin6");
            Assert.AreEqual(0, result[0].Mileage);
            Assert.AreEqual(50, result[1].Mileage);
            Assert.AreEqual(150, result[2].Mileage);
        }

        private string RandomString()
        {
            return Guid.NewGuid().ToString("n").Substring(0, 8);
        }
    }
}