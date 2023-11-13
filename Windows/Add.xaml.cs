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

namespace Regex_Zanevskaya.Windows
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Classes.Passport EditPassports;
        /// <summary>
        /// <param name="EditPassports">Паспорт для изменения</param>
        /// </summary>
        public Add(Classes.Passport EditPassports)
        {
            InitializeComponent();
            if (EditPassports != null)
            {
                Name.Text = EditPassports.Name;
                Surname.Text = EditPassports.Surname;
                Patronymic.Text = EditPassports.Patronymic;
                Issued.Text = EditPassports.Issued;
                DateOfIssued.Text = EditPassports.DateOfIssued;
                DepartmentCode.Text = EditPassports.DepartmentCode; // [0-9]{3}\\-[0-9]{3}
                SeriesAndNumber.Text = EditPassports.SeriesAndNumber; // [0-9]{10}
                DateOfBirth.Text = EditPassports.DateOfBirth;
                PlaceOfBirth.Text = EditPassports.PlaceOfBirth; // g.//w+

                this.EditPassports = EditPassports;
                BtnAdd.Content = "Изменить";
            }
        }

        private void AddPassport(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-я]*$", Name.Text))
            {
                MessageBox.Show("Неправильно указано имя пользователя");
                return;
            }
            if (string.IsNullOrEmpty(Surname.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-я]*$", Surname.Text))
            {
                MessageBox.Show("Неправильно указано фамилия пользователя");
                return;
            }
            if (string.IsNullOrEmpty(Patronymic.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-я]*$", Patronymic.Text))
            {
                MessageBox.Show("Неправильно указано отчество пользователя");
                return;
            }

            if (EditPassports == null)
            {
                EditPassports = new Classes.Passport();
                MainWindow.init.Passports.Add(EditPassports);
            }
            EditPassports.Name = Name.Text;
            EditPassports.Surname = Surname.Text;
            EditPassports.Patronymic = Patronymic.Text;
            EditPassports.Issued = Issued.Text;
            EditPassports.DateOfIssued = DateOfIssued.Text;
            EditPassports.DepartmentCode = DepartmentCode.Text;
            EditPassports.SeriesAndNumber = SeriesAndNumber.Text;
            EditPassports.DateOfBirth = DateOfBirth.Text;
            EditPassports.PlaceOfBirth = PlaceOfBirth.Text;

            MainWindow.init.LoadPassport();
            this.Close();
        }
    }
}
