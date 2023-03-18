using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface IResultRepo
    {
        public List<Result> GetResults();
        public Result GetResultByID(String ResultID);
        public Result CreateResult(ResultDTO Result);
        public void UpdateResult(ResultUpdateDTO Result);
        public void DeleteResult(String ResultID);
    }
}
