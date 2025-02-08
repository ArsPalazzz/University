using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Bank
{
    public partial class FormSearchForBalance : Form
    {
        public FormSearchForBalance()
        {
            InitializeComponent();
        }

        List<Owner> owners;
        private const string path = @"SearchBalance.json";

        public FormSearchForBalance(List<Owner> owners)
        {
            InitializeComponent();
            this.owners = owners;
        }

        private void BalanceSearch_button_Click(object sender, EventArgs e)
        {
            List<Owner> searchedOwners = new List<Owner>();
            var search = owners.FindAll(item => item.Account.Balance == Convert.ToInt32(BalanceSearchTextBox.Text));
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

        private void BalanceSearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            char bs = e.KeyChar;

            if (!Char.IsDigit(number) && !Char.IsControl(bs))
            {
                e.Handled = true;
            }
        }
    }
}
