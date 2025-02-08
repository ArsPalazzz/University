
namespace Bank
{
    partial class FormSearchForBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchForBalance));
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.BalanceSearch_button = new System.Windows.Forms.Button();
            this.BalanceSearch_label = new System.Windows.Forms.Label();
            this.BalanceSearchTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(44, 263);
            this.OutputBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(707, 189);
            this.OutputBox.TabIndex = 15;
            this.OutputBox.Text = "";
            // 
            // BalanceSearch_button
            // 
            this.BalanceSearch_button.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BalanceSearch_button.Location = new System.Drawing.Point(579, 64);
            this.BalanceSearch_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BalanceSearch_button.Name = "BalanceSearch_button";
            this.BalanceSearch_button.Size = new System.Drawing.Size(172, 45);
            this.BalanceSearch_button.TabIndex = 14;
            this.BalanceSearch_button.Text = "Поиск";
            this.BalanceSearch_button.UseVisualStyleBackColor = true;
            this.BalanceSearch_button.Click += new System.EventHandler(this.BalanceSearch_button_Click);
            // 
            // BalanceSearch_label
            // 
            this.BalanceSearch_label.AutoSize = true;
            this.BalanceSearch_label.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BalanceSearch_label.Location = new System.Drawing.Point(12, 64);
            this.BalanceSearch_label.Name = "BalanceSearch_label";
            this.BalanceSearch_label.Size = new System.Drawing.Size(79, 28);
            this.BalanceSearch_label.TabIndex = 13;
            this.BalanceSearch_label.Text = "Баланс:";
            // 
            // BalanceSearchTextBox
            // 
            this.BalanceSearchTextBox.Location = new System.Drawing.Point(125, 64);
            this.BalanceSearchTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BalanceSearchTextBox.Name = "BalanceSearchTextBox";
            this.BalanceSearchTextBox.Size = new System.Drawing.Size(397, 45);
            this.BalanceSearchTextBox.TabIndex = 12;
            this.BalanceSearchTextBox.Text = "";
            this.BalanceSearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BalanceSearchTextBox_KeyPress);
            // 
            // FormSearchForBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(810, 492);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.BalanceSearch_button);
            this.Controls.Add(this.BalanceSearch_label);
            this.Controls.Add(this.BalanceSearchTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormSearchForBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск по балансу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.Button BalanceSearch_button;
        private System.Windows.Forms.Label BalanceSearch_label;
        private System.Windows.Forms.RichTextBox BalanceSearchTextBox;
    }
}