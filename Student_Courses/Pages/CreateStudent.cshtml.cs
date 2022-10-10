using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_Courses.Model;
using Student_Courses.Services;
using System.Collections.Generic;

namespace Student_Courses.Pages
{
    public class CreateStudentModel : PageModel
    {
        [BindProperty]
        public StudentBinding Student { get; set; }


        private readonly StudentService service;
        public CreateStudentModel(StudentService service)
        {
            this.service = service;
        }

        public List<SelectListItem> Courses { get; set; } = new List<SelectListItem>{
                new SelectListItem {
                    Value = "",
                    Text = "Choose courses",
                    Selected = true,
                    Disabled = true
                }
        };

        public List<SelectListItem> Nationality { get; set; } = new List<SelectListItem>{
                new SelectListItem {
                    Value = "",
                    Text = "Nationality",
                    Selected = true,
                    Disabled = true
                }
        };

        public void OnGet()
        {
            Courses = service.GetAllCourses(Courses);
            Nationality = service.GetAllNationalities(Nationality);


        }

        public IActionResult OnPost()
        {
            Courses = service.GetAllCourses(Courses);
            Nationality = service.GetAllNationalities(Nationality);

            if (ModelState.IsValid)
            {
                service.CreateStudent(Student);
                return RedirectToPage("/AllStudents");
            }
            return Page();
        }
    }
}
