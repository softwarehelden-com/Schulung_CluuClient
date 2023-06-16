namespace WinFormsCluuDemo
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
            this.testCluuConnectionButton = new Button();
            this.loginButton = new Button();
            this.queryButton = new Button();
            this.resultTextBox = new TextBox();
            this.SuspendLayout();
            // 
            // testCluuConnectionButton
            // 
            this.testCluuConnectionButton.Location = new Point(12, 12);
            this.testCluuConnectionButton.Name = "testCluuConnectionButton";
            this.testCluuConnectionButton.Size = new Size(159, 23);
            this.testCluuConnectionButton.TabIndex = 0;
            this.testCluuConnectionButton.Text = "Test Cluu Connection";
            this.testCluuConnectionButton.UseVisualStyleBackColor = true;
            this.testCluuConnectionButton.Click += this.HandleTestCluuConnectionButtonClick;
            // 
            // loginButton
            // 
            this.loginButton.Location = new Point(177, 12);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new Size(148, 23);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += this.HandleLoginButtonClick;
            // 
            // queryButton
            // 
            this.queryButton.Location = new Point(12, 84);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new Size(159, 23);
            this.queryButton.TabIndex = 2;
            this.queryButton.Text = "Query";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += this.HandleQueryButtonClick;
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new Point(12, 113);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new Size(271, 151);
            this.resultTextBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(461, 276);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.queryButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.testCluuConnectionButton);
            this.Name = "MainForm";
            this.Text = "Demo";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Button testCluuConnectionButton;
        private Button loginButton;
        private Button queryButton;
        private TextBox resultTextBox;
    }
}