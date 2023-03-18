using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class TeacherRepo : ITeacherRepo
    {
        public List<Teacher> GetTeachers() => TeacherDAO.GetAllTeachers();
        public Teacher GetTeacherByID(String TeacherID) => TeacherDAO.GetTeacherById(TeacherID);
        public Teacher CreateTeacher(TeacherDTO teacherDTO)
        {
            var TeacherCount = TeacherDAO.GetAllTeachers().Count;
            var teacher = new Teacher()
            {
                TeacherId = "Teacher" + (TeacherCount + 1),
                TeacherName = teacherDTO.TeacherName,
                Email = teacherDTO.Email,
                Password = teacherDTO.Password,
                Phone = teacherDTO.Phone,
                DateOfBirth = teacherDTO.DateOfBirth,
                Status = false,
                Address = teacherDTO.Address,
                CreateDate = DateTime.Now
            };
            return TeacherDAO.CreateTeacher(teacher);
        }
        public void UpdateTeacher(TeacherUpdateDTO teacherUpdateDTO)
        {
            var teacher = new Teacher()
            {
                TeacherId = teacherUpdateDTO.TeacherID,
                TeacherName = teacherUpdateDTO.TeacherName,
                Email = teacherUpdateDTO.Email,
                Password = teacherUpdateDTO.Password,
                Phone = teacherUpdateDTO.Phone,
                DateOfBirth = teacherUpdateDTO.DateOfBirth,
                Status = teacherUpdateDTO.Status,
                Address = teacherUpdateDTO.Address,
                CreateDate = teacherUpdateDTO.CreateDate
            };
            TeacherDAO.UpdateTeacher(teacher);
        }
        public void DeleteTeacher(String TeacherID) => TeacherDAO.DeleteTeacher(TeacherID);
    }
}
