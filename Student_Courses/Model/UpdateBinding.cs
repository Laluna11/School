using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Student_Courses.Model
{
    public class UpdateBinding
    {

        [Display(Name = "Enter Your Name : ")]
        [Required(ErrorMessage = "Name field is required!")]
        public string StudentName { get; set; }

        [Display(Name = "Enter Your Age: ")]
        [Required(ErrorMessage = "Age is required!")]
        public int Age { get; set; }

        [Display(Name = "Gender: ")]
        [Required(ErrorMessage = "Gender is required!")]
        public string Gender { get; set; }

        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Courses : ")]
        [Required]
        public List<int> CourseIds { get; set; }

        [Display(Name = "Nationality : ")]
        [Required]
        public int Nationality { get; set; }
    }
}

