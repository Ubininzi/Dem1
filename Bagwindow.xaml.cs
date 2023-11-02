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
using static System.Net.Mime.MediaTypeNames;
using WpfApp2.ef;

namespace WpfApp2
{
	/// <summary>
	/// Логика взаимодействия для Bagwindow.xaml
	/// </summary>
	public partial class Bagwindow : Window
	{
        static Dictionary<int, int> bag;
        public Bagwindow(Dictionary<int, int> bag1)
		{
			InitializeComponent();
            bag = bag1;
            create_table();


        }
		public void create_table()
		{
            beauty db = new beauty();
            for (int i = 0; i < bag.Count; i++)
                gr.RowDefinitions.Add(new RowDefinition());
            int j = 0;
            foreach (var item in bag)
            {
                TextBlock text1 = new TextBlock();
                text1.TextAlignment = TextAlignment.Center;
                TextBlock text2 = new TextBlock();
                text2.TextAlignment = TextAlignment.Center;
                TextBlock text3 = new TextBlock();
                text3.TextAlignment = TextAlignment.Center;

                text1.Text = db.Product.Where(x => x.ID == item.Key).Select(x => x.Title).First();
                text2.Text = item.Value.ToString();
                text3.Text = (db.Product.Where(x => x.ID == item.Key).Select(x => x.Cost).First() * item.Value).ToString();
                Button button = new Button();
                button.Content = "Удалить товар из корзины";
                button.Click += Button_Click;
                button.Tag = item.Key.ToString();
                Grid.SetColumn(text1, 0);
                Grid.SetRow(text1, j);
                Grid.SetColumn(text2, 1);
                Grid.SetRow(text2, j);
                Grid.SetColumn(text3, 2);
                Grid.SetRow(text3, j);
                Grid.SetColumn(button, 3);
                Grid.SetRow(button, j);
                gr.Children.Add(text1);
                gr.Children.Add(text2);
                gr.Children.Add(text3);
                gr.Children.Add(button);
                j++;
            }
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bag.Remove(Convert.ToInt32(((Button)sender).Tag));
            gr.RowDefinitions.Clear();
            gr.Children.Clear();
            create_table();
        }
    }
}
