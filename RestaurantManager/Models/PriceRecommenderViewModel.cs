namespace RestaurantManager.Models
{
    public class PriceRecommenderViewModel
    {
        public string category { get; set; }
        public int calories { get; set; }
        public float prep_time { get; set; }
        public float production_cost { get; set; }

        public float score { get; set; }
    }
}
