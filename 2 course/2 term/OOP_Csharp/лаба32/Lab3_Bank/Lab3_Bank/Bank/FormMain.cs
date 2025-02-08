using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Bank
{
    public partial class FormMain : Form
    {
        private const string path = @"File.json";
        private Account account;
        private Owner owner;
        Timer timer;
        public List<Owner> OwnerList { get; set; }
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        public string lastAction;
        public FormMain()
        {
            InitializeComponent();
            OwnerList = new List<Owner>();
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            StatusStrip.Items.Add(infoLabel);
            StatusStrip.Items.Add(dateLabel);
            StatusStrip.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }

        Stack<string> undoActionName = new Stack<string>();
        Stack<string> redoActionName = new Stack<string>();

        Stack<string> undoActionNumber = new Stack<string>();
        Stack<string> redoActionNumber = new Stack<string>();

        Stack<string> undoActionPassport = new Stack<string>();
        Stack<string> redoActionPassport = new Stack<string>();

        #region Buttons region

        private void toFile_button_Click(object sender, EventArgs e)
        {
            MyValidator validator = new MyValidator(fullName_textBox.Text, passport_textBox.Text, number_textBox.Text, contribType_comboBox.Text);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(validator);
            if (!Validator.TryValidateObject(validator, context, results, true))
            {
                string err = String.Empty;
                foreach (var error in results)
                {
                    err += error.ErrorMessage + "\n";
                }
                MessageBox.Show(err);
            }
            else
            {
                try
                {
                    JsonSerializator.ToJson(OwnerList, path);
                    MessageBox.Show("Данные записаны в файл");
                }
                catch (Exception)
                {

                    MessageBox.Show("Не удалось сериализовать");
                }
                lastAction = "Запись новых данных в файл";
            }
        }

        private void fromFile_button_Click(object sender, EventArgs e)
        {
            OutputBox.Text = "";
            OwnerList = JsonSerializator.FromJson(path);
            try
            {
                if (OwnerList == null)
                {
                    throw new Exception();
                }
                    OwnerList = JsonSerializator.FromJson(path);
                    foreach (var owner in OwnerList)
                    {
                        OutputBox.Text += owner.ShowOwnerInfo();
                    }
                
            }
            catch (Exception)
            {

                MessageBox.Show("Не удалось сериализовать объект");
            }
            lastAction = "Выгрузка данных из файла";
        }

        private void reg_button_Click(object sender, EventArgs e)
        {
            MyValidator validator = new MyValidator(fullName_textBox.Text, passport_textBox.Text, number_textBox.Text, contribType_comboBox.Text);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(validator);
            if (!Validator.TryValidateObject(validator, context, results, true))
            {
                string err = String.Empty;
                foreach (var error in results)
                {
                    err += error.ErrorMessage + "\n";
                }
                MessageBox.Show(err);
            }
            else
            {
                account = new Account(number_textBox.Text, opendate_calendar.Value, Int32.Parse(balance_textBox.Text), contribType_comboBox.Text);
                owner = new Owner(account, fullName_textBox.Text, birthday_calendar.Value, passport_textBox.Text, sms_checkBox.Checked, netBank_checkBox.Checked);
                OutputBox.Text += owner.ShowOwnerInfo();
                if (sms_checkBox.Checked || netBank_checkBox.Checked)
                {
                    owner = new SMSServOwner(owner);
                    owner = new NetServOwner(owner);
                }
                else if (sms_checkBox.Checked)
                {
                    owner = new SMSServOwner(owner);
                }
                else if (netBank_checkBox.Checked)
                {
                    owner = new NetServOwner(owner);
                }
                FormRegistration userInfo = new FormRegistration(owner, account);
                OwnerList.Add(owner);
                userInfo.Show();
                lastAction = "Регистрация нового пользователя";
            }
        }
        #endregion

        #region Search Forms showing
        private void SrchNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearchForNumber newForm = new FormSearchForNumber(OwnerList);
            newForm.Show();
        }

        private void SrchFullNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearchForFullName newForm = new FormSearchForFullName(OwnerList);
            newForm.Show();
        }

        private void SrchContribTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearchForContribType newForm = new FormSearchForContribType(OwnerList);
            newForm.Show();
        }

        private void SrchBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearchForBalance newForm = new FormSearchForBalance(OwnerList);
            newForm.Show();
        }
        #endregion

        #region Sorting
        private void SortedComtrTTtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Owner> SortedOwnerList = new List<Owner>();
            var ownerSearchList = OwnerList.OrderBy(x => x.Account.ContributionType);
            if (ownerSearchList.Count() > 0)
            {
                OutputBox.Text = string.Empty;
                foreach (var owner in ownerSearchList)
                {
                    OutputBox.Text += owner.ShowOwnerInfo();
                    SortedOwnerList.Add(owner);
                }
            }
            else
            {
                MessageBox.Show("Зарегистрировавшиеся пользователи не найдены.");
            }
        }
        private void SortedOpenDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Owner> SortedOwnerList = new List<Owner>();
            var ownerSearchList = OwnerList.OrderBy(x => x.Account.OpeningDate);
            if (ownerSearchList.Count() > 0)
            {
                OutputBox.Text = string.Empty;
                foreach (var owner in ownerSearchList)
                {
                    OutputBox.Text += owner.ShowOwnerInfo();
                    SortedOwnerList.Add(owner);
                }
            }
            else
            {
                MessageBox.Show("Зарегистрировавшиеся пользователи не найдены.");
            }
        }
        #endregion

        private void ClearForm_Click(object sender, EventArgs e)
        {
            fullName_textBox.Text = string.Empty;
            number_textBox.Text = string.Empty;
            passport_textBox.Text = string.Empty;
            contribType_comboBox.Text = string.Empty;
            OutputBox.Text = string.Empty;
            sms_checkBox.Checked = false;
            netBank_checkBox.Checked = false;
            fixedProc_radioButton.Checked = false;
            floatProc_radioButton.Checked = false;
            lastAction = "Очищена форма";
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0 \nПалазник Арсений", "О программе");
        }
        private void sum_trackBar_Scroll(object sender, EventArgs e)
        {
            balance_textBox.Text = sum_trackBar.Value.ToString();
        }

        private void number_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            char bs = e.KeyChar;

            if (!Char.IsDigit(number) && !Char.IsControl(bs))
            {
                e.Handled = true;
            }
        }

        private void fullName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar;
            char bs = e.KeyChar;
            char ws = e.KeyChar;

            if (!Char.IsLetter(letter) && !Char.IsControl(bs) && !Char.IsWhiteSpace(ws))
            {
                e.Handled = true;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
            if (OwnerList != null)
            CountOfItemsStatusLabel.Text = "Кол-во объектов: " + OwnerList.Count;
            lastActionStatusLabel.Text = "Последнее действие: " + lastAction;
        }
        //private void passport_label_MouseHover(object sender, EventArgs e)
        //{
        //    help_label.Visible = true;
        //}

        //private void passport_label_MouseLeave(object sender, EventArgs e)
        //{
        //    help_label.Visible = false;
        //}

        #region ToolStrip instruments
        private void HideToolStripButton_Click(object sender, EventArgs e)
        {
            TopToolStrip.Visible = (TopToolStrip.Visible) ? false : true;
            ShowToolStripButton.Visible = (ShowToolStripButton.Visible) ? false : true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TopToolStrip.Visible = true;
            ShowToolStripButton.Visible = false;
        }

        private void msUndo_Click(object sender, EventArgs e)
        {
            if (undoActionName.Count < 1 || undoActionNumber.Count < 1 || undoActionPassport.Count < 1)
            {
                return;
            }

            if (redoActionName.Count == 0 || redoActionNumber.Count == 0 || redoActionPassport.Count == 0 || fullName_textBox.Text != string.Empty || number_textBox.Text != string.Empty || passport_textBox.Text != string.Empty)
            {
                redoActionName.Push(fullName_textBox.Text);
                redoActionNumber.Push(number_textBox.Text);
                redoActionPassport.Push(passport_textBox.Text);
            }

            fullName_textBox.Text = undoActionName.Pop();
            string numberString = number_textBox.Text;
            string passportString = passport_textBox.Text;

            number_textBox.Text = undoActionNumber.Pop();
            number_textBox.Text = numberString.Remove(numberString.Length - 1);

            passport_textBox.Text = undoActionPassport.Pop();
            passport_textBox.Text = passportString.Remove(passportString.Length - 1);
        }

        private void fullName_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            undoActionName.Push(fullName_textBox.Text);
            undoActionNumber.Push(number_textBox.Text);
            undoActionPassport.Push(passport_textBox.Text);
        }

        private void msRedo_Click(object sender, EventArgs e)
        {
            if (redoActionName.Count < 1 || redoActionNumber.Count < 1 || redoActionPassport.Count < 1)
            {
                return;
            }

            if (undoActionName.Count == 0 || undoActionNumber.Count == 0 || undoActionPassport.Count == 0 || fullName_textBox.Text != string.Empty || number_textBox.Text != string.Empty || passport_textBox.Text != string.Empty)
            {
                undoActionName.Push(fullName_textBox.Text);
                undoActionNumber.Push(number_textBox.Text);
                undoActionPassport.Push(passport_textBox.Text);
            }

            fullName_textBox.Text = redoActionName.Pop();
            number_textBox.Text = redoActionNumber.Pop();
            passport_textBox.Text = redoActionPassport.Pop();
        }

        private void DelToolStripButton_Click(object sender, EventArgs e)
        {
            if (OwnerList.Count > 0)
            OwnerList.RemoveAt(OwnerList.Count - 1);
            else
                MessageBox.Show("Добавьте владельца");
        }
        #endregion

        private void AddButToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var owner in OwnerList)
            {
                OutputBox.Text += owner.ShowOwnerInfo();
                OutputBox.Text += owner.AdditionalServices();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void addServ_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
