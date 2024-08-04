using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 社員管理システム2.Models;

namespace 社員管理システム2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var DB = new DatabaseContext();
            try
            {
                DB.connectDB();
                DB.disconnectDB();
            }
            catch(Exception error) {
                //Console.WriteLine(error.Message);
                MessageBox.Show(error.Message);
            }
            // カラム数を指定
            // dataGridView1.ColumnCount = 5;

            // カラム名を指定
            // dataGridView1.Columns[0].HeaderText = "社員番号";
            // dataGridView1.Columns[1].HeaderText = "氏名";
            // dataGridView1.Columns[2].HeaderText = "氏名（かな）";
            // dataGridView1.Columns[3].HeaderText = "所属部門";
            // dataGridView1.Columns[4].HeaderText = "役職";

            // データを追加
            // dataGridView1.Rows.Add("000001", "田中", "太郎", "たなか", "たろう", "tanaka-tarou@ost.co.jp", "080-1111-2222", "1977/4/1",  "本社", "社長", "在籍");
            // dataGridView1.Rows.Add("000002", "山田", "一樹", "やまだ", "かずき", "yamada-kazuki@ost.co.jp", "080-1111-2223", "1997/4/2", "本社", "取締役", "在籍");
            // dataGridView1.Rows.Add("000003", "内田", "弘", "うちだ", "ひろし", "uchida-hiroshi@ost.co.jp", "080-1111-2224", "1997/4/3", "東京支部", "支部長", "在籍");
            // dataGridView1.Rows.Add("000004", "田中", "司郎", "たなか", "しろう", "tanaka-shiro@ost.co.jp", "080-1111-2225", "1997/4/4", "横浜支部", "支部長", "在籍");
            // dataGridView1.Rows.Add("000005", "山田", "浩介", "やまだ", "こうすけ", "yamada-kosuke@ost.co.jp", "080-1111-2226", "1997/4/5", "東京支部", "課長", "在籍");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeAddForm addForm = new EmployeeAddForm();
            addForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmployeeSearchForm form7 = new EmployeeSearchForm();
            form7.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmployeeDetailForm detailForm = new EmployeeDetailForm();
            detailForm.Show();
        }
    }
}
