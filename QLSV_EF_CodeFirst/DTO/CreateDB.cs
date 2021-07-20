using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QLSV_EF_CodeFirst.DTO
{
    class CreateDB : CreateDatabaseIfNotExists<CSDL>
    {
        protected override void Seed(CSDL context)
        {
            context.Students.AddRange(new Student[]
            {
                new Student {ID = "1", Name = "NVA", Gender = true, DateOfBirth = DateTime.Now, Class_ID = 1},
                new Student {ID = "2", Name = "NVB", Gender = true, DateOfBirth = DateTime.Now, Class_ID = 2},
                new Student {ID = "3", Name = "NVC", Gender = true, DateOfBirth = DateTime.Now, Class_ID = 1},
                new Student {ID = "4", Name = "NTC", Gender = false, DateOfBirth = DateTime.Now, Class_ID = 2},
                new Student {ID = "5", Name = "NTD", Gender = false, DateOfBirth = DateTime.Now, Class_ID = 1}
            });

            context.Classes.AddRange(new Class[]
            {
                new Class {Class_ID = 1, Class_Name = "CNTT"},
                new Class {Class_ID = 2, Class_Name = "DTVT"}
            });
        }
    }
}
