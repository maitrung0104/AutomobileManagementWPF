using System.Collections.Generic;
using System.Linq;
using AutomobileLibrary.DataAccess;
using AutomobileLibrary.DataAccess.AutomobileLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomobileLibrary.DataAccess
{
    // CarManagement class to manage car-related operations
    // This class provides methods to interact with the database for car entities
    // It uses Entity Framework Core to perform CRUD operations on the Car entity
    // The context is initialized with a connection string to the SQL Server database
    public class CarManagement
    {
        private static CarManagement instance = null;
        private static readonly object instanceLock = new object();

        private MyStockContext context = new MyStockContext();

        // Constructor private để ngăn tạo từ bên ngoài
        private CarManagement() { }

        // Singleton Instance
        public static CarManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Car> GetCarsList()
        {
            List<Car> cars = new List<Car>();
            try
            {
                cars = context.Set<Car>().ToList(); // Fixed to use DbSet<Car>
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cars;
        }

        public Car GetCarByID(int carID)
        {
            Car car = null;
            try
            {
                car = context.Set<Car>().SingleOrDefault(car => car.CarId == carID); // Fixed to use DbSet<Car>
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }

        public void AddNew(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarId);
                if (_car == null)
                {
                    context.Set<Car>().Add(car); // Fixed to use DbSet<Car>
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The car is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCar(Car car)
        {
            try
            {
                Car c = GetCarByID(car.CarId);
                if (c != null)
                {
                    context.Entry<Car>(car).State = EntityState.Modified; // Fixed variable name and DbSet usage
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The car is not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarId);
                if (_car != null)
                {
                    context.Set<Car>().Remove(car); // Fixed to use DbSet<Car>
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The car is not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


