using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class SemesterRepo : ISemesterRepo
    {
        public List<Semester> GetSemesters() => SemesterDAO.GetAllSemesters();
        public Semester GetSemesterByID(String SemesterID) => SemesterDAO.GetSemesterById(SemesterID);
        public Semester CreateSemester(SemesterDTO SemesterDTO)
        {
            var SemesterCount = SemesterDAO.GetAllSemesters().Count;
            var Semester = new Semester()
            {
                SemesterId = "Semester" + (SemesterCount + 1),
                SemesterName = SemesterDTO.SemesterName,
                StartDate = SemesterDTO.StartDate,
                EndDate = SemesterDTO.EndDate             
            };
            return SemesterDAO.CreateSemester(Semester);
        }
        public void UpdateSemester(SemesterUpdateDTO SemesterDTO)
        {
            var Semester = new Semester()
            {
                SemesterId = SemesterDTO.SemesterID,
                SemesterName = SemesterDTO.SemesterName,
                StartDate = SemesterDTO.StartDate,
                EndDate = SemesterDTO.EndDate
            };
            SemesterDAO.UpdateSemester(Semester);
        }
        public void DeleteSemester(String SemesterID) => SemesterDAO.DeleteSemester(SemesterID);
    }
}
