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
    public class SubjectItemDTO
    {
        public string SubjectId { get; set; }
        public string StudentId { get; set; }
    }

    public class SubjectItemDAO
    {
        public static List<SubjectItem> GetAllSubjectItems()
        {
            using (var db = new ECourseDBContext())
            {
                return db.SubjectItems.ToList();
            }
        }

        public static SubjectItem GetSubjectItemById(String SubjectID, String StudentID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.SubjectItems.FirstOrDefault(s => s.SubjectId == SubjectID && s.StudentId == StudentID);
            }
        }

        public static SubjectItem CreateSubjectItem(SubjectItem SubjectItem)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    //if (GetSubjectItemById(SubjectItem.SubjectId, SubjectItem.StudentId) != null)
                    //{
                    //    throw new Exception(ErrorMessage.SubjectItemError.SubjectItem_EXITED);
                    //}
                    db.SubjectItems.Add(SubjectItem);
                    db.SaveChanges();
                    return SubjectItem;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public static void UpdateSubjectItem(SubjectItem SubjectItem)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    //if (GetSubjectItemById(SubjectItem.SubjectItemId) == null)
                    //{
                    //    throw new Exception(ErrorMessage.SubjectItemError.SubjectItem_IS_NOT_EXITED);
                    //}
                    db.SubjectItems.Update(SubjectItem);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteSubjectItem(String SubjectID, String StudentID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    //if (GetSubjectItemById(SubjectItemID) == null)
                    //{
                    //    throw new Exception(ErrorMessage.SubjectItemError.SubjectItem_IS_NOT_EXITED);
                    //}
                    SubjectItem SubjectItem = GetSubjectItemById(SubjectID, StudentID);
                    db.SubjectItems.Remove(SubjectItem);
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
