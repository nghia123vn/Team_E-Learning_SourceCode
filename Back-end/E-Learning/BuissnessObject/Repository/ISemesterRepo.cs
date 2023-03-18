using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface ISemesterRepo
    {
        public List<Semester> GetSemesters();
        public Semester GetSemesterByID(String SemesterID);
        public Semester CreateSemester(SemesterDTO Semester);
        public void UpdateSemester(SemesterUpdateDTO Semester);
        public void DeleteSemester(String SemesterID);
    }
}
