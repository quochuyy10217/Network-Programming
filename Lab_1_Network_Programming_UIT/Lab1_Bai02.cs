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
    public partial class Lab1_Bai02 : Form
    {
        public Lab1_Bai02()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ 3 số!", "Lỗi");
            }
            else
            {
                int[] nums = { 0, 0, 0 };
                int max_num, min_num;
                bool isSuccess1 = Int32.TryParse(textBox1.Text.Trim(), out nums[0]);
                bool isSuccess2 = Int32.TryParse(textBox2.Text.Trim(), out nums[1]);
                bool isSuccess3 = Int32.TryParse(textBox3.Text.Trim(), out nums[2]);
                if (!isSuccess1 || !isSuccess2 || !isSuccess3)
                {
                    MessageBox.Show("Vui lòng nhập số nguyên!", "Lỗi");
                }
                else
                {
                    max_num = nums[0];
                    min_num = nums[0];
                    for (int i=1;i<nums.Length;i++)
                    {
                        if (max_num < nums[i]) max_num = nums[i];
                        if (min_num > nums[i]) min_num = nums[i];
                        textBox4.Text = max_num.ToString();
                        textBox5.Text = min_num.ToString();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
