namespace SyainKanriSystem
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
            this.button_Add = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button_Detail = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.button_AddSearchCondition = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchComboBox0 = new System.Windows.Forms.ComboBox();
            this.searchTextBox0 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_ClearSearchConditions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 116);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1117, 408);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(345, 25);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(151, 69);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "社員追加";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.buttonAdd_Click);
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
            // button_Detail
            // 
            this.button_Detail.Location = new System.Drawing.Point(158, 25);
            this.button_Detail.Name = "button_Detail";
            this.button_Detail.Size = new System.Drawing.Size(151, 69);
            this.button_Detail.TabIndex = 31;
            this.button_Detail.Text = "社員詳細表示";
            this.button_Detail.UseVisualStyleBackColor = true;
            this.button_Detail.Click += new System.EventHandler(this.buttonDetailed_Click);
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(441, 21);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(151, 69);
            this.button_Search.TabIndex = 3;
            this.button_Search.Text = "社員検索";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // button_AddSearchCondition
            // 
            this.button_AddSearchCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button_AddSearchCondition.Location = new System.Drawing.Point(6, 10);
            this.button_AddSearchCondition.Name = "button_AddSearchCondition";
            this.button_AddSearchCondition.Size = new System.Drawing.Size(20, 20);
            this.button_AddSearchCondition.TabIndex = 61;
            this.button_AddSearchCondition.Text = "+";
            this.button_AddSearchCondition.UseVisualStyleBackColor = true;
            this.button_AddSearchCondition.Click += new System.EventHandler(this.button_AddSearchCondition_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(509, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 104);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            // 
            // searchComboBox0
            // 
            this.searchComboBox0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchComboBox0.FormattingEnabled = true;
            this.searchComboBox0.Items.AddRange(new object[] {
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
            this.searchComboBox0.Location = new System.Drawing.Point(40, 10);
            this.searchComboBox0.Name = "searchComboBox0";
            this.searchComboBox0.Size = new System.Drawing.Size(115, 19);
            this.searchComboBox0.TabIndex = 58;
            // 
            // searchTextBox0
            // 
            this.searchTextBox0.Location = new System.Drawing.Point(166, 10);
            this.searchTextBox0.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.searchTextBox0.Name = "searchTextBox0";
            this.searchTextBox0.Size = new System.Drawing.Size(196, 17);
            this.searchTextBox0.TabIndex = 59;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.button_ClearSearchConditions);
            this.panel1.Controls.Add(this.button_AddSearchCondition);
            this.panel1.Controls.Add(this.searchTextBox0);
            this.panel1.Controls.Add(this.searchComboBox0);
            this.panel1.Location = new System.Drawing.Point(9, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 83);
            this.panel1.TabIndex = 61;
            // 
            // button_ClearSearchConditions
            // 
            this.button_ClearSearchConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ClearSearchConditions.Location = new System.Drawing.Point(0, 40);
            this.button_ClearSearchConditions.Name = "button_ClearSearchConditions";
            this.button_ClearSearchConditions.Size = new System.Drawing.Size(40, 20);
            this.button_ClearSearchConditions.TabIndex = 61;
            this.button_ClearSearchConditions.Text = "クリア";
            this.button_ClearSearchConditions.UseVisualStyleBackColor = true;
            this.button_ClearSearchConditions.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 570);
            this.Controls.Add(this.button_Detail);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "社員情報管理システム";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_Detail;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Button button_AddSearchCondition;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox searchComboBox0;
        private System.Windows.Forms.TextBox searchTextBox0;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_ClearSearchConditions;
    }
}

