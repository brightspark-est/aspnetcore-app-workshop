using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConferenceDTO;
using System.Collections.Generic;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class SearchController : Controller
    {
        private IApiClient _apiClient;
        //public List<object> SearchResults;

        public SearchController(IApiClient apiClient) //pean läbi modeli saama kätte va Interfaceid
        {
            _apiClient = apiClient;
        }
        
        public async Task Index(string term) //Indexiks muuta
        {

            var results = await _apiClient.SearchAsync(term);
            
            var vm = new Search();
            vm.Term = term;

            vm.SearchResults = results.Select(sr =>
            {
                switch (sr.Type)
                {
                    case SearchResultType.Session:
                        return (object)sr.Value.ToObject<SessionResponse>();
                    case SearchResultType.Speaker:
                        return (object)sr.Value.ToObject<SpeakerResponse>();
                    default:
                        return (object)sr;
                }
            })
                                    .ToList();
        }
    }
}