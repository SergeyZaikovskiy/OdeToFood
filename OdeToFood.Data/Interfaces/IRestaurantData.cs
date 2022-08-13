using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data.Interfaces
{

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        IEnumerable<Restaurant> GetRestaurantByName(string name);

        Restaurant GetRestaurantById(int id);

        Restaurant UpdateRestaurantInfo(Restaurant restaurant);

        Restaurant AddRestaurant(Restaurant newRestaurant);

        int Commit();
    }

}
