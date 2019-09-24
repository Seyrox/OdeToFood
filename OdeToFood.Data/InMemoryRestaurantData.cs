using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant{Id = 1, Name = "Valentino", Location = "Craiova", Cuisine = CuisineType.Italian},
                new Restaurant{Id = 2, Name = "Praz Vegas", Location = "Craiova", Cuisine = CuisineType.Mexican},
                new Restaurant{Id = 3, Name = "Charlie", Location = "Timisoara", Cuisine = CuisineType.Indian}

            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
