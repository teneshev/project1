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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _17thn
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        sssEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new sssEntities();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGridRental.ItemsSource = context.Rental.ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewRental = new Rental();
            context.Rental.Add(NewRental);
            var addRentalWindow = new AddRentalWindow(context, NewRental);
            addRentalWindow.ShowDialog();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentRental = DataGridRental.SelectedItem as Rental;
            if (currentRental == null)
            {
                MessageBox.Show("Выберите строку!");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удадить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Rental.Remove(currentRental);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnAddtableData_Click(object sender, RoutedEventArgs e)
        {
            var RentalSelect = new ClientWindow();
            RentalSelect.ShowDialog();
        }

        private void BtnAddtable1Data_Click(object sender, RoutedEventArgs e)
        {
            var RentalSelect = new CarWindow();
            RentalSelect.ShowDialog();
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentRental = BtnEdit.DataContext as Rental;
            var EdiWindow = new AddRentalWindow(context, currentRental);
            EdiWindow.ShowDialog();
        }
    }
}
