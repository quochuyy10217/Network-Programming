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
    public partial class Lab1_Bai05 : Form
    {
        public Lab1_Bai05()
        {
            InitializeComponent();
        }
        // Hàm kiểm tra dữ liệu nhập vào
        private int check_Input(string[] input_str)
        {
            for (int i = 0; i < input_str.Length; i++)
            {
                bool isSuccess;
                double temp_num;
                isSuccess = Double.TryParse(input_str[i].Trim(), out temp_num);
                if (!isSuccess) return 1;
                if (temp_num < 0 || temp_num > 10) return 2;
            }
            return 0;
        }
        // Hàm tạo label chứa các điểm đã nhập
        private void create_label_of_results(Label[] labels, string[] marks, int index, int width, int height)
        {
            labels[index] = new Label();
            labels[index].Text = "Môn " + (index+1) + ": " + marks[index].Trim() + "đ";
            labels[index].AutoSize = true;
            labels[index].Location = new Point(width, height);
            groupBox1.Controls.Add(labels[index]);
            labels[index].BringToFront();
        }
        // Hàm tạo label chứa thông tin về học lực, điểm trung bình, etc...
        private void create_label_of_informations(Label[] labels, string[] marks, int index, int width, int height, string content)
        {
            //95, 508
            labels[index] = new Label();
            labels[index].Text = content;
            labels[index].AutoSize = true;
            labels[index].Location = new Point(width, height);
            this.Controls.Add(labels[index]);
            labels[index].BringToFront();
        }
        //Hàm tính điểm trung bình
        private double tinh_DTB(string[] array_of_marks)
        {
            double diem_tb = 0;
            for (int i=0;i<array_of_marks.Length;i++)
            {
                diem_tb += Double.Parse(array_of_marks[i]);
            }
            return Math.Round(diem_tb / array_of_marks.Length,2);
        }
        // Hàm tìm điểm cao nhất
        private double tim_Diem_Cao_Nhat(string[] array_of_marks)
        {
            double max_Mark = Double.Parse(array_of_marks[0]);
            for (int i=1;i<array_of_marks.Length;i++)
            {
                double temp_Num = Double.Parse(array_of_marks[i]);
                if (max_Mark < temp_Num) max_Mark = temp_Num;
            }
            return max_Mark;
        }
        // Hàm tìm điểm thấp nhất
        private double tim_Diem_Thap_Nhat(string[] array_of_marks)
        {
            double min_Mark = Double.Parse(array_of_marks[0]);
            for (int i = 1; i < array_of_marks.Length; i++)
            {
                double temp_Num = Double.Parse(array_of_marks[i]);
                if (min_Mark > temp_Num) min_Mark = temp_Num;
            }
            return min_Mark;
        }
        // Hàm xếp loại học lực
        private string xep_Loai_Hoc_Luc(string[] array_of_marks,double Diem_TB)
        {
            double diem_Thap_Nhat = Double.Parse(array_of_marks[0]);
            for (int i=1;i<array_of_marks.Length;i++)
            {
                double temp_num = Double.Parse(array_of_marks[i]);
                if (diem_Thap_Nhat>temp_num)
                {
                    diem_Thap_Nhat = temp_num;
                }
            }
            if (Diem_TB >= 8 && diem_Thap_Nhat >= 6.5) return "Giỏi";
            else if (Diem_TB >= 6.5 && diem_Thap_Nhat >= 5) return "Khá";
            else if (Diem_TB >= 5.0 && diem_Thap_Nhat >= 3.5) return "Trung bình";
            else if (Diem_TB >= 3.5 && diem_Thap_Nhat >= 2) return "Yếu";
            else return "Kém";
        }

        private int dem_So_Mon_Dau(string[] array_of_marks)
        {
            int dem_Mon = 0;
            for (int i = 0; i < array_of_marks.Length; i++)
            {
                if (Double.Parse(array_of_marks[i])>=5)
                {
                    dem_Mon++;
                }
            }
            return dem_Mon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Bạn chưa nhập điểm!", "Lỗi");
            } else
            {
                string[] array_of_marks = textBox1.Text.Split(',');
                if (check_Input(array_of_marks) == 1) MessageBox.Show("Dữ liệu nhập vào không hợp lệ, vui lòng kiểm tra lại!", "Lỗi");
                else if (check_Input(array_of_marks) == 2) MessageBox.Show("Điểm nhập vào phải lớn hơn 0 hoặc nhỏ hơn 10!", "Lỗi");
                else
                {
                    Label[] labels = new Label[array_of_marks.Length];
                    int width = 48;
                    int height = 31;
                    create_label_of_results(labels, array_of_marks, 0, width, height);
                    for (int i = 1; i < array_of_marks.Length; i++)
                    {
                        if (i % 4 == 0)
                        {
                            width = 48;
                            height += 20;
                        }
                        else
                        {
                            width += 150;
                        }
                        create_label_of_results(labels, array_of_marks, i, width, height);
                    }
                    Label[] labels_of_information = new Label[6];
                    string[] contents = new string[6]; 
                    contents[0] = "Điểm trung bình: " + tinh_DTB(array_of_marks);
                    contents[1] = "Xếp loại học lực: " + xep_Loai_Hoc_Luc(array_of_marks, tinh_DTB(array_of_marks));
                    contents[2] = "Môn có điểm cao nhất: " + tim_Diem_Cao_Nhat(array_of_marks);
                    contents[3] = "Môn có điểm thấp nhất: " + tim_Diem_Thap_Nhat(array_of_marks);
                    int so_mon_dau = dem_So_Mon_Dau(array_of_marks);
                    contents[4] = "Số môn đậu: " + so_mon_dau;
                    contents[5] = "Số môn không đậu: " + (array_of_marks.Length - so_mon_dau);
                    width = 75;
                    height = 490;
                    create_label_of_informations(labels_of_information, array_of_marks, 0, width, height,contents[0]);
                    for (int i = 1; i < 6; i++)
                    {
                        if ((i+1)%2!=0)
                        {
                            width = 75;
                            height += 40;
                        } else
                        {
                            width += 300;
                        }
                        create_label_of_informations(labels_of_information, array_of_marks, 1, width, height, contents[i]);
                    }
                }
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
