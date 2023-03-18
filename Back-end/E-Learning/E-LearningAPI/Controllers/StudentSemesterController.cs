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
    public class StudentSemestersController : ControllerBase
    {
        private readonly IStudentSemesterRepo StudentSemesterRepo = new StudentSemesterRepo();

        public StudentSemestersController()
        {
        }

        // GET: api/StudentSemesters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentSemester>>> GetStudentSemesters()
        {
            return StudentSemesterRepo.GetStudentSemesters();
        }

        // GET: api/StudentSemesters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentSemester>> GetStudentSemester(string id)
        {
            var StudentSemester = StudentSemesterRepo.GetStudentSemesterByID(id);

            if (StudentSemester == null)
            {
                return NotFound();
            }

            return StudentSemester;
        }

        // PUT: api/StudentSemesters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutStudentSemester(StudentSemesterUpdateDTO  StudentSemester)
        {
            try
            {
                StudentSemesterRepo.UpdateStudentSemester(StudentSemester);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NoContent();
        }

        // POST: api/StudentSemesters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentSemester>> PostStudentSemester(StudentSemesterDTO StudentSemester)
        {
            try
            {
                return Ok(StudentSemesterRepo.CreateStudentSemester(StudentSemester));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // DELETE: api/StudentSemesters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentSemester(string id)
        {
            var StudentSemester = StudentSemesterRepo.GetStudentSemesterByID(id);
            if (StudentSemester == null)
            {
                return NotFound();
            }

            StudentSemesterRepo.DeleteStudentSemester(id);

            return NoContent();
        }

        private bool StudentSemesterExists(string id)
        {
            return StudentSemesterRepo.GetStudentSemesters().Any(e => e.StudentSemesterId == id);
        }
    }
}
