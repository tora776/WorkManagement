namespace SyainKanriSystem
{
    partial class EmployeeAddForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label_Email = new System.Windows.Forms.Label();
            this.label_PhoneNumber = new System.Windows.Forms.Label();
            this.label_HireDate = new System.Windows.Forms.Label();
            this.label_Position = new System.Windows.Forms.Label();
            this.button_Back = new System.Windows.Forms.Button();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.textBox_PhoneNumber1 = new System.Windows.Forms.TextBox();
            this.textBox_PhoneNumber2 = new System.Windows.Forms.TextBox();
            this.textBox_PhoneNumber3 = new System.Windows.Forms.TextBox();
            this.dateTimePicker_HireDate = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Department = new System.Windows.Forms.ComboBox();
            this.comboBox_Position = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_Department = new System.Windows.Forms.Label();
            this.label_Position_Error = new System.Windows.Forms.Label();
            this.label_Department_Error = new System.Windows.Forms.Label();
            this.label_HireDate_Error = new System.Windows.Forms.Label();
            this.label_PhoneNumber_Error = new System.Windows.Forms.Label();
            this.label_Email_Error = new System.Windows.Forms.Label();
            this.label_MeiKana_Error = new System.Windows.Forms.Label();
            this.label_Mei_Error = new System.Windows.Forms.Label();
            this.label_SeiKana_Error = new System.Windows.Forms.Label();
            this.label_Sei_Error = new System.Windows.Forms.Label();
            this.label_MeiKana = new System.Windows.Forms.Label();
            this.label_Mei = new System.Windows.Forms.Label();
            this.textBox_MeiKana = new System.Windows.Forms.TextBox();
            this.textBox_SeiKana = new System.Windows.Forms.TextBox();
            this.textBox_Mei = new System.Windows.Forms.TextBox();
            this.textBox_Sei = new System.Windows.Forms.TextBox();
            this.label_SeiKana = new System.Windows.Forms.Label();
            this.label_Sei = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 14F);
            this.label1.Location = new System.Drawing.Point(57, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "社員追加";
            // 
            // label_Email
            // 
            this.label_Email.AutoSize = true;
            this.label_Email.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Email.Location = new System.Drawing.Point(43, 351);
            this.label_Email.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Email.Name = "label_Email";
            this.label_Email.Size = new System.Drawing.Size(128, 22);
            this.label_Email.TabIndex = 3;
            this.label_Email.Text = "メールアドレス";
            // 
            // label_PhoneNumber
            // 
            this.label_PhoneNumber.AutoSize = true;
            this.label_PhoneNumber.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_PhoneNumber.Location = new System.Drawing.Point(43, 406);
            this.label_PhoneNumber.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_PhoneNumber.Name = "label_PhoneNumber";
            this.label_PhoneNumber.Size = new System.Drawing.Size(98, 22);
            this.label_PhoneNumber.TabIndex = 5;
            this.label_PhoneNumber.Text = "電話番号";
            // 
            // label_HireDate
            // 
            this.label_HireDate.AutoSize = true;
            this.label_HireDate.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_HireDate.Location = new System.Drawing.Point(43, 463);
            this.label_HireDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_HireDate.Name = "label_HireDate";
            this.label_HireDate.Size = new System.Drawing.Size(76, 22);
            this.label_HireDate.TabIndex = 6;
            this.label_HireDate.Text = "雇用日";
            // 
            // label_Position
            // 
            this.label_Position.AutoSize = true;
            this.label_Position.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Position.Location = new System.Drawing.Point(43, 575);
            this.label_Position.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Position.Name = "label_Position";
            this.label_Position.Size = new System.Drawing.Size(54, 22);
            this.label_Position.TabIndex = 7;
            this.label_Position.Text = "役職";
            // 
            // button_Back
            // 
            this.button_Back.Location = new System.Drawing.Point(372, 13);
            this.button_Back.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(197, 72);
            this.button_Back.TabIndex = 0;
            this.button_Back.Text = "クリア";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.Button_Clear_Click);
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(183, 349);
            this.textBox_Email.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(421, 25);
            this.textBox_Email.TabIndex = 5;
            // 
            // textBox_PhoneNumber1
            // 
            this.textBox_PhoneNumber1.Location = new System.Drawing.Point(183, 406);
            this.textBox_PhoneNumber1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_PhoneNumber1.Name = "textBox_PhoneNumber1";
            this.textBox_PhoneNumber1.Size = new System.Drawing.Size(89, 25);
            this.textBox_PhoneNumber1.TabIndex = 6;
            // 
            // textBox_PhoneNumber2
            // 
            this.textBox_PhoneNumber2.Location = new System.Drawing.Point(308, 406);
            this.textBox_PhoneNumber2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_PhoneNumber2.Name = "textBox_PhoneNumber2";
            this.textBox_PhoneNumber2.Size = new System.Drawing.Size(89, 25);
            this.textBox_PhoneNumber2.TabIndex = 7;
            // 
            // textBox_PhoneNumber3
            // 
            this.textBox_PhoneNumber3.Location = new System.Drawing.Point(433, 406);
            this.textBox_PhoneNumber3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_PhoneNumber3.Name = "textBox_PhoneNumber3";
            this.textBox_PhoneNumber3.Size = new System.Drawing.Size(89, 25);
            this.textBox_PhoneNumber3.TabIndex = 8;
            // 
            // dateTimePicker_HireDate
            // 
            this.dateTimePicker_HireDate.Location = new System.Drawing.Point(182, 463);
            this.dateTimePicker_HireDate.Name = "dateTimePicker_HireDate";
            this.dateTimePicker_HireDate.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker_HireDate.TabIndex = 9;
            // 
            // comboBox_Department
            // 
            this.comboBox_Department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Department.FormattingEnabled = true;
            this.comboBox_Department.Location = new System.Drawing.Point(183, 518);
            this.comboBox_Department.Name = "comboBox_Department";
            this.comboBox_Department.Size = new System.Drawing.Size(162, 26);
            this.comboBox_Department.TabIndex = 10;
            this.comboBox_Department.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Department_SelectedIndexChanged);
            // 
            // comboBox_Position
            // 
            this.comboBox_Position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Position.FormattingEnabled = true;
            this.comboBox_Position.Location = new System.Drawing.Point(182, 575);
            this.comboBox_Position.Name = "comboBox_Position";
            this.comboBox_Position.Size = new System.Drawing.Size(163, 26);
            this.comboBox_Position.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(408, 412);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 18);
            this.label11.TabIndex = 25;
            this.label11.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(283, 412);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 18);
            this.label10.TabIndex = 26;
            this.label10.Text = "-";
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(118, 637);
            this.button_Add.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(197, 72);
            this.button_Add.TabIndex = 12;
            this.button_Add.Text = "追加";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(458, 637);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(217, 71);
            this.button_Cancel.TabIndex = 13;
            this.button_Cancel.Text = "キャンセル";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // label_Department
            // 
            this.label_Department.AutoSize = true;
            this.label_Department.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Department.Location = new System.Drawing.Point(43, 518);
            this.label_Department.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Department.Name = "label_Department";
            this.label_Department.Size = new System.Drawing.Size(54, 22);
            this.label_Department.TabIndex = 29;
            this.label_Department.Text = "部門";
            // 
            // label_Position_Error
            // 
            this.label_Position_Error.AutoSize = true;
            this.label_Position_Error.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Position_Error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label_Position_Error.Location = new System.Drawing.Point(179, 550);
            this.label_Position_Error.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Position_Error.Name = "label_Position_Error";
            this.label_Position_Error.Size = new System.Drawing.Size(76, 22);
            this.label_Position_Error.TabIndex = 72;
            this.label_Position_Error.Text = "※必須";
            // 
            // label_Department_Error
            // 
            this.label_Department_Error.AutoSize = true;
            this.label_Department_Error.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Department_Error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label_Department_Error.Location = new System.Drawing.Point(178, 493);
            this.label_Department_Error.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Department_Error.Name = "label_Department_Error";
            this.label_Department_Error.Size = new System.Drawing.Size(76, 22);
            this.label_Department_Error.TabIndex = 75;
            this.label_Department_Error.Text = "※必須";
            // 
            // label_HireDate_Error
            // 
            this.label_HireDate_Error.AutoSize = true;
            this.label_HireDate_Error.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_HireDate_Error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label_HireDate_Error.Location = new System.Drawing.Point(178, 436);
            this.label_HireDate_Error.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_HireDate_Error.Name = "label_HireDate_Error";
            this.label_HireDate_Error.Size = new System.Drawing.Size(268, 22);
            this.label_HireDate_Error.TabIndex = 76;
            this.label_HireDate_Error.Text = "※必須　半角数字のみ 11桁";
            // 
            // label_PhoneNumber_Error
            // 
            this.label_PhoneNumber_Error.AutoSize = true;
            this.label_PhoneNumber_Error.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_PhoneNumber_Error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label_PhoneNumber_Error.Location = new System.Drawing.Point(179, 379);
            this.label_PhoneNumber_Error.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_PhoneNumber_Error.Name = "label_PhoneNumber_Error";
            this.label_PhoneNumber_Error.Size = new System.Drawing.Size(249, 22);
            this.label_PhoneNumber_Error.TabIndex = 77;
            this.label_PhoneNumber_Error.Text = "※必須 半角数字のみ 4桁";
            // 
            // label_Email_Error
            // 
            this.label_Email_Error.AutoSize = true;
            this.label_Email_Error.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Email_Error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label_Email_Error.Location = new System.Drawing.Point(179, 322);
            this.label_Email_Error.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Email_Error.Name = "label_Email_Error";
            this.label_Email_Error.Size = new System.Drawing.Size(504, 22);
            this.label_Email_Error.TabIndex = 78;
            this.label_Email_Error.Text = "※必須 半角英数字一部記号のみ 255文字まで入力可";
            // 
            // label_MeiKana_Error
            // 
            this.label_MeiKana_Error.AutoSize = true;
            this.label_MeiKana_Error.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_MeiKana_Error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label_MeiKana_Error.Location = new System.Drawing.Point(179, 267);
            this.label_MeiKana_Error.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_MeiKana_Error.Name = "label_MeiKana_Error";
            this.label_MeiKana_Error.Size = new System.Drawing.Size(294, 22);
            this.label_MeiKana_Error.TabIndex = 91;
            this.label_MeiKana_Error.Text = "※必須 カタカナのみ 50文字まで\r\n";
            // 
            // label_Mei_Error
            // 
            this.label_Mei_Error.AutoSize = true;
            this.label_Mei_Error.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Mei_Error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label_Mei_Error.Location = new System.Drawing.Point(179, 157);
            this.label_Mei_Error.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Mei_Error.Name = "label_Mei_Error";
            this.label_Mei_Error.Size = new System.Drawing.Size(184, 22);
            this.label_Mei_Error.TabIndex = 90;
            this.label_Mei_Error.Text = "※必須 50文字まで";
            // 
            // label_SeiKana_Error
            // 
            this.label_SeiKana_Error.AutoSize = true;
            this.label_SeiKana_Error.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_SeiKana_Error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label_SeiKana_Error.Location = new System.Drawing.Point(179, 212);
            this.label_SeiKana_Error.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_SeiKana_Error.Name = "label_SeiKana_Error";
            this.label_SeiKana_Error.Size = new System.Drawing.Size(259, 22);
            this.label_SeiKana_Error.TabIndex = 89;
            this.label_SeiKana_Error.Text = "※必須 カタカナのみ 50文字";
            // 
            // label_Sei_Error
            // 
            this.label_Sei_Error.AutoSize = true;
            this.label_Sei_Error.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Sei_Error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label_Sei_Error.Location = new System.Drawing.Point(179, 99);
            this.label_Sei_Error.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Sei_Error.Name = "label_Sei_Error";
            this.label_Sei_Error.Size = new System.Drawing.Size(184, 22);
            this.label_Sei_Error.TabIndex = 88;
            this.label_Sei_Error.Text = "※必須 50文字まで";
            // 
            // label_MeiKana
            // 
            this.label_MeiKana.AutoSize = true;
            this.label_MeiKana.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_MeiKana.Location = new System.Drawing.Point(42, 293);
            this.label_MeiKana.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_MeiKana.Name = "label_MeiKana";
            this.label_MeiKana.Size = new System.Drawing.Size(88, 22);
            this.label_MeiKana.TabIndex = 87;
            this.label_MeiKana.Text = "名（カナ）";
            // 
            // label_Mei
            // 
            this.label_Mei.AutoSize = true;
            this.label_Mei.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Mei.Location = new System.Drawing.Point(42, 187);
            this.label_Mei.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Mei.Name = "label_Mei";
            this.label_Mei.Size = new System.Drawing.Size(32, 22);
            this.label_Mei.TabIndex = 86;
            this.label_Mei.Text = "名";
            // 
            // textBox_MeiKana
            // 
            this.textBox_MeiKana.Location = new System.Drawing.Point(182, 293);
            this.textBox_MeiKana.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_MeiKana.Name = "textBox_MeiKana";
            this.textBox_MeiKana.Size = new System.Drawing.Size(421, 25);
            this.textBox_MeiKana.TabIndex = 83;
            // 
            // textBox_SeiKana
            // 
            this.textBox_SeiKana.Location = new System.Drawing.Point(182, 238);
            this.textBox_SeiKana.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_SeiKana.Name = "textBox_SeiKana";
            this.textBox_SeiKana.Size = new System.Drawing.Size(421, 25);
            this.textBox_SeiKana.TabIndex = 82;
            // 
            // textBox_Mei
            // 
            this.textBox_Mei.Location = new System.Drawing.Point(182, 183);
            this.textBox_Mei.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_Mei.Name = "textBox_Mei";
            this.textBox_Mei.Size = new System.Drawing.Size(421, 25);
            this.textBox_Mei.TabIndex = 81;
            // 
            // textBox_Sei
            // 
            this.textBox_Sei.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Sei.Location = new System.Drawing.Point(182, 126);
            this.textBox_Sei.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_Sei.Name = "textBox_Sei";
            this.textBox_Sei.Size = new System.Drawing.Size(421, 25);
            this.textBox_Sei.TabIndex = 80;
            // 
            // label_SeiKana
            // 
            this.label_SeiKana.AutoSize = true;
            this.label_SeiKana.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_SeiKana.Location = new System.Drawing.Point(42, 242);
            this.label_SeiKana.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_SeiKana.Name = "label_SeiKana";
            this.label_SeiKana.Size = new System.Drawing.Size(88, 22);
            this.label_SeiKana.TabIndex = 85;
            this.label_SeiKana.Text = "姓（カナ）";
            // 
            // label_Sei
            // 
            this.label_Sei.AutoSize = true;
            this.label_Sei.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label_Sei.Location = new System.Drawing.Point(42, 126);
            this.label_Sei.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Sei.Name = "label_Sei";
            this.label_Sei.Size = new System.Drawing.Size(32, 22);
            this.label_Sei.TabIndex = 84;
            this.label_Sei.Text = "姓";
            // 
            // EmployeeAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 794);
            this.Controls.Add(this.label_MeiKana_Error);
            this.Controls.Add(this.label_Mei_Error);
            this.Controls.Add(this.label_SeiKana_Error);
            this.Controls.Add(this.label_Sei_Error);
            this.Controls.Add(this.label_MeiKana);
            this.Controls.Add(this.label_Mei);
            this.Controls.Add(this.textBox_MeiKana);
            this.Controls.Add(this.textBox_SeiKana);
            this.Controls.Add(this.textBox_Mei);
            this.Controls.Add(this.textBox_Sei);
            this.Controls.Add(this.label_SeiKana);
            this.Controls.Add(this.label_Sei);
            this.Controls.Add(this.label_Email_Error);
            this.Controls.Add(this.label_PhoneNumber_Error);
            this.Controls.Add(this.label_HireDate_Error);
            this.Controls.Add(this.label_Department_Error);
            this.Controls.Add(this.label_Position_Error);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.dateTimePicker_HireDate);
            this.Controls.Add(this.comboBox_Position);
            this.Controls.Add(this.comboBox_Department);
            this.Controls.Add(this.label_Department);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_PhoneNumber1);
            this.Controls.Add(this.textBox_PhoneNumber2);
            this.Controls.Add(this.textBox_PhoneNumber3);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.label_Position);
            this.Controls.Add(this.label_HireDate);
            this.Controls.Add(this.label_PhoneNumber);
            this.Controls.Add(this.label_Email);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "EmployeeAddForm";
            this.Text = "社員情報管理システム";
            this.Load += new System.EventHandler(this.EmployeeAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.Label label_PhoneNumber;
        private System.Windows.Forms.Label label_HireDate;
        private System.Windows.Forms.Label label_Position;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.TextBox textBox_PhoneNumber3;
        private System.Windows.Forms.TextBox textBox_PhoneNumber2;
        private System.Windows.Forms.TextBox textBox_PhoneNumber1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_Department;
        private System.Windows.Forms.ComboBox comboBox_Position;
        private System.Windows.Forms.ComboBox comboBox_Department;
        private System.Windows.Forms.DateTimePicker dateTimePicker_HireDate;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.Label label_Position_Error;
        private System.Windows.Forms.Label label_Department_Error;
        private System.Windows.Forms.Label label_HireDate_Error;
        private System.Windows.Forms.Label label_PhoneNumber_Error;
        private System.Windows.Forms.Label label_Email_Error;
        private System.Windows.Forms.Label label_MeiKana_Error;
        private System.Windows.Forms.Label label_Mei_Error;
        private System.Windows.Forms.Label label_SeiKana_Error;
        private System.Windows.Forms.Label label_Sei_Error;
        private System.Windows.Forms.Label label_MeiKana;
        private System.Windows.Forms.Label label_Mei;
        private System.Windows.Forms.TextBox textBox_MeiKana;
        private System.Windows.Forms.TextBox textBox_SeiKana;
        private System.Windows.Forms.TextBox textBox_Mei;
        private System.Windows.Forms.TextBox textBox_Sei;
        private System.Windows.Forms.Label label_SeiKana;
        private System.Windows.Forms.Label label_Sei;
    }
}