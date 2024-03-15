

using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Products>>>  GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            return await _repo.GetProductByIdAysnc(id);
        }

         [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductsBrand()
        {
            var brands = await _repo.GetProductBrandAsync();
            return Ok(brands);
        }

          [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProductsType()
        {
            var types = await _repo.GetProductTypeAsync();
            return Ok(types);
        }
    }
}