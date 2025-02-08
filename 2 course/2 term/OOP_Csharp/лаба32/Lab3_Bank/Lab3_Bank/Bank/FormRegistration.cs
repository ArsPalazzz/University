using System;
using System.Windows.Forms;

namespace Bank
{
    public partial class FormRegistration : Form
    {
        public Owner owner;
        public Account account;
        public FormRegistration(Owner owner, Account account)
        {
            InitializeComponent();
            this.owner = owner;
            this.account = account;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fio_label.Text = owner.FullName;
            num_label.Text = owner.Account.Number.ToString();
            dateReg_label.Text = owner.Account.OpeningDate.ToString();
            balance_label.Text = $"{owner.Account.Balance} BYN";
            contrType_label.Text = $"{owner.Account.ContributionType}";
        }
    }
}
