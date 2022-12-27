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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        SalonKrasotyEntities db = new SalonKrasotyEntities();
        public AddWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newSer = new Services
            {
                NameProd = NameText.Text,
                Suplyer = SuplyerText.Text,
                Price = PriceText.Text
            };
            db.Services.Add(newSer);
            db.SaveChanges();
            MessageBox.Show("Запись добавлена!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Katalog kt = new Katalog();
            kt.Show();
            this.Close();
        }
    }
}
