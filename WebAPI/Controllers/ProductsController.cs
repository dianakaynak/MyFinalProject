using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  //ATTRIBUTE----->Class ile ilgili bilgi verme, onu imzalama.
    public class ProductsController : ControllerBase
    {    //Loosely coupled-->Gevşek bağımlılık
        //Naming convention--> İsimlendirme standardı
        //IoS Container--Inversion of Control

        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }




        [HttpGet("getall")]
        public IActionResult GetAll()
        {    //Swagger
           //Dependency chain -->Bağımlılık zinciri
           var result= _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }


            return BadRequest(result);


            
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result =_productService.GetById(id);
            if (result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result);  
        }

        [HttpPost("add")]
        public IActionResult Add(Product product) 
        {
            var result= _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
