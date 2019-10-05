using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            db.Restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant DeleteRestaurant(int restaurantID)
        {
            var deleteRestaurant = GetById(restaurantID);

            if (deleteRestaurant != null)
                db.Restaurants.Remove(deleteRestaurant);

            return deleteRestaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string restaurantName)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(restaurantName) || string.IsNullOrEmpty(restaurantName)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var entity = db.Restaurants.Attach(updateRestaurant);
            entity.State = EntityState.Modified;

            return updateRestaurant;
        }
    }
}
