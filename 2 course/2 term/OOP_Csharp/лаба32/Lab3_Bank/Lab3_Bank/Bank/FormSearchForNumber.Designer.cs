
namespace Bank
{
    partial class FormSearchForNumber
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchForNumber));
            this.numberSearchTextBox = new System.Windows.Forms.RichTextBox();
            this.numberSearch_label = new System.Windows.Forms.Label();
            this.numberSearch_button = new System.Windows.Forms.Button();
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numberSearchTextBox
            // 
            this.numberSearchTextBox.Location = new System.Drawing.Point(96, 25);
            this.numberSearchTextBox.Name = "numberSearchTextBox";
            this.numberSearchTextBox.Size = new System.Drawing.Size(414, 45);
            this.numberSearchTextBox.TabIndex = 0;
            this.numberSearchTextBox.Text = "";
            // 
            // numberSearch_label
            // 
            this.numberSearch_label.AutoSize = true;
            this.numberSearch_label.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberSearch_label.Location = new System.Drawing.Point(12, 31);
            this.numberSearch_label.Name = "numberSearch_label";
            this.numberSearch_label.Size = new System.Drawing.Size(78, 28);
            this.numberSearch_label.TabIndex = 1;
            this.numberSearch_label.Text = "Номер:";
            this.numberSearch_label.Click += new System.EventHandler(this.numberSearch_label_Click);
            // 
            // numberSearch_button
            // 
            this.numberSearch_button.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberSearch_button.Location = new System.Drawing.Point(553, 25);
            this.numberSearch_button.Name = "numberSearch_button";
            this.numberSearch_button.Size = new System.Drawing.Size(241, 45);
            this.numberSearch_button.TabIndex = 2;
            this.numberSearch_button.Text = "Найти все";
            this.numberSearch_button.UseVisualStyleBackColor = true;
            this.numberSearch_button.Click += new System.EventHandler(this.numberSearch_button_Click);
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(42, 242);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(728, 226);
            this.OutputBox.TabIndex = 3;
            this.OutputBox.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(553, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 52);
            this.button1.TabIndex = 4;
            this.button1.Text = "Начинается с 1,2 или 3";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SearchButtonOneToThreeNumber_Click);
            // 
            // FormSearchForNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(806, 499);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.numberSearch_button);
            this.Controls.Add(this.numberSearch_label);
            this.Controls.Add(this.numberSearchTextBox);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormSearchForNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск по номеру";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox numberSearchTextBox;
        private System.Windows.Forms.Label numberSearch_label;
        private System.Windows.Forms.Button numberSearch_button;
        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.Button button1;
    }
}