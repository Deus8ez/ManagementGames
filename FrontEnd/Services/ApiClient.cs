using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ManagementGamesDTO;
using Newtonsoft.Json;

namespace FrontEnd.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Tournament>> GetTournamentsAsync()
        {
            var response = await _httpClient.GetAsync("api/tournaments");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<Tournament>>();
        }

        public async Task<Tournament> GetTournament(int id) 
        {
            var response = await _httpClient.GetAsync($"/api/tournament/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Tournament>();
        }

        public async Task<List<Participant>> GetParticipantsAsync()
        {
            var response = await _httpClient.GetAsync("api/participants");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<Participant>>();
        }

        public async Task<Participant> GetParticipant(int id)
        {
            var response = await _httpClient.GetAsync($"api/participants/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Participant>();
        }

        public async Task<List<Participant>> GetParticipantsInTournamentAsync(int id)
        {

            var response = await _httpClient.GetAsync($"api/ParticipantInTournaments/getById/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<Participant>>();
        }
    }
}
