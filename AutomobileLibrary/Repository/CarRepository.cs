using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        private CarManagement manager = new CarManagement();

        public List<Car> GetCars() => manager.GetCars();
        public Car GetCarById(int id) => manager.GetCarById(id);
        public void AddCar(Car car) => manager.AddCar(car);
        public void UpdateCar(Car car) => manager.UpdateCar(car);
        public void DeleteCar(int id) => manager.DeleteCar(id);
    }
}
