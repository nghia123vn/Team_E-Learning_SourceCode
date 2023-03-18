using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class CourseRepo : ICourseRepo
    {
        public List<Course> GetCourses() => CourseDAO.GetAllCourses();
        public Course GetCourseByID(String CourseID) => CourseDAO.GetCourseById(CourseID);
        public Course CreateCourse(CourseDTO CourseDTO)
        {
            var CourseCount = CourseDAO.GetAllCourses().Count;
            var Course = new Course()
            {
                CourseId = "Course" + (CourseCount + 1),
                LinkCourse = CourseDTO.LinkCourse,
                SubjectId = CourseDTO.SubjectId,
                TeacherId = CourseDTO.TeacherId,
                Time = CourseDTO.Time
            };
            return CourseDAO.CreateCourse(Course);
        }
        public void UpdateCourse(CourseUpdateDTO CourseDTO)
        {
            var Course = new Course()
            {
                CourseId = CourseDTO.CourseID,
                LinkCourse = CourseDTO.LinkCourse,
                SubjectId = CourseDTO.SubjectId,
                TeacherId = CourseDTO.TeacherId,
                Time = CourseDTO.Time
            };
            CourseDAO.UpdateCourse(Course);
        }
        public void DeleteCourse(String CourseID) => CourseDAO.DeleteCourse(CourseID);
    }
}
