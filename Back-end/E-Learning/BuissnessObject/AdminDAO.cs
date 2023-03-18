using DataAccess.Models;
using System.Linq;
namespace BuissnessObject
{
	public class AdminDAO
	{
		private readonly ECourseDBContext _context;
		public AdminDAO(ECourseDBContext context)
		{
			_context = context;
		}

		public Admin Login(string email, string password)
		{
			return _context.Admins.FirstOrDefault(a => a.Email == email && a.Password == password);
		}
	}
}
