using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_EF_CodeFirst.DTO
{
    public class Class
    {
        [Key]
        public int Class_ID { get; set; }
        public string Class_Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public Class()
        {
            Students = new HashSet<Student>();
        }
    }
}
