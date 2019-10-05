using System;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace PluralsightFundamentals.ViewComponents
{
    public class RestaurantCountViewComponents
        :ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponents(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountOfRestaurants();

            return View(count);
        }
    }
}
