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
    public partial class Lab1_Bai04 : Form
    {
        public Lab1_Bai04()
        {
            InitializeComponent();
        }

        public string Decimal_To_Binary(int decimal_num)
        {
            string ketqua = "";
            while (decimal_num != 0)
            {
                string sodu = (decimal_num % 2).ToString();
                ketqua = sodu + ketqua;
                decimal_num /= 2;
            }
            return ketqua;
        }

        public string Decimal_To_Hexa(int Hexa_num)
        {
            string ketqua = "";
            while (Hexa_num != 0)
            {
                string sodu = (Hexa_num % 16).ToString();
                if (Int32.Parse(sodu) > 9)
                {
                    if (sodu == "10") sodu = "A";
                    else if (sodu == "11") sodu = "B";
                    else if (sodu == "12") sodu = "C";
                    else if (sodu == "13") sodu = "D";
                    else if (sodu == "14") sodu = "E";
                    else sodu = "F";
                }
                ketqua = sodu + ketqua;
                Hexa_num = Hexa_num / 16;
            }
            return ketqua;
        }

        public int tinh_luy_thua(int so_can_tinh,int somu)
        {
            int ketqua = 1;
            int i = 1;
            while (somu > 0 && i <= somu)
            {
                ketqua *= so_can_tinh;
                i++;
            }
            return ketqua;
        }

        public string Binary_to_Decimal(string Binary_num)
        {
            long ketqua=0;
            int i = Binary_num.Length - 1;
            int j = 0;
            while (i>=0)
            {
                string temp = Binary_num[j].ToString();
                if (temp == "1")
                {
                    ketqua += tinh_luy_thua(2,i);
                }
                    i--;
                    j++;
            }
            return ketqua.ToString();
        }
        public string Binary_To_Hexa(string Binary_num)
        {
            int Decimal_num = Int32.Parse(Binary_to_Decimal(Binary_num));
            return Decimal_To_Hexa(Decimal_num);
        }

        public string Hexa_To_Decimal(string Hexa_num)
        {
            long ketqua = 0;
            int i = Hexa_num.Length - 1;
            int j = 0;
            while (i >= 0)
            {
                string temp = Hexa_num[j].ToString();
                int num;
                bool isDigit = Int32.TryParse(temp, out num);
                if (!isDigit)
                {
                    if (temp.ToUpper() == "A")
                    {
                        ketqua += 10 * tinh_luy_thua(16, i);
                    }
                    else if (temp.ToUpper() == "B")
                    {
                        ketqua += 11 * tinh_luy_thua(16, i);
                    }
                    else if (temp.ToUpper() == "C")
                    {
                        ketqua += 12 * tinh_luy_thua(16, i);
                    }
                    else if (temp.ToUpper() == "D")
                    {
                        ketqua += 13 * tinh_luy_thua(16, i);
                    }
                    else if (temp.ToUpper() == "E")
                    {
                        ketqua += 14 * tinh_luy_thua(16, i);
                    }
                    else if (temp.ToUpper() == "F")
                    {
                        ketqua += 15 * tinh_luy_thua(16, i);
                    }
                } else
                {
                    ketqua = ketqua + num * tinh_luy_thua(16, i);
                }
                i--;
                j++;
            }
            return ketqua.ToString();
        }

        public string Hexa_To_Binary(string Hexa_num)
        {
            string Decimal_num = Hexa_To_Decimal(Hexa_num);
            return Decimal_To_Binary(Int32.Parse(Decimal_num));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Bạn chưa nhập số!", "Lỗi");
                check = false;
            }
            if (comboBox1.Text==comboBox2.Text)
            {
                MessageBox.Show("Không thể thực hiện vì bạn đang lựa chọn 2 kiểu số giống nhau!", "Lỗi");
                check = false;
            }
            if (check==true)
            {
                if (comboBox1.Text == "Decimal")
                {
                    int num;
                    bool isSuccess = Int32.TryParse(textBox1.Text.Trim(), out num);
                    if (!isSuccess)
                    {
                        MessageBox.Show("Dữ liệu bạn nhập vào không hợp lệ!", "Lỗi");
                    }
                    else
                    {
                        if (comboBox2.Text == "Binary")
                        {
                            textBox2.Text = Decimal_To_Binary(num);
                        }
                        else
                        {                            
                            textBox2.Text = Decimal_To_Hexa(num);
                        }
                    }
                }
                else if (comboBox1.Text == "Binary")
                {                    
                    bool flag = true;
                    for (int i=0;i<textBox1.Text.Length;i++)
                    {
                        string bientam = textBox1.Text[i].ToString();
                        if (bientam != "0" && bientam != "1")
                        {
                            MessageBox.Show("Dữ liệu bạn nhập không phải là kiểu Binary", "Lỗi");
                            flag = false;
                            break;
                         }
                    }
                    if (flag == true)
                    {
                        if (comboBox2.Text == "Decimal")
                            textBox2.Text = Binary_to_Decimal(textBox1.Text);
                        else
                            textBox2.Text = Binary_To_Hexa(textBox1.Text);
                    }
                } 
                else if (comboBox1.Text == "Hexadecimal")
                {
                    bool flag = true;
                    for (int i=0;i<textBox1.Text.Length;i++)
                    {
                        if (!Char.IsDigit(textBox1.Text[i]))
                        {
                            int ascii_code = (int)Char.ToUpper(textBox1.Text[i]);
                            if (ascii_code<65 || ascii_code > 70)
                            {
                                MessageBox.Show("Số bạn vừa nhập không phải là số Hexa!", "Lỗi");
                                flag = false;
                                break;
                            }
                        }
                    }
                    if (flag==true)
                    { 
                        if (comboBox2.Text == "Decimal")
                            textBox2.Text = Hexa_To_Decimal(textBox1.Text);
                        else if (comboBox2.Text == "Binary")
                            textBox2.Text = Hexa_To_Binary(textBox1.Text);
                    }
                }
            }
        }

        private void Lab1_Bai04_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Decimal";
            comboBox2.SelectedItem = "Binary";
        }
    }
}
