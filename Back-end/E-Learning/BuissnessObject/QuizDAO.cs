using DataAccess.ErrorMessage;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject
{
    public class QuizDTO
    {
        public string StudentName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CourseId { get; set; }
    }
    public class QuizUpdateDTO
    {
        public string QuizID { get; set; }
        public string StudentName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CourseId { get; set; }
    }
    public class QuizDAO
    {
        public static List<Quiz> GetAllQuizs()
        {
            using (var db = new ECourseDBContext())
            {
                return db.Quizzes.ToList();
            }
        }

        public static Quiz GetQuizById(String QuizID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.Quizzes.FirstOrDefault(s => s.QuizId == QuizID);
            }
        }

        public static Quiz CreateQuiz(Quiz Quiz)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetQuizById(Quiz.QuizId) != null)
                    {
                        throw new Exception(ErrorMessage.QuizError.QUIZ_EXITED);
                    }
                    db.Quizzes.Add(Quiz);
                    db.SaveChanges();
                    return Quiz;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public static void UpdateQuiz(Quiz Quiz)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetQuizById(Quiz.QuizId) == null)
                    {
                        throw new Exception(ErrorMessage.QuizError.QUIZ_IS_NOT_EXITED);
                    }
                    db.Quizzes.Update(Quiz);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteQuiz(String QuizID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetQuizById(QuizID) == null)
                    {
                        throw new Exception(ErrorMessage.QuizError.QUIZ_IS_NOT_EXITED);
                    }
                    Quiz Quiz = GetQuizById(QuizID);
                    db.Quizzes.Remove(Quiz);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
