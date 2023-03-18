using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface ISubjectItemRepo
    {
        public List<SubjectItem> GetSubjectItems();
        public SubjectItem GetSubjectItemByID(String SubjectID, String StudentID);
        public SubjectItem CreateSubjectItem(SubjectItemDTO SubjectItem);
        public void UpdateSubjectItem(SubjectItemDTO SubjectItem);
        public void DeleteSubjectItem(String SubjectID, String StudentID);
    }
}
