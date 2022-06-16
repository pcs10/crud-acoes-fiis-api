using CrudSimplesApiFiis.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route(template: "categorias")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var categorias = await context
                .Categorias
                .AsNoTracking()
                .ToListAsync();
            return Ok(categorias);
        }
    }
}
