using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Courses.Data
{
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Course> Courses { get; set; }


        public Nationality Nationality { get; set; }
   
    }
}
