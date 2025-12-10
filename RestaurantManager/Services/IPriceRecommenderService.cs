using System.Threading.Tasks;
using RestaurantManager.Models;

namespace RestaurantManager.Services
{
    public interface IPriceRecommenderService
    {
        Task<string> RecommendPriceAsync(PriceRecommender input);
    }
}
