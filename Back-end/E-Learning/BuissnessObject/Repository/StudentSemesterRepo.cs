using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class StudentSemesterRepo : IStudentSemesterRepo
    {
        public List<StudentSemester> GetStudentSemesters() => StudentSemesterDAO.GetAllStudentSemesters();
        public StudentSemester GetStudentSemesterByID(String StudentSemesterID) => StudentSemesterDAO.GetStudentSemesterById(StudentSemesterID);
        public StudentSemester CreateStudentSemester(StudentSemesterDTO StudentSemesterDTO)
        {
            var StudentSemesterCount = StudentSemesterDAO.GetAllStudentSemesters().Count;
            var StudentSemester = new StudentSemester()
            {
                StudentSemesterId = "StudentSemester" + (StudentSemesterCount + 1),
                Name = StudentSemesterDTO.Name
            };
            return StudentSemesterDAO.CreateStudentSemester(StudentSemester);
        }
        public void UpdateStudentSemester(StudentSemesterUpdateDTO StudentSemesterDTO)
        {
            var StudentSemester = new StudentSemester()
            {
                StudentSemesterId = StudentSemesterDTO.StudentSemesterID,
                Name = StudentSemesterDTO.Name
            };
            StudentSemesterDAO.UpdateStudentSemester(StudentSemester);
        }
        public void DeleteStudentSemester(String StudentSemesterID) => StudentSemesterDAO.DeleteStudentSemester(StudentSemesterID);
    }
}
