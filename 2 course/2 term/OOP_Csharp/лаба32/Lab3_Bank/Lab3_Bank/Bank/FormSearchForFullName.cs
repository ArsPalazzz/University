using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Bank
{
    public partial class FormSearchForFullName : Form
    {
        public FormSearchForFullName()
        {
            InitializeComponent();
        }

        List<Owner> owners;
        private const string path = @"SearchFullName.json";
        public FormSearchForFullName(List<Owner> owners)
        {
            InitializeComponent();
            this.owners = owners;
        }

        private void FNSearch_button_Click(object sender, EventArgs e)
        {
            OutputBox.Text = "";
            List<Owner> searchedOwners = new List<Owner>();
            var search = owners.FindAll(item => item.FullName.Contains(FNSearchTextBox.Text));
            if (search.Count() > 0)
            {
                searchedOwners.Clear();
                foreach (var owner in search)
                {
                    OutputBox.Text += owner.ShowOwnerInfo();
                    searchedOwners.Add(owner);
                }
            }
            var jsonData = JsonConvert.SerializeObject(owners);

            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.Write(jsonData);
            }
        }

        private void numberSearch_label_Click(object sender, EventArgs e)
        {

        }

        //private void SearchButtonEngFullName_Click(object sender, EventArgs e)
        //{
        //    foreach (var owner in owners)
        //    {

        //        Regex regex2 = new Regex(@"[A-Za-z]");
        //        MatchCollection matches = regex2.Matches(owner.FullName);
        //        if (matches.Count > 0)
        //        {
        //            foreach (Match match in matches)
        //                OutputBox.Text += owner.ShowOwnerInfo();
        //        }
        //        else
        //        {
        //            Console.WriteLine("Совпадений не найдено");
        //        }
        //    }
        //}

    }
}
