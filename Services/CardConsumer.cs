using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TokenValidator.Models;

namespace TokenValidator.Services
{
    public class CardConsumer : ICardConsumer
    {
        private readonly HttpClient _httpClient;

        public CardConsumer(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CardRegisterApiResponse> GetCardRegister(int cardId)
        {
            var response = await _httpClient.GetAsync($"api/Card/card-register/{cardId}");

            var resultContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<CardRegisterApiResponse>(resultContent);
        }

        public async Task<CardApiResponse> GetCard(int cardId)
        {
            var response = await _httpClient.GetAsync($"api/Card/card/{cardId}");

            var resultContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
            {

                return null;
            }
            return JsonConvert.DeserializeObject<CardApiResponse>(resultContent);
        }
    }
}
