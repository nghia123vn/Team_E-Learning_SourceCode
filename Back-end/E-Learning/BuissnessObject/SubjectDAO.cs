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
    public class SubjectDTO
    {
        public string SubjectName { get; set; }
        public string MajorId { get; set; }
        public string TeacherId { get; set; }
        public string StudentSemesterId { get; set; }
        public string SemesterId { get; set; }
    }

    public class SubjectUpdateDTO
    {
        public string SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string MajorId { get; set; }
        public string TeacherId { get; set; }
        public string StudentSemesterId { get; set; }
        public string SemesterId { get; set; }
    }

    public class SubjectDAO
    {
        public static List<Subject> GetAllSubjects()
        {
            using (var db = new ECourseDBContext())
            {
                return db.Subjects.ToList();
            }
        }

        public static Subject GetSubjectById(String SubjectID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.Subjects.FirstOrDefault(s => s.SubjectId == SubjectID);
            }
        }

        public static Subject CreateSubject(Subject Subject)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetSubjectById(Subject.SubjectId) != null)
                    {
                        throw new Exception(ErrorMessage.SubjectError.SUBJECT_EXITED);
                    }
                    db.Subjects.Add(Subject);
                    db.SaveChanges();
                    return Subject;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public static void UpdateSubject(Subject Subject)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetSubjectById(Subject.SubjectId) == null)
                    {
                        throw new Exception(ErrorMessage.SubjectError.SUBJECT_IS_NOT_EXITED);
                    }
                    db.Subjects.Update(Subject);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteSubject(String SubjectID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetSubjectById(SubjectID) == null)
                    {
                        throw new Exception(ErrorMessage.SubjectError.SUBJECT_IS_NOT_EXITED);
                    }
                    Subject Subject = GetSubjectById(SubjectID);
                    db.Subjects.Remove(Subject);
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
