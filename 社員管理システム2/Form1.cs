using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 社員管理システム2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // カラム数を指定
            dataGridView1.ColumnCount = 5;

            // カラム名を指定
            dataGridView1.Columns[0].HeaderText = "社員番号";
            dataGridView1.Columns[1].HeaderText = "氏名";
            dataGridView1.Columns[2].HeaderText = "氏名（かな）";
            dataGridView1.Columns[3].HeaderText = "所属部門";
            dataGridView1.Columns[4].HeaderText = "役職";

            // データを追加
            dataGridView1.Rows.Add("000001", "田中　太郎", "たなか　たろう", "本社", "社長");
            dataGridView1.Rows.Add("000002", "山田　一樹", "やまだ　かずき", "本社", "取締役");
            dataGridView1.Rows.Add("000003", "内田　弘", "うちだ　ひろし", "東京支部", "支部長");
            dataGridView1.Rows.Add("000004", "田中　司郎", "たなか　しろう", "横浜支部", "課長");
            dataGridView1.Rows.Add("000005", "山田　浩介", "やまだ　こうすけ", "東京支部", "SL");
            dataGridView1.Rows.Add("000006", "内田　五郎", "うちだ　ごろう", "横浜支部", "TL");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }
    }
}
