using FrontEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class SpeakerController : Controller
    {
        private readonly IApiClient _apiClient;

        public SpeakerController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index(int id)
        {
            var model = new SpeakerViewModel
            {
                Speaker = await _apiClient.GetSpeakerAsync(id)
            };

            if (model.Speaker == null)
            {
                return NotFound();
            }

            return View();
        }
    }
}
