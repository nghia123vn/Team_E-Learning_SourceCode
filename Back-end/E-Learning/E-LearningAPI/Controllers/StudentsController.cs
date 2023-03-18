using BuissnessObject;
using BuissnessObject.Repository;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
namespace E_LearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo studentRepo;

        public StudentsController(IStudentRepo student)
        {
            studentRepo = student;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return studentRepo.GetStudents();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(string id)
        {
            var student = studentRepo.GetStudentByID(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutStudent(StudentUpdateDTO student)
        {
            try
            {
                studentRepo.UpdateStudent(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(StudentDTO student)
        {
            try
            {
                SendEmailToStudent(student.Email);
                return Ok(studentRepo.CreateStudent(student));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}/UpdateStatus")]
        public async Task<ActionResult> UpdateStudentStatus(String id)
        {
            var student = studentRepo.GetStudentByID(id);
            if (student == null)
            {
                return NotFound();
            }
            studentRepo.UpdateStudentStatus(id);

            return Ok("Createa student Success");
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(String id)
        {
            var student = studentRepo.GetStudentByID(id);
            if (student == null)
            {
                return NotFound();
            }

            studentRepo.DeleteStudent(id);

            return Ok("Delete student Success");
        }

        private bool StudentExists(string id)
        {
            return studentRepo.GetStudents().Any(e => e.StudentId == id);
        }


        private void SendEmailToStudent(string studentEmail)
        {
            // set up sender and recipient addresses

            MailAddress fromAddress = new MailAddress("jobsharingvn24h@gmail.com", "Job Sharing VN24H");
            MailAddress toAddress = new MailAddress(studentEmail, "Recipient Name");

            // set up SMTP client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("jobsharingvn24h@gmail.com", "jzxbegcswrpffnek");
            // read HTML file into a string variable
            string htmlBody;
            using (StreamReader reader = new StreamReader(@"D:\SWD\Github\E-Learning\E-Learning\E-LearningAPI\sendMail.html"))
            {
                htmlBody = reader.ReadToEnd();
            }
            // create email message
            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Subject = "Check Email";
            message.Body = htmlBody;
            message.IsBodyHtml = true;
            // send email
            smtpClient.Send(message);
        }
    }
}
