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
    /// Логика взаимодействия для Avtoriz.xaml
    /// </summary>
    public partial class Avtoriz : Window
    {
        SalonKrasotyEntities db = new SalonKrasotyEntities();
        public Avtoriz()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sved = db.Client.FirstOrDefault(s => s.LastName == InputLog.Text && s.Email == InputPas.Text);

            if (sved == null)
            {
                MessageBox.Show("Неправильно ввели логин или пароль");
            }
            else if (sved.Phone == 3)
            {
                Katalog kt = new Katalog();
                kt.Show();
                User.Person = sved;
            }
            else
            {
                MessageBox.Show("Неправильно ввели логин или пароль!");
            }
        }
    }
}
