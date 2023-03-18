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
    public class SemestersController : ControllerBase
    {
        private readonly ISemesterRepo SemesterRepo = new SemesterRepo();

        public SemestersController()
        {
        }

        // GET: api/Semesters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Semester>>> GetSemesters()
        {
            return SemesterRepo.GetSemesters();
        }

        // GET: api/Semesters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Semester>> GetSemester(string id)
        {
            var Semester = SemesterRepo.GetSemesterByID(id);

            if (Semester == null)
            {
                return NotFound();
            }

            return Semester;
        }

        // PUT: api/Semesters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutSemester(SemesterUpdateDTO Semester)
        {

            try
            {
                SemesterRepo.UpdateSemester(Semester);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NoContent();
        }

        // POST: api/Semesters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Semester>> PostSemester(SemesterDTO Semester)
        {
            try
            {
                return Ok(SemesterRepo.CreateSemester(Semester));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // DELETE: api/Semesters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(string id)
        {
            var Semester = SemesterRepo.GetSemesterByID(id);
            if (Semester == null)
            {
                return NotFound();
            }

            SemesterRepo.DeleteSemester(id);

            return NoContent();
        }

        private bool SemesterExists(string id)
        {
            return SemesterRepo.GetSemesters().Any(e => e.SemesterId == id);
        }
    }
}
