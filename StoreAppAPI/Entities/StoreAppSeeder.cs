using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppAPI.Entities
{
    public class StoreAppSeeder
    {
        private readonly StoreAppContext _dbContext;

        public StoreAppSeeder(StoreAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Products.Any())
                {
                    var products = GetProducts();
                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {

                Name = "Koszulka biała",
                Description = "Klasyczna koszulka z logo marki",
                Price = 99.00M,
                PictureUrl = "https://media.istockphoto.com/id/1151955708/pl/zdj%C4%99cie/m%C4%99ski-bia%C5%82y-pusty-t-shirt-szablon-z-dw%C3%B3ch-stron-naturalny-kszta%C5%82t-na-niewidzialnym.webp?s=612x612&w=is&k=20&c=LVPNi2lG90pjHu1KPKhRmAaHcE4Jsjp8tqHXcaD0c3g=",
                QuantityInStock = 5,
                Category = new Category()
                    {
                        Name = "t-shirt"
                    },
                Brand = new Brand()
                    {
                        Name = "StoreAppBrand"
                    }
                } 
            };

            return products;
        }
    }
}
