using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace PluralsightFundamentals.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant deleteRestaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantID)
        {
            deleteRestaurant = restaurantData.GetById(restaurantID);

            if (deleteRestaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int restaurantID)
        {
            var tempRestaurant = restaurantData.DeleteRestaurant(restaurantID);
            restaurantData.Commit();

            if (tempRestaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{tempRestaurant.Name} deleted!";
            return RedirectToPage("./List");
        }
    }
}
