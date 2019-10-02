using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            throw new System.NotImplementedException();
        }

        public int Commit()
        {
            throw new System.NotImplementedException();
        }

        public Restaurant DeleteRestaurant(int restaurantID)
        {
            throw new System.NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string restaurantName)
        {
            throw new System.NotImplementedException();
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            throw new System.NotImplementedException();
        }
    }
}
