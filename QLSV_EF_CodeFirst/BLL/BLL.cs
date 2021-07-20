using QLSV_EF_CodeFirst.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_EF_CodeFirst.BLL
{
    class BLL
    {
        public static BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        private static BLL _Instance;
        private BLL()
        {

        }
        public List<StudentViewModel> GetStudents(int class_ID, string student_Name)
        {
            List<StudentViewModel> studentViewModels = new List<StudentViewModel>();
            var students = DAL.DAL.Instance.GetStudents(class_ID, student_Name);
            foreach (var s in students)
            {
                studentViewModels.Add(new StudentViewModel
                {
                    ID = s.ID,
                    Name = s.Name,
                    Gender = s.Gender,
                    DateOfBirth = s.DateOfBirth,
                    Class_Name = s.Class.Class_Name
                });
            }
            return studentViewModels;
        }
        public List<Class> GetClasses()
        {
            return DAL.DAL.Instance.GetClasses();
        }
        public List<string> GetStudentProperty()
        {
            return DAL.DAL.Instance.GetStudentProperty();
        }
        public List<StudentViewModel> Sort(List<StudentViewModel> students, string property)
        {
            List<StudentViewModel> sortedList = new List<StudentViewModel>();
            switch (property)
            {
                case "ID":
                    sortedList = students.OrderBy(p => p.ID).ToList();
                    break;
                case "Name":
                    sortedList = students.OrderBy(p => p.Name).ToList();
                    break;
                case "Gender":
                    sortedList = students.OrderBy(p => p.Gender).ToList();
                    break;
                case "DateOfBirth":
                    sortedList = students.OrderBy(p => p.DateOfBirth).ToList();
                    break;
                case "Class":
                    sortedList = students.OrderBy(p => p.Class_Name).ToList();
                    break;
            }
            return sortedList;
        }
        public bool DeleteStudents(List<string> IDs)
        {
            return DAL.DAL.Instance.DeleteStudents(IDs);
        }
        public bool AddStudent(Student student)
        {
            return DAL.DAL.Instance.AddStudent(student);
        }
        public bool IsExist(string ID)
        {
            return DAL.DAL.Instance.IsExist(ID);
        }
        public Student GetStudentByID(string ID)
        {
            return DAL.DAL.Instance.GetStudentByID(ID);
        }
        public bool UpdateStudent(Student student)
        {
            return DAL.DAL.Instance.UpdateStudent(student);
        }
    }
}
