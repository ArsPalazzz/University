using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Lab45.Vinyl;

namespace Lab45
{
    /// <summary>
    /// Логика взаимодействия для FilterItems.xaml
    /// </summary>
    public partial class FilterItems : Window
    {
        BindingList<Record> FilteredRecordList = new BindingList<Record>();
        ListBox FilteredRecord = new ListBox();
        int fromCost = 0, toCost = 0;
        int fromYear = 0, toYear = 0;
        string chosenGenre;


        public FilterItems(BindingList<Record> RecordList, ListBox Records)
        {
            InitializeComponent();

            FilteredRecordList = RecordList;
            FilteredRecord = Records;
        }

        public void FilterList(object sender, RoutedEventArgs e)
        {
            if ((bool)radiobtnCost.IsChecked)
            {
                if (costFrom.Text != "" && costTo.Text != "")
                {
                    int i;
                    if (int.TryParse(costFrom.Text, out i) && int.TryParse(costTo.Text, out i))
                    {
                        fromCost = Convert.ToInt32(costFrom.Text);
                        toCost = Convert.ToInt32(costTo.Text);

                        
                        var SortedList = from record in FilteredRecordList
                                         where record.Cost >= fromCost && record.Cost <= toCost
                                         select record;

                        FilteredRecord.ItemsSource = SortedList;
                    }
                    else
                    {
                        costFrom.Text = "";
                        costTo.Text = "";
                        MessageBox.Show("Please enter a valid cost interval");
                    }
                }
                else
                {
                    costFrom.Text = "";
                    costTo.Text = "";

                    MessageBox.Show("Enter 'from' and 'to' cost interval");
                }
            }

            if ((bool)radiobtnGenre.IsChecked)
            {
                if ((bool)genre1.IsChecked)
                    chosenGenre = "Pop";
                if ((bool)genre2.IsChecked)
                    chosenGenre = "Rock";
                if ((bool)genre3.IsChecked)
                    chosenGenre = "Alternative rock";
                if ((bool)genre4.IsChecked)
                    chosenGenre = "Hip-hop";
                if ((bool)genre5.IsChecked)
                    chosenGenre = "Comedy-rock";
                if ((bool)genre6.IsChecked)
                    chosenGenre = "Horror-punk";
                if ((bool)genre7.IsChecked)
                    chosenGenre = "Russian bard";

                var SortedList2 = from record in FilteredRecordList
                                  where record.Genre == chosenGenre
                                  select record;

                FilteredRecord.ItemsSource = SortedList2;

            }

            if ((bool)radiobtnYear.IsChecked)
            {
                if (yearFrom.Text != "" && yearTo.Text != "")
                {
                    int i;
                    if (int.TryParse(yearFrom.Text, out i) && int.TryParse(yearTo.Text, out i))
                    {
                        fromYear = Convert.ToInt32(yearFrom.Text);
                        toYear = Convert.ToInt32(yearTo.Text);


                        var SortedList3 = from record in FilteredRecordList
                                         where Convert.ToInt32(record.Year) >= fromYear && Convert.ToInt32(record.Year) <= toYear
                                          select record;

                        FilteredRecord.ItemsSource = SortedList3;
                    }
                    else
                    {
                        yearFrom.Text = "";
                        yearTo.Text = "";
                        MessageBox.Show("Please enter a valid year interval");
                    }
                }
                else
                {
                    yearFrom.Text = "";
                    yearTo.Text = "";

                    MessageBox.Show("Enter 'from' and 'to' year interval");
                }

              
            }
        }

        public void ResetFilterList(object sender, RoutedEventArgs e)
        {
            FilteredRecord.ItemsSource = FilteredRecordList;
        }
    }
}
