using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileSorterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortController : ControllerBase
    {
        // POST: api/Sort
        [HttpPost]
        public IActionResult Post([FromBody] string path)
        {
            try
            {
                Sort sort = new Sort(path);
                return StatusCode(200);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
