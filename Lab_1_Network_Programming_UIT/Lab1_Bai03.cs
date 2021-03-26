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
    public partial class Lab1_Bai03 : Form
    {
        public Lab1_Bai03()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Bạn chưa nhập số!", "Lỗi");
            } else
            {
                int num;
                bool isSuccess = Int32.TryParse(textBox1.Text.Trim(), out num);
                if (!isSuccess)
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên!", "Lỗi");
                }
                else
                {
                    if (textBox1.Text.Length == 1)
                    {
                        switch (num)
                        {
                            case 0:
                                textBox2.Text = "Không";
                                break;
                            case 1:
                                textBox2.Text = "Một";
                                break;
                            case 2:
                                textBox2.Text = "Hai";
                                break;
                            case 3:
                                textBox2.Text = "Ba";
                                break;
                            case 4:
                                textBox2.Text = "Bốn";
                                break;
                            case 5:
                                textBox2.Text = "Năm";
                                break;
                            case 6:
                                textBox2.Text = "Sáu";
                                break;
                            case 7:
                                textBox2.Text = "Bảy";
                                break;
                            case 8:
                                textBox2.Text = "Tám";
                                break;
                            case 9:
                                textBox2.Text = "Chín";
                                break;
                        }
                    }
                    else
                    { string[] Doc_1_So = { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
                        int DoDaiChuoi = num.ToString().Length;
                        int[] Mang = new int[DoDaiChuoi];
                        string KetQua = "";
                        int i = DoDaiChuoi - 1;
                        while (num!=0)
                        {
                            Mang[i] = num % 10;
                            num = num / 10;
                            i--;
                        }
                        if (DoDaiChuoi==10)
                        {
                            KetQua += Doc_1_So[Mang[0]] + "tỉ";
                        }
                        if (DoDaiChuoi>=9)
                        {
                            if (DoDaiChuoi>9 && Mang[1]==0)
                            {

                            }
                        }

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
