using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class SubjectRepo : ISubjectRepo
    {
        public List<Subject> GetSubjects() => SubjectDAO.GetAllSubjects();
        public Subject GetSubjectByID(String SubjectID) => SubjectDAO.GetSubjectById(SubjectID);
        public Subject CreateSubject(SubjectDTO SubjectDTO)
        {
            var SubjectCount = SubjectDAO.GetAllSubjects().Count;
            var Subject = new Subject()
            {
                SubjectId = "Subject" + (SubjectCount + 1),
                SubjectName = SubjectDTO.SubjectName,
                MajorId = SubjectDTO.MajorId,
                SemesterId = SubjectDTO.SemesterId,
                StudentSemesterId = SubjectDTO.StudentSemesterId,
                TeacherId = SubjectDTO.TeacherId               
            };
            return SubjectDAO.CreateSubject(Subject);
        }
        public void UpdateSubject(SubjectUpdateDTO SubjectDTO)
        {
            var Subject = new Subject()
            {
                SubjectId = SubjectDTO.SubjectID,
                SubjectName = SubjectDTO.SubjectName,
                MajorId = SubjectDTO.MajorId,
                SemesterId = SubjectDTO.SemesterId,
                StudentSemesterId = SubjectDTO.StudentSemesterId,
                TeacherId = SubjectDTO.TeacherId
            };
            SubjectDAO.UpdateSubject(Subject);
        }
        public void DeleteSubject(String SubjectID) => SubjectDAO.DeleteSubject(SubjectID);
    }
}
