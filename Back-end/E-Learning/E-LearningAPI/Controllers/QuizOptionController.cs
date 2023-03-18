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
    public class QuizOptionsController : ControllerBase
    {
        private readonly IQuizOptionRepo QuizOptionRepo = new QuizOptionRepo();

        public QuizOptionsController()
        {
        }

        // GET: api/QuizOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizOption>>> GetQuizOptions()
        {
            return QuizOptionRepo.GetQuizOptions();
        }

        // GET: api/QuizOptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizOption>> GetQuizOption(string id)
        {
            var QuizOption = QuizOptionRepo.GetQuizOptionByID(id);

            if (QuizOption == null)
            {
                return NotFound();
            }

            return QuizOption;
        }

        // PUT: api/QuizOptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutQuizOption(QuizOptionUpdateDTO QuizOption)
        {

            try
            {
                QuizOptionRepo.UpdateQuizOption(QuizOption);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NoContent();
        }

        // POST: api/QuizOptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuizOption>> PostQuizOption(QuizOptionDTO QuizOption)
        {
            try
            {
                return Ok(QuizOptionRepo.CreateQuizOption(QuizOption));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // DELETE: api/QuizOptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizOption(string id)
        {
            var QuizOption = QuizOptionRepo.GetQuizOptionByID(id);
            if (QuizOption == null)
            {
                return NotFound();
            }

            QuizOptionRepo.DeleteQuizOption(id);

            return NoContent();
        }

        private bool QuizOptionExists(string id)
        {
            return QuizOptionRepo.GetQuizOptions().Any(e => e.OptionId == id);
        }
    }
}
