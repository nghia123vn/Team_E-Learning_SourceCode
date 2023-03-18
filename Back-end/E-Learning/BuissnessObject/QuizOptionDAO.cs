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
    public class QuizOptionDTO
    {
        public string QuestionId { get; set; }
        public string OptionText { get; set; }
    }

    public class QuizOptionUpdateDTO
    {
        public string OptionID { get; set; }
        public string QuestionId { get; set; }
        public string OptionText { get; set; }
    }
    public class QuizOptionDAO
    {
        public static List<QuizOption> GetAllQuizOptions()
        {
            using (var db = new ECourseDBContext())
            {
                return db.QuizOptions.ToList();
            }
        }

        public static QuizOption GetQuizOptionById(String QuizOptionID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.QuizOptions.FirstOrDefault(s => s.OptionId == QuizOptionID);
            }
        }

        public static QuizOption CreateQuizOption(QuizOption QuizOption)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetQuizOptionById(QuizOption.OptionId) != null)
                    {
                        throw new Exception(ErrorMessage.QuizOptionError.QUIZ_OPTION_EXITED);
                    }
                    db.QuizOptions.Add(QuizOption);
                    db.SaveChanges();
                    return QuizOption;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public static void UpdateQuizOption(QuizOption QuizOption)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetQuizOptionById(QuizOption.OptionId) == null)
                    {
                        throw new Exception(ErrorMessage.QuizOptionError.QUIZ_OPTION_IS_NOT_EXITED);
                    }
                    db.QuizOptions.Update(QuizOption);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteQuizOption(String QuizOptionID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetQuizOptionById(QuizOptionID) == null)
                    {
                        throw new Exception(ErrorMessage.QuizOptionError.QUIZ_OPTION_IS_NOT_EXITED);
                    }
                    QuizOption QuizOption = GetQuizOptionById(QuizOptionID);
                    db.QuizOptions.Remove(QuizOption);
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
