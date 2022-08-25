using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data.Interfaces
{

    public interface IRestaurantData
    {
        IQueryable<Restaurant> GetAll();
        IQueryable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updateRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int GetCountOfRestaturants();
        int Commit();
    }

}
