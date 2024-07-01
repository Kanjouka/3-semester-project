namespace Scheduler.WinForms
{
    partial class CreateEmployeeForm
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
            tableLayoutPanel2 = new TableLayoutPanel();
            passwordTextBox = new TextBox();
            firstNameLbl = new Label();
            firstNameTextBox = new TextBox();
            lastNameLbl = new Label();
            emailLbl = new Label();
            streetNameLbl = new Label();
            zipCodeLbl = new Label();
            passwordLbl = new Label();
            phoneNumberLbl = new Label();
            streetNumberLbl = new Label();
            cityLbl = new Label();
            roleLbl = new Label();
            zipCodeTextBox = new TextBox();
            cityTextBox = new TextBox();
            streetNameTextBox = new TextBox();
            phoneNumberTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            streetNumberTextBox = new TextBox();
            emailTextBox = new TextBox();
            roleComboBox = new ComboBox();
            createBtn = new Button();
            cancelBtn = new Button();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(passwordTextBox, 0, 9);
            tableLayoutPanel2.Controls.Add(firstNameLbl, 0, 0);
            tableLayoutPanel2.Controls.Add(firstNameTextBox, 0, 1);
            tableLayoutPanel2.Controls.Add(lastNameLbl, 1, 0);
            tableLayoutPanel2.Controls.Add(emailLbl, 0, 2);
            tableLayoutPanel2.Controls.Add(streetNameLbl, 0, 4);
            tableLayoutPanel2.Controls.Add(zipCodeLbl, 0, 6);
            tableLayoutPanel2.Controls.Add(passwordLbl, 0, 8);
            tableLayoutPanel2.Controls.Add(phoneNumberLbl, 1, 2);
            tableLayoutPanel2.Controls.Add(streetNumberLbl, 1, 4);
            tableLayoutPanel2.Controls.Add(cityLbl, 1, 6);
            tableLayoutPanel2.Controls.Add(roleLbl, 1, 8);
            tableLayoutPanel2.Controls.Add(zipCodeTextBox, 0, 7);
            tableLayoutPanel2.Controls.Add(cityTextBox, 1, 7);
            tableLayoutPanel2.Controls.Add(streetNameTextBox, 0, 5);
            tableLayoutPanel2.Controls.Add(phoneNumberTextBox, 1, 3);
            tableLayoutPanel2.Controls.Add(lastNameTextBox, 1, 1);
            tableLayoutPanel2.Controls.Add(streetNumberTextBox, 1, 5);
            tableLayoutPanel2.Controls.Add(emailTextBox, 0, 3);
            tableLayoutPanel2.Controls.Add(roleComboBox, 1, 9);
            tableLayoutPanel2.Location = new Point(138, 61);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 10;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.Size = new Size(525, 507);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            passwordTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordTextBox.Location = new Point(3, 453);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(256, 34);
            passwordTextBox.TabIndex = 9;
            // 
            // firstNameLbl
            // 
            firstNameLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            firstNameLbl.AutoSize = true;
            firstNameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLbl.Location = new Point(3, 22);
            firstNameLbl.Name = "firstNameLbl";
            firstNameLbl.Size = new Size(106, 28);
            firstNameLbl.TabIndex = 0;
            firstNameLbl.Text = "First Name";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            firstNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameTextBox.Location = new Point(3, 53);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(256, 34);
            firstNameTextBox.TabIndex = 1;
            // 
            // lastNameLbl
            // 
            lastNameLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lastNameLbl.AutoSize = true;
            lastNameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLbl.Location = new Point(265, 22);
            lastNameLbl.Name = "lastNameLbl";
            lastNameLbl.Size = new Size(103, 28);
            lastNameLbl.TabIndex = 2;
            lastNameLbl.Text = "Last Name";
            // 
            // emailLbl
            // 
            emailLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            emailLbl.AutoSize = true;
            emailLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailLbl.Location = new Point(3, 122);
            emailLbl.Name = "emailLbl";
            emailLbl.Size = new Size(59, 28);
            emailLbl.TabIndex = 3;
            emailLbl.Text = "Email";
            // 
            // streetNameLbl
            // 
            streetNameLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            streetNameLbl.AutoSize = true;
            streetNameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            streetNameLbl.Location = new Point(3, 222);
            streetNameLbl.Name = "streetNameLbl";
            streetNameLbl.Size = new Size(120, 28);
            streetNameLbl.TabIndex = 4;
            streetNameLbl.Text = "Street Name";
            // 
            // zipCodeLbl
            // 
            zipCodeLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            zipCodeLbl.AutoSize = true;
            zipCodeLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            zipCodeLbl.Location = new Point(3, 322);
            zipCodeLbl.Name = "zipCodeLbl";
            zipCodeLbl.Size = new Size(91, 28);
            zipCodeLbl.TabIndex = 5;
            zipCodeLbl.Text = "Zip Code";
            // 
            // passwordLbl
            // 
            passwordLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            passwordLbl.AutoSize = true;
            passwordLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordLbl.Location = new Point(3, 422);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(93, 28);
            passwordLbl.TabIndex = 6;
            passwordLbl.Text = "Password";
            // 
            // phoneNumberLbl
            // 
            phoneNumberLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            phoneNumberLbl.AutoSize = true;
            phoneNumberLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            phoneNumberLbl.Location = new Point(265, 122);
            phoneNumberLbl.Name = "phoneNumberLbl";
            phoneNumberLbl.Size = new Size(144, 28);
            phoneNumberLbl.TabIndex = 7;
            phoneNumberLbl.Text = "Phone Number";
            // 
            // streetNumberLbl
            // 
            streetNumberLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            streetNumberLbl.AutoSize = true;
            streetNumberLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            streetNumberLbl.Location = new Point(265, 222);
            streetNumberLbl.Name = "streetNumberLbl";
            streetNumberLbl.Size = new Size(140, 28);
            streetNumberLbl.TabIndex = 8;
            streetNumberLbl.Text = "Street Number";
            // 
            // cityLbl
            // 
            cityLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cityLbl.AutoSize = true;
            cityLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cityLbl.Location = new Point(265, 322);
            cityLbl.Name = "cityLbl";
            cityLbl.Size = new Size(46, 28);
            cityLbl.TabIndex = 9;
            cityLbl.Text = "City";
            // 
            // roleLbl
            // 
            roleLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            roleLbl.AutoSize = true;
            roleLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            roleLbl.Location = new Point(265, 422);
            roleLbl.Name = "roleLbl";
            roleLbl.Size = new Size(50, 28);
            roleLbl.TabIndex = 10;
            roleLbl.Text = "Role";
            // 
            // zipCodeTextBox
            // 
            zipCodeTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            zipCodeTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            zipCodeTextBox.Location = new Point(3, 353);
            zipCodeTextBox.Name = "zipCodeTextBox";
            zipCodeTextBox.Size = new Size(256, 34);
            zipCodeTextBox.TabIndex = 7;
            // 
            // cityTextBox
            // 
            cityTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cityTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cityTextBox.Location = new Point(265, 353);
            cityTextBox.Name = "cityTextBox";
            cityTextBox.Size = new Size(257, 34);
            cityTextBox.TabIndex = 8;
            // 
            // streetNameTextBox
            // 
            streetNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            streetNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            streetNameTextBox.Location = new Point(3, 253);
            streetNameTextBox.Name = "streetNameTextBox";
            streetNameTextBox.Size = new Size(256, 34);
            streetNameTextBox.TabIndex = 5;
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            phoneNumberTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            phoneNumberTextBox.Location = new Point(265, 153);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.Size = new Size(257, 34);
            phoneNumberTextBox.TabIndex = 4;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lastNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameTextBox.Location = new Point(265, 53);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(257, 34);
            lastNameTextBox.TabIndex = 2;
            // 
            // streetNumberTextBox
            // 
            streetNumberTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            streetNumberTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            streetNumberTextBox.Location = new Point(265, 253);
            streetNumberTextBox.Name = "streetNumberTextBox";
            streetNumberTextBox.Size = new Size(257, 34);
            streetNumberTextBox.TabIndex = 6;
            // 
            // emailTextBox
            // 
            emailTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            emailTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailTextBox.Location = new Point(3, 153);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(256, 34);
            emailTextBox.TabIndex = 3;
            // 
            // roleComboBox
            // 
            roleComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Items.AddRange(new object[] { "Admin", "Manager", "Employee" });
            roleComboBox.Location = new Point(265, 453);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(257, 28);
            roleComboBox.TabIndex = 11;
            // 
            // createBtn
            // 
            createBtn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            createBtn.Location = new Point(251, 607);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(133, 47);
            createBtn.TabIndex = 12;
            createBtn.Text = "&Create";
            createBtn.UseVisualStyleBackColor = true;
            createBtn.Click += createBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cancelBtn.Location = new Point(414, 607);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(133, 47);
            cancelBtn.TabIndex = 13;
            cancelBtn.Text = "&Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // CreateEmployeeForm
            // 
            AcceptButton = createBtn;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(864, 693);
            Controls.Add(cancelBtn);
            Controls.Add(createBtn);
            Controls.Add(tableLayoutPanel2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CreateEmployeeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Scheduler";
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private TextBox passwordTextBox;
        private Label firstNameLbl;
        private TextBox firstNameTextBox;
        private Label lastNameLbl;
        private Label emailLbl;
        private Label streetNameLbl;
        private Label zipCodeLbl;
        private Label passwordLbl;
        private Label phoneNumberLbl;
        private Label streetNumberLbl;
        private Label cityLbl;
        private Label roleLbl;
        private TextBox zipCodeTextBox;
        private TextBox cityTextBox;
        private TextBox streetNameTextBox;
        private TextBox phoneNumberTextBox;
        private TextBox lastNameTextBox;
        private TextBox streetNumberTextBox;
        private TextBox emailTextBox;
        private Button createBtn;
        private Button cancelBtn;
        private ComboBox roleComboBox;
    }
}