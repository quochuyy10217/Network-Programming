using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Lab1_Bai01 : Form
    {
        public Lab1_Bai01()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            if (String.IsNullOrEmpty(textBox1.Text)||String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ 2 số!","Lỗi");
            }
            else
            {
                int num1, num2;
                long sum = 0;
                bool isSuccess1 = Int32.TryParse(textBox1.Text.Trim(), out num1);
                bool isSuccess2 = Int32.TryParse(textBox2.Text.Trim(), out num2);
                if (!isSuccess1||!isSuccess2)
                {
                    MessageBox.Show("Vui lòng nhập số nguyên!","Lỗi");
                }
                else
                {
                    sum = num1 + num2;
                    textBox3.Text = sum.ToString();
                }
            }
        }
    }
}
