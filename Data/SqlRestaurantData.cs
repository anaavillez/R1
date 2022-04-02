using R1.Core;

namespace R1.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly R1DbContext db;

        public SqlRestaurantData(R1DbContext db)
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurants)
        {
            var entity = db.Restaurants.Attach(updatedRestaurants);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;//Modifies elements of database
            return updatedRestaurants;
        }
    }

}

