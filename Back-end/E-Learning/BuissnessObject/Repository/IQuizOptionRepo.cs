using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface IQuizOptionRepo
    {
        public List<QuizOption> GetQuizOptions();
        public QuizOption GetQuizOptionByID(String OptionID);
        public QuizOption CreateQuizOption(QuizOptionDTO quizOption);
        public void UpdateQuizOption(QuizOptionUpdateDTO quizOption);
        public void DeleteQuizOption(String OptionID);
    }
}
