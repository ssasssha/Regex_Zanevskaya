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

namespace Regex_Zanevskaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Classes.Passport> Passports = new List<Classes.Passport>();
        public static MainWindow init;


        public MainWindow()
        {
            InitializeComponent();
            init = this;
        }

        public void LoadPassport()
        {
            lv_passport.Items.Clear();
            foreach (Classes.Passport Passport in Passports)
            {
                lv_passport.Items.Add(Passport);
            }
        }

        private void Add(object sender, RoutedEventArgs e) =>
           new Windows.Add(null).ShowDialog();


        private void Update(object sender, RoutedEventArgs e)
        {
            if (lv_passport.SelectedIndex > -1) { new Windows.Add(lv_passport.SelectedItem as Classes.Passport).ShowDialog(); }
            else { MessageBox.Show("Выберите элемент для изменения"); }
        }



        private void Delete(object sender, RoutedEventArgs e)
        {
            if (lv_passport.SelectedIndex > -1)
            {
                Passports.Remove(lv_passport.SelectedItem as Classes.Passport);
                LoadPassport();
            }
            else { MessageBox.Show("Выберите элемент управления"); }
        }

        public void Search(string Fullname)
        {
            int ss = -1;
            for (int i = 0; i < Passports.Count; i++)
            {
                string Name = Passports[i].Name.ToString().ToLower();
                string Surname = Passports[i].Surname.ToString().ToLower();
                string Patronymic = Passports[i].Patronymic.ToString().ToLower();
                if (Name.Contains(Fullname) || Surname.Contains(Fullname) || Patronymic.Contains(Fullname))
                {
                    lv_passport.Items.Add(Passports[i]);
                }
            }
        }

        private void SearchFIO_KeyDown(object sender, KeyEventArgs e)
        {
            if (SearchFIO.Text == "" && e.Key == Key.Enter)
            {
                lv_passport.Items.Clear();
                LoadPassport();
                return;
            }
            string search = SearchFIO.Text.ToLower();
            lv_passport.Items.Clear();
            if (e.Key == Key.Enter)
                Search(search);

        }
    }
}
