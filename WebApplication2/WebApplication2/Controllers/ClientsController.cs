using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IDbService _dbService;

    public ClientsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{clientId}")]
    public async Task<IActionResult> GetClient(int clientId)
    {
        var client = await _dbService.GetClientByIdAsync(clientId);
        if (client == null) return NotFound();

        return Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> AddClientWithRental([FromBody] ClientDto clientDto)
    {
        try
        {
            await _dbService.AddClientWithRentalAsync(clientDto);
            return CreatedAtAction(nameof(GetClient), new { clientId = clientDto.Id }, clientDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
