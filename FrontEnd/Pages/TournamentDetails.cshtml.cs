using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Services;
using ManagementGamesDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages.Shared
{
    public class TournamentDetailsModel : PageModel
    {
        private readonly IApiClient _apiClient;
        public List<Participant> Participants { get; set; }

        public TournamentDetailsModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            Participants = await _apiClient.GetParticipantsInTournamentAsync(id);

            if (Participants == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
