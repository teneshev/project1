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
    /// Логика взаимодействия для AddRentalWindow.xaml
    /// </summary>
    public partial class AddRentalWindow : Window
    {
        sssEntities context;
        public AddRentalWindow(sssEntities context, Rental rental)
        {
            InitializeComponent();
            this.context = context;
            CmbClient.ItemsSource = context.Client.ToList();
            CmbCarModel.ItemsSource = context.CarModel.ToList();
            this.DataContext = rental;
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }
    }
}
