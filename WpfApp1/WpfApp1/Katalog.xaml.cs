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
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Katalog.xaml
    /// </summary>
    public static class spisok
    {
        public static List<Services> zaklist = new List<Services>();
    }
    public partial class Katalog : Window
    {
        SalonKrasotyEntities db = new SalonKrasotyEntities();
        public Katalog()
        {
            InitializeComponent();
            Lv.ItemsSource = db.Services.ToList();
            //Loaded += ImportImags;
        }

        public void ImportImags(object sender, RoutedEventArgs e)
        {
            var import = Directory.GetFiles(@"C:\Users\Айназ\Desktop\Товары салона красоты");

            foreach(var ser in db.Services)
            {


                    ser.Picture = File.ReadAllBytes(import.FirstOrDefault(s => s.Contains(ser.NamePhoto)));
            }
            db.SaveChanges();
        }

        private void look()
        {
            var servic = db.Services.ToList();

            servic = servic.Where(s => s.NameProd.StartsWith(Find.Text)).ToList();

            switch (Sort.SelectedIndex)
            {
                case 0:
                    {
                        servic = servic.OrderByDescending(s => s.Price).ToList();
                    }
                    break;
                case 1:
                    {
                        servic = servic.OrderBy(s => s.Price).ToList();
                    }
                    break;
            }

            Lv.ItemsSource = servic;
        }

        private void Find_TextChanged(object sender, TextChangedEventArgs e)
        {
            look();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow aw = new AddWindow();
            aw.Show();
            this.Close();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            db.Services.Attach(Lv.SelectedItem as Services);
            db.Services.Remove(Lv.SelectedItem as Services);
            db.SaveChanges();
            Lv.ItemsSource = db.Services.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var persons = Lv.SelectedItem as Services;

            var ed = new EditWindow(persons);
            ed.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var tr = Lv.SelectedItem as Services;
            tr.Count = 1;
            spisok.zaklist.Add(tr);

            Busket bs = new Busket();
            bs.Show();
        }
    }
}
