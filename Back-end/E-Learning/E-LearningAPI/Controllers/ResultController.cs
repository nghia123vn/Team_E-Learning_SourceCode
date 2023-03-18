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
    public class ResultsController : ControllerBase
    {
        private readonly IResultRepo ResultRepo = new ResultRepo();

        public ResultsController()
        {
        }

        // GET: api/Results
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Result>>> GetResults()
        {
            return ResultRepo.GetResults();
        }

        // GET: api/Results/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Result>> GetResult(string id)
        {
            var Result = ResultRepo.GetResultByID(id);

            if (Result == null)
            {
                return NotFound();
            }

            return Result;
        }

        // PUT: api/Results/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutResult(ResultUpdateDTO Result)
        {

            try
            {
                ResultRepo.UpdateResult(Result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NoContent();
        }

        // POST: api/Results
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Result>> PostResult(ResultDTO Result)
        {
            try
            {
                return Ok(ResultRepo.CreateResult(Result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // DELETE: api/Results/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResult(string id)
        {
            var Result = ResultRepo.GetResultByID(id);
            if (Result == null)
            {
                return NotFound();
            }

            ResultRepo.DeleteResult(id);

            return NoContent();
        }

        private bool ResultExists(string id)
        {
            return ResultRepo.GetResults().Any(e => e.ResultId == id);
        }
    }
}
