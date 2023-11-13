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
            string img = @"img/Паспорт.jpg";
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
            if (string.IsNullOrEmpty(DateOfIssued.Text) || !Classes.Common.CheckRegex.Match("^([1-9]|0[1-9]|[12][0-9]|3[01])\\.([1-9]|0[1-9]|1[012])\\.\\d{4}$", DateOfIssued.Text))
            {
                MessageBox.Show("Неправильно указана дата выдачи");
                return;
            }
            if (string.IsNullOrEmpty(DateOfBirth.Text) || !Classes.Common.CheckRegex.Match("^([1-9]|0[1-9]|[12][0-9]|3[01])\\.([1-9]|0[1-9]|1[012])\\.\\d{4}$", DateOfBirth.Text))
            {
                MessageBox.Show("Неправильно указана дата рождения");
                return;
            }
            if (string.IsNullOrEmpty(DepartmentCode.Text) || !Classes.Common.CheckRegex.Match("[0-9]{3}\\-[0-9]{3}", DepartmentCode.Text))
            {
                MessageBox.Show("Неправильно указан код департамента");
                return;
            }
            if (string.IsNullOrEmpty(SeriesAndNumber.Text) || !Classes.Common.CheckRegex.Match("[0-9]{10}", SeriesAndNumber.Text))
            {
                MessageBox.Show("Неправильно указана серия и номер");
                return;
            }
            if (string.IsNullOrEmpty(Issued.Text) || !Classes.Common.CheckRegex.Match("\\w+[а-я А-я]", Issued.Text))
            {
                MessageBox.Show("Неправильно указан выдаватель");
                return;

            }
            if (string.IsNullOrEmpty(PlaceOfBirth.Text) || !Classes.Common.CheckRegex.Match("[гГ]\\.\\w+", PlaceOfBirth.Text))
            {
                MessageBox.Show("Неправильно Указан место рождения");
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
            EditPassports.Image = @"img/Паспорт.jpg";
            MainWindow.init.LoadPassport();
            this.Close();
        }
    }
}
