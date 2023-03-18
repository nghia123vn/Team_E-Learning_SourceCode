using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class MajorRepo : IMajorRepo
    {
        public List<Major> GetMajors() => MajorDAO.GetAllMajors();
        public Major GetMajorByID(String MajorID) => MajorDAO.GetMajorById(MajorID);
        public Major CreateMajor(MajorDTO MajorDTO)
        {
            var MajorCount = MajorDAO.GetAllMajors().Count;
            var Major = new Major()
            {
                MajorId = "Major" + (MajorCount + 1),
                MajorName = MajorDTO.MajorName
            };
            return MajorDAO.CreateMajor(Major);
        }
        public void UpdateMajor(MajorUpdateDTO MajorDTO)
        {
            var Major = new Major()
            {
                MajorId = MajorDTO.MajorID,
                MajorName = MajorDTO.MajorName
            };
            MajorDAO.UpdateMajor(Major);
        }
        public void DeleteMajor(String MajorID) => MajorDAO.DeleteMajor(MajorID);
    }
}
