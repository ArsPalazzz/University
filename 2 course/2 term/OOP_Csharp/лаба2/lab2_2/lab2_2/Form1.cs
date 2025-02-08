using System.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace laba2
{
    public partial class Form1 : Form
    {
        int koef = 1;
        public Form1()
        {
            InitializeComponent();

            changeTheme.Click += changeThemeClick;
            colorDialog1.FullOpen = true;
            // установка начального цвета для colorDialog
            colorDialog1.Color = this.BackColor;


            changeFont.Click += changeFontClick;
            fontDialog1.ShowColor = true;
            

          
           
            timer1.Tick += timer1_Tick;

            deserializeButton.Click += DeserializeButton;
            
        }

        public string DepositeTypeCheckedState;
        public string SMSCheckedState;
        public string InternetCheckedState;
        public string path = @"D:\Study\ООПиП\лаба2\lab2_2\lab2_2\data.json";
        public string lowList = "abcdefghijklmnoprstuvwxyzйцукенгшщзхъфывапролджэячсмитьбю";

        


        private void FormSend_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkBoxRequire.Checked)
                {
                    throw new Exception("Вы не ознакомились в формой");
                }

                if (Saving_radioButton.Checked)
                    DepositeTypeCheckedState = "Сберегательные";
                if (Accumulative_radioButton.Checked)
                    DepositeTypeCheckedState = "Накопительные ";
                if (Targeted_radioButton.Checked)
                    DepositeTypeCheckedState = "Целевые";


                if (SMSON_radioButton.Checked)
                    SMSCheckedState = "Включено";
                if (SMSOFF_radioButton.Checked)
                    SMSCheckedState = "Выключено";


                if (InternetON_radioButton.Checked)
                    InternetCheckedState = "Включено";
                if (InterneOFF_radioButton.Checked)
                    InternetCheckedState = "Выключено";

               



                if (Balance_TextBox.Text.IndexOfAny(lowList.ToCharArray()) != -1)
                {
                    throw new Exception("Вводить можно только числа");
                }

                if (Convert.ToInt32(Balance_TextBox.Text) < 0)
                {
                    throw new Exception("Число должно быть неотрицательным");
                }

                if (DepositeTypeCheckedState != null && SMSCheckedState != null && InternetCheckedState != null &&
                    Number_TextBox.Text != "" && Owner_TextBox.Text != "" && Balance_TextBox.Text != "" &&
                    SecondName_textBox.Text != "" && Name_textBox.Text != "" && Surname_textBox.Text != "" && 
                    Passpord_textBox.Text != "" && Owner_TextBox.Text == SecondName_textBox.Text)
                {

                    Owner owner = new Owner(SecondName_textBox.Text, Name_textBox.Text, Surname_textBox.Text,
                        Birthday_textBox.Value, Passpord_textBox.Text);


                    Bank bank = new Bank(Convert.ToInt32(Number_TextBox.Text), Convert.ToInt32(Balance_TextBox.Text),
                        Opening_TextBox.Value, Owner_TextBox.Text, DepositeTypeCheckedState, SMSCheckedState, InternetCheckedState, owner);

                    

                    NumberOutput_label.Text = "Номер счета:  " + Convert.ToString(bank.Number);
                    BalanceOutput_label.Text = "Баланс:  " + Convert.ToString(bank.Balance);
                    OpeningOutput_label.Text = "Дата открытия:  " + Convert.ToString(bank.OpeningDate);
                    OwnerOutput_label.Text = "Владелец:  " + Convert.ToString(bank.Owner);
                    DepositeTypeOutput_label.Text = "Тип вклада:  " + Convert.ToString(bank.DepostiteType);
                    SMSOutput_label.Text = "СМС оповещения:  " + Convert.ToString(bank.SMS);
                    InternetOutput_label.Text = "Интернет-банкинга:  " + Convert.ToString(bank.Internet);




                    SecondNameOutput_label.Text = "Фамилия:  " + Convert.ToString(bank.UserOwner.secondName);
                    NameOutput_label.Text = "Имя:  " + Convert.ToString(bank.UserOwner.name);
                    SurnameOutput_label.Text = "Отчество:  " + Convert.ToString(bank.UserOwner.surname);
                    BirthdayOutput_label.Text = "День рождения:  " + Convert.ToString(bank.UserOwner.bitrhday);
                    PasspordOutput_label.Text = "Паспорт:  " + Convert.ToString(bank.UserOwner.passpord);

                    var jsonFormatterBank = new DataContractJsonSerializer(typeof(Bank)); //создаём объект DataContractJsonSerializer

                    using (var file = new FileStream("bank.json", FileMode.OpenOrCreate)) // получаем поток, куда будем записывать сериализованный объект
                    {
                        jsonFormatterBank.WriteObject(file, bank);
                    }

                    var jsonFormatterOwner = new DataContractJsonSerializer(typeof(Owner)); //создаём объект DataContractJsonSerializer

                    using (var file = new FileStream("owner.json", FileMode.OpenOrCreate)) // получаем поток, куда будем записывать сериализованный объект
                    {
                        jsonFormatterOwner.WriteObject(file, owner);
                    }

                    MessageBox.Show("Данные сериализованы");





                    if (timer1.Enabled == true)
                    {
                        timer1.Stop();
                    }
                    else
                    {
                        timer1.Start();
                    }

                }

               
                else if (BalanceOutput_label.Text.IndexOfAny(lowList.ToCharArray()) != -1)
                {
                    throw new Exception("вводить можно только числа!");
                }

                else if (Owner_TextBox.Text != SecondName_textBox.Text)
                    MessageBox.Show("Фамилии владельца отличаются!");
                else
                    MessageBox.Show("Заполните все поля!");
                
            }
            catch (Exception ex)
            {
                
                
                    MessageBox.Show(ex.Message);
                
                
            }
            

            
        }

        void changeThemeClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка цвета формы
            this.BackColor = colorDialog1.Color;
        }

        void changeFontClick(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка шрифта
            changeFont.Font = fontDialog1.Font;
            Number_TextBox.Font = fontDialog1.Font;
            Number_label.Font = fontDialog1.Font;
            Saving_radioButton.Font = fontDialog1.Font;
            Internet_GroupBox.Font = fontDialog1.Font;
            DepositeType_GroupBox.Font = fontDialog1.Font;
            SMS_GroupBox.Font = fontDialog1.Font;
            Owner_groupBox.Font = fontDialog1.Font;
            Bank_groupBox.Font = fontDialog1.Font;
            Number_label.Font = fontDialog1.Font;
            Balance_label.Font = fontDialog1.Font;
            Opening_label.Font = fontDialog1.Font;
            Owner_label.Font = fontDialog1.Font;
            SecondName_label.Font = fontDialog1.Font;
            DepositeType_GroupBox.Font = fontDialog1.Font;
            SMS_GroupBox.Font = fontDialog1.Font;
            Owner_groupBox.Font = fontDialog1.Font;
            Bank_groupBox.Font = fontDialog1.Font;
            // установка цвета шрифта
            changeFont.ForeColor = fontDialog1.Color;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (FormSend_button.Left == (this.Width - FormSend_button.Width - 10))
            {
                koef = -1;
            }
            else if (FormSend_button.Left == 0)
            {
                koef = 1;
            }
            

            progressBar1.PerformStep();
            
        }

        void DeserializeButton(object sender, EventArgs e)
        {
            var jsonFormatterBank = new DataContractJsonSerializer(typeof(Bank)); //создаём объект DataContractJsonSerializer
            using (var file = new FileStream("bank.json", FileMode.OpenOrCreate))
            {
                Bank newBank = (Bank)jsonFormatterBank.ReadObject(file);

                NumberOutput_label.Text = "Номер счета:  " + Convert.ToString(newBank.Number);
                BalanceOutput_label.Text = "Баланс:  " + Convert.ToString(newBank.Balance);
                OpeningOutput_label.Text = "Дата открытия:  " + Convert.ToString(newBank.OpeningDate);
                OwnerOutput_label.Text = "Владелец:  " + Convert.ToString(newBank.Owner);
                DepositeTypeOutput_label.Text = "Тип вклада:  " + Convert.ToString(newBank.DepostiteType);
                SMSOutput_label.Text = "СМС оповещения:  " + Convert.ToString(newBank.SMS);
                InternetOutput_label.Text = "Интернет-банкинга:  " + Convert.ToString(newBank.Internet);

              
            }
            var jsonFormatterOwner = new DataContractJsonSerializer(typeof(Owner)); //создаём объект DataContractJsonSerializer
            using (var file = new FileStream("owner.json", FileMode.OpenOrCreate))
            {
                Owner newOwner = (Owner)jsonFormatterOwner.ReadObject(file);

                SecondNameOutput_label.Text = "Фамилия:  " + Convert.ToString(newOwner.secondName);
                NameOutput_label.Text = "Имя:  " + Convert.ToString(newOwner.name);
                SurnameOutput_label.Text = "Отчество:  " + Convert.ToString(newOwner.surname);
                BirthdayOutput_label.Text = "День рождения:  " + Convert.ToString(newOwner.bitrhday);
                PasspordOutput_label.Text = "Паспорт:  " + Convert.ToString(newOwner.passpord);


            }

            MessageBox.Show("Данные десериализованы");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Opening_TextBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Birthday_textBox_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void Opening_TextBox_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void Bank_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Owner_groupBox_Enter(object sender, EventArgs e)
        {

        }

        
    }
}