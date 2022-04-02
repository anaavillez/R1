using R1.Core;

namespace R1.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        public Restaurant Add(Restaurant newRestaurant);
        public Restaurant Delete(int id);
        public Restaurant GetById(int id);
        public Restaurant Update(Restaurant updatedRestaurants);
        public int GetCountOfRestaurants();
        public int Commit();
    }
}
