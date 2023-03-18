using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface ICourseRepo
    {
        public List<Course> GetCourses();
        public Course GetCourseByID(String CourseID);
        public Course CreateCourse(CourseDTO Course);
        public void UpdateCourse(CourseUpdateDTO Course);
        public void DeleteCourse(String CourseID);
    }
}
