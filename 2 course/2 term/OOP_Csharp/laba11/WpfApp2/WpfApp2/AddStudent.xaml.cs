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
using WpfApp2.Models;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        public void AddNewItem(object sender, RoutedEventArgs e)
        {
            bool IsHere = false;
            int i;
            if (txtBlck1 != null && txtBlck2 != null && txtBlck3 != null)
            {
                if (int.TryParse(txtBlck3.Text, out i))
                {
                    if (Convert.ToInt32(txtBlck3.Text) >=17 && Convert.ToInt32(txtBlck3.Text) <= 60)
                    {
                        using (CourseContext db = new CourseContext())
                        {
                            foreach (var item in db.Student)
                            {
                                if (item.Name == txtBlck1.Text && item.Surname == txtBlck2.Text)
                                {
                                    IsHere = true;
                                }
                            }
                            if (!IsHere)
                            {
                                using (var transaction = db.Database.BeginTransaction())
                                {
                                    Student disc = new Student
                                    {
                                        Name = txtBlck1.Text,
                                        Surname = txtBlck2.Text,
                                        Age = Convert.ToInt32(txtBlck3.Text)
                                    };
                                    db.Student.Add(disc);
                                    db.SaveChanges();
                                    transaction.Commit();
                                    MessageBox.Show("Student has been added successfully!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("This Student is already existing!");
                                IsHere = false;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please, Type 100 > Age > 0!");
                    }
                }
                else
                {
                    MessageBox.Show("Type Age type of int!");
                }
                
            }
            else
            {
                MessageBox.Show("Please, Type all info!");
            }
        }
    }
}
