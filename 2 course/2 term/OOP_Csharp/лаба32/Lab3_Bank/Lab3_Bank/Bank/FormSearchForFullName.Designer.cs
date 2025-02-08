
namespace Bank
{
    partial class FormSearchForFullName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchForFullName));
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.FNSearch_button = new System.Windows.Forms.Button();
            this.numberSearch_label = new System.Windows.Forms.Label();
            this.FNSearchTextBox = new System.Windows.Forms.RichTextBox();
            this.SearchButtonEngFullName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(36, 228);
            this.OutputBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(807, 233);
            this.OutputBox.TabIndex = 7;
            this.OutputBox.Text = "";
            // 
            // FNSearch_button
            // 
            this.FNSearch_button.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FNSearch_button.Location = new System.Drawing.Point(656, 42);
            this.FNSearch_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FNSearch_button.Name = "FNSearch_button";
            this.FNSearch_button.Size = new System.Drawing.Size(187, 44);
            this.FNSearch_button.TabIndex = 6;
            this.FNSearch_button.Text = "Поиск";
            this.FNSearch_button.UseVisualStyleBackColor = true;
            this.FNSearch_button.Click += new System.EventHandler(this.FNSearch_button_Click);
            // 
            // numberSearch_label
            // 
            this.numberSearch_label.AutoSize = true;
            this.numberSearch_label.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberSearch_label.Location = new System.Drawing.Point(31, 48);
            this.numberSearch_label.Name = "numberSearch_label";
            this.numberSearch_label.Size = new System.Drawing.Size(61, 28);
            this.numberSearch_label.TabIndex = 5;
            this.numberSearch_label.Text = "ФИО:";
            this.numberSearch_label.Click += new System.EventHandler(this.numberSearch_label_Click);
            // 
            // FNSearchTextBox
            // 
            this.FNSearchTextBox.Location = new System.Drawing.Point(105, 41);
            this.FNSearchTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FNSearchTextBox.Name = "FNSearchTextBox";
            this.FNSearchTextBox.Size = new System.Drawing.Size(455, 45);
            this.FNSearchTextBox.TabIndex = 4;
            this.FNSearchTextBox.Text = "";
            // 
            // SearchButtonEngFullName
            // 
            this.SearchButtonEngFullName.Location = new System.Drawing.Point(0, 0);
            this.SearchButtonEngFullName.Margin = new System.Windows.Forms.Padding(4);
            this.SearchButtonEngFullName.Name = "SearchButtonEngFullName";
            this.SearchButtonEngFullName.Size = new System.Drawing.Size(100, 28);
            this.SearchButtonEngFullName.TabIndex = 0;
            // 
            // FormSearchForFullName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(872, 497);
            this.Controls.Add(this.SearchButtonEngFullName);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.FNSearch_button);
            this.Controls.Add(this.numberSearch_label);
            this.Controls.Add(this.FNSearchTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormSearchForFullName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск по ФИО";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.Button FNSearch_button;
        private System.Windows.Forms.Label numberSearch_label;
        private System.Windows.Forms.RichTextBox FNSearchTextBox;
        private System.Windows.Forms.Button SearchButtonEngFullName;
    }
}