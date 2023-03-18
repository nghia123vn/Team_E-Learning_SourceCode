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
    public class MajorDTO
    {
        public string MajorName { get; set; }
    }
    public class MajorUpdateDTO
    {
        public string MajorID { get; set; }
        public string MajorName { get; set; }
    }
    public class MajorDAO
    {
        public static List<Major> GetAllMajors()
        {
            using (var db = new ECourseDBContext())
            {
                return db.Majors.ToList();
            }
        }

        public static Major GetMajorById(String MajorID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.Majors.FirstOrDefault(s => s.MajorId == MajorID);
            }
        }

        public static Major CreateMajor(Major Major)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetMajorById(Major.MajorId) != null)
                    {
                        throw new Exception(ErrorMessage.MajorError.MAJOR_EXITED);
                    }
                    db.Majors.Add(Major);
                    db.SaveChanges();
                    return Major;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public static void UpdateMajor(Major Major)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetMajorById(Major.MajorId) == null)
                    {
                        throw new Exception(ErrorMessage.MajorError.MAJOR_IS_NOT_EXITED);
                    }
                    db.Majors.Update(Major);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteMajor(String MajorID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetMajorById(MajorID) == null)
                    {
                        throw new Exception(ErrorMessage.MajorError.MAJOR_IS_NOT_EXITED);
                    }
                    Major Major = GetMajorById(MajorID);
                    
                    db.Majors.Remove(Major);
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
