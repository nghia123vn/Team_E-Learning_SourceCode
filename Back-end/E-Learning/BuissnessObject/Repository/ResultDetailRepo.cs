using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class ResultDetailRepo : IResultDetailRepo
    {
        public List<ResultDetail> GetResultDetails() => ResultDetailDAO.GetAllResultDetails();
        public ResultDetail GetResultDetailByID(String ResultID, String QuestionID) => ResultDetailDAO.GetResultDetailById(ResultID, QuestionID);
        public ResultDetail CreateResultDetail(ResultDetailDTO ResultDetailDTO)
        {
            var ResultDetail = new ResultDetail()
            {
                ResultId = ResultDetailDTO.ResultId, 
                IsCorrect = ResultDetailDTO.IsCorrect,
                OptionId = ResultDetailDTO.OptionId,
                OptionText = ResultDetailDTO.OptionText,
                QuestionId = ResultDetailDTO.QuestionId,      
                Question = ResultDetailDTO.Question
            };
            return ResultDetailDAO.CreateResultDetail(ResultDetail);
        }
        public void UpdateResultDetail(ResultDetailDTO ResultDetailDTO)
        {
            var ResultDetail = new ResultDetail()
            {
                ResultId = ResultDetailDTO.ResultId,
                IsCorrect = ResultDetailDTO.IsCorrect,
                OptionId = ResultDetailDTO.OptionId,
                OptionText = ResultDetailDTO.OptionText,
                QuestionId = ResultDetailDTO.QuestionId,
                Question = ResultDetailDTO.Question
            };
            ResultDetailDAO.UpdateResultDetail(ResultDetail);
        }
        public void DeleteResultDetail(String ResultID, String QuestionID) => ResultDetailDAO.DeleteResultDetail(ResultID, QuestionID);
    }
}
