using AutomobileLibrary.DataAccess;
using AutomobileLibrary.DataAccess.AutomobileLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public Car GetCarByID(int carID) => CarManagement.Instance.GetCarByID(carID);

        public IEnumerable<Car> GetCarsList() => CarManagement.Instance.GetCarsList();

        public void InsertCar(Car car) => CarManagement.Instance.AddNew(car);

        public void DeleteCar(int carID)
        {
            var car = CarManagement.Instance.GetCarByID(carID);
            if (car != null)
            {
                CarManagement.Instance.Remove(car);
            }
        }

        public void UpdateCar(Car car) => CarManagement.Instance.UpdateCar(car);
    }
}
