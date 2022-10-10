using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Courses.Data;
using Student_Courses.Services;
using System;
using System.Collections.Generic;

namespace Student_Courses.Pages
{
    public class AllStudentsModel : PageModel
    {

        private readonly StudentService Student;

        public AllStudentsModel(StudentService Student)
        {
            this.Student = Student;
        }

        public List<Student> students { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public void OnGet()
        {
            students = Student.GetAllStudent();
            

        }
      

         public IActionResult OnPostZizi()
         {
            Student.DeleteStudent(Id);
            return RedirectToPage("/AllStudents");
         }
    }
}
