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
    public class QuizQuestionsController : ControllerBase
    {
        private readonly IQuizQuestionRepo QuizQuestionRepo = new QuizQuestionRepo();

        public QuizQuestionsController()
        {
        }

        // GET: api/QuizQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizQuestion>>> GetQuizQuestions()
        {
            return QuizQuestionRepo.GetQuizQuestions();
        }

        // GET: api/QuizQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizQuestion>> GetQuizQuestion(string id)
        {
            var QuizQuestion = QuizQuestionRepo.GetQuizQuestionByID(id);

            if (QuizQuestion == null)
            {
                return NotFound();
            }

            return QuizQuestion;
        }

        // PUT: api/QuizQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutQuizQuestion(QuizQuestionUpdateDTO QuizQuestion)
        {

            try
            {
                QuizQuestionRepo.UpdateQuizQuestion(QuizQuestion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NoContent();
        }

        // POST: api/QuizQuestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuizQuestion>> PostQuizQuestion(QuizQuestionDTO QuizQuestion)
        {
            try
            {
                return Ok(QuizQuestionRepo.CreateQuizQuestion(QuizQuestion));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // DELETE: api/QuizQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizQuestion(string id)
        {
            var QuizQuestion = QuizQuestionRepo.GetQuizQuestionByID(id);
            if (QuizQuestion == null)
            {
                return NotFound();
            }

            QuizQuestionRepo.DeleteQuizQuestion(id);

            return NoContent();
        }

        private bool QuizQuestionExists(string id)
        {
            return QuizQuestionRepo.GetQuizQuestions().Any(e => e.QuestionId == id);
        }
    }
}
