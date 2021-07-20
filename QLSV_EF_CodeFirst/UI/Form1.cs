using QLSV_EF_CodeFirst.DTO;
using QLSV_EF_CodeFirst.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_EF_CodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadCBBSort();
            LoadCBBClass();

            LoadStudent();
        }
        void LoadStudent()
        {
            string student_Name = textBox1.Text;
            int class_ID = ((CBBItems)cbb_Class.SelectedItem).Value;
            dataGridView1.DataSource = BLL.BLL.Instance.GetStudents(class_ID, student_Name);
        }
        void LoadCBBClass()
        {
            cbb_Class.Items.Add(new CBBItems
            {
                Name = "All",
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
        private void cbb_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadStudent();
        }
        void LoadCBBSort()
        {
            var properties = BLL.BLL.Instance.GetStudentProperty();
            foreach (var p in properties)
            {
                cbb_Sort.Items.Add(new CBBItems
                {
                    Name = p,
                    Value = 0
                });
            }
            cbb_Sort.SelectedIndex = 0;
        }

        private void btn_Sort_Click(object sender, EventArgs e)
        {
            List<StudentViewModel> students = new List<StudentViewModel>();
            string property = ((CBBItems)cbb_Sort.SelectedItem).Name;

            foreach(DataGridViewRow dr in dataGridView1.Rows)
            {
                students.Add(new StudentViewModel
                {
                    ID = dr.Cells["ID"].Value.ToString(),
                    Name = dr.Cells["Name"].Value.ToString(),
                    Gender = Convert.ToBoolean(dr.Cells["Gender"].Value),
                    DateOfBirth = Convert.ToDateTime(dr.Cells["DateOfBirth"].Value),
                    Class_Name = dr.Cells["Class_Name"].Value.ToString()
                });
            }

            dataGridView1.DataSource = BLL.BLL.Instance.Sort(students, property);
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            cbb_Class.SelectedIndex = 0;
            cbb_Sort.SelectedIndex = 0;
            textBox1.Text = "";
            LoadStudent();
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No row is selected!!");
                return;
            }
            else
            {
                DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa (những) bản ghi này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (d)
                {
                    case DialogResult.Yes:
                        List<string> IDs = new List<string>();
                        foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                        {
                            IDs.Add(dr.Cells["ID"].Value.ToString());
                        }
                        if (BLL.BLL.Instance.DeleteStudents(IDs))
                            MessageBox.Show("Xóa thành công!");
                        else
                            MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau!");
                        break;
                    case DialogResult.No:
                        return;
                }    
            }

            LoadStudent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Dispose();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            string ID = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            this.Hide();
            Form2 f2 = new Form2();
            f2.Sender(ID);
            f2.ShowDialog();
            this.Dispose();
        }
    }
}
