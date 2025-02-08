namespace laba2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Number_TextBox = new System.Windows.Forms.TextBox();
            this.Number_label = new System.Windows.Forms.Label();
            this.Saving_radioButton = new System.Windows.Forms.RadioButton();
            this.DepositeType_GroupBox = new System.Windows.Forms.GroupBox();
            this.Targeted_radioButton = new System.Windows.Forms.RadioButton();
            this.Accumulative_radioButton = new System.Windows.Forms.RadioButton();
            this.Balance_label = new System.Windows.Forms.Label();
            this.Balance_TextBox = new System.Windows.Forms.TextBox();
            this.Opening_label = new System.Windows.Forms.Label();
            this.Opening_TextBox = new System.Windows.Forms.DateTimePicker();
            this.Owner_label = new System.Windows.Forms.Label();
            this.Owner_TextBox = new System.Windows.Forms.TextBox();
            this.SMS_GroupBox = new System.Windows.Forms.GroupBox();
            this.SMSOFF_radioButton = new System.Windows.Forms.RadioButton();
            this.SMSON_radioButton = new System.Windows.Forms.RadioButton();
            this.Internet_GroupBox = new System.Windows.Forms.GroupBox();
            this.InterneOFF_radioButton = new System.Windows.Forms.RadioButton();
            this.InternetON_radioButton = new System.Windows.Forms.RadioButton();
            this.Surname_label = new System.Windows.Forms.Label();
            this.Surname_textBox = new System.Windows.Forms.TextBox();
            this.Name_label = new System.Windows.Forms.Label();
            this.Name_textBox = new System.Windows.Forms.TextBox();
            this.SecondName_label = new System.Windows.Forms.Label();
            this.SecondName_textBox = new System.Windows.Forms.TextBox();
            this.Birthday_textBox = new System.Windows.Forms.DateTimePicker();
            this.Birthday_label = new System.Windows.Forms.Label();
            this.Passpord_label = new System.Windows.Forms.Label();
            this.Passpord_textBox = new System.Windows.Forms.TextBox();
            this.FormSend_button = new System.Windows.Forms.Button();
            this.Bank_groupBox = new System.Windows.Forms.GroupBox();
            this.Owner_groupBox = new System.Windows.Forms.GroupBox();
            this.BankOutput_groupBox = new System.Windows.Forms.GroupBox();
            this.InternetOutput_label = new System.Windows.Forms.Label();
            this.SMSOutput_label = new System.Windows.Forms.Label();
            this.DepositeTypeOutput_label = new System.Windows.Forms.Label();
            this.NumberOutput_label = new System.Windows.Forms.Label();
            this.BalanceOutput_label = new System.Windows.Forms.Label();
            this.OwnerOutput_label = new System.Windows.Forms.Label();
            this.OpeningOutput_label = new System.Windows.Forms.Label();
            this.OwnerOutput_groupBox = new System.Windows.Forms.GroupBox();
            this.SecondNameOutput_label = new System.Windows.Forms.Label();
            this.SurnameOutput_label = new System.Windows.Forms.Label();
            this.PasspordOutput_label = new System.Windows.Forms.Label();
            this.NameOutput_label = new System.Windows.Forms.Label();
            this.BirthdayOutput_label = new System.Windows.Forms.Label();
            this.Form_groupBox = new System.Windows.Forms.GroupBox();
            this.deserializeButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.changeFont = new System.Windows.Forms.Button();
            this.changeTheme = new System.Windows.Forms.Button();
            this.checkBoxRequire = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DepositeType_GroupBox.SuspendLayout();
            this.SMS_GroupBox.SuspendLayout();
            this.Internet_GroupBox.SuspendLayout();
            this.Bank_groupBox.SuspendLayout();
            this.Owner_groupBox.SuspendLayout();
            this.BankOutput_groupBox.SuspendLayout();
            this.OwnerOutput_groupBox.SuspendLayout();
            this.Form_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Number_TextBox
            // 
            this.Number_TextBox.BackColor = System.Drawing.Color.PaleGreen;
            this.Number_TextBox.Location = new System.Drawing.Point(103, 21);
            this.Number_TextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Number_TextBox.Name = "Number_TextBox";
            this.Number_TextBox.Size = new System.Drawing.Size(142, 27);
            this.Number_TextBox.TabIndex = 0;
            this.Number_TextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Number_label
            // 
            this.Number_label.AutoSize = true;
            this.Number_label.Location = new System.Drawing.Point(7, 25);
            this.Number_label.Name = "Number_label";
            this.Number_label.Size = new System.Drawing.Size(98, 20);
            this.Number_label.TabIndex = 2;
            this.Number_label.Text = "Номер счета";
            // 
            // Saving_radioButton
            // 
            this.Saving_radioButton.AutoSize = true;
            this.Saving_radioButton.Location = new System.Drawing.Point(7, 29);
            this.Saving_radioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Saving_radioButton.Name = "Saving_radioButton";
            this.Saving_radioButton.Size = new System.Drawing.Size(145, 24);
            this.Saving_radioButton.TabIndex = 4;
            this.Saving_radioButton.TabStop = true;
            this.Saving_radioButton.Text = "Сберегательные";
            this.Saving_radioButton.UseVisualStyleBackColor = true;
            // 
            // DepositeType_GroupBox
            // 
            this.DepositeType_GroupBox.BackColor = System.Drawing.Color.PaleGreen;
            this.DepositeType_GroupBox.Controls.Add(this.Targeted_radioButton);
            this.DepositeType_GroupBox.Controls.Add(this.Accumulative_radioButton);
            this.DepositeType_GroupBox.Controls.Add(this.Saving_radioButton);
            this.DepositeType_GroupBox.Location = new System.Drawing.Point(7, 215);
            this.DepositeType_GroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DepositeType_GroupBox.Name = "DepositeType_GroupBox";
            this.DepositeType_GroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DepositeType_GroupBox.Size = new System.Drawing.Size(246, 133);
            this.DepositeType_GroupBox.TabIndex = 5;
            this.DepositeType_GroupBox.TabStop = false;
            this.DepositeType_GroupBox.Text = "Тип вклада";
            this.DepositeType_GroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Targeted_radioButton
            // 
            this.Targeted_radioButton.AutoSize = true;
            this.Targeted_radioButton.Location = new System.Drawing.Point(7, 96);
            this.Targeted_radioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Targeted_radioButton.Name = "Targeted_radioButton";
            this.Targeted_radioButton.Size = new System.Drawing.Size(96, 24);
            this.Targeted_radioButton.TabIndex = 6;
            this.Targeted_radioButton.TabStop = true;
            this.Targeted_radioButton.Text = "Целевые ";
            this.Targeted_radioButton.UseVisualStyleBackColor = true;
            // 
            // Accumulative_radioButton
            // 
            this.Accumulative_radioButton.AutoSize = true;
            this.Accumulative_radioButton.Location = new System.Drawing.Point(7, 63);
            this.Accumulative_radioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Accumulative_radioButton.Name = "Accumulative_radioButton";
            this.Accumulative_radioButton.Size = new System.Drawing.Size(145, 24);
            this.Accumulative_radioButton.TabIndex = 5;
            this.Accumulative_radioButton.TabStop = true;
            this.Accumulative_radioButton.Text = "Накопительные ";
            this.Accumulative_radioButton.UseVisualStyleBackColor = true;
            // 
            // Balance_label
            // 
            this.Balance_label.AutoSize = true;
            this.Balance_label.Location = new System.Drawing.Point(7, 69);
            this.Balance_label.Name = "Balance_label";
            this.Balance_label.Size = new System.Drawing.Size(80, 20);
            this.Balance_label.TabIndex = 7;
            this.Balance_label.Text = "Баланс ($)";
            // 
            // Balance_TextBox
            // 
            this.Balance_TextBox.BackColor = System.Drawing.Color.PaleGreen;
            this.Balance_TextBox.Location = new System.Drawing.Point(103, 65);
            this.Balance_TextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Balance_TextBox.Name = "Balance_TextBox";
            this.Balance_TextBox.Size = new System.Drawing.Size(142, 27);
            this.Balance_TextBox.TabIndex = 6;
            // 
            // Opening_label
            // 
            this.Opening_label.AutoSize = true;
            this.Opening_label.Location = new System.Drawing.Point(7, 117);
            this.Opening_label.Name = "Opening_label";
            this.Opening_label.Size = new System.Drawing.Size(90, 20);
            this.Opening_label.TabIndex = 8;
            this.Opening_label.Text = "Дата откр-я";
            // 
            // Opening_TextBox
            // 
            this.Opening_TextBox.CalendarMonthBackground = System.Drawing.Color.PaleGreen;
            this.Opening_TextBox.Location = new System.Drawing.Point(103, 111);
            this.Opening_TextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Opening_TextBox.MinDate = new System.DateTime(2023, 2, 21, 0, 0, 0, 0);
            this.Opening_TextBox.Name = "Opening_TextBox";
            this.Opening_TextBox.Size = new System.Drawing.Size(142, 27);
            this.Opening_TextBox.TabIndex = 9;
            this.Opening_TextBox.ValueChanged += new System.EventHandler(this.Opening_TextBox_ValueChanged_1);
            // 
            // Owner_label
            // 
            this.Owner_label.AutoSize = true;
            this.Owner_label.Location = new System.Drawing.Point(7, 164);
            this.Owner_label.Name = "Owner_label";
            this.Owner_label.Size = new System.Drawing.Size(75, 20);
            this.Owner_label.TabIndex = 11;
            this.Owner_label.Text = "Владелец";
            // 
            // Owner_TextBox
            // 
            this.Owner_TextBox.BackColor = System.Drawing.Color.PaleGreen;
            this.Owner_TextBox.Location = new System.Drawing.Point(103, 161);
            this.Owner_TextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Owner_TextBox.Name = "Owner_TextBox";
            this.Owner_TextBox.Size = new System.Drawing.Size(142, 27);
            this.Owner_TextBox.TabIndex = 10;
            // 
            // SMS_GroupBox
            // 
            this.SMS_GroupBox.BackColor = System.Drawing.Color.PaleGreen;
            this.SMS_GroupBox.Controls.Add(this.SMSOFF_radioButton);
            this.SMS_GroupBox.Controls.Add(this.SMSON_radioButton);
            this.SMS_GroupBox.Location = new System.Drawing.Point(7, 356);
            this.SMS_GroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SMS_GroupBox.Name = "SMS_GroupBox";
            this.SMS_GroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SMS_GroupBox.Size = new System.Drawing.Size(246, 103);
            this.SMS_GroupBox.TabIndex = 7;
            this.SMS_GroupBox.TabStop = false;
            this.SMS_GroupBox.Text = "Подключение смс оповещения";
            // 
            // SMSOFF_radioButton
            // 
            this.SMSOFF_radioButton.AutoSize = true;
            this.SMSOFF_radioButton.Location = new System.Drawing.Point(7, 63);
            this.SMSOFF_radioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SMSOFF_radioButton.Name = "SMSOFF_radioButton";
            this.SMSOFF_radioButton.Size = new System.Drawing.Size(108, 24);
            this.SMSOFF_radioButton.TabIndex = 5;
            this.SMSOFF_radioButton.TabStop = true;
            this.SMSOFF_radioButton.Text = "Выключить";
            this.SMSOFF_radioButton.UseVisualStyleBackColor = true;
            // 
            // SMSON_radioButton
            // 
            this.SMSON_radioButton.AutoSize = true;
            this.SMSON_radioButton.Location = new System.Drawing.Point(7, 29);
            this.SMSON_radioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SMSON_radioButton.Name = "SMSON_radioButton";
            this.SMSON_radioButton.Size = new System.Drawing.Size(97, 24);
            this.SMSON_radioButton.TabIndex = 4;
            this.SMSON_radioButton.TabStop = true;
            this.SMSON_radioButton.Text = "Включить";
            this.SMSON_radioButton.UseVisualStyleBackColor = true;
            // 
            // Internet_GroupBox
            // 
            this.Internet_GroupBox.BackColor = System.Drawing.Color.PaleGreen;
            this.Internet_GroupBox.Controls.Add(this.InterneOFF_radioButton);
            this.Internet_GroupBox.Controls.Add(this.InternetON_radioButton);
            this.Internet_GroupBox.Location = new System.Drawing.Point(7, 467);
            this.Internet_GroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Internet_GroupBox.Name = "Internet_GroupBox";
            this.Internet_GroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Internet_GroupBox.Size = new System.Drawing.Size(246, 117);
            this.Internet_GroupBox.TabIndex = 8;
            this.Internet_GroupBox.TabStop = false;
            this.Internet_GroupBox.Text = "Подключение интернет-банкинга";
            // 
            // InterneOFF_radioButton
            // 
            this.InterneOFF_radioButton.AutoSize = true;
            this.InterneOFF_radioButton.Location = new System.Drawing.Point(7, 79);
            this.InterneOFF_radioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InterneOFF_radioButton.Name = "InterneOFF_radioButton";
            this.InterneOFF_radioButton.Size = new System.Drawing.Size(108, 24);
            this.InterneOFF_radioButton.TabIndex = 5;
            this.InterneOFF_radioButton.TabStop = true;
            this.InterneOFF_radioButton.Text = "Выключить";
            this.InterneOFF_radioButton.UseVisualStyleBackColor = true;
            // 
            // InternetON_radioButton
            // 
            this.InternetON_radioButton.AutoSize = true;
            this.InternetON_radioButton.Location = new System.Drawing.Point(7, 45);
            this.InternetON_radioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InternetON_radioButton.Name = "InternetON_radioButton";
            this.InternetON_radioButton.Size = new System.Drawing.Size(97, 24);
            this.InternetON_radioButton.TabIndex = 4;
            this.InternetON_radioButton.TabStop = true;
            this.InternetON_radioButton.Text = "Включить";
            this.InternetON_radioButton.UseVisualStyleBackColor = true;
            // 
            // Surname_label
            // 
            this.Surname_label.AutoSize = true;
            this.Surname_label.Location = new System.Drawing.Point(7, 121);
            this.Surname_label.Name = "Surname_label";
            this.Surname_label.Size = new System.Drawing.Size(72, 20);
            this.Surname_label.TabIndex = 14;
            this.Surname_label.Text = "Отчество";
            // 
            // Surname_textBox
            // 
            this.Surname_textBox.BackColor = System.Drawing.Color.PaleGreen;
            this.Surname_textBox.Location = new System.Drawing.Point(103, 117);
            this.Surname_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Surname_textBox.Name = "Surname_textBox";
            this.Surname_textBox.Size = new System.Drawing.Size(149, 27);
            this.Surname_textBox.TabIndex = 13;
            // 
            // Name_label
            // 
            this.Name_label.AutoSize = true;
            this.Name_label.Location = new System.Drawing.Point(7, 73);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(39, 20);
            this.Name_label.TabIndex = 16;
            this.Name_label.Text = "Имя";
            // 
            // Name_textBox
            // 
            this.Name_textBox.BackColor = System.Drawing.Color.PaleGreen;
            this.Name_textBox.Location = new System.Drawing.Point(103, 69);
            this.Name_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(149, 27);
            this.Name_textBox.TabIndex = 15;
            // 
            // SecondName_label
            // 
            this.SecondName_label.AutoSize = true;
            this.SecondName_label.Location = new System.Drawing.Point(7, 25);
            this.SecondName_label.Name = "SecondName_label";
            this.SecondName_label.Size = new System.Drawing.Size(73, 20);
            this.SecondName_label.TabIndex = 18;
            this.SecondName_label.Text = "Фамилия";
            // 
            // SecondName_textBox
            // 
            this.SecondName_textBox.BackColor = System.Drawing.Color.PaleGreen;
            this.SecondName_textBox.Location = new System.Drawing.Point(103, 21);
            this.SecondName_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SecondName_textBox.Name = "SecondName_textBox";
            this.SecondName_textBox.Size = new System.Drawing.Size(149, 27);
            this.SecondName_textBox.TabIndex = 17;
            // 
            // Birthday_textBox
            // 
            this.Birthday_textBox.Location = new System.Drawing.Point(103, 164);
            this.Birthday_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Birthday_textBox.MaxDate = new System.DateTime(2023, 2, 21, 0, 0, 0, 0);
            this.Birthday_textBox.MinDate = new System.DateTime(2005, 2, 14, 0, 0, 0, 0);
            this.Birthday_textBox.Name = "Birthday_textBox";
            this.Birthday_textBox.Size = new System.Drawing.Size(149, 27);
            this.Birthday_textBox.TabIndex = 20;
            this.Birthday_textBox.Value = new System.DateTime(2023, 2, 14, 0, 0, 0, 0);
            this.Birthday_textBox.ValueChanged += new System.EventHandler(this.Birthday_textBox_ValueChanged);
            // 
            // Birthday_label
            // 
            this.Birthday_label.AutoSize = true;
            this.Birthday_label.Location = new System.Drawing.Point(7, 172);
            this.Birthday_label.Name = "Birthday_label";
            this.Birthday_label.Size = new System.Drawing.Size(85, 20);
            this.Birthday_label.TabIndex = 19;
            this.Birthday_label.Text = "Дата рожд.";
            // 
            // Passpord_label
            // 
            this.Passpord_label.AutoSize = true;
            this.Passpord_label.Location = new System.Drawing.Point(7, 215);
            this.Passpord_label.Name = "Passpord_label";
            this.Passpord_label.Size = new System.Drawing.Size(104, 20);
            this.Passpord_label.TabIndex = 22;
            this.Passpord_label.Text = "Пасп. данные";
            this.Passpord_label.Click += new System.EventHandler(this.label11_Click);
            // 
            // Passpord_textBox
            // 
            this.Passpord_textBox.BackColor = System.Drawing.Color.PaleGreen;
            this.Passpord_textBox.Location = new System.Drawing.Point(103, 211);
            this.Passpord_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Passpord_textBox.Name = "Passpord_textBox";
            this.Passpord_textBox.Size = new System.Drawing.Size(149, 27);
            this.Passpord_textBox.TabIndex = 21;
            this.Passpord_textBox.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // FormSend_button
            // 
            this.FormSend_button.BackColor = System.Drawing.Color.YellowGreen;
            this.FormSend_button.Location = new System.Drawing.Point(19, 676);
            this.FormSend_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FormSend_button.Name = "FormSend_button";
            this.FormSend_button.Size = new System.Drawing.Size(555, 44);
            this.FormSend_button.TabIndex = 24;
            this.FormSend_button.Text = "Отправить";
            this.FormSend_button.UseVisualStyleBackColor = false;
            this.FormSend_button.Click += new System.EventHandler(this.FormSend_button_Click);
            // 
            // Bank_groupBox
            // 
            this.Bank_groupBox.BackColor = System.Drawing.Color.LimeGreen;
            this.Bank_groupBox.Controls.Add(this.Number_label);
            this.Bank_groupBox.Controls.Add(this.Number_TextBox);
            this.Bank_groupBox.Controls.Add(this.DepositeType_GroupBox);
            this.Bank_groupBox.Controls.Add(this.Balance_TextBox);
            this.Bank_groupBox.Controls.Add(this.Balance_label);
            this.Bank_groupBox.Controls.Add(this.Opening_label);
            this.Bank_groupBox.Controls.Add(this.Opening_TextBox);
            this.Bank_groupBox.Controls.Add(this.Owner_TextBox);
            this.Bank_groupBox.Controls.Add(this.Owner_label);
            this.Bank_groupBox.Controls.Add(this.SMS_GroupBox);
            this.Bank_groupBox.Controls.Add(this.Internet_GroupBox);
            this.Bank_groupBox.Location = new System.Drawing.Point(19, 29);
            this.Bank_groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Bank_groupBox.Name = "Bank_groupBox";
            this.Bank_groupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Bank_groupBox.Size = new System.Drawing.Size(265, 595);
            this.Bank_groupBox.TabIndex = 39;
            this.Bank_groupBox.TabStop = false;
            this.Bank_groupBox.Text = "Банк";
            this.Bank_groupBox.Enter += new System.EventHandler(this.Bank_groupBox_Enter);
            // 
            // Owner_groupBox
            // 
            this.Owner_groupBox.BackColor = System.Drawing.Color.LimeGreen;
            this.Owner_groupBox.Controls.Add(this.SecondName_label);
            this.Owner_groupBox.Controls.Add(this.Surname_textBox);
            this.Owner_groupBox.Controls.Add(this.Surname_label);
            this.Owner_groupBox.Controls.Add(this.Name_textBox);
            this.Owner_groupBox.Controls.Add(this.Name_label);
            this.Owner_groupBox.Controls.Add(this.SecondName_textBox);
            this.Owner_groupBox.Controls.Add(this.Birthday_label);
            this.Owner_groupBox.Controls.Add(this.Birthday_textBox);
            this.Owner_groupBox.Controls.Add(this.Passpord_textBox);
            this.Owner_groupBox.Controls.Add(this.Passpord_label);
            this.Owner_groupBox.Location = new System.Drawing.Point(306, 33);
            this.Owner_groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Owner_groupBox.Name = "Owner_groupBox";
            this.Owner_groupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Owner_groupBox.Size = new System.Drawing.Size(269, 265);
            this.Owner_groupBox.TabIndex = 40;
            this.Owner_groupBox.TabStop = false;
            this.Owner_groupBox.Text = "Владелец";
            this.Owner_groupBox.Enter += new System.EventHandler(this.Owner_groupBox_Enter);
            // 
            // BankOutput_groupBox
            // 
            this.BankOutput_groupBox.BackColor = System.Drawing.Color.LimeGreen;
            this.BankOutput_groupBox.Controls.Add(this.InternetOutput_label);
            this.BankOutput_groupBox.Controls.Add(this.SMSOutput_label);
            this.BankOutput_groupBox.Controls.Add(this.DepositeTypeOutput_label);
            this.BankOutput_groupBox.Controls.Add(this.NumberOutput_label);
            this.BankOutput_groupBox.Controls.Add(this.BalanceOutput_label);
            this.BankOutput_groupBox.Controls.Add(this.OwnerOutput_label);
            this.BankOutput_groupBox.Controls.Add(this.OpeningOutput_label);
            this.BankOutput_groupBox.Location = new System.Drawing.Point(678, 68);
            this.BankOutput_groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BankOutput_groupBox.Name = "BankOutput_groupBox";
            this.BankOutput_groupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BankOutput_groupBox.Size = new System.Drawing.Size(258, 327);
            this.BankOutput_groupBox.TabIndex = 41;
            this.BankOutput_groupBox.TabStop = false;
            this.BankOutput_groupBox.Text = "Банк";
            // 
            // InternetOutput_label
            // 
            this.InternetOutput_label.AutoSize = true;
            this.InternetOutput_label.Location = new System.Drawing.Point(9, 289);
            this.InternetOutput_label.Name = "InternetOutput_label";
            this.InternetOutput_label.Size = new System.Drawing.Size(146, 20);
            this.InternetOutput_label.TabIndex = 18;
            this.InternetOutput_label.Text = "Интернет-банкинга";
            // 
            // SMSOutput_label
            // 
            this.SMSOutput_label.AutoSize = true;
            this.SMSOutput_label.Location = new System.Drawing.Point(9, 256);
            this.SMSOutput_label.Name = "SMSOutput_label";
            this.SMSOutput_label.Size = new System.Drawing.Size(133, 20);
            this.SMSOutput_label.TabIndex = 17;
            this.SMSOutput_label.Text = "СМС оповещения";
            this.SMSOutput_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // DepositeTypeOutput_label
            // 
            this.DepositeTypeOutput_label.AutoSize = true;
            this.DepositeTypeOutput_label.Location = new System.Drawing.Point(9, 225);
            this.DepositeTypeOutput_label.Name = "DepositeTypeOutput_label";
            this.DepositeTypeOutput_label.Size = new System.Drawing.Size(86, 20);
            this.DepositeTypeOutput_label.TabIndex = 16;
            this.DepositeTypeOutput_label.Text = "Тип вклада";
            // 
            // NumberOutput_label
            // 
            this.NumberOutput_label.AutoSize = true;
            this.NumberOutput_label.Location = new System.Drawing.Point(9, 44);
            this.NumberOutput_label.Name = "NumberOutput_label";
            this.NumberOutput_label.Size = new System.Drawing.Size(98, 20);
            this.NumberOutput_label.TabIndex = 12;
            this.NumberOutput_label.Text = "Номер счета";
            // 
            // BalanceOutput_label
            // 
            this.BalanceOutput_label.AutoSize = true;
            this.BalanceOutput_label.Location = new System.Drawing.Point(9, 88);
            this.BalanceOutput_label.Name = "BalanceOutput_label";
            this.BalanceOutput_label.Size = new System.Drawing.Size(58, 20);
            this.BalanceOutput_label.TabIndex = 13;
            this.BalanceOutput_label.Text = "Баланс";
            // 
            // OwnerOutput_label
            // 
            this.OwnerOutput_label.AutoSize = true;
            this.OwnerOutput_label.Location = new System.Drawing.Point(9, 183);
            this.OwnerOutput_label.Name = "OwnerOutput_label";
            this.OwnerOutput_label.Size = new System.Drawing.Size(75, 20);
            this.OwnerOutput_label.TabIndex = 15;
            this.OwnerOutput_label.Text = "Владелец";
            // 
            // OpeningOutput_label
            // 
            this.OpeningOutput_label.AutoSize = true;
            this.OpeningOutput_label.Location = new System.Drawing.Point(9, 136);
            this.OpeningOutput_label.Name = "OpeningOutput_label";
            this.OpeningOutput_label.Size = new System.Drawing.Size(90, 20);
            this.OpeningOutput_label.TabIndex = 14;
            this.OpeningOutput_label.Text = "Дата откр-я";
            // 
            // OwnerOutput_groupBox
            // 
            this.OwnerOutput_groupBox.BackColor = System.Drawing.Color.LimeGreen;
            this.OwnerOutput_groupBox.Controls.Add(this.SecondNameOutput_label);
            this.OwnerOutput_groupBox.Controls.Add(this.SurnameOutput_label);
            this.OwnerOutput_groupBox.Controls.Add(this.PasspordOutput_label);
            this.OwnerOutput_groupBox.Controls.Add(this.NameOutput_label);
            this.OwnerOutput_groupBox.Controls.Add(this.BirthdayOutput_label);
            this.OwnerOutput_groupBox.Location = new System.Drawing.Point(1011, 70);
            this.OwnerOutput_groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OwnerOutput_groupBox.Name = "OwnerOutput_groupBox";
            this.OwnerOutput_groupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OwnerOutput_groupBox.Size = new System.Drawing.Size(257, 292);
            this.OwnerOutput_groupBox.TabIndex = 42;
            this.OwnerOutput_groupBox.TabStop = false;
            this.OwnerOutput_groupBox.Text = "Владелец";
            // 
            // SecondNameOutput_label
            // 
            this.SecondNameOutput_label.AutoSize = true;
            this.SecondNameOutput_label.Location = new System.Drawing.Point(9, 36);
            this.SecondNameOutput_label.Name = "SecondNameOutput_label";
            this.SecondNameOutput_label.Size = new System.Drawing.Size(73, 20);
            this.SecondNameOutput_label.TabIndex = 25;
            this.SecondNameOutput_label.Text = "Фамилия";
            // 
            // SurnameOutput_label
            // 
            this.SurnameOutput_label.AutoSize = true;
            this.SurnameOutput_label.Location = new System.Drawing.Point(9, 132);
            this.SurnameOutput_label.Name = "SurnameOutput_label";
            this.SurnameOutput_label.Size = new System.Drawing.Size(72, 20);
            this.SurnameOutput_label.TabIndex = 23;
            this.SurnameOutput_label.Text = "Отчество";
            // 
            // PasspordOutput_label
            // 
            this.PasspordOutput_label.AutoSize = true;
            this.PasspordOutput_label.Location = new System.Drawing.Point(9, 225);
            this.PasspordOutput_label.Name = "PasspordOutput_label";
            this.PasspordOutput_label.Size = new System.Drawing.Size(104, 20);
            this.PasspordOutput_label.TabIndex = 27;
            this.PasspordOutput_label.Text = "Пасп. данные";
            // 
            // NameOutput_label
            // 
            this.NameOutput_label.AutoSize = true;
            this.NameOutput_label.Location = new System.Drawing.Point(9, 84);
            this.NameOutput_label.Name = "NameOutput_label";
            this.NameOutput_label.Size = new System.Drawing.Size(39, 20);
            this.NameOutput_label.TabIndex = 24;
            this.NameOutput_label.Text = "Имя";
            // 
            // BirthdayOutput_label
            // 
            this.BirthdayOutput_label.AutoSize = true;
            this.BirthdayOutput_label.Location = new System.Drawing.Point(9, 183);
            this.BirthdayOutput_label.Name = "BirthdayOutput_label";
            this.BirthdayOutput_label.Size = new System.Drawing.Size(85, 20);
            this.BirthdayOutput_label.TabIndex = 26;
            this.BirthdayOutput_label.Text = "Дата рожд.";
            // 
            // Form_groupBox
            // 
            this.Form_groupBox.Controls.Add(this.deserializeButton);
            this.Form_groupBox.Controls.Add(this.progressBar1);
            this.Form_groupBox.Controls.Add(this.changeFont);
            this.Form_groupBox.Controls.Add(this.changeTheme);
            this.Form_groupBox.Controls.Add(this.checkBoxRequire);
            this.Form_groupBox.Controls.Add(this.Bank_groupBox);
            this.Form_groupBox.Controls.Add(this.Owner_groupBox);
            this.Form_groupBox.Controls.Add(this.FormSend_button);
            this.Form_groupBox.Location = new System.Drawing.Point(29, 31);
            this.Form_groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Form_groupBox.Name = "Form_groupBox";
            this.Form_groupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Form_groupBox.Size = new System.Drawing.Size(607, 728);
            this.Form_groupBox.TabIndex = 43;
            this.Form_groupBox.TabStop = false;
            // 
            // deserializeButton
            // 
            this.deserializeButton.Location = new System.Drawing.Point(306, 477);
            this.deserializeButton.Name = "deserializeButton";
            this.deserializeButton.Size = new System.Drawing.Size(218, 29);
            this.deserializeButton.TabIndex = 45;
            this.deserializeButton.Text = "Десериализовать данные";
            this.deserializeButton.UseVisualStyleBackColor = true;
            
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(306, 595);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(205, 29);
            this.progressBar1.TabIndex = 44;
            // 
            // changeFont
            // 
            this.changeFont.Location = new System.Drawing.Point(306, 429);
            this.changeFont.Name = "changeFont";
            this.changeFont.Size = new System.Drawing.Size(139, 29);
            this.changeFont.TabIndex = 43;
            this.changeFont.Text = "Смена шрифта";
            this.changeFont.UseVisualStyleBackColor = true;
            // 
            // changeTheme
            // 
            this.changeTheme.Location = new System.Drawing.Point(306, 385);
            this.changeTheme.Name = "changeTheme";
            this.changeTheme.Size = new System.Drawing.Size(139, 29);
            this.changeTheme.TabIndex = 42;
            this.changeTheme.Text = "Смена темы";
            this.changeTheme.UseVisualStyleBackColor = true;
            this.changeTheme.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxRequire
            // 
            this.checkBoxRequire.AutoSize = true;
            this.checkBoxRequire.Location = new System.Drawing.Point(23, 631);
            this.checkBoxRequire.Name = "checkBoxRequire";
            this.checkBoxRequire.Size = new System.Drawing.Size(351, 24);
            this.checkBoxRequire.TabIndex = 41;
            this.checkBoxRequire.Text = "Я ознакомился с формой и ввел свои данные";
            this.checkBoxRequire.UseVisualStyleBackColor = true;
            this.checkBoxRequire.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // fontDialog1
            // 
            this.fontDialog1.MaxSize = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1315, 772);
            this.Controls.Add(this.Form_groupBox);
            this.Controls.Add(this.OwnerOutput_groupBox);
            this.Controls.Add(this.BankOutput_groupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DepositeType_GroupBox.ResumeLayout(false);
            this.DepositeType_GroupBox.PerformLayout();
            this.SMS_GroupBox.ResumeLayout(false);
            this.SMS_GroupBox.PerformLayout();
            this.Internet_GroupBox.ResumeLayout(false);
            this.Internet_GroupBox.PerformLayout();
            this.Bank_groupBox.ResumeLayout(false);
            this.Bank_groupBox.PerformLayout();
            this.Owner_groupBox.ResumeLayout(false);
            this.Owner_groupBox.PerformLayout();
            this.BankOutput_groupBox.ResumeLayout(false);
            this.BankOutput_groupBox.PerformLayout();
            this.OwnerOutput_groupBox.ResumeLayout(false);
            this.OwnerOutput_groupBox.PerformLayout();
            this.Form_groupBox.ResumeLayout(false);
            this.Form_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox Number_TextBox;
        private Label Number_label;
        private RadioButton Saving_radioButton;
        private GroupBox DepositeType_GroupBox;
        private RadioButton Accumulative_radioButton;
        private RadioButton Targeted_radioButton;
        private Label Balance_label;
        private TextBox Balance_TextBox;
        private Label Opening_label;
        private DateTimePicker Opening_TextBox;
        private Label Owner_label;
        private TextBox Owner_TextBox;
        private GroupBox SMS_GroupBox;
        private RadioButton SMSOFF_radioButton;
        private RadioButton SMSON_radioButton;
        private GroupBox Internet_GroupBox;
        private RadioButton InterneOFF_radioButton;
        private RadioButton InternetON_radioButton;
        private Label Surname_label;
        private TextBox Surname_textBox;
        private Label Name_label;
        private TextBox Name_textBox;
        private Label SecondName_label;
        private TextBox SecondName_textBox;
        private DateTimePicker Birthday_textBox;
        private Label Birthday_label;
        private Label Passpord_label;
        private TextBox Passpord_textBox;
        private Button FormSend_button;
        private GroupBox Bank_groupBox;
        private GroupBox Owner_groupBox;
        private GroupBox BankOutput_groupBox;
        private GroupBox OwnerOutput_groupBox;
        private Label NumberOutput_label;
        private Label BalanceOutput_label;
        private Label OwnerOutput_label;
        private Label OpeningOutput_label;
        private Label SecondNameOutput_label;
        private Label SurnameOutput_label;
        private Label PasspordOutput_label;
        private Label NameOutput_label;
        private Label BirthdayOutput_label;
        private GroupBox Form_groupBox;
        private Label InternetOutput_label;
        private Label SMSOutput_label;
        private Label DepositeTypeOutput_label;
        private CheckBox checkBoxRequire;
        private ColorDialog colorDialog1;
        private Button changeTheme;
        private Button changeFont;
        private FontDialog fontDialog1;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private Button deserializeButton;
    }
}