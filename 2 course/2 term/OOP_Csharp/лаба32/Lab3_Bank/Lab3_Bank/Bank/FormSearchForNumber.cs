using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Bank
{
    public partial class FormSearchForNumber : Form
    {
        public FormSearchForNumber()
        {
            InitializeComponent();
        }

        List<Owner> owners;
        private const string path = @"SearchNum.json";
        public FormSearchForNumber(List<Owner> owners)
        {     
            InitializeComponent();
            this.owners = owners;
        }
        private void numberSearch_button_Click(object sender, EventArgs e)
        {
            OutputBox.Text = "";
            List<Owner> searchedOwners = new List<Owner>();
            var search = owners.FindAll(item => item.Account.Number.Contains(numberSearchTextBox.Text));
            if (search.Count() > 0)
            {
                searchedOwners.Clear();
                foreach (var owner in search)
                {
                    OutputBox.Text += owner.ShowOwnerInfo();
                    searchedOwners.Add(owner);
                }
            }
            var jsonData = JsonConvert.SerializeObject(searchedOwners);

            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.Write(jsonData);
            }
        }

        private void SearchButtonOneToThreeNumber_Click(object sender, EventArgs e)
        {
            OutputBox.Text = "";
            foreach (var owner in owners)
            {

                
                Regex regex3 = new Regex(@"^(1|2|3)");
                MatchCollection matches = regex3.Matches(owner.Account.Number);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        OutputBox.Text += owner.ShowOwnerInfo();
                }
                else
                {
                    Console.WriteLine("Совпадений не найдено");
                }
            }
        }

        private void numberSearch_label_Click(object sender, EventArgs e)
        {

        }
    }
}
