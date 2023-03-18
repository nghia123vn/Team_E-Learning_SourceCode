using DataAccess.ErrorMessage;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuissnessObject
{
    public class StudentDTO
    {
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class StudentUpdateDTO
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Status { get; set; }
        public string StudentSemesterId { get; set; }
    }

    public class StudentDAO
    {

        public static List<Student> GetAllStudents()
        {
            using (var db = new ECourseDBContext())
            {
                return db.Students.ToList();
            }
        }

        public static Student GetStudentById(String StudentID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.Students.FirstOrDefault(s => s.StudentId == StudentID);
            }
        }

        public static Student CreateStudent(Student student)
        {
            using (var db = new ECourseDBContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
                return student;
            }
        }

        public static void UpdateStudent(Student student)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetStudentById(student.StudentId) == null)
                    {
                        throw new Exception(ErrorMessage.StudentError.STUDENT_IS_NOT_EXITED);
                    }
                    db.Students.Update(student);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteStudent(String StudentID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    Student student = GetStudentById(StudentID);
                    if (student == null || student.Status == false)
                    {
                        throw new Exception(ErrorMessage.StudentError.STUDENT_IS_NOT_EXITED);
                    }

                    student.Status = false;
                    db.Students.Update(student);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void UpdateStudentStatus(String studentID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    Student student = GetStudentById(studentID);
                    student.Status = true;
                    db.Students.Update(student);
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
