using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class QuizQuestionRepo : IQuizQuestionRepo
    {
        public List<QuizQuestion> GetQuizQuestions() => QuizQuestionDAO.GetAllQuizQuestions();
        public QuizQuestion GetQuizQuestionByID(String QuizQuestionID) => QuizQuestionDAO.GetQuizQuestionById(QuizQuestionID);
        public QuizQuestion CreateQuizQuestion(QuizQuestionDTO QuizQuestionDTO)
        {
            var QuizQuestionCount = QuizQuestionDAO.GetAllQuizQuestions().Count;
            var QuizQuestion = new QuizQuestion()
            {
                QuestionId = "QuizQuestion" + (QuizQuestionCount + 1),
                Question = QuizQuestionDTO.Question,
                QuizId = QuizQuestionDTO.QuizId,
                Answer = QuizQuestionDTO.Answer
            };
            return QuizQuestionDAO.CreateQuizQuestion(QuizQuestion);
        }
        public void UpdateQuizQuestion(QuizQuestionUpdateDTO QuizQuestionDTO)
        {
            var QuizQuestion = new QuizQuestion()
            {
                QuestionId = QuizQuestionDTO.QuestionID,
                Question = QuizQuestionDTO.Question,
                QuizId = QuizQuestionDTO.QuizId,
                Answer = QuizQuestionDTO.Answer
            };
            QuizQuestionDAO.UpdateQuizQuestion(QuizQuestion);
        }
        public void DeleteQuizQuestion(String QuizQuestionID) => QuizQuestionDAO.DeleteQuizQuestion(QuizQuestionID);
    }
}
