using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

       
        [HttpGet]  // swagger arayüzü için httpget yazılmalı mutlaka yoksa ambiguous hatası veriyor iki tane get olunca
        public async Task<IActionResult> GetAll()
        {
           var list=  await _productsRepository.GetAllAsync();

            return Ok(list);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var data= await _productsRepository.GetByIdAsync(id);

            if (data==null)
            {
                return NotFound(data);
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Products product)
        {
            var addedProduct= await _productsRepository.CreateAsync(product);
            return Created(string.Empty, addedProduct);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Products product)
        {
            var checkProduct=await _productsRepository.GetByIdAsync(product.Id);
            if (checkProduct==null)
            {
                return NotFound(product.Id);
            }
            await _productsRepository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var checkProduct = await _productsRepository.GetByIdAsync(id);
            if (checkProduct==null)
            {
                return NotFound(id);
            }
            await _productsRepository.RemoveAsync(id);
            return NoContent();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm]IFormFile formFile)
        {
            var newName = Guid.NewGuid() + "." + Path.GetExtension(formFile.FileName);
            var path=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot" ,newName);
            var stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return Created(string.Empty, formFile);
        }
    }
}
