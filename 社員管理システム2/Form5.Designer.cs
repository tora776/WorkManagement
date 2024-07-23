namespace 社員管理システム2
{
    partial class Form5
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EmployeeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KanaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeNumber,
            this.EmployeeName,
            this.KanaName,
            this.Email,
            this.PhoneNumber,
            this.HireDate,
            this.Department,
            this.Position,
            this.Status});
            this.dataGridView1.Location = new System.Drawing.Point(11, 219);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1450, 272);
            this.dataGridView1.TabIndex = 1;
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.HeaderText = "社員番号";
            this.EmployeeNumber.MaxInputLength = 6;
            this.EmployeeNumber.MinimumWidth = 8;
            this.EmployeeNumber.Name = "EmployeeNumber";
            this.EmployeeNumber.Width = 90;
            // 
            // EmployeeName
            // 
            this.EmployeeName.HeaderText = "氏名";
            this.EmployeeName.MinimumWidth = 8;
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Width = 90;
            // 
            // KanaName
            // 
            this.KanaName.HeaderText = "氏名（かな）";
            this.KanaName.MinimumWidth = 8;
            this.KanaName.Name = "KanaName";
            this.KanaName.Width = 90;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 8;
            this.Email.Name = "Email";
            this.Email.Width = 90;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.HeaderText = "電話番号";
            this.PhoneNumber.MinimumWidth = 8;
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Width = 90;
            // 
            // HireDate
            // 
            this.HireDate.HeaderText = "雇用日";
            this.HireDate.MinimumWidth = 8;
            this.HireDate.Name = "HireDate";
            this.HireDate.Width = 90;
            // 
            // Department
            // 
            this.Department.HeaderText = "部門";
            this.Department.MinimumWidth = 8;
            this.Department.Name = "Department";
            this.Department.Width = 90;
            // 
            // Position
            // 
            this.Position.HeaderText = "役職";
            this.Position.MinimumWidth = 8;
            this.Position.Name = "Position";
            this.Position.Width = 90;
            // 
            // Status
            // 
            this.Status.HeaderText = "ステータス";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.Width = 90;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(411, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 69);
            this.button1.TabIndex = 2;
            this.button1.Text = "社員検索";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("メイリオ", 14F);
            this.label9.Location = new System.Drawing.Point(57, 24);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 42);
            this.label9.TabIndex = 29;
            this.label9.Text = "社員検索";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "社員番号",
            "氏名",
            "氏名（かな）",
            "Email",
            "電話番号",
            "雇用日",
            "部門",
            "役職",
            "ステータス"});
            this.comboBox1.Location = new System.Drawing.Point(55, 107);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(118, 26);
            this.comboBox1.TabIndex = 30;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(184, 108);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 25);
            this.textBox1.TabIndex = 39;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(586, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 69);
            this.button2.TabIndex = 40;
            this.button2.Text = "条件クリア";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 27);
            this.button3.TabIndex = 41;
            this.button3.Text = "＋";
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(761, 25);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 69);
            this.button4.TabIndex = 42;
            this.button4.Text = "社員表示画面に戻る";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1585, 562);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form5";
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn KanaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn HireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button button4;
    }
}