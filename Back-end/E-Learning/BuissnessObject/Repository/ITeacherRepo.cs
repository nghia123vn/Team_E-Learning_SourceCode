using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface ITeacherRepo
    {
        public List<Teacher> GetTeachers();
        public Teacher GetTeacherByID(String TeacherID);
        public Teacher CreateTeacher(TeacherDTO teacher);
        public void UpdateTeacher(TeacherUpdateDTO teacherUpdateDTO);
        public void DeleteTeacher(String TeacherID);
    }
}
