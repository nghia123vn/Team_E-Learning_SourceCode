using DataAccess.ErrorMessage;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject
{
    public class StudentSemesterDTO
    {
        public string Name { get; set; }
    }

    public class StudentSemesterUpdateDTO
    {
        public string StudentSemesterID { get; set; }
        public string Name { get; set; }
    }
    public class StudentSemesterDAO
    {
        public static List<StudentSemester> GetAllStudentSemesters()
        {
            using (var db = new ECourseDBContext())
            {
                return db.StudentSemesters.ToList();
            }
        }

        public static StudentSemester GetStudentSemesterById(String StudentSemesterID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.StudentSemesters.FirstOrDefault(s => s.StudentSemesterId == StudentSemesterID);
            }
        }

        public static StudentSemester CreateStudentSemester(StudentSemester StudentSemester)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetStudentSemesterById(StudentSemester.StudentSemesterId) != null)
                    {
                        throw new Exception(ErrorMessage.StudentSemesterError.STUDENT_SEMESTER_EXITED);
                    }
                    db.StudentSemesters.Add(StudentSemester);
                    db.SaveChanges();
                    return StudentSemester;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public static void UpdateStudentSemester(StudentSemester StudentSemester)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetStudentSemesterById(StudentSemester.StudentSemesterId) == null)
                    {
                        throw new Exception(ErrorMessage.StudentSemesterError.STUDENT_SEMESTER_IS_NOT_EXITED);
                    }
                    db.StudentSemesters.Update(StudentSemester);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteStudentSemester(String StudentSemesterID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    StudentSemester StudentSemester = GetStudentSemesterById(StudentSemesterID);
                    if (GetStudentSemesterById(StudentSemesterID) == null)
                    {
                        throw new Exception(ErrorMessage.StudentSemesterError.STUDENT_SEMESTER_IS_NOT_EXITED);
                    }
                    db.StudentSemesters.Remove(StudentSemester);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
