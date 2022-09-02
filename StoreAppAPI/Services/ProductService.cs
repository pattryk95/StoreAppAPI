using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreAppAPI.Entities;
using StoreAppAPI.Models;
using StoreAppAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreAppContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(StoreAppContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await _dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();
            var productDTOs = _mapper.Map<List<ProductDTO>>(products); 

            return productDTOs;
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product is null)
            {
                return null;
            }
            var productDTO = _mapper.Map<ProductDTO>(product);

            return productDTO;
        }
    }
}
