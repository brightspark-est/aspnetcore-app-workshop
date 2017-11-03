using FrontEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly IApiClient _apiClient;
        
        public AttendeesController(IApiClient apiClient)
        {
            _apiClient = apiClient;          
        }
 
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get(string username)
        {
            await _apiClient.GetAttendeeAsync(username);

            var vm = new AttendeeViewModel()
            {
                UserName = username
            };

            return View("Index", vm);

        }

        [HttpPost]
        public async Task<IActionResult> Post(AttendeeViewModel model)
        {
            await _apiClient.AddAttendeeAsync(model.AsDto());

            return RedirectToAction("Index");
        }
    }
}
