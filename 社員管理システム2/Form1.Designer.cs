namespace 社員管理システム2
{
    partial class Form1
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
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KanaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
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
            this.Department,
            this.Position});
            this.dataGridView1.Location = new System.Drawing.Point(11, 116);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(813, 728);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.HeaderText = "社員番号";
            this.EmployeeNumber.MinimumWidth = 8;
            this.EmployeeNumber.Name = "EmployeeNumber";
            this.EmployeeNumber.Width = 150;
            // 
            // EmployeeName
            // 
            this.EmployeeName.HeaderText = "氏名";
            this.EmployeeName.MinimumWidth = 8;
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Width = 150;
            // 
            // KanaName
            // 
            this.KanaName.HeaderText = "氏名（かな）";
            this.KanaName.MinimumWidth = 8;
            this.KanaName.Name = "KanaName";
            this.KanaName.Width = 150;
            // 
            // Department
            // 
            this.Department.HeaderText = "部門";
            this.Department.MinimumWidth = 8;
            this.Department.Name = "Department";
            this.Department.Width = 150;
            // 
            // Position
            // 
            this.Position.HeaderText = "役職";
            this.Position.MinimumWidth = 8;
            this.Position.Name = "Position";
            this.Position.Width = 150;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(327, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 69);
            this.button1.TabIndex = 1;
            this.button1.Text = "社員表示";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(499, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 69);
            this.button2.TabIndex = 2;
            this.button2.Text = "新規社員追加";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(676, 25);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 428);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn KanaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
    }
}

