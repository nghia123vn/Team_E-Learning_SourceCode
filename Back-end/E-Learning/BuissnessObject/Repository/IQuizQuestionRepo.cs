using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface IQuizQuestionRepo
    {
        public List<QuizQuestion> GetQuizQuestions();
        public QuizQuestion GetQuizQuestionByID(String QuestionID);
        public QuizQuestion CreateQuizQuestion(QuizQuestionDTO quizQuestion);
        public void UpdateQuizQuestion(QuizQuestionUpdateDTO quizQuestion);
        public void DeleteQuizQuestion(String QuestionID);
    }
}
