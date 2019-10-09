using System;
using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string restaurantName);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updateRestaurant);
        Restaurant AddRestaurant(Restaurant newRestaurant);
        Restaurant DeleteRestaurant(int restaurantID);
        int Commit();
        int GetCountOfRestaurants();
    }
}
