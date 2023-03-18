using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class QuizRepo : IQuizRepo
    {
        public List<Quiz> GetQuizs() => QuizDAO.GetAllQuizs();
        public Quiz GetQuizByID(String QuizID) => QuizDAO.GetQuizById(QuizID);
        public Quiz CreateQuiz(QuizDTO QuizDTO)
        {
            var QuizCount = QuizDAO.GetAllQuizs().Count;
            var Quiz = new Quiz()
            {
                QuizId = "Quiz" + (QuizCount + 1),
                StudentName = QuizDTO.StudentName,
                CourseId = QuizDTO.CourseId,
                EndDate = QuizDTO.EndDate,
                StartDate = QuizDTO.StartDate
            };
            return QuizDAO.CreateQuiz(Quiz);
        }
        public void UpdateQuiz(QuizUpdateDTO QuizDTO)
        {
            var Quiz = new Quiz()
            {
                QuizId = QuizDTO.QuizID,
                StudentName = QuizDTO.StudentName,
                CourseId = QuizDTO.CourseId,
                EndDate = QuizDTO.EndDate,
                StartDate = QuizDTO.StartDate
            };
            QuizDAO.UpdateQuiz(Quiz);
        }
        public void DeleteQuiz(String QuizID) => QuizDAO.DeleteQuiz(QuizID);
    }
}
