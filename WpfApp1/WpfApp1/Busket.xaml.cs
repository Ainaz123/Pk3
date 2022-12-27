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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Busket.xaml
    /// </summary>
    public partial class Busket : Window
    {
        SalonKrasotyEntities db = new SalonKrasotyEntities();
        public decimal sumPromItog { get; set; }
        public Busket()
        {
            InitializeComponent();
            grdZak.ItemsSource = spisok.zaklist;
            sumPromItog = Convert.ToDecimal(spisok.zaklist.Sum(s => s.Cost));
            var CountSuply = grdZak.SelectedItem as Services;
            SumItog.Text = "" + CountSuply.Cost;
        }

        private void grdZak_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var CountSuply = grdZak.SelectedItem as Services;

            sumPromItog = Convert.ToDecimal(spisok.zaklist.Sum(s => s.Cost));
            SumItog.Text = "" + (sumPromItog * CountSuply.Count);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            var reg = User.Person;
            var zak = grdZak.SelectedItem as Services;
            var newOrder = new Order
            {
                IdClient = reg.IdClients,
                Date = DateTime.Now
            };
            db.Order.Add(newOrder);
            db.SaveChanges();
            var newOrderProduct = new OrderProduct
            {
                OrderId = newOrder.IdOrder,
                IdServices = zak.IdProduct,
                Count = zak.Count,
                Sum = zak.Count * zak.Cost
            };
            db.OrderProduct.Add(newOrderProduct);
            db.SaveChanges();
            MessageBox.Show("Заказ оформлен");
        }
    }
}
