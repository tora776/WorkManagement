namespace 社員管理システム2
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EmployeeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KanaLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KanaFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeNumber,
            this.LastName,
            this.FirstName,
            this.KanaLastName,
            this.KanaFirstName,
            this.Email,
            this.Phone,
            this.HireDate,
            this.Department,
            this.Position,
            this.Status});
            this.dataGridView1.Location = new System.Drawing.Point(22, 127);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1117, 408);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.HeaderText = "社員番号";
            this.EmployeeNumber.MinimumWidth = 8;
            this.EmployeeNumber.Name = "EmployeeNumber";
            this.EmployeeNumber.Width = 95;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "姓";
            this.LastName.MinimumWidth = 8;
            this.LastName.Name = "LastName";
            this.LastName.Width = 95;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "名";
            this.FirstName.MinimumWidth = 8;
            this.FirstName.Name = "FirstName";
            this.FirstName.Width = 95;
            // 
            // KanaLastName
            // 
            this.KanaLastName.HeaderText = "姓（かな）";
            this.KanaLastName.MinimumWidth = 8;
            this.KanaLastName.Name = "KanaLastName";
            this.KanaLastName.Width = 95;
            // 
            // KanaFirstName
            // 
            this.KanaFirstName.HeaderText = "名（かな）";
            this.KanaFirstName.MinimumWidth = 8;
            this.KanaFirstName.Name = "KanaFirstName";
            this.KanaFirstName.Width = 95;
            // 
            // Email
            // 
            this.Email.HeaderText = "メールアドレス";
            this.Email.MinimumWidth = 8;
            this.Email.Name = "Email";
            this.Email.Width = 95;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "電話番号";
            this.Phone.MinimumWidth = 8;
            this.Phone.Name = "Phone";
            this.Phone.Width = 95;
            // 
            // HireDate
            // 
            this.HireDate.HeaderText = "雇用日";
            this.HireDate.MinimumWidth = 8;
            this.HireDate.Name = "HireDate";
            this.HireDate.Width = 95;
            // 
            // Department
            // 
            this.Department.HeaderText = "部門";
            this.Department.MinimumWidth = 8;
            this.Department.Name = "Department";
            this.Department.Width = 95;
            // 
            // Position
            // 
            this.Position.HeaderText = "役職";
            this.Position.MinimumWidth = 8;
            this.Position.Name = "Position";
            this.Position.Width = 95;
            // 
            // Status
            // 
            this.Status.HeaderText = "ステータス";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.Width = 95;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(345, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 69);
            this.button2.TabIndex = 2;
            this.button2.Text = "社員追加";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(372, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 69);
            this.button3.TabIndex = 3;
            this.button3.Text = "社員検索";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("メイリオ", 14F);
            this.label9.Location = new System.Drawing.Point(64, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 42);
            this.label9.TabIndex = 30;
            this.label9.Text = "社員一覧";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(158, 25);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 69);
            this.button4.TabIndex = 31;
            this.button4.Text = "社員詳細表示";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "社員番号",
            "姓",
            "名",
            "姓（かな）",
            "名（かな）",
            "メールアドレス",
            "電話番号",
            "雇用日",
            "部門",
            "役職",
            "ステータス"});
            this.comboBox1.Location = new System.Drawing.Point(40, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(115, 28);
            this.comboBox1.TabIndex = 58;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(166, 21);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(196, 26);
            this.textBox2.TabIndex = 59;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(509, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 104);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.Location = new System.Drawing.Point(9, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 24);
            this.button1.TabIndex = 61;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 428);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "社員情報管理システム";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn KanaLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn KanaFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn HireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}

