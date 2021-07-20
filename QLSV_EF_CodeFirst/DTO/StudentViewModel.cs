using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_EF_CodeFirst.DTO
{
    class StudentViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Class_Name { get; set; }
    }
}
