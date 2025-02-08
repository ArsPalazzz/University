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

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для SignUpForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == null || PasswordTextBox.Text.Length == 0)
                MessageBox.Show("Заполните все поля");
            else
            {
                using (Entities1 ent = new Entities1())
                {
                    if (UsernameTextBox.Text == "Admin" && PasswordTextBox.Text == "Admin")
                    {
                        MessageBox.Show("It's Admin");
                    }
                    else
                    {
                        bool userExist = false;
                        foreach (var item in ent.GETUSERS())
                        {
                            if (UsernameTextBox.Text == item.LOGIN_CLIENT && PasswordTextBox.Text == item.PASSWORD_CLIENT)
                            {
                                Global.USER_ID = item.CLIENT_ID;
                                Global.LOGIN = item.LOGIN_CLIENT;

                                UserWindow userWindow = new UserWindow();
                                userWindow.Show();
                                Close();
                                userExist = true;
                            }
                        }
                        if (userExist == false)
                            MessageBox.Show("Такой учетной записи нет. Зарегистрируйтесь или введите корректные данные!");
                        //var list = from person in ent.CLIENT
                        //           where person.LOGIN_CLIENT == UsernameTextBox.Text && person.PASSWORD_CLIENT == PasswordTextBox.Text
                        //           select person;

                        //if (list.ToList().Count > 0)
                        //{
                        //    UserWindow userWindow = new UserWindow();
                        //    userWindow.Show();
                        //    Close();


                        //}
                        //else
                        //    MessageBox.Show("Такого пользователя не существует");
                    }

                }
                
            }

        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUpForm signupWindow = new SignUpForm();
            signupWindow.Show();

            Close();
        }
    }
}
