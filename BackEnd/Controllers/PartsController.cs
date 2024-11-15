using Microsoft.AspNetCore.Mvc;
using StockOfMachineParts.Dtos;
using StockOfMachineParts.Services;

namespace StockOfMachineParts.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PartsController : ControllerBase
{
    private readonly IPartsService _partsService;

    public PartsController(IPartsService partsService)
    {
        _partsService = partsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
       var result = await _partsService.GetAllPartsAsync();
       return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllById(int id)
    {
        var result = await _partsService.GetAllPartsAsyncById(id);
        if (result is null)
            return NotFound();
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateParts(PartsRequestDto requestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _partsService.AddParts(requestDto);
        return CreatedAtAction(nameof(GetAllById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateParts(int id, PartsRequestDto requestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _partsService.UpdateParts(id, requestDto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteParts(int id)
    {
        await _partsService.DeleteParts(id);
        return NoContent();
    }
}