using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BuissnessObject.Repository
{
    public class StudentRepo : IStudentRepo
    {
        public List<Student> GetStudents() => StudentDAO.GetAllStudents();
        public Student GetStudentByID(String StudentID) => StudentDAO.GetStudentById(StudentID);
        public Student CreateStudent(StudentDTO studentDTO)
        {
            var studentCount = StudentDAO.GetAllStudents().Count;
            var student = new Student
            {
                StudentId = "Student" + (studentCount + 1),
                StudentName = studentDTO.StudentName,
                Email = studentDTO.Email,
                Password = studentDTO.Password,
                Address = studentDTO.Address,
                Phone = studentDTO.Phone,
                DateOfBirth = studentDTO.DateOfBirth,
                Status = false,
                CreateDate = DateTime.Now,
                StudentSemesterId = "ss1",
            };
            return StudentDAO.CreateStudent(student);
        }
        public void UpdateStudent(StudentUpdateDTO studentUpdateDTO)
        {
            var student = new Student
            {
                StudentName = studentUpdateDTO.StudentName,
                Email = studentUpdateDTO.Email,
                Password = studentUpdateDTO.Password,
                Address = studentUpdateDTO.Address,
                Phone = studentUpdateDTO.Phone,
                DateOfBirth = studentUpdateDTO.DateOfBirth,
                Status = studentUpdateDTO.Status,
                StudentSemesterId = studentUpdateDTO.StudentSemesterId
            };
            StudentDAO.UpdateStudent(student);
        }
        public void DeleteStudent(String StudentID) => StudentDAO.DeleteStudent(StudentID);

        public void UpdateStudentStatus(String studentId) => StudentDAO.UpdateStudentStatus(studentId);
    }
}
