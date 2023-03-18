using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using BuissnessObject.Repository;
using BuissnessObject;

namespace E_LearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepo CourseRepo = new CourseRepo();

        public CoursesController()
        {
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return CourseRepo.GetCourses();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(string id)
        {
            var Course = CourseRepo.GetCourseByID(id);

            if (Course == null)
            {
                return NotFound();
            }

            return Course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutCourse(CourseUpdateDTO Course)
        {

            try
            {
                CourseRepo.UpdateCourse(Course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CourseDTO Course)
        {
            try
            {
                return Ok(CourseRepo.CreateCourse(Course));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            var Course = CourseRepo.GetCourseByID(id);
            if (Course == null)
            {
                return NotFound();
            }

            CourseRepo.DeleteCourse(id);

            return NoContent();
        }

        private bool CourseExists(string id)
        {
            return CourseRepo.GetCourses().Any(e => e.CourseId == id);
        }
    }
}
