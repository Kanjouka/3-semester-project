namespace Scheduler.WinForms
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
            emailTextBox = new TextBox();
            emailLbl = new Label();
            schedulerLbl = new Label();
            passwordLbl = new Label();
            passwordTextBox = new TextBox();
            loginBtn = new Button();
            SuspendLayout();
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(313, 189);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(166, 27);
            emailTextBox.TabIndex = 0;
            // 
            // emailLbl
            // 
            emailLbl.AutoSize = true;
            emailLbl.Location = new Point(313, 166);
            emailLbl.Name = "emailLbl";
            emailLbl.Size = new Size(46, 20);
            emailLbl.TabIndex = 1;
            emailLbl.Text = "Email";
            // 
            // schedulerLbl
            // 
            schedulerLbl.AutoSize = true;
            schedulerLbl.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            schedulerLbl.Location = new Point(249, 49);
            schedulerLbl.Name = "schedulerLbl";
            schedulerLbl.Size = new Size(312, 81);
            schedulerLbl.TabIndex = 2;
            schedulerLbl.Text = "Scheduler";
            // 
            // passwordLbl
            // 
            passwordLbl.AutoSize = true;
            passwordLbl.Location = new Point(313, 237);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(70, 20);
            passwordLbl.TabIndex = 4;
            passwordLbl.Text = "Password\r\n";
            passwordLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(313, 260);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(166, 27);
            passwordTextBox.TabIndex = 3;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(346, 316);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(100, 36);
            loginBtn.TabIndex = 5;
            loginBtn.Text = "&Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginLbl_Click;
            // 
            // LoginForm
            // 
            AcceptButton = loginBtn;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginBtn);
            Controls.Add(passwordLbl);
            Controls.Add(passwordTextBox);
            Controls.Add(schedulerLbl);
            Controls.Add(emailLbl);
            Controls.Add(emailTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox emailTextBox;
        private Label emailLbl;
        private Label schedulerLbl;
        private Label passwordLbl;
        private TextBox passwordTextBox;
        private Button loginBtn;
    }
}