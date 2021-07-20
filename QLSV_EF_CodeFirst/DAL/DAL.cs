using QLSV_EF_CodeFirst.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_EF_CodeFirst.DAL
{
    class DAL : IDAL
    {
        CSDL db = new CSDL();
        public static DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        private static DAL _Instance;
        private DAL()
        {

        }
        /// <summary>
        /// Lấy danh sách sinh viên ứng với class_ID và student_Name
        /// </summary>
        /// <param name="class_ID">Mã Lớp</param>
        /// <param name="student_Name">Tên sinh viên</param>
        /// <returns></returns>
        public List<Student> GetStudents(int class_ID, string student_Name)
        {
            List<Student> students = new List<Student>();
            if (class_ID == 0)
            {
                if (student_Name == "")
                {
                    students = db.Students.Select(p => p).ToList();
                }
                else
                {
                    students = db.Students.Where(p => p.Name.Contains(student_Name)).ToList();
                }
            }
            else
            {
                if (student_Name == "")
                {
                    students = db.Students.Where(p => p.Class_ID == class_ID).ToList();
                }
                else
                {
                    students = db.Students.Where(p => p.Class_ID == class_ID &&
                                                p.Name.Contains(student_Name)).ToList();
                }
            }
            return students;
        }
        /// <summary>
        /// Lấy danh sách toàn bộ lớp hiện có
        /// </summary>
        /// <returns></returns>
        public List<Class> GetClasses()
        {
            var classes = db.Classes.Select(p => p).ToList();
            return classes;
        }
        /// <summary>
        /// Thêm 1 sinh viên vào csdl
        /// </summary>
        /// <param name="student">Đối tượng sinh viên được thêm</param>
        /// <returns>true nếu được thêm thành công, ngược lại false</returns>
        public bool AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// Xóa 1 hoặc nhiều sinh viên.
        /// </summary>
        /// <param name="IDs">Danh sách ID của sinh viên được xóa</param>
        /// <returns></returns>
        public bool DeleteStudents(List<string> IDs)
        {
            foreach (var ID in IDs)
            {
                var student = db.Students.FirstOrDefault(p => p.ID == ID);
                if (student == null)
                    return false;
                else
                {
                    db.Students.Remove(student);
                }
            }
            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// Lấy thông tin của 1 sinh viên theo ID
        /// </summary>
        /// <param name="ID">ID của sinh viên được lấy thông tin</param>
        /// <returns></returns>
        public Student GetStudentByID(string ID)
        {
            var student = db.Students.FirstOrDefault(p => p.ID == ID);
            return student;
        }
        /// <summary>
        /// Cập nhập thông tin của 1 sinh viên
        /// </summary>
        /// <param name="student">Đối tượng sinh viên cần được update</param>
        /// <returns></returns>
        public bool UpdateStudent(Student student)
        {
            var s = db.Students.FirstOrDefault(p => p.ID == student.ID);
            if (s == null)
                return false;
            else
            {
                s.Name = student.Name;
                s.Gender = student.Gender;
                s.DateOfBirth = student.DateOfBirth;
                s.Class_ID = student.Class_ID;
            }

            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// Lấy danh sách các thuộc tính của sinh viên
        /// </summary>
        /// <returns></returns>
        public List<string> GetStudentProperty()
        {
            List<string> properties = new List<string>();
            Student student = new Student();
            foreach (var p in student.GetType().GetProperties())
            {
                properties.Add(p.Name);
            }
            properties.RemoveAt(properties.Count - 2);
            return properties;
        }
        /// <summary>
        /// Kiểm tra xem 'ID' của sinh viên đã tồn tại hay chưa?
        /// </summary>
        /// <param name="ID">ID của sinh viên muốn kiểm tra</param>
        /// <returns>true nếu ID đã tồn tại, ngược lại false</returns>
        public bool IsExist(string ID)
        {
            var student = db.Students.FirstOrDefault(p => p.ID == ID);
            if (student == null)
                return true;
            return false;
        }
    }
}
