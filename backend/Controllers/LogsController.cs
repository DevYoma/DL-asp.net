using Microsoft.AspNetCore.Mvc;
using DigitalLogbookAPI.DTOs;
using DigitalLogbookAPI.Models;
using Supabase;
using System;
using System.Threading.Tasks;

namespace DigitalLogbookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly SupabaseService _supabaseService;

        public LogsController()
        {
            _supabaseService = new SupabaseService();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateLog([FromBody] LogDto dto)
        {
            try
            {
                var client = _supabaseService.GetClient();

                // Create a new DailyLog model
                var log = new DailyLog
                {
                    Text = dto.Text,
                    Date = dto.Date,
                };

                // ✅ Insert using the model, not a string table name
                var response = await client.From<DailyLog>().Insert(log);

                return Ok(new { message = "Log created successfully!", data = response.Models });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLogs()
        {
            try
            {
                var client = _supabaseService.GetClient();

                // ✅ Retrieve using the model
                var response = await client.From<DailyLog>().Get();

                return Ok(response.Models);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
