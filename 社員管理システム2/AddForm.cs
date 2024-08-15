﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyainKanriSystem
{
    public partial class EmployeeAddForm : Form
    {
        public EmployeeAddForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                addEmployee();
                MessageBox.Show("データを追加しました。");
            }
            catch (Exception error) {
                MessageBox.Show(error.Message);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private String[] getInputText()
        {
            string FirstNameValue = textBox_FirstName.Text;
            string LastNameValue = textBox_LastName.Text;
            string FirstNameKanaValue = textBox_FirstNameKana.Text;
            string LastNameKanaValue = textBox_LastNameKana.Text;
            string EmailValue = textBox_Email.Text;
            string PhoneNumber1Value = textBox_PhoneNumber1.Text;
            string PhoneNumber2Value = textBox_PhoneNumber2.Text;
            string PhoneNumber3Value = textBox_PhoneNumber3.Text;
            string HireDateValue = dateTimePicker1.Text;
            string DepartmentValue = comboBox_Department.Text;
            string PositionValue = comboBox_Position.Text;

            String[] addData = {FirstNameValue, LastNameValue, FirstNameKanaValue, LastNameKanaValue, EmailValue, PhoneNumber1Value, PhoneNumber2Value, PhoneNumber3Value, HireDateValue,  DepartmentValue, PositionValue};
            return addData;
        }

        private void emptyChk(string[] addData)
        {
            try
            {

                for (int i = 0; i < addData.Length; i++)
                {
                    if (String.IsNullOrEmpty(addData[i]) == true)
                    {
                        MessageBox.Show("空の入力項目が存在します");
                        break;
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void wordCount(string[] addData)
        {
            try
            {
                int[] limit = { 50, 50, 50, 50, 255, 3, 4, 4, 10, 6, 6 };
                for (int i = 0; i < addData.Length; i++)
                {
                    if (addData[i].Length > limit[i])
                    {
                        string content = string.Format("{0}は既定の文字数をオーバーしています。※{1}文字まで", addData[i], limit[i]);
                        MessageBox.Show(content);
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void kanaChk(string[] addData)
        {
            try
            {
                for (int i = 2; i < 4; i++)
                {
                    if (Regex.IsMatch(addData[i], @"^\p{IsHiragana}*$") == false)
                    {
                        string content = string.Format("{0}をひらがな入力してください", addData[i]);
                        MessageBox.Show(content);
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private string phoneChk(string[] addData)
        {
            String[] PhoneNumberArray = { addData[6], addData[7], addData[8] };
            for (int i = 0; i < PhoneNumberArray.Length; i++)
            {
                bool result = int.TryParse(PhoneNumberArray[i], out _);
                if (result == false)
                {
                    MessageBox.Show("電話番号には数字を記載してください");
                    return null;
                }
            }

            String PhoneNumberValue = PhoneNumberArray[0] + "-" + PhoneNumberArray[1] + "-" + PhoneNumberArray[2];         

            return PhoneNumberValue;
        }

        private void mailChk(string[] addData)
        {
            try
            {
                String[] strRequired = { "@", "." };
                foreach (String str in strRequired)
                {
                    if (addData[4].Contains(str) == false)
                    {
                        string content = string.Format("メールアドレスに指定の文字（{0}）が入力されていません", str);
                        MessageBox.Show(content);
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private DateTime calendarChk(string[] addData)
        {
            DateTime HireDateValue = DateTime.Parse(addData[9]);


            if (HireDateValue > DateTime.Today)
            {
                MessageBox.Show("未来の日付は入力できません");
            }

            return HireDateValue;
        }


        private void addEmployee()
        {
            try
            {
                String[] addData = getInputText();
                // emptyChk(addData);
                // wordCount(addData);
                // mailChk(addData);
                kanaChk(addData);
                // DateTime HireDateValue = calendarChk(addData);
                // String PhoneNumberArray = phoneChk(addData);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        

        
    }
}
