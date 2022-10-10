using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Courses.Data;
using Student_Courses.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Courses.Services
{
    public class StudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void CreateStudent(StudentBinding student)
        {

            List<Course> courses = new List<Course>();
            foreach (int Course in student.CourseIds)
            {
                courses.Add(_context.Courses.Where(n => n.CourseId == Course).Select(n => n).Single());
                
            }

            Student s = new Student
            {
                StudentName = student.StudentName,
                Age = student.Age,
                Email = student.Email,
                Gender = student.Gender,
                Nationality = _context.Nationality.Where(n => n.NationalityID == student.Nationality).Select(n => n).Single(),
                Courses = courses,

            };

            _context.Students.Add(s);
            _context.SaveChanges();
          
        }


        public bool CourseExist(ICollection<Course> courses , int id )
        {
            foreach (var course in courses)
            {
                if(course.CourseId == id)
                {
                    return true;
                }
                
            }
            return false;
        }

       /* public bool NationalityExist(ICollection<Nationality> nationalities, int id)
        {
            foreach (var nationality in nationalities)
            {
                if (nationality.NationalityID == id)
                {
                    return true;
                }

            }
            return false;
        }*/

        public Student GetStudent(int id, List<SelectListItem> courses , List<SelectListItem> nationality)
        {
            Student st = _context.Students.Where(s=>s.StudentId == id).Include(C => C.Nationality).Include(C=>C.Courses).Single();

            List<Course> c = _context.Courses.ToList();

            foreach (var course in c)
            {
               
                if (CourseExist(st.Courses , course.CourseId))
                {
                    SelectListItem s = new SelectListItem()
                    {
                        Value = course.CourseId.ToString(),
                        Text = course.Name,
                        Selected = true
                    };
                    courses.Add(s);
                }
                else
                {

                    SelectListItem s = new SelectListItem()
                    {
                        Value = course.CourseId.ToString(),
                        Text = course.Name,
                        Selected = false
                    };
                    courses.Add(s);
                }
                
            }

            List<Nationality> n = _context.Nationality.ToList();

            foreach (var nationality1 in n)
            {

                if(nationality1.NationalityID == st.Nationality.NationalityID){
                    SelectListItem s = new SelectListItem()
                    {
                        Value = nationality1.NationalityID.ToString(),
                        Text = nationality1.Name,
                        Selected = true
                    };
                    nationality.Add(s);
                }
                else
                {

                    SelectListItem s = new SelectListItem()
                    {
                        Value = nationality1.NationalityID.ToString(),
                        Text = nationality1.Name,
                        Selected = false
                    };
                    nationality.Add(s);

                }

            }

            return st ;
        }


        public List<Student> GetAllStudent()
        {
            return _context.Students.Where(n => !n.IsDeleted).Include(s => s.Courses).Include(s => s.Nationality).ToList();
           
        }

        public List<SelectListItem> GetAllCourses(List<SelectListItem> courses)
        {

            List<Course> c = _context.Courses.ToList();

            foreach (var course in c)
            {
                SelectListItem s = new SelectListItem()
                {
                    Value = course.CourseId.ToString(),
                    Text = course.Name,
                    Selected= false
                };
                courses.Add(s);
            }
            return courses;
            

            
        }

        public List<SelectListItem> GetAllNationalities(List<SelectListItem> nationality)
        {

            List<Nationality> c = _context.Nationality.ToList();

            foreach (var nationality1 in c)
            {
                SelectListItem s = new SelectListItem()
                {
                    Value = nationality1.NationalityID.ToString(),
                    Text = nationality1.Name,
                    Selected = false
                };
                nationality.Add(s);
            }
            return nationality;



        }


        public Student Edit(int id , UpdateBinding student)
        {

            Student st = _context.Students.Where(n=> n.StudentId == id).Include(n => n.Courses).Single();

            st.StudentName = student.StudentName;
            st.Age = student.Age;
            st.Gender = student.Gender;
            st.Email = student.Email;
            st.Nationality = _context.Nationality.Where(n => n.NationalityID == student.Nationality).Select(n => n).Single();
            List<Course> courses = new List<Course>();

            foreach (var item in st.Courses)
            {
                st.Courses.Remove(item);

            }


            foreach (int Course in student.CourseIds)
            {
                 
               st.Courses.Add(_context.Courses.Where(n => n.CourseId == Course).Select(n => n).Single());

            }
            


            _context.SaveChanges();
            return st;


        }

    

        public void DeleteStudent(int id)
        {
            Student student = _context.Students.Find(id);

            student.IsDeleted = true;
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();

            }
        }

       
    }

   


}
