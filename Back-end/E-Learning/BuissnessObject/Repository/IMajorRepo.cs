using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface IMajorRepo
    {
        public List<Major> GetMajors();
        public Major GetMajorByID(String MajorID);
        public Major CreateMajor(MajorDTO Major);
        public void UpdateMajor(MajorUpdateDTO Major);
        public void DeleteMajor(String MajorID);
    }
}
