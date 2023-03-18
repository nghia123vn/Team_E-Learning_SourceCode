using DataAccess.Models;

namespace BuissnessObject.Repository.AdminRepository
{
	public interface IAdminRepository
	{
		public Admin Login(string email, string password);
	}
}
