using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_EF_CodeFirst.DTO
{
    public class Student
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Class_ID { get; set; }
        [ForeignKey("Class_ID")]
        public virtual Class Class { get; set; }
    }
}
