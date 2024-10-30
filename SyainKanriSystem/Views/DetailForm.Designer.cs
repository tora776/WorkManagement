namespace SyainKanriSystem
{
    partial class EmployeeDetailForm
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
            this.label9 = new System.Windows.Forms.Label();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_BackEmployeeShow = new System.Windows.Forms.Button();
            this.dateTimePicker_HireDate = new System.Windows.Forms.DateTimePicker();
            this.label_MeiKana = new System.Windows.Forms.Label();
            this.label_Mei = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_PhoneNumber3 = new System.Windows.Forms.TextBox();
            this.textBox_PhoneNumber2 = new System.Windows.Forms.TextBox();
            this.textBox_PhoneNumber1 = new System.Windows.Forms.TextBox();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.textBox_MeiKana = new System.Windows.Forms.TextBox();
            this.textBox_SeiKana = new System.Windows.Forms.TextBox();
            this.textBox_Mei = new System.Windows.Forms.TextBox();
            this.textBox_Sei = new System.Windows.Forms.TextBox();
            this.textBox_EmployeeID = new System.Windows.Forms.TextBox();
            this.label_HireDate = new System.Windows.Forms.Label();
            this.label_PhoneNumber = new System.Windows.Forms.Label();
            this.label_Email = new System.Windows.Forms.Label();
            this.label_SeiKana = new System.Windows.Forms.Label();
            this.label_Sei = new System.Windows.Forms.Label();
            this.label_EmployeeID = new System.Windows.Forms.Label();
            this.comboBox_Position = new System.Windows.Forms.ComboBox();
            this.comboBox_Department = new System.Windows.Forms.ComboBox();
            this.comboBox_Status = new System.Windows.Forms.ComboBox();
            this.label_Status = new System.Windows.Forms.Label();
            this.label_Position = new System.Windows.Forms.Label();
            this.label_Department = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("メイリオ", 14F);
            this.label9.Location = new System.Drawing.Point(34, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 28);
            this.label9.TabIndex = 28;
            this.label9.Text = "社員詳細表示";
            // 
            // button_Edit
            // 
            this.button_Edit.Location = new System.Drawing.Point(71, 499);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(118, 48);
            this.button_Edit.TabIndex = 55;
            this.button_Edit.Text = "編集";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.Button_EditForm);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(275, 499);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(118, 48);
            this.button_Delete.TabIndex = 56;
            this.button_Delete.Text = "削除";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.Button_DeleteEmployee);
            // 
            // button_BackEmployeeShow
            // 
            this.button_BackEmployeeShow.Location = new System.Drawing.Point(260, 17);
            this.button_BackEmployeeShow.Name = "button_BackEmployeeShow";
            this.button_BackEmployeeShow.Size = new System.Drawing.Size(118, 48);
            this.button_BackEmployeeShow.TabIndex = 57;
            this.button_BackEmployeeShow.Text = "社員一覧に戻る";
            this.button_BackEmployeeShow.UseVisualStyleBackColor = true;
            this.button_BackEmployeeShow.Click += new System.EventHandler(this.Button_CloseDetailForm);
            // 
            // dateTimePicker_HireDate
            // 
            this.dateTimePicker_HireDate.Enabled = false;
            this.dateTimePicker_HireDate.Location = new System.Drawing.Point(106, 349);
            this.dateTimePicker_HireDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker_HireDate.Name = "dateTimePicker_HireDate";
            this.dateTimePicker_HireDate.Size = new System.Drawing.Size(122, 19);
            this.dateTimePicker_HireDate.TabIndex = 68;
            // 
            // label_MeiKana
            // 
            this.label_MeiKana.AutoSize = true;
            this.label_MeiKana.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_MeiKana.Location = new System.Drawing.Point(22, 233);
            this.label_MeiKana.Name = "label_MeiKana";
            this.label_MeiKana.Size = new System.Drawing.Size(61, 15);
            this.label_MeiKana.TabIndex = 78;
            this.label_MeiKana.Text = "名（カナ）";
            // 
            // label_Mei
            // 
            this.label_Mei.AutoSize = true;
            this.label_Mei.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Mei.Location = new System.Drawing.Point(22, 163);
            this.label_Mei.Name = "label_Mei";
            this.label_Mei.Size = new System.Drawing.Size(22, 15);
            this.label_Mei.TabIndex = 77;
            this.label_Mei.Text = "名";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(241, 315);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 69;
            this.label12.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(166, 315);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 76;
            this.label11.Text = "-";
            // 
            // textBox_PhoneNumber3
            // 
            this.textBox_PhoneNumber3.Enabled = false;
            this.textBox_PhoneNumber3.Location = new System.Drawing.Point(256, 311);
            this.textBox_PhoneNumber3.Name = "textBox_PhoneNumber3";
            this.textBox_PhoneNumber3.Size = new System.Drawing.Size(55, 19);
            this.textBox_PhoneNumber3.TabIndex = 67;
            // 
            // textBox_PhoneNumber2
            // 
            this.textBox_PhoneNumber2.Enabled = false;
            this.textBox_PhoneNumber2.Location = new System.Drawing.Point(181, 311);
            this.textBox_PhoneNumber2.Name = "textBox_PhoneNumber2";
            this.textBox_PhoneNumber2.Size = new System.Drawing.Size(55, 19);
            this.textBox_PhoneNumber2.TabIndex = 66;
            // 
            // textBox_PhoneNumber1
            // 
            this.textBox_PhoneNumber1.Enabled = false;
            this.textBox_PhoneNumber1.Location = new System.Drawing.Point(106, 311);
            this.textBox_PhoneNumber1.Name = "textBox_PhoneNumber1";
            this.textBox_PhoneNumber1.Size = new System.Drawing.Size(55, 19);
            this.textBox_PhoneNumber1.TabIndex = 65;
            // 
            // textBox_Email
            // 
            this.textBox_Email.Enabled = false;
            this.textBox_Email.Location = new System.Drawing.Point(106, 271);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(341, 19);
            this.textBox_Email.TabIndex = 64;
            // 
            // textBox_MeiKana
            // 
            this.textBox_MeiKana.Enabled = false;
            this.textBox_MeiKana.Location = new System.Drawing.Point(106, 233);
            this.textBox_MeiKana.Name = "textBox_MeiKana";
            this.textBox_MeiKana.Size = new System.Drawing.Size(254, 19);
            this.textBox_MeiKana.TabIndex = 63;
            // 
            // textBox_SeiKana
            // 
            this.textBox_SeiKana.Enabled = false;
            this.textBox_SeiKana.Location = new System.Drawing.Point(106, 197);
            this.textBox_SeiKana.Name = "textBox_SeiKana";
            this.textBox_SeiKana.Size = new System.Drawing.Size(254, 19);
            this.textBox_SeiKana.TabIndex = 62;
            // 
            // textBox_Mei
            // 
            this.textBox_Mei.Enabled = false;
            this.textBox_Mei.Location = new System.Drawing.Point(106, 161);
            this.textBox_Mei.Name = "textBox_Mei";
            this.textBox_Mei.Size = new System.Drawing.Size(254, 19);
            this.textBox_Mei.TabIndex = 61;
            // 
            // textBox_Sei
            // 
            this.textBox_Sei.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Sei.Enabled = false;
            this.textBox_Sei.Location = new System.Drawing.Point(106, 126);
            this.textBox_Sei.Name = "textBox_Sei";
            this.textBox_Sei.Size = new System.Drawing.Size(254, 19);
            this.textBox_Sei.TabIndex = 60;
            // 
            // textBox_EmployeeID
            // 
            this.textBox_EmployeeID.Enabled = false;
            this.textBox_EmployeeID.Location = new System.Drawing.Point(106, 89);
            this.textBox_EmployeeID.Name = "textBox_EmployeeID";
            this.textBox_EmployeeID.Size = new System.Drawing.Size(100, 19);
            this.textBox_EmployeeID.TabIndex = 59;
            // 
            // label_HireDate
            // 
            this.label_HireDate.AutoSize = true;
            this.label_HireDate.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_HireDate.Location = new System.Drawing.Point(22, 351);
            this.label_HireDate.Name = "label_HireDate";
            this.label_HireDate.Size = new System.Drawing.Size(52, 15);
            this.label_HireDate.TabIndex = 75;
            this.label_HireDate.Text = "雇用日";
            // 
            // label_PhoneNumber
            // 
            this.label_PhoneNumber.AutoSize = true;
            this.label_PhoneNumber.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_PhoneNumber.Location = new System.Drawing.Point(22, 312);
            this.label_PhoneNumber.Name = "label_PhoneNumber";
            this.label_PhoneNumber.Size = new System.Drawing.Size(67, 15);
            this.label_PhoneNumber.TabIndex = 74;
            this.label_PhoneNumber.Text = "電話番号";
            // 
            // label_Email
            // 
            this.label_Email.AutoSize = true;
            this.label_Email.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Email.Location = new System.Drawing.Point(22, 272);
            this.label_Email.Name = "label_Email";
            this.label_Email.Size = new System.Drawing.Size(85, 15);
            this.label_Email.TabIndex = 73;
            this.label_Email.Text = "メールアドレス";
            // 
            // label_SeiKana
            // 
            this.label_SeiKana.AutoSize = true;
            this.label_SeiKana.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_SeiKana.Location = new System.Drawing.Point(22, 199);
            this.label_SeiKana.Name = "label_SeiKana";
            this.label_SeiKana.Size = new System.Drawing.Size(61, 15);
            this.label_SeiKana.TabIndex = 72;
            this.label_SeiKana.Text = "姓（カナ）";
            // 
            // label_Sei
            // 
            this.label_Sei.AutoSize = true;
            this.label_Sei.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Sei.Location = new System.Drawing.Point(22, 126);
            this.label_Sei.Name = "label_Sei";
            this.label_Sei.Size = new System.Drawing.Size(22, 15);
            this.label_Sei.TabIndex = 71;
            this.label_Sei.Text = "姓";
            // 
            // label_EmployeeID
            // 
            this.label_EmployeeID.AutoSize = true;
            this.label_EmployeeID.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_EmployeeID.Location = new System.Drawing.Point(22, 90);
            this.label_EmployeeID.Name = "label_EmployeeID";
            this.label_EmployeeID.Size = new System.Drawing.Size(67, 15);
            this.label_EmployeeID.TabIndex = 70;
            this.label_EmployeeID.Text = "社員番号";
            // 
            // comboBox_Position
            // 
            this.comboBox_Position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Position.Enabled = false;
            this.comboBox_Position.FormattingEnabled = true;
            this.comboBox_Position.Location = new System.Drawing.Point(106, 423);
            this.comboBox_Position.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Position.Name = "comboBox_Position";
            this.comboBox_Position.Size = new System.Drawing.Size(99, 20);
            this.comboBox_Position.TabIndex = 80;
            // 
            // comboBox_Department
            // 
            this.comboBox_Department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Department.Enabled = false;
            this.comboBox_Department.FormattingEnabled = true;
            this.comboBox_Department.Location = new System.Drawing.Point(106, 386);
            this.comboBox_Department.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Department.Name = "comboBox_Department";
            this.comboBox_Department.Size = new System.Drawing.Size(99, 20);
            this.comboBox_Department.TabIndex = 79;
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Status.Enabled = false;
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.Items.AddRange(new object[] {
            "在籍",
            "退職済"});
            this.comboBox_Status.Location = new System.Drawing.Point(106, 462);
            this.comboBox_Status.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(99, 20);
            this.comboBox_Status.TabIndex = 81;
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Status.Location = new System.Drawing.Point(22, 462);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(62, 15);
            this.label_Status.TabIndex = 84;
            this.label_Status.Text = "ステータス";
            // 
            // label_Position
            // 
            this.label_Position.AutoSize = true;
            this.label_Position.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Position.Location = new System.Drawing.Point(22, 423);
            this.label_Position.Name = "label_Position";
            this.label_Position.Size = new System.Drawing.Size(37, 15);
            this.label_Position.TabIndex = 83;
            this.label_Position.Text = "役職";
            // 
            // label_Department
            // 
            this.label_Department.AutoSize = true;
            this.label_Department.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Department.Location = new System.Drawing.Point(22, 386);
            this.label_Department.Name = "label_Department";
            this.label_Department.Size = new System.Drawing.Size(37, 15);
            this.label_Department.TabIndex = 82;
            this.label_Department.Text = "部門";
            // 
            // EmployeeDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 561);
            this.Controls.Add(this.comboBox_Position);
            this.Controls.Add(this.comboBox_Department);
            this.Controls.Add(this.comboBox_Status);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.label_Position);
            this.Controls.Add(this.label_Department);
            this.Controls.Add(this.dateTimePicker_HireDate);
            this.Controls.Add(this.label_MeiKana);
            this.Controls.Add(this.label_Mei);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_PhoneNumber3);
            this.Controls.Add(this.textBox_PhoneNumber2);
            this.Controls.Add(this.textBox_PhoneNumber1);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.textBox_MeiKana);
            this.Controls.Add(this.textBox_SeiKana);
            this.Controls.Add(this.textBox_Mei);
            this.Controls.Add(this.textBox_Sei);
            this.Controls.Add(this.textBox_EmployeeID);
            this.Controls.Add(this.label_HireDate);
            this.Controls.Add(this.label_PhoneNumber);
            this.Controls.Add(this.label_Email);
            this.Controls.Add(this.label_SeiKana);
            this.Controls.Add(this.label_Sei);
            this.Controls.Add(this.label_EmployeeID);
            this.Controls.Add(this.button_BackEmployeeShow);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.label9);
            this.Name = "EmployeeDetailForm";
            this.Text = "社員情報管理システム";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_BackEmployeeShow;
        private System.Windows.Forms.DateTimePicker dateTimePicker_HireDate;
        private System.Windows.Forms.Label label_MeiKana;
        private System.Windows.Forms.Label label_Mei;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_PhoneNumber3;
        private System.Windows.Forms.TextBox textBox_PhoneNumber2;
        private System.Windows.Forms.TextBox textBox_PhoneNumber1;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.TextBox textBox_MeiKana;
        private System.Windows.Forms.TextBox textBox_SeiKana;
        private System.Windows.Forms.TextBox textBox_Mei;
        private System.Windows.Forms.TextBox textBox_Sei;
        private System.Windows.Forms.TextBox textBox_EmployeeID;
        private System.Windows.Forms.Label label_HireDate;
        private System.Windows.Forms.Label label_PhoneNumber;
        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.Label label_SeiKana;
        private System.Windows.Forms.Label label_Sei;
        private System.Windows.Forms.Label label_EmployeeID;
        private System.Windows.Forms.ComboBox comboBox_Position;
        private System.Windows.Forms.ComboBox comboBox_Department;
        private System.Windows.Forms.ComboBox comboBox_Status;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Label label_Position;
        private System.Windows.Forms.Label label_Department;
    }
}