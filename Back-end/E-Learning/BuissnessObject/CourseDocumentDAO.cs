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
    public class CourseDocumentDTO
    {
        public string CourseId { get; set; }
        public string Title { get; set; }
        public string Defination { get; set; }
        public string Video { get; set; }
    }
    public class CourseDocumentUpdateDTO
    {
        public string DocumentID { get; set; }
        public string CourseId { get; set; }
        public string Title { get; set; }
        public string Defination { get; set; }
        public string Video { get; set; }
    }
    public class CourseDocumentDAO
    {
        public static List<CourseDocument> GetAllCourseDocuments()
        {
            using (var db = new ECourseDBContext())
            {
                return db.CourseDocuments.ToList();
            }
        }

        public static CourseDocument GetCourseDocumentById(String CourseDocumentID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.CourseDocuments.FirstOrDefault(s => s.DocumentId == CourseDocumentID);
            }
        }

        public static CourseDocument CreateCourseDocument(CourseDocument CourseDocument)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetCourseDocumentById(CourseDocument.DocumentId) != null)
                    {
                        throw new Exception(ErrorMessage.CourseDocumentError.COURSEDOCUMENT_EXITED);
                    }
                    db.CourseDocuments.Add(CourseDocument);
                    db.SaveChanges();
                    return CourseDocument;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public static void UpdateCourseDocument(CourseDocument CourseDocument)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetCourseDocumentById(CourseDocument.DocumentId) == null)
                    {
                        throw new Exception(ErrorMessage.CourseDocumentError.COURSEDOCUMENT_IS_NOT_EXITED);
                    }
                    db.CourseDocuments.Update(CourseDocument);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteCourseDocument(String CourseDocumentID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetCourseDocumentById(CourseDocumentID) == null)
                    {
                        throw new Exception(ErrorMessage.CourseDocumentError.COURSEDOCUMENT_IS_NOT_EXITED);
                    }
                    CourseDocument CourseDocument = GetCourseDocumentById(CourseDocumentID);
                    db.CourseDocuments.Remove(CourseDocument);
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
