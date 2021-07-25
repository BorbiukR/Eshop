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
    [Route("api/user")]
    [ApiController]
    public class UserContoller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public UserContoller(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
    }
}
