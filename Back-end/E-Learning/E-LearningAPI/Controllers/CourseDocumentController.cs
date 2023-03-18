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
    public class CourseDocumentsController : ControllerBase
    {
        private readonly ICourseDocumentRepo CourseDocumentRepo = new CourseDocumentRepo();

        public CourseDocumentsController()
        {
        }

        // GET: api/CourseDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDocument>>> GetCourseDocuments()
        {
            return CourseDocumentRepo.GetCourseDocuments();
        }

        // GET: api/CourseDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDocument>> GetCourseDocument(string id)
        {
            var CourseDocument = CourseDocumentRepo.GetCourseDocumentByID(id);

            if (CourseDocument == null)
            {
                return NotFound();
            }

            return CourseDocument;
        }

        // PUT: api/CourseDocuments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutCourseDocument(CourseDocumentUpdateDTO CourseDocument)
        {

            try
            {
                CourseDocumentRepo.UpdateCourseDocument(CourseDocument);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NoContent();
        }

        // POST: api/CourseDocuments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseDocument>> PostCourseDocument(CourseDocumentDTO CourseDocument)
        {
            try
            {
                return Ok(CourseDocumentRepo.CreateCourseDocument(CourseDocument));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // DELETE: api/CourseDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseDocument(string id)
        {
            var CourseDocument = CourseDocumentRepo.GetCourseDocumentByID(id);
            if (CourseDocument == null)
            {
                return NotFound();
            }

            CourseDocumentRepo.DeleteCourseDocument(id);

            return NoContent();
        }

        private bool CourseDocumentExists(string id)
        {
            return CourseDocumentRepo.GetCourseDocuments().Any(e => e.DocumentId == id);
        }
    }
}
