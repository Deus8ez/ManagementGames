using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementGamesDTO;

namespace FrontEnd.Services
{
    public interface IApiClient
    {
        List<Tournament> GetFakeTournaments();
        Task<List<Tournament>> GetTournamentsAsync();
        Task<Tournament> GetTournament(int id);
        Task<List<Participant>> GetParticipantsAsync();
        Task<Participant> GetParticipant(int id);
        Task<List<Participant>> GetParticipantsInTournamentAsync(int id);
    }
}
