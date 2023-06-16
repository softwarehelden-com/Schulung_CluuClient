namespace WinFormsCluuDemo
{
    partial class LoginForm
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
            this.cancelButton = new Button();
            this.loginButton = new Button();
            this.loginTypeComboBox = new ComboBox();
            this.label1 = new Label();
            this.usernameLabel = new Label();
            this.usernameTextBox = new TextBox();
            this.passwordLabel = new Label();
            this.passwordTextBox = new TextBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = DialogResult.Cancel;
            this.cancelButton.Location = new Point(296, 164);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Abbrechen";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // loginButton
            // 
            this.loginButton.Location = new Point(215, 164);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new Size(75, 23);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "Anmelden";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += this.HandleLoginButtonClick;
            // 
            // loginTypeComboBox
            // 
            this.loginTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.loginTypeComboBox.FormattingEnabled = true;
            this.loginTypeComboBox.Location = new Point(129, 12);
            this.loginTypeComboBox.Name = "loginTypeComboBox";
            this.loginTypeComboBox.Size = new Size(242, 23);
            this.loginTypeComboBox.TabIndex = 2;
            this.loginTypeComboBox.SelectedIndexChanged += this.HandleLoginTypeComboBoxSelectedIndexChanged;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(111, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Typ der Anmeldung";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new Point(12, 44);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new Size(83, 15);
            this.usernameLabel.TabIndex = 4;
            this.usernameLabel.Text = "Benutzername";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new Point(129, 41);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new Size(242, 23);
            this.usernameTextBox.TabIndex = 5;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new Point(12, 73);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new Size(54, 15);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Passwort";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new Point(129, 70);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new Size(242, 23);
            this.passwordTextBox.TabIndex = 6;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new Size(383, 199);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginTypeComboBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button loginButton;
        private ComboBox loginTypeComboBox;
        private Label label1;
        private Label usernameLabel;
        private TextBox usernameTextBox;
        private Label passwordLabel;
        private TextBox passwordTextBox;
    }
}