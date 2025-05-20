using AutomobileLibrary.DataAccess.AutomobileLibrary.Models;
using AutomobileLibrary.Repository;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomobileWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    

    
        public partial class WindowCarManagement : Window
    {
        ICarRepository carRepository;

        public WindowCarManagement(ICarRepository repository)
        {
            InitializeComponent();
            carRepository = repository;
        }

        //------------------------------------------------------
        private Car GetCarObject()
        {
            Car car = null;
            try
            {
                car = new Car
                {
                    CarId = int.Parse(txtCarId.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = txtManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleasedYear = int.Parse(txtReleasedYear.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get car");
            }
            return car;
        }//end GetCarObject

        //------------------------------------------------------
        public void LoadCarList()
        {
            lvCars.ItemsSource = carRepository.GetCarsList();
        }

        //------------------------------------------------------
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCarList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load car list");
            }
        }

        //------------------------------------------------------
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                carRepository.InsertCar(car);
                LoadCarList();
                MessageBox.Show($"{car.CarName} inserted successfully ", "Insert car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert car");
            }
        }

        //------------------------------------------------------
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                carRepository.UpdateCar(car);
                LoadCarList();
                MessageBox.Show($"{car.CarName} updated successfully ", "Update car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update car");
            }
        }

        //------------------------------------------------------
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int carId = int.Parse(txtCarId.Text); // Extract CarId from the input field
                carRepository.DeleteCar(carId); // Pass the CarId to the DeleteCar method
                LoadCarList();
                MessageBox.Show($"Car with ID {carId} deleted successfully", "Delete car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete car");
            }
        }

        //------------------------------------------------------
        private void btnClose_Click(object sender, RoutedEventArgs e) => Close();
    }//end class
}