using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int QuantityInStock { get; set; }


        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

    }
}
