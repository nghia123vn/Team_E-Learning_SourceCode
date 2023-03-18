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

    public class TeacherDTO
    {
        public string TeacherName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class TeacherUpdateDTO
    {
        public string TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class TeacherDAO
    {
        public static List<Teacher> GetAllTeachers()
        {
            using(var db = new ECourseDBContext())
            {
                return db.Teachers.ToList();
            }
        }

        public static Teacher GetTeacherById(String TeacherID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.Teachers.FirstOrDefault(s => s.TeacherId == TeacherID );
            }
        }

        public static Teacher CreateTeacher(Teacher teacher)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if(GetTeacherById(teacher.TeacherId) != null)
                    {
                        throw new Exception(ErrorMessage.TeacherError.TEACHER_EXITED);
                    }
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                    return teacher;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }
        }

        public static void UpdateTeacher(Teacher teacher)
        {
            using(var db = new ECourseDBContext())
            {
                try
                {
                    if(GetTeacherById(teacher.TeacherId) == null)
                    {
                        throw new Exception(ErrorMessage.TeacherError.TEACHER_IS_NOT_EXITED);
                    }
                    db.Teachers.Update(teacher);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteTeacher(String TeacherID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetTeacherById(TeacherID) == null)
                    {
                        throw new Exception(ErrorMessage.TeacherError.TEACHER_IS_NOT_EXITED);
                    }
                    Teacher teacher = GetTeacherById(TeacherID);
                    teacher.Status = false;
                    db.Teachers.Update(teacher);
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
