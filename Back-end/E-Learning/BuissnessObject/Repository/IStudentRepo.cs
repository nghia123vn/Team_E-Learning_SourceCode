using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BuissnessObject.Repository
{
    public interface IStudentRepo
    {
        public List<Student> GetStudents();
        public Student GetStudentByID(String StudentID);
        public Student CreateStudent(StudentDTO student);
        public void UpdateStudent(StudentUpdateDTO student);
        public void DeleteStudent(String StudentID);
        public void UpdateStudentStatus(String studentId);
    }
}
