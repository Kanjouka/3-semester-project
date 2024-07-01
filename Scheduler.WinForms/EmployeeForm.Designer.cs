namespace Scheduler.WinForms
{
    partial class EmployeeForm
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
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            deleteBtn = new Button();
            createBtn = new Button();
            editBtn = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            employeeIdTextBox = new TextBox();
            firstNameLbl = new Label();
            firstNameTextBox = new TextBox();
            lastNameLbl = new Label();
            emailLbl = new Label();
            streetNameLbl = new Label();
            zipCodeLbl = new Label();
            employeeIdLbl = new Label();
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
            employeeListBox = new ListBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(employeeListBox);
            splitContainer1.Size = new Size(916, 558);
            splitContainer1.SplitterDistance = 609;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tableLayoutPanel1.Controls.Add(deleteBtn, 2, 0);
            tableLayoutPanel1.Controls.Add(createBtn, 0, 0);
            tableLayoutPanel1.Controls.Add(editBtn, 1, 0);
            tableLayoutPanel1.Location = new Point(185, 434);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(4);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(368, 94);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // deleteBtn
            // 
            deleteBtn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            deleteBtn.Location = new Point(247, 29);
            deleteBtn.Margin = new Padding(3, 2, 3, 2);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(114, 35);
            deleteBtn.TabIndex = 13;
            deleteBtn.Text = "&Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // createBtn
            // 
            createBtn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            createBtn.Location = new Point(7, 29);
            createBtn.Margin = new Padding(3, 2, 3, 2);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(116, 35);
            createBtn.TabIndex = 11;
            createBtn.Text = "&Create";
            createBtn.UseVisualStyleBackColor = true;
            createBtn.Click += createBtn_Click;
            // 
            // editBtn
            // 
            editBtn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            editBtn.Location = new Point(129, 29);
            editBtn.Margin = new Padding(3, 2, 3, 2);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(112, 35);
            editBtn.TabIndex = 12;
            editBtn.Text = "&Edit";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(employeeIdTextBox, 0, 9);
            tableLayoutPanel2.Controls.Add(firstNameLbl, 0, 0);
            tableLayoutPanel2.Controls.Add(firstNameTextBox, 0, 1);
            tableLayoutPanel2.Controls.Add(lastNameLbl, 1, 0);
            tableLayoutPanel2.Controls.Add(emailLbl, 0, 2);
            tableLayoutPanel2.Controls.Add(streetNameLbl, 0, 4);
            tableLayoutPanel2.Controls.Add(zipCodeLbl, 0, 6);
            tableLayoutPanel2.Controls.Add(employeeIdLbl, 0, 8);
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
            tableLayoutPanel2.Location = new Point(44, 31);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
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
            tableLayoutPanel2.Size = new Size(459, 380);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // employeeIdTextBox
            // 
            employeeIdTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            employeeIdTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            employeeIdTextBox.Location = new Point(3, 344);
            employeeIdTextBox.Margin = new Padding(3, 2, 3, 2);
            employeeIdTextBox.Name = "employeeIdTextBox";
            employeeIdTextBox.Size = new Size(223, 29);
            employeeIdTextBox.TabIndex = 9;
            // 
            // firstNameLbl
            // 
            firstNameLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            firstNameLbl.AutoSize = true;
            firstNameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLbl.Location = new Point(3, 17);
            firstNameLbl.Name = "firstNameLbl";
            firstNameLbl.Size = new Size(86, 21);
            firstNameLbl.TabIndex = 0;
            firstNameLbl.Text = "First Name";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            firstNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameTextBox.Location = new Point(3, 40);
            firstNameTextBox.Margin = new Padding(3, 2, 3, 2);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(223, 29);
            firstNameTextBox.TabIndex = 1;
            // 
            // lastNameLbl
            // 
            lastNameLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lastNameLbl.AutoSize = true;
            lastNameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLbl.Location = new Point(232, 17);
            lastNameLbl.Name = "lastNameLbl";
            lastNameLbl.Size = new Size(84, 21);
            lastNameLbl.TabIndex = 2;
            lastNameLbl.Text = "Last Name";
            // 
            // emailLbl
            // 
            emailLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            emailLbl.AutoSize = true;
            emailLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailLbl.Location = new Point(3, 93);
            emailLbl.Name = "emailLbl";
            emailLbl.Size = new Size(48, 21);
            emailLbl.TabIndex = 3;
            emailLbl.Text = "Email";
            // 
            // streetNameLbl
            // 
            streetNameLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            streetNameLbl.AutoSize = true;
            streetNameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            streetNameLbl.Location = new Point(3, 169);
            streetNameLbl.Name = "streetNameLbl";
            streetNameLbl.Size = new Size(96, 21);
            streetNameLbl.TabIndex = 4;
            streetNameLbl.Text = "Street Name";
            // 
            // zipCodeLbl
            // 
            zipCodeLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            zipCodeLbl.AutoSize = true;
            zipCodeLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            zipCodeLbl.Location = new Point(3, 245);
            zipCodeLbl.Name = "zipCodeLbl";
            zipCodeLbl.Size = new Size(72, 21);
            zipCodeLbl.TabIndex = 5;
            zipCodeLbl.Text = "Zip Code";
            // 
            // employeeIdLbl
            // 
            employeeIdLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            employeeIdLbl.AutoSize = true;
            employeeIdLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            employeeIdLbl.Location = new Point(3, 321);
            employeeIdLbl.Name = "employeeIdLbl";
            employeeIdLbl.Size = new Size(97, 21);
            employeeIdLbl.TabIndex = 6;
            employeeIdLbl.Text = "Employee ID";
            // 
            // phoneNumberLbl
            // 
            phoneNumberLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            phoneNumberLbl.AutoSize = true;
            phoneNumberLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            phoneNumberLbl.Location = new Point(232, 93);
            phoneNumberLbl.Name = "phoneNumberLbl";
            phoneNumberLbl.Size = new Size(116, 21);
            phoneNumberLbl.TabIndex = 7;
            phoneNumberLbl.Text = "Phone Number";
            // 
            // streetNumberLbl
            // 
            streetNumberLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            streetNumberLbl.AutoSize = true;
            streetNumberLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            streetNumberLbl.Location = new Point(232, 169);
            streetNumberLbl.Name = "streetNumberLbl";
            streetNumberLbl.Size = new Size(112, 21);
            streetNumberLbl.TabIndex = 8;
            streetNumberLbl.Text = "Street Number";
            // 
            // cityLbl
            // 
            cityLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cityLbl.AutoSize = true;
            cityLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cityLbl.Location = new Point(232, 245);
            cityLbl.Name = "cityLbl";
            cityLbl.Size = new Size(37, 21);
            cityLbl.TabIndex = 9;
            cityLbl.Text = "City";
            // 
            // roleLbl
            // 
            roleLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            roleLbl.AutoSize = true;
            roleLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            roleLbl.Location = new Point(232, 321);
            roleLbl.Name = "roleLbl";
            roleLbl.Size = new Size(41, 21);
            roleLbl.TabIndex = 10;
            roleLbl.Text = "Role";
            // 
            // zipCodeTextBox
            // 
            zipCodeTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            zipCodeTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            zipCodeTextBox.Location = new Point(3, 268);
            zipCodeTextBox.Margin = new Padding(3, 2, 3, 2);
            zipCodeTextBox.Name = "zipCodeTextBox";
            zipCodeTextBox.Size = new Size(223, 29);
            zipCodeTextBox.TabIndex = 7;
            // 
            // cityTextBox
            // 
            cityTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cityTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cityTextBox.Location = new Point(232, 268);
            cityTextBox.Margin = new Padding(3, 2, 3, 2);
            cityTextBox.Name = "cityTextBox";
            cityTextBox.Size = new Size(224, 29);
            cityTextBox.TabIndex = 8;
            // 
            // streetNameTextBox
            // 
            streetNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            streetNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            streetNameTextBox.Location = new Point(3, 192);
            streetNameTextBox.Margin = new Padding(3, 2, 3, 2);
            streetNameTextBox.Name = "streetNameTextBox";
            streetNameTextBox.Size = new Size(223, 29);
            streetNameTextBox.TabIndex = 5;
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            phoneNumberTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            phoneNumberTextBox.Location = new Point(232, 116);
            phoneNumberTextBox.Margin = new Padding(3, 2, 3, 2);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.Size = new Size(224, 29);
            phoneNumberTextBox.TabIndex = 4;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lastNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameTextBox.Location = new Point(232, 40);
            lastNameTextBox.Margin = new Padding(3, 2, 3, 2);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(224, 29);
            lastNameTextBox.TabIndex = 2;
            // 
            // streetNumberTextBox
            // 
            streetNumberTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            streetNumberTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            streetNumberTextBox.Location = new Point(232, 192);
            streetNumberTextBox.Margin = new Padding(3, 2, 3, 2);
            streetNumberTextBox.Name = "streetNumberTextBox";
            streetNumberTextBox.Size = new Size(224, 29);
            streetNumberTextBox.TabIndex = 6;
            // 
            // emailTextBox
            // 
            emailTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            emailTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailTextBox.Location = new Point(3, 116);
            emailTextBox.Margin = new Padding(3, 2, 3, 2);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(223, 29);
            emailTextBox.TabIndex = 3;
            // 
            // roleComboBox
            // 
            roleComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Items.AddRange(new object[] { "Admin", "Manager", "Employee" });
            roleComboBox.Location = new Point(232, 344);
            roleComboBox.Margin = new Padding(3, 2, 3, 2);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(224, 23);
            roleComboBox.TabIndex = 11;
            // 
            // employeeListBox
            // 
            employeeListBox.Dock = DockStyle.Fill;
            employeeListBox.FormattingEnabled = true;
            employeeListBox.ItemHeight = 15;
            employeeListBox.Location = new Point(0, 0);
            employeeListBox.Name = "employeeListBox";
            employeeListBox.Size = new Size(303, 558);
            employeeListBox.TabIndex = 0;
            employeeListBox.SelectedIndexChanged += employeeListBox_SelectedIndexChanged;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 558);
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "EmployeeForm";
            Text = "EmployeeForm";
            Load += EmployeeForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button deleteBtn;
        private Button editBtn;
        private Button createBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label firstNameLbl;
        private TextBox firstNameTextBox;
        private Label lastNameLbl;
        private Label emailLbl;
        private Label streetNameLbl;
        private Label zipCodeLbl;
        private Label employeeIdLbl;
        private Label phoneNumberLbl;
        private Label streetNumberLbl;
        private Label cityLbl;
        private Label roleLbl;
        private TextBox employeeIdTextBox;
        private TextBox zipCodeTextBox;
        private TextBox cityTextBox;
        private TextBox streetNameTextBox;
        private TextBox emailTextBox;
        private TextBox phoneNumberTextBox;
        private TextBox lastNameTextBox;
        private TextBox streetNumberTextBox;
        private ListBox employeeListBox;
        private ComboBox roleComboBox;
    }
}