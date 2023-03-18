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
    public class QuizsController : ControllerBase
    {
        private readonly IQuizRepo QuizRepo = new QuizRepo();

        public QuizsController()
        {
        }

        // GET: api/Quizs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizs()
        {
            return QuizRepo.GetQuizs();
        }

        // GET: api/Quizs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quiz>> GetQuiz(string id)
        {
            var Quiz = QuizRepo.GetQuizByID(id);

            if (Quiz == null)
            {
                return NotFound();
            }

            return Quiz;
        }

        // PUT: api/Quizs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutQuiz(QuizUpdateDTO Quiz)
        {

            try
            {
                QuizRepo.UpdateQuiz(Quiz);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NoContent();
        }

        // POST: api/Quizs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quiz>> PostQuiz(QuizDTO Quiz)
        {
            try
            {
                return Ok(QuizRepo.CreateQuiz(Quiz));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // DELETE: api/Quizs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(string id)
        {
            var Quiz = QuizRepo.GetQuizByID(id);
            if (Quiz == null)
            {
                return NotFound();
            }

            QuizRepo.DeleteQuiz(id);

            return NoContent();
        }

        private bool QuizExists(string id)
        {
            return QuizRepo.GetQuizs().Any(e => e.QuizId == id);
        }
    }
}
