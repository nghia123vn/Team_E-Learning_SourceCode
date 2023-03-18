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
    public class SubjectItemsController : ControllerBase
    {
        private readonly ISubjectItemRepo SubjectItemRepo = new SubjectItemRepo();

        public SubjectItemsController()
        {
        }

        // GET: api/SubjectItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectItem>>> GetSubjectItems()
        {
            return SubjectItemRepo.GetSubjectItems();
        }

        // GET: api/SubjectItems/5
        [HttpGet("{SubjectID},{StudentID}")]
        public async Task<ActionResult<SubjectItem>> GetSubjectItem(string SubjectID, string StudentID)
        {
            var SubjectItem = SubjectItemRepo.GetSubjectItemByID(SubjectID, StudentID);

            if (SubjectItem == null)
            {
                return NotFound();
            }

            return SubjectItem;
        }

        // PUT: api/SubjectItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutSubjectItem(SubjectItemDTO SubjectItem)
        {
            

            try
            {
                SubjectItemRepo.UpdateSubjectItem(SubjectItem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NoContent();
        }

        // POST: api/SubjectItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubjectItem>> PostSubjectItem(SubjectItemDTO SubjectItem)
        {
            try
            {
                return Ok(SubjectItemRepo.CreateSubjectItem(SubjectItem));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // DELETE: api/SubjectItems/5
        [HttpDelete("{SubjectID},{StudentID}")]
        public async Task<IActionResult> DeleteSubjectItem(string SubjectID, string StudentID)
        {
            var SubjectItem = SubjectItemRepo.GetSubjectItemByID(SubjectID, StudentID);
            if (SubjectItem == null)
            {
                return NotFound();
            }

            SubjectItemRepo.DeleteSubjectItem(SubjectID, StudentID);

            return NoContent();
        }

        private bool SubjectItemExists(string SubjectID, string StudentID)
        {
            return SubjectItemRepo.GetSubjectItems().Any(e => e.SubjectId == SubjectID && e.StudentId == StudentID);
        }
    }
}
