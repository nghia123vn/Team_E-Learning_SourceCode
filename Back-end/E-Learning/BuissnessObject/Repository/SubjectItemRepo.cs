using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class SubjectItemRepo : ISubjectItemRepo
    {
        public List<SubjectItem> GetSubjectItems() => SubjectItemDAO.GetAllSubjectItems();
        public SubjectItem GetSubjectItemByID(String SubjectID, String StudentID) => SubjectItemDAO.GetSubjectItemById(SubjectID, StudentID);
        public SubjectItem CreateSubjectItem(SubjectItemDTO subjectItemDTO)
        {
            var SubjectItem = new SubjectItem()
            {
                SubjectId = subjectItemDTO.SubjectId,
                StudentId = subjectItemDTO.StudentId
            };
            return SubjectItemDAO.CreateSubjectItem(SubjectItem);
        }
        public void UpdateSubjectItem(SubjectItemDTO subjectItemDTO)
        {
            var SubjectItem = new SubjectItem()
            {
                SubjectId = subjectItemDTO.SubjectId,
                StudentId = subjectItemDTO.StudentId
            };
            SubjectItemDAO.UpdateSubjectItem(SubjectItem);
        }
        public void DeleteSubjectItem(String SubjectID, String StudentID) => SubjectItemDAO.DeleteSubjectItem(SubjectID, StudentID);
    }
}
