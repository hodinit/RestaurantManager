using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RestaurantManager.Services;
using RestaurantManager.Models;

namespace RestaurantManager.Services
{
    public class PriceRecommenderService : IPriceRecommenderService
    {
        private readonly HttpClient _httpClient;

        public PriceRecommenderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> RecommendPriceAsync(PriceRecommender input)
        {
            // POST catre /predict
            var response = await _httpClient.PostAsJsonAsync("/predict", input);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<PriceRecommenderApiResponse>();
            return result?.score.ToString();
        }

        private class PriceRecommenderApiResponse
        {
            public float score { get; set; }
        }
    }
}
