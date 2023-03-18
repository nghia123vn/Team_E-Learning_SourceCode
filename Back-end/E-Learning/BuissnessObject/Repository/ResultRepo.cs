using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class ResultRepo : IResultRepo
    {
        public List<Result> GetResults() => ResultDAO.GetAllResults();
        public Result GetResultByID(String ResultID) => ResultDAO.GetResultById(ResultID);
        public Result CreateResult(ResultDTO ResultDTO)
        {
            var ResultCount = ResultDAO.GetAllResults().Count;
            var Result = new Result()
            {
                ResultId = "Result" + (ResultCount + 1),
                CorrectQuestion = ResultDTO.CorrectQuestion,
                Point = ResultDTO.Point,
                QuizId = ResultDTO.QuizId,
                StudentName = ResultDTO.StudentName
            };
            return ResultDAO.CreateResult(Result);
        }
        public void UpdateResult(ResultUpdateDTO ResultDTO)
        {
            var Result = new Result()
            {
                ResultId = ResultDTO.ResultID,
                CorrectQuestion = ResultDTO.CorrectQuestion,
                Point = ResultDTO.Point,
                QuizId = ResultDTO.QuizId,
                StudentName = ResultDTO.StudentName
            };
            ResultDAO.UpdateResult(Result);
        }
        public void DeleteResult(String ResultID) => ResultDAO.DeleteResult(ResultID);
    }
}
