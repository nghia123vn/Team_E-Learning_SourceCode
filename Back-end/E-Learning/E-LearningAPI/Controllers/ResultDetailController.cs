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
    public class ResultDetailsController : ControllerBase
    {
        private readonly IResultDetailRepo ResultDetailRepo = new ResultDetailRepo();

        public ResultDetailsController()
        {
        }

        // GET: api/ResultDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultDetail>>> GetResultDetails()
        {
            return ResultDetailRepo.GetResultDetails();
        }

        // GET: api/ResultDetails/5
        [HttpGet("{ResultID},{QuestionID}")]
        public async Task<ActionResult<ResultDetail>> GetResultDetail(string ResultID, string QuestionID)
        {
            var ResultDetail = ResultDetailRepo.GetResultDetailByID(ResultID, QuestionID);

            if (ResultDetail == null)
            {
                return NotFound();
            }

            return ResultDetail;
        }

        // PUT: api/ResultDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{ResultID},{QuestionID}")]
        public async Task<IActionResult> PutResultDetail(ResultDetailDTO ResultDetail)
        {
            

            try
            {
                ResultDetailRepo.UpdateResultDetail(ResultDetail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NoContent();
        }

        // POST: api/ResultDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResultDetail>> PostResultDetail(ResultDetailDTO ResultDetail)
        {
            try
            {
                return Ok(ResultDetailRepo.CreateResultDetail(ResultDetail));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/ResultDetails/5
        [HttpDelete("{ResultID},{QuestionID}")]
        public async Task<IActionResult> DeleteResultDetail(string ResultID, string QuestionID)
        {
            var ResultDetail = ResultDetailRepo.GetResultDetailByID(ResultID, QuestionID);
            if (ResultDetail == null)
            {
                return NotFound();
            }

            ResultDetailRepo.DeleteResultDetail(ResultID, QuestionID);

            return NoContent();
        }

        private bool ResultDetailExists(string ResultID, string QuestionID)
        {
            return ResultDetailRepo.GetResultDetails().Any(e => e.ResultId == ResultID && e.QuestionId == QuestionID);
        }
    }
}
