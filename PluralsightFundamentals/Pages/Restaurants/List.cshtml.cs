using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace PluralsightFundamentals.Pages.Restaurants
{

public class ListModel : PageModel
    {
        private readonly ILogger<ListModel> logger;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IConfiguration Configuration { get; }
        public IRestaurantData RestaurantData { get; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            Configuration = configuration;
            RestaurantData = restaurantData;
            this.logger = logger;
        }

        public void OnGet()
        {
            logger.LogError("Executing ListModel");
            Message = Configuration["Message"];
            Restaurants = RestaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
