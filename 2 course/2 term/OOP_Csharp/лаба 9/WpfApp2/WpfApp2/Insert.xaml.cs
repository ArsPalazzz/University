using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Insert.xaml
    /// </summary>
    public partial class Insert : Window
    {
        private OpenFileDialog openFileDialog;
        private Uri fileUri;
        private ADDRESS address;
        private PASSPORT passport;
        private PERSON person;
        public Insert()
        {
            InitializeComponent();
        }

        private void imgButton_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == true)
            {
                fileUri = new Uri(openFileDialog.FileName);
                if (fileUri == null)
                {
                    openFileDialog.FileName = "E:\\Универ\\Лабораторные работы\\4 семестр\\ООП\\лаба 8\\lab_8\\lab_8\\img\\agataKristi.jpg";
                    fileUri = new Uri(openFileDialog.FileName);
                }
            }
        }
        private byte[] B64Encode()
        {
            if (fileUri != null)
            {
                byte[] array = Encoding.ASCII.GetBytes(fileUri.ToString());
                return array;
            }
            else
            {
                return null;
            }
        }
        private void AsyncMethod()
        {
            System.Windows.Forms.MessageBox.Show("Data has been updated");
        }

        async private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            if (int.TryParse(ageTextBox.Text, out i) && int.TryParse(houseTextBox.Text, out i) &&
                int.TryParse(flatTextBox.Text, out i) && int.TryParse(numberTextBox.Text, out i))
            {
                if (int.Parse(ageTextBox.Text) > 2 && int.Parse(houseTextBox.Text) > 0 &&
                    int.Parse(flatTextBox.Text) > 0 && int.Parse(numberTextBox.Text) > 0)
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                address = new ADDRESS
                                {
                                    country = countryTextBox.Text,
                                    city = cityTextBox.Text,
                                    street = streetTextBox.Text,
                                    house = int.Parse(houseTextBox.Text),
                                    build = int.Parse(buildTextBox.Text),
                                    flat = int.Parse(flatTextBox.Text)
                                };

                                await Task.Run(() => B64Encode());

                                passport = new PASSPORT
                                {
                                    serial = serialTextBox.Text,
                                    number = int.Parse(numberTextBox.Text),
                                    photo = B64Encode()
                                };                                
                                db.PASSPORT.Add(passport);
                                db.ADDRESS.Add(address);
                                db.SaveChanges();

                                var id_address_db = (from dataAddress in db.ADDRESS
                                                     where dataAddress.country == countryTextBox.Text &&
                                                     dataAddress.city == cityTextBox.Text &&
                                                     dataAddress.street == streetTextBox.Text &&
                                                     dataAddress.house.ToString().Equals(houseTextBox.Text) &&
                                                     dataAddress.build.ToString().Equals(buildTextBox.Text) &&
                                                     dataAddress.flat.ToString().Equals(flatTextBox.Text)
                                                     select dataAddress.id_address).FirstOrDefault<int>();
                                var id_passport_db = (from dataPassport in db.PASSPORT
                                                      where dataPassport.serial == serialTextBox.Text &&
                                                      dataPassport.number.ToString().Equals(numberTextBox.Text)
                                                      select dataPassport.id_passport).FirstOrDefault<int>();

                                person = new PERSON
                                {
                                    first_name = firstNameTextBox.Text,
                                    last_name = lastNameTextBox.Text,
                                    middle_name = middleNameTextBox.Text,
                                    age = int.Parse(ageTextBox.Text),
                                    phone = phoneTextBox.Text,
                                    id_address = id_address_db,
                                    id_passport = id_passport_db,
                                    ADDRESS = address,
                                    PASSPORT = passport
                                };

                                db.PERSON.Add(person);
                                db.SaveChanges();
                                transaction.Commit();

                                Show();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                transaction.Rollback();
                            }
                            Close();
                        }
                    }
                }
            }
            
        }
    }
}
