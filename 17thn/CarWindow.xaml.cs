using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _17thn
{
    /// <summary>
    /// Логика взаимодействия для CarWindow.xaml
    /// </summary>
    public partial class CarWindow : Window
    {
        sssEntities context;
        public CarWindow()
        {
            InitializeComponent();
            context = new sssEntities();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGridCars.ItemsSource = context.Car.ToList();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentCar = DataGridCars.SelectedItem as Car;
            if (currentCar == null)
            {
                MessageBox.Show("Выберите строку!");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удадить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Car.Remove(currentCar);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewCar = new Car();
            context.Car.Add(NewCar);
            var EditWindow = new AddCarWindow(context, NewCar);
            EditWindow.ShowDialog();
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentCar = BtnEdit.DataContext as Car;
            var EdiWindow = new AddCarWindow(context, currentCar);
            EdiWindow.ShowDialog();
        }
    }
}
