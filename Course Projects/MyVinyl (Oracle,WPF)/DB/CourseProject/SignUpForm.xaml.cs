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
using Oracle.DataAccess.Client;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для SignUpForm.xaml
    /// </summary>
    public partial class SignUpForm : Window
    {
        public SignUpForm()
        {
            InitializeComponent();

            //RadioButton rb1 = new RadioButton { IsChecked = true, GroupName = "Sex", Content = "Male" };
            //rb1.Checked += Checked_1;
            //grid.Children.Add(rb1);

            //RadioButton rb2 = new RadioButton { IsChecked = true, GroupName = "Sex", Content = "Female" };
            //rb2.Checked += Checked_2;
            //grid.Children.Add(rb2);
        }

        private void SignUp_Click(object sender, RoutedEventArgs ee)
        {

            if (UsernameTextBox.Text.Length == 0 || PasswordTextBox.Text.Length == 0 || PhoneNumberTextBox.Text.Length == 0 || EmailTextBox.Text.Length == 0 || calendar1.SelectedDate == null || (RadioMale.IsChecked == false && RadioFemale.IsChecked == false) )
                MessageBox.Show("Заполните все поля");
            else if (PasswordTextBox.Text == ConfirmPasswordTextBox.Text)
            {

                string strForSex;
                if (RadioMale.IsChecked == true)
                {
                    strForSex = "M";
                }
                else
                {
                    strForSex = "F";
                }

                using (Entities1 ent = new Entities1())
                {
                    if (UsernameTextBox.Text == "Admin" && PasswordTextBox.Text == "Admin")
                    {
                        MessageBox.Show("It's Admin");
                    }
                    else
                    {
                        bool userExist = false;
                        decimal userId = 0;

                        foreach (var item in ent.GETUSERS())
                        {
                            if (UsernameTextBox.Text.ToLower() == item.LOGIN_CLIENT && PasswordTextBox.Text.ToLower() == item.PASSWORD_CLIENT)
                            {
                                userExist = true;
                                //userId = item.CLIENT_ID;
                            }
                        }

                        if (!userExist)
                        {
                            ent.REGNEWUSER(null, UsernameTextBox.Text, PasswordTextBox.Text, PhoneNumberTextBox.Text, EmailTextBox.Text, strForSex, calendar1.SelectedDate);

                            //using (var item = new ent.GETUSERS())
                            //{
                            //    int maxColumnValue = item.CLIENT.Max(x => x.columnName);
                            //    return maxColumnValue;
                            //}

                            MessageBox.Show("Регистрация прошла успешно!");
                            SignInForm window = new SignInForm();
                            window.Show();
                            Close();
                        }
                        else
                            MessageBox.Show("Такая учетная запись уже есть!");

                        //var list = from person in ent.CLIENT
                        //           where person.LOGIN_CLIENT == UsernameTextBox.Text && person.PASSWORD_CLIENT == PasswordTextBox.Text
                        //           select person;

                        //if (ent.CLIENT.Where(e => e.LOGIN_CLIENT == UsernameTextBox.Text).Count() == 0)
                        //{


                        //MessageBox.Show(Convert.ToString(calendar1.SelectedDate));

                        //using (Entities9 ctx = new Entities9())
                        //{
                        //    foreach (var items in ctx.GETCLIENTS())
                        //    {
                        //        MessageBox.Show(items.NAME + items.SURNAME + items.AGE + items.EMAIL);
                        //    }
                        //}

                    }
                        
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают!");
            }

        }

        private void Checked_1(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            MessageBox.Show(pressed.Content.ToString());
        }

        private void Checked_2(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            MessageBox.Show(pressed.Content.ToString());
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            SignInForm signinWindow = new SignInForm();
            signinWindow.Show();

            Close();
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendar1.SelectedDate;

            MessageBox.Show(selectedDate.Value.Date.ToShortDateString());
        }


    }

}



 
