using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using WpfApp2.ef;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Dictionary<int, int> Bag = new Dictionary<int, int>();
        public MainWindow()
        {
           
            InitializeComponent();
            
            beauty db = new beauty();
            Manufacturer manufacturer = new Manufacturer();
            Product product = new Product();
          
            dg.ItemsSource = db.Product.ToList();
            
           
            
        }
        public void MainFrameLoad(object sender, EventArgs e) { 
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           Product product = dg.SelectedItem as Product;
            if(!Bag.Keys.Contains(product.ID)) Bag.Add(product.ID, 1);
            else Bag[product.ID] += 1;
            MessageBox.Show("Товар успешно добавлен");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Bagwindow bagwindow = new Bagwindow(Bag);
            bagwindow.Show();
        }
    }
}
