using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    //ControllerBaseden kalıtım alma ve [ApiController] attributeya sahip olmak api controller olma şartıdır. 
    public class ProductsController : ControllerBase
    {
        //Loosely Coupled
        //naming convention
        //IoC Container -- Inversion Of Control
         IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            //Dependency chain --
            
            var result =  _productService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int productId)
        {
            var result = _productService.GetById(productId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);


        }


        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


       
    }
}
