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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Window
    {
        public ProfilePage()
        {
            InitializeComponent();
        }


        public void ProfilePage_Loaded(object sender, RoutedEventArgs e)
        {
            using (Entities1 ent = new Entities1())
            {
                foreach (var item in ent.GETUSERINFO())
                {
                    if (Global.USER_ID == item.CLIENT_ID)
                    {
                        profileLogin.Text = item.LOGIN_CLIENT;
                        profilePhone.Text = item.PHONE_NUMBER;
                        profileEmail.Text = item.EMAIL;
                        profileSex.Text = item.SEX;
                        profileDate.Text = item.DATE_OF_BIRTH.ToString();
                    }
                }
            }
        }
    }
}
