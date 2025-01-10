using Microsoft.AspNetCore.Mvc;
using ShopClickDrive.LeadManagement.DTOs;
using ShopClickDrive.LeadManagement.Services;

namespace ShopClickDrive.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeadController : ControllerBase
{
    private readonly LeadService _service;

    public LeadController(LeadService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLead([FromBody] CreateLeadDto leadDto)
    {
        await _service.AddLeadAsync(leadDto);
        return Ok("Lead created successfully.");
    }

    [HttpGet("{dealerId}")]
    public async Task<IActionResult> GetLeads(int dealerId)
    {
        var leads = await _service.GetLeadsByDealerIdAsync(dealerId);
        return Ok(leads);
    }
}
