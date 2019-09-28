using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVet_Cf.Web.Data;
using MyVet_Cf.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyVet_Cf.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PetTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public PetTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PetTypes
        [HttpGet]
        public IEnumerable<PetType> GetPetTypes()
        {
            return _context.PetTypes.OrderBy(pt => pt.Name);
        }


    }
}