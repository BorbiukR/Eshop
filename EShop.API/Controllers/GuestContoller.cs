using EShop.BL.DTOs;
using EShop.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EShop.API.Controllers
{
    [Route("api/guest")]
    [ApiController]
    public class GuestContoller : ControllerBase
    {
        private readonly IGuestService _guestService;
        private readonly ILogger<GuestContoller> _logger;

        public GuestContoller(IGuestService guestService, ILogger<GuestContoller> logger)
        {
            _guestService = guestService;
            _logger = logger;
        }

        [HttpGet("products")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _guestService.GetAll();
                
                if (products == null)
                    return StatusCode(404, "Product not found");

                _logger.LogInformation($"Returned all products from database.");

                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllProducts action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("products/{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _guestService.FindById(id);

                //if (product == null)
                //    return StatusCode(404, "Product not found");

                _logger.LogInformation($"Returned product with {product.Id} Id from database.");

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("product/{productName}")]
        public IActionResult GetProductByName(string productName)
        {
            try
            {
                var product = _guestService.FindByName(productName);

                if (product == null)
                    return StatusCode(404, "Product not found");

                _logger.LogInformation($"Returned product with {product.Id} Id from database.");

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}