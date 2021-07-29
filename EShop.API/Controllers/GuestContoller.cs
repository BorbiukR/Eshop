using AutoMapper;
using DAL.Interfaces;
using Eshop.DAL.Models;
using EShop.API.Models.Request;
using EShop.BL.DTOs;
using EShop.BL.Interfaces;
using EShop.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.API.Controllers
{
    [Route("api/guest")]
    [ApiController]
    public class GuestContoller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;
        private readonly IGuestService _guestService;

        public GuestContoller(IUnitOfWork unit, IMapper mapper, IGuestService guestService)
        {
            _unit = unit;
            _mapper = mapper;
            _guestService = guestService;
        }

        [HttpGet("products/")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _guestService.GetAllProducts();
                if (products == null)
                {
                    return StatusCode(404, "Product not found");
                }
                var productsResult = _mapper.Map<List<ProductDTO>>(products);
                return Ok(productsResult);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("product/{productid}")]
        public IActionResult GetProductById(int productId, [FromBody] ProductRequest productRequest)
        {
            try
            {
                var products = _guestService.GetProductById(productId);
                if (products == null)
                {
                    return StatusCode(404, "Product not found");
                }
                return Ok(_mapper.Map<ProductDTO>(productRequest));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
