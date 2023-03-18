using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class QuizOptionRepo : IQuizOptionRepo
    {
        public List<QuizOption> GetQuizOptions() => QuizOptionDAO.GetAllQuizOptions();
        public QuizOption GetQuizOptionByID(String QuizOptionID) => QuizOptionDAO.GetQuizOptionById(QuizOptionID);
        public QuizOption CreateQuizOption(QuizOptionDTO QuizOptionDTO)
        {
            var QuizOptionCount = QuizOptionDAO.GetAllQuizOptions().Count;
            var QuizOption = new QuizOption()
            {
                OptionId = "QuizOption" + (QuizOptionCount + 1),
                QuestionId = QuizOptionDTO.QuestionId,
                OptionText = QuizOptionDTO.OptionText
            };
            return QuizOptionDAO.CreateQuizOption(QuizOption);
        }
        public void UpdateQuizOption(QuizOptionUpdateDTO QuizOptionDTO)
        {
            var QuizOption = new QuizOption()
            {
                OptionId = QuizOptionDTO.OptionID,
                QuestionId = QuizOptionDTO.QuestionId,
                OptionText = QuizOptionDTO.OptionText
            };
            QuizOptionDAO.UpdateQuizOption(QuizOption);
        }
        public void DeleteQuizOption(String QuizOptionID) => QuizOptionDAO.DeleteQuizOption(QuizOptionID);
    }
}
