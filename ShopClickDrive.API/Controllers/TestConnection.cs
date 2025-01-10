using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ShopClickDrive.API.Controllers;

public class TestConnection : Controller
{
    [HttpGet("test-db-connection")]
    public IActionResult TestDbConnection([FromServices] IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ShopClickDriveDb");
        try
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            return Ok("Connection Successful!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Connection Failed: {ex.Message}");
        }
    }
}