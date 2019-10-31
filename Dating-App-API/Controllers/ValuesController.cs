using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dating_App_API.Data;
using Microsoft.AspNetCore.Authorization;

namespace Dating_App_API.Controllers
{
    // DEFAULT: http://localhost:5000/api
    [Authorize] // makes all requests have to be authorized
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // For accessing the database in the class
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        // async allows for multiple requests by passing the request to a delegate then handeling the next
        // Task is used for async to keep the thread open and not block any other requests
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Users.ToListAsync();

            return Ok(values);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}