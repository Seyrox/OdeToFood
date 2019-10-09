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

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;

            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant DeleteRestaurant(int restaurantID)
        {
            var deleteRestaurant = GetById(restaurantID);

            if (deleteRestaurant != null)
                restaurants.Remove(deleteRestaurant);

            return deleteRestaurant;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string restaurantName = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(restaurantName) || r.Name.StartsWith(restaurantName)
                   orderby r.Name 
                   select r;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updateRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Cuisine = updateRestaurant.Cuisine;
            }

            return restaurant;
        }
    }
}
