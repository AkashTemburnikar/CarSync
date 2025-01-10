using Microsoft.AspNetCore.Mvc;
using ShopClickDrive.InventoryManagement.DTOs;
using ShopClickDrive.InventoryManagement.Services;

namespace ShopClickDrive.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly InventoryService _inventoryService;

    public InventoryController(InventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateInventoryDto dto)
    {
        var inventory = await _inventoryService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = inventory.Id }, inventory);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var inventory = await _inventoryService.GetByIdAsync(id);
        if (inventory == null) return NotFound();
        return Ok(inventory);
    }

    [HttpGet("dealer/{dealerId:guid}")]
    public async Task<IActionResult> GetByDealer(Guid dealerId)
    {
        var inventories = await _inventoryService.GetByDealerIdAsync(dealerId);
        return Ok(inventories);
    }
}