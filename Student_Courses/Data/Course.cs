using System.Collections.Generic;

namespace Student_Courses.Data
{
    public class Course
    {

        public int CourseId { get; set; }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Student> Student { get; set; }


    }
}
