using BuissnessObject.Repository.AdminRepository;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_LearningAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly IAdminRepository _adminRepository;
		public AdminController(IAdminRepository adminRepository)
		{
			_adminRepository = adminRepository;
		}
		[HttpGet("LoginByAdmin")]
		public async Task<ActionResult<Admin>> Login(string email, string password)
		{
			var user = _adminRepository.Login(email, password);
			return user;
		}



	}
}
