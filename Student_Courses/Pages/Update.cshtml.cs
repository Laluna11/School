using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_Courses.Data;
using Student_Courses.Model;
using Student_Courses.Services;
using System.Collections.Generic;

namespace Student_Courses.Pages
{
    public class UpdateModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }


        private readonly StudentService service;
        public UpdateModel(StudentService service)
        {
            this.service = service;
        }
        [BindProperty]
        public UpdateBinding Student { get; set; }

        public Student st { get; set; }

        public List<SelectListItem> Courses { get; set; } = new List<SelectListItem>{
                new SelectListItem {
                    Value = "",
                    Text = "Choose courses",
                    Disabled = true

                }
        };

        public List<SelectListItem> Nationality { get; set; } = new List<SelectListItem>{
                new SelectListItem {
                    Value = "",
                    Text = "Nationality",
                    Disabled = true
                }
        };

        public void OnGet()
        {
            st = service.GetStudent(Id, Courses,Nationality);


        }

        public IActionResult OnPost()
        {
            

            if (ModelState.IsValid)
            {
                service.Edit(Id , Student);
                return RedirectToPage("/AllStudents");
            }
            return Page();
        }
    }
}
