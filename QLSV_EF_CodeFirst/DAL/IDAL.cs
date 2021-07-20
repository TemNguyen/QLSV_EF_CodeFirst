using QLSV_EF_CodeFirst.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_EF_CodeFirst.DAL
{
    interface IDAL
    {
        /// <summary>
        /// Lấy danh sách sinh viên ứng với class_ID và student_Name
        /// </summary>
        /// <param name="class_ID">Mã Lớp</param>
        /// <param name="student_Name">Tên sinh viên</param>
        /// <returns></returns>
        List<Student> GetStudents(int class_ID, string student_Name);
        /// <summary>
        /// Lấy danh sách toàn bộ lớp hiện có
        /// </summary>
        /// <returns></returns>
        List<Class> GetClasses();
        /// <summary>
        /// Thêm 1 sinh viên vào csdl
        /// </summary>
        /// <param name="student">Đối tượng sinh viên được thêm</param>
        /// <returns>true nếu được thêm thành công, ngược lại false</returns>
        bool AddStudent(Student student);
        /// <summary>
        /// Xóa 1 hoặc nhiều sinh viên.
        /// </summary>
        /// <param name="IDs">Danh sách ID của sinh viên được xóa</param>
        /// <returns></returns>
        bool DeleteStudents(List<string> IDs);
        /// <summary>
        /// Lấy thông tin của 1 sinh viên theo ID
        /// </summary>
        /// <param name="ID">ID của sinh viên được lấy thông tin</param>
        /// <returns></returns>
        Student GetStudentByID(string ID);
        /// <summary>
        /// Cập nhập thông tin của 1 sinh viên
        /// </summary>
        /// <param name="student">Đối tượng sinh viên cần được update</param>
        /// <returns></returns>
        bool UpdateStudent(Student student);
        /// <summary>
        /// Lấy danh sách các thuộc tính của sinh viên
        /// </summary>
        /// <returns></returns>
        List<string> GetStudentProperty();
        /// <summary>
        /// Kiểm tra xem 'ID' của sinh viên đã tồn tại hay chưa?
        /// </summary>
        /// <param name="ID">ID của sinh viên muốn kiểm tra</param>
        /// <returns>true nếu ID đã tồn tại, ngược lại false</returns>
        bool IsExist(string ID);
    }
}
