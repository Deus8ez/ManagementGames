using FrontEnd.Services;
using ManagementGamesDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        protected readonly IApiClient _apiClient;
        public List<Tournament> Tournaments { get; set; }

        public IndexModel(IApiClient apiClient, ILogger<IndexModel> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public async Task OnGet()
        {        
            Tournaments = await _apiClient.GetTournamentsAsync();
        }
    }
}
