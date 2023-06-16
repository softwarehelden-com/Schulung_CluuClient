namespace WinFormsThreadingDemo
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sqrtButton = new Button();
            this.valueTextBox = new TextBox();
            this.SuspendLayout();
            // 
            // sqrtButton
            // 
            this.sqrtButton.Location = new Point(142, 137);
            this.sqrtButton.Name = "sqrtButton";
            this.sqrtButton.Size = new Size(75, 23);
            this.sqrtButton.TabIndex = 0;
            this.sqrtButton.Text = "SQRT";
            this.sqrtButton.UseVisualStyleBackColor = true;
            this.sqrtButton.Click += this.HandleSqrtButtonClick;
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new Point(58, 69);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new Size(238, 23);
            this.valueTextBox.TabIndex = 1;
            this.valueTextBox.Text = "321";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(378, 256);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.sqrtButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Button sqrtButton;
        private TextBox valueTextBox;
    }
}