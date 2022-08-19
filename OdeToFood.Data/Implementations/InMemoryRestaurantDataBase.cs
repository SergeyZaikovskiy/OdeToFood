using OdeToFood.Core;
using OdeToFood.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data.Implementations
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
                {
                    new Restaurant{Id = 1, Name = "Dodo", Location = "Moscow", Cuisine = CuisineType.Italian},
                    new Restaurant{Id = 2, Name = "Pelmeni", Location = "Chekyabinsk", Cuisine = CuisineType.Russian},
                    new Restaurant{Id = 3, Name = "Starbucks", Location = "Washigton", Cuisine = CuisineType.American},
                    new Restaurant{Id = 4, Name = "Chillis", Location = "Mexico", Cuisine = CuisineType.Mexican},
                };
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(restaurant => restaurant.Name);
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);

            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;

            return newRestaurant;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var rest = restaurants.SingleOrDefault(r => r.Id == restaurant.Id);

            if (restaurant != null)
            {
                rest.Name = restaurant.Name;
                rest.Location = restaurant.Location;
                rest.Cuisine = restaurant.Cuisine;
            }

            return rest;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int GetCountOfRestaturants()
        {
            return restaurants.Count();
        }
    }
}
