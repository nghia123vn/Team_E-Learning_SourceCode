using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface ISubjectRepo
    {
        public List<Subject> GetSubjects();
        public Subject GetSubjectByID(String SubjectID);
        public Subject CreateSubject(SubjectDTO SubjectDTO);
        public void UpdateSubject(SubjectUpdateDTO SubjectDTO);
        public void DeleteSubject(String SubjectID);
    }
}
