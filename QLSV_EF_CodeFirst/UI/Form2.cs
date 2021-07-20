using QLSV_EF_CodeFirst.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_EF_CodeFirst.UI
{
    public partial class Form2 : Form
    {
        Thread thread;
        public delegate void Send(string ID);
        public Send Sender;
        string ID;
        void GetID(string ID)
        {
            this.ID = ID;
        }
        public Form2()
        {
            Sender = new Send(GetID);
            InitializeComponent();
            LoadCBBClass();
        }
        void LoadCBBClass()
        {
            cbb_Class.Items.Add(new CBBItems
            {
                Name = "----Select Class----",
                Value = 0
            });
            var classes = BLL.BLL.Instance.GetClasses();
            foreach (var c in classes)
            {
                cbb_Class.Items.Add(new CBBItems
                {
                    Name = c.Class_Name,
                    Value = c.Class_ID
                });
            }
            cbb_Class.SelectedIndex = 0;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                return;
            }
                
            if(ID == null)
            {
                if (!BLL.BLL.Instance.IsExist(tb_StudentID.Text))
                {
                    MessageBox.Show("ID đã tồn tại!");
                    return;
                }
                if (BLL.BLL.Instance.AddStudent(GetStudent()))
                    MessageBox.Show("Thêm sinh viên thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau!");
            }
            else
            {
                if (BLL.BLL.Instance.UpdateStudent(GetStudent()))
                    MessageBox.Show("Cập nhập sinh viên thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau!");
            }

            GoToForm1();
        }
        bool IsValid()
        {
            if (tb_StudentID.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ID sinh viên!");
                return false;
            }
            if (tb_Name.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên sinh viên!");
                return false;
            } 
            if (cbb_Class.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp!");
                return false;
            }    
            if (rbtn_Male.Checked == false && rbtn_Female.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return false;
            }
            return true;
        }
        Student GetStudent()
        {
            Student student = new Student();
            student.ID = tb_StudentID.Text;
            student.Name = tb_Name.Text;
            student.DateOfBirth = dateTimePicker1.Value;
            student.Class_ID = ((CBBItems)cbb_Class.SelectedItem).Value;
            if (rbtn_Male.Checked)
                student.Gender = true;
            else
                student.Gender = false;
            return student;
        }
        void RunForm1(object sender)
        {
            Application.Run(new Form1());
        }
        void GoToForm1()
        {
            this.Dispose();
            thread = new Thread(RunForm1);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            GoToForm1();
        }
        void FillInformation()
        {
            tb_StudentID.Enabled = false;
            Student student = BLL.BLL.Instance.GetStudentByID(ID);
            tb_StudentID.Text = student.ID;
            tb_Name.Text = student.Name;
            cbb_Class.SelectedIndex = student.Class_ID;
            if (student.Gender)
                rbtn_Male.Checked = true;
            else
                rbtn_Female.Checked = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (ID == null)
                return;
            FillInformation();
        }
    }
}
