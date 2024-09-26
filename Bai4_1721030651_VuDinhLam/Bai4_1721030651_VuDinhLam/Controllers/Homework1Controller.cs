using AutoMapper;
using Bai4_1721030651_VuDinhLam.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bai4_1721030651_VuDinhLam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Homework1Controller : ControllerBase
    {
        private readonly ApiteachingContext _context;
        private readonly IMapper _mapper;
        public Homework1Controller(ApiteachingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Address
        [HttpGet]

    }
}
