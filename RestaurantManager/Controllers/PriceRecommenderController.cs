using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RestaurantManager.Services;
using RestaurantManager.Models;

namespace RestaurantManager.Controllers
{
    public class PriceRecommenderController : Controller
    {
        private readonly IPriceRecommenderService _riskService;
        public PriceRecommenderController(IPriceRecommenderService riskService)
        {
            _riskService = riskService;
        }

        // GET: RiskPrediction/Index
        [HttpGet]
        public IActionResult Index()
        {
            var model = new PriceRecommenderViewModel();
            return View("~/Views/Home/Index.cshtml", model);
        }

        // POST: RiskPrediction/Index
        [HttpPost]
        public async Task<IActionResult> Index(PriceRecommenderViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("~/Views/Home/Index.cshtml", model);
            //}

            var input = new PriceRecommender
            {
                category = model.category,
                calories = model.calories,
                prep_time = model.prep_time,
                production_cost = model.production_cost
            };

            var prediction = await _riskService.RecommendPriceAsync(input);
            if (float.TryParse(prediction, out var score))
            {
                model.score = score;
            }
            else
            {
                model.score = 0; // or handle error as needed
            }
            ViewBag.Message = model.score;

            return View("~/Views/Home/Index.cshtml", model);
        }
    }
}
