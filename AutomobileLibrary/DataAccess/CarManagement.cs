using System.Collections.Generic;
using System.Linq;
using AutomobileLibrary.DataAccess;

public class CarManagement
{
    private MyStockContext context = new MyStockContext();

    public List<Car> GetCars() => context.Cars.ToList();

    public Car GetCarById(int id) => context.Cars.FirstOrDefault(c => c.CarId == id);

    public void AddCar(Car car)
    {
        context.Cars.Add(car);
        context.SaveChanges();
    }

    public void UpdateCar(Car car)
    {
        context.Cars.Update(car);
        context.SaveChanges();
    }

    public void DeleteCar(int id)
    {
        var car = context.Cars.FirstOrDefault(c => c.CarId == id);
        if (car != null)
        {
            context.Cars.Remove(car);
            context.SaveChanges();
        }
    }
}
