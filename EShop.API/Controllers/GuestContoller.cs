using AutoMapper;
using DAL.Interfaces;
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

        public GuestContoller(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet("{login}")]
        public async Task<IActionResult> GetEmployeeByLogin(string login)
        {

           return StatusCode(500);
            
        }
    }
}
