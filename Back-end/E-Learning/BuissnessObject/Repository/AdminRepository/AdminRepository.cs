using DataAccess.Models;

namespace BuissnessObject.Repository.AdminRepository
{
	public class AdminRepository : IAdminRepository
	{
		private readonly AdminDAO _adminDAO;

		public AdminRepository(AdminDAO adminDAO)
		{
			_adminDAO = adminDAO;
		}
		public Admin Login(string email, string password)
			=> _adminDAO.Login(email, password);
	}
}
