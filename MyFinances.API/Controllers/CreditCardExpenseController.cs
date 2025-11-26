using Microsoft.AspNetCore.Mvc;
using MyFinances.Application.DTOs.Requests;
using MyFinances.Application.Services.Interfaces;

namespace MyFinances.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreditCardExpenseController : ControllerBase
{
    private readonly ICreditCardExpenseService _service;
    
    public CreditCardExpenseController(ICreditCardExpenseService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreditCardExpenseRequest request)
    {
        var created = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, CreditCardExpenseRequest request)
    {
        var updated = await _service.UpdateAsync(id, request);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }
}