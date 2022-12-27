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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        SalonKrasotyEntities db = new SalonKrasotyEntities();
        public EditWindow(Services persons)
        {
            Id = persons.IdProduct;
            InitializeComponent();
            NameText.Text = persons.NameProd;
            SuplyerText.Text = persons.Suplyer;
            PriceText.Text = persons.Price;
        }

        public int Id;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var br = db.Services.First(s => s.IdProduct == Id);
            br.NameProd = NameText.Text;
            br.Suplyer = SuplyerText.Text;
            br.Price = PriceText.Text;

            db.SaveChanges();
        }
    }
}
