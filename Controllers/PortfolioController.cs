using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController(UserManager<AppUser> userManager, IPortfolioRepository portfolioRepository) : ControllerBase
    {
        private readonly UserManager<AppUser> userManager = userManager;
        private readonly IPortfolioRepository portfolioRepository = portfolioRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userName = User.GetUserName();
            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest();
            }
            var appUser = await userManager.FindByNameAsync(userName);
            if (appUser == null)
            {
                return BadRequest();
            }
            var portfolios = portfolioRepository.GetStocks(appUser);
            return Ok(portfolios);
        }
    }
}