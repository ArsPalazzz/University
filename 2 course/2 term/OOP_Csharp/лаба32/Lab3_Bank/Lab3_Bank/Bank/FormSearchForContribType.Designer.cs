
namespace Bank
{
    partial class FormSearchForContribType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchForContribType));
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.CTSearch_button = new System.Windows.Forms.Button();
            this.CTSearch_label = new System.Windows.Forms.Label();
            this.CTSearchTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(43, 266);
            this.OutputBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(756, 189);
            this.OutputBox.TabIndex = 11;
            this.OutputBox.Text = "";
            // 
            // CTSearch_button
            // 
            this.CTSearch_button.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CTSearch_button.Location = new System.Drawing.Point(643, 58);
            this.CTSearch_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CTSearch_button.Name = "CTSearch_button";
            this.CTSearch_button.Size = new System.Drawing.Size(156, 45);
            this.CTSearch_button.TabIndex = 10;
            this.CTSearch_button.Text = "Поиск";
            this.CTSearch_button.UseVisualStyleBackColor = true;
            this.CTSearch_button.Click += new System.EventHandler(this.CTSearch_button_Click);
            // 
            // CTSearch_label
            // 
            this.CTSearch_label.AutoSize = true;
            this.CTSearch_label.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CTSearch_label.Location = new System.Drawing.Point(12, 58);
            this.CTSearch_label.Name = "CTSearch_label";
            this.CTSearch_label.Size = new System.Drawing.Size(118, 28);
            this.CTSearch_label.TabIndex = 9;
            this.CTSearch_label.Text = "Тип вклада:";
            // 
            // CTSearchTextBox
            // 
            this.CTSearchTextBox.Location = new System.Drawing.Point(136, 58);
            this.CTSearchTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CTSearchTextBox.Name = "CTSearchTextBox";
            this.CTSearchTextBox.Size = new System.Drawing.Size(397, 45);
            this.CTSearchTextBox.TabIndex = 8;
            this.CTSearchTextBox.Text = "";
            // 
            // FormSearchForContribType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(874, 487);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.CTSearch_button);
            this.Controls.Add(this.CTSearch_label);
            this.Controls.Add(this.CTSearchTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormSearchForContribType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск по типу вклада";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.Button CTSearch_button;
        private System.Windows.Forms.Label CTSearch_label;
        private System.Windows.Forms.RichTextBox CTSearchTextBox;
    }
}