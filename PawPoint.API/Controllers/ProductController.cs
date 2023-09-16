using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PawPoint.API.Input;
using PawPoint.API.Response;
using PawPoint.Domain.Interfaces;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductDomain _productDomain;
        private IProductInfraestructure _productInfraestructure;
        private IMapper _mapper;
        
        public ProductController (IProductDomain productDomain, IProductInfraestructure productInfraestructure, IMapper mapper)
        {
            _productDomain = productDomain;
            _productInfraestructure = productInfraestructure;
            _mapper = mapper;
        }

        
        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result=await _productInfraestructure.GetProductsAsync();
            var list=_mapper.Map<List<Product>,List<ProductResponse>>(result);
            return Ok(list);
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetById(int id)
        {
            var productFound = await _productInfraestructure.GetProductByIdAsync(id);
            if (productFound == null) return NotFound();
            var result = _mapper.Map<Product,ProductResponse>(productFound);
            
            return Ok(result);
            
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCreateInput productInput)
        {
            if (ModelState.IsValid)
            {
                var product=_mapper.Map<ProductCreateInput,Product>(productInput);
                await _productDomain.CreateProductAsync(product);
                
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductCreateInput productInput)
        {
            if (ModelState.IsValid)
            {
                var product=_mapper.Map<ProductCreateInput,Product>(productInput);
                await _productDomain.UpdateProductAsync(id,product);
                
            }
            else
            {
                return BadRequest();
            }
            return Ok();
            
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productDomain.DeleteProductAsync(id);
            return Ok();
        }
    }
}
