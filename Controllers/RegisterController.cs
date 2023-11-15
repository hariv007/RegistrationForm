using Microsoft.AspNetCore.Mvc;
using MultipleCourses.Data;
using MultipleCourses.Models;
using Newtonsoft.Json;

namespace MultipleCourses.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public RegisterController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(string jsonData)
        {
            try
            {
                RegistrationForm data = JsonConvert.DeserializeObject<RegistrationForm>(jsonData);
                _dbContext.Add(data);
                await _dbContext.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
