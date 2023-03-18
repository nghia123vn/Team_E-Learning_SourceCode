using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class CourseDocumentRepo : ICourseDocumentRepo
    {
        public List<CourseDocument> GetCourseDocuments() => CourseDocumentDAO.GetAllCourseDocuments();
        public CourseDocument GetCourseDocumentByID(String CourseID) => CourseDocumentDAO.GetCourseDocumentById(CourseID);
        public CourseDocument CreateCourseDocument(CourseDocumentDTO CourseDocumentDTO)
        {
            var CourseDocumentCount = CourseDocumentDAO.GetAllCourseDocuments().Count;
            var CourseDocument = new CourseDocument()
            {
                DocumentId = "CourseDocument" + (CourseDocumentCount + 1),
                CourseId = CourseDocumentDTO.CourseId,
                Defination = CourseDocumentDTO.Defination,
                Title = CourseDocumentDTO.Title,
                Video = CourseDocumentDTO.Video
            };
            return CourseDocumentDAO.CreateCourseDocument(CourseDocument);
        }
        public void UpdateCourseDocument(CourseDocumentUpdateDTO CourseDocumentDTO)
        {
            var CourseDocument = new CourseDocument()
            {
                DocumentId = CourseDocumentDTO.DocumentID,
                CourseId = CourseDocumentDTO.CourseId,
                Defination = CourseDocumentDTO.Defination,
                Title = CourseDocumentDTO.Title,
                Video = CourseDocumentDTO.Video
            };
            CourseDocumentDAO.UpdateCourseDocument(CourseDocument);
        }
        public void DeleteCourseDocument(String CourseID) => CourseDocumentDAO.DeleteCourseDocument(CourseID);
    }
}
