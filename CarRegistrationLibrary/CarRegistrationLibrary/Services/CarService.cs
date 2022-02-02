﻿using CarRegistrationLibrary.Domain;
using CarRegistrationLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegistrationLibrary.Services
{
    public class CarService
    {

        private List<Car> cars;
        private List<HistoryEntry> history;

        public CarService()
        {
            cars = FileUtils.LoadFile("cars.db").Select(line => Car.FromDbLine(line)).ToList();
            history = FileUtils.LoadFile("history.db").Select(line => HistoryEntry.FromDbLine(line)).ToList();
        }

        public List<(Car, List<HistoryEntry>)> GetAllCarsWithHistory() {
            return cars.Select(car =>
                (car, history.Where(entry => entry.Vin == car.Vin).ToList())
            ).ToList();
        }

        public void AddNewCar(Car car, string ownerName)
        {
            var deleted = cars.RemoveAll(_car => _car.Vin.Equals(car.Vin));
            cars.Add(car);

            if (deleted == 0)
            {
                history.Add(new HistoryEntry(car.Vin, ownerName, 0));
            }
            Flush();
        }

        public void AddHistoryEntry(HistoryEntry entry)
        {
            history.Add(entry);
            Flush();
        }

        public List<HistoryEntry> GetHistoryForVin(string vin)
        {
            return history.Where(entry => entry.Vin == vin).ToList();
        }

        public Car? GetCarForVin(string vin)
        {
            try
            {
                return cars.Where(entry => entry.Vin == vin).First();
            } catch
            {
                return null;
            }
        }

        public void Clear()
        {
            this.cars.Clear();
            this.history.Clear();
            Flush();
        }

        private void Flush()
        {
            FileUtils.SaveToFile("cars.db", cars.Select(car => car.ToDbLine()));
            FileUtils.SaveToFile("history.db", history.Select(entry => entry.ToDbLine()));
        }
    }
}
