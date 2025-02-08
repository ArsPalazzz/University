using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        ObservableCollection<DISCIPLINE> _Disciplines;
        public bool IsHere = false;
        public AddItem(ObservableCollection<DISCIPLINE> Disciplines)
        {
            InitializeComponent();
            _Disciplines = Disciplines;
        }

        public void AddNewItem(object sender, RoutedEventArgs e)
        {
            if (txtBlck1 != null && txtBlck2 != null && txtBlck3 != null && txtBlck4 != null)
            {
                try
                {
                    if (Convert.ToInt32(txtBlck2.Text) > 0 && Convert.ToInt32(txtBlck4.Text) > 0)
                    {
                        using (CourseContext db = new CourseContext())
                        {
                            foreach (var item in db.DISCIPLINE)
                            {
                                if (item.Name == txtBlck1.Text)
                                {
                                    IsHere = true;
                                }
                            }
                            if (!IsHere)
                            {
                                using (var transaction = db.Database.BeginTransaction())
                                {
                                    DISCIPLINE disc = new DISCIPLINE
                                    {
                                        Name = txtBlck1.Text,
                                        QuantityHours = Convert.ToInt32(txtBlck2.Text),
                                        Lector = txtBlck3.Text,
                                        Quantity = Convert.ToInt32(txtBlck4.Text)
                                    };
                                    db.DISCIPLINE.Add(disc);
                                    db.SaveChanges();
                                    transaction.Commit();
                                    MessageBox.Show("Discipline has been added successfully!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("This Discipline is already existing!");
                                IsHere = false;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please, Type Hours and Quantity > 0!");
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Please, Type all info!");
            }
        }
    }
}
