using RestApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace RestApp.Data
{
   public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int restId);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        int Commit();
    }
    public class InMemoryRestaurnatData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurnatData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant{Id=1, Title="Mogli", City="Noida", Cuisine=CuisineType.Indian},
                new Restaurant{Id=2, Title="Yo China", City="Delhi", Cuisine=CuisineType.Mexican},
                new Restaurant{Id=3, Title="Haldiram", City="Delhi", Cuisine=CuisineType.Italian}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Title.StartsWith(name)
                   orderby r.Title
                   select r;
        }
        public Restaurant GetById(int restId)
        {
            return restaurants.SingleOrDefault(r => r.Id == restId);

        }

        public Restaurant Update(Restaurant updatedRestaurant){
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Title = updatedRestaurant.Title;
                restaurant.City = updatedRestaurant.City;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }
    }
}
