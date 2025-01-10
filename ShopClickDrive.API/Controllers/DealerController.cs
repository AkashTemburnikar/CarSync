using Microsoft.AspNetCore.Mvc;
using ShopClickDrive.Application.DealerManagement.DTOs;
using ShopClickDrive.Application.DealerManagement.Services;
using ShopClickDrive.Core.Exceptions;

namespace ShopClickDrive.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DealerController : ControllerBase
{
    private readonly DealerService _dealerService;

    public DealerController(DealerService dealerService)
    {
        _dealerService = dealerService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDealer([FromBody] CreateDealerDto dto)
    {
        var dealer= await _dealerService.CreateDealerAsync(dto);
        return CreatedAtAction(nameof(GetDealerById), new { id = dealer.Id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateDealer(Guid id, [FromBody] UpdateDealerDto dto)
    {
        await _dealerService.UpdateDealerAsync(id, dto);
        return NoContent();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetDealerById(Guid id)
    {
        var dealer = await _dealerService.GetDealerByIdAsync(id);
        return Ok(dealer);
    }

    [HttpGet]
    public async Task<IActionResult> GetDealers([FromQuery] DealerQueryDto queryDto)
    {
        var dealers = await _dealerService.GetDealersAsync(queryDto);
        return Ok(dealers);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteDealer(Guid id)
    {
        await _dealerService.DeleteDealerAsync(id);
        return NoContent();
        
    }
}      