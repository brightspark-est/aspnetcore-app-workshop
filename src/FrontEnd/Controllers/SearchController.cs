using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConferenceDTO;
using FrontEnd.ViewModels;

namespace FrontEnd.Controllers
{
    public class SearchController : Controller
    {
        private readonly IApiClient _apiClient;

        public SearchController(IApiClient apiClient) //pean läbi modeli saama kätte va Interfaceid
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index(string term) //Indexiks muuta
        {
            var results = await _apiClient.SearchAsync(term);

            var vm = new SearchViewModel
            {
                Term = term,
                SearchResults = results.Select(sr =>
                    {
                        switch (sr.Type)
                        {
                            case SearchResultType.Session:
                                return (object) sr.Value.ToObject<SessionResponseDto>();
                            case SearchResultType.Speaker:
                                return (object) sr.Value.ToObject<SpeakerResponseDto>();
                            default:
                                return (object) sr;
                        }
                    })
                    .ToList()
            };

            return View(vm);
        }
    }
}