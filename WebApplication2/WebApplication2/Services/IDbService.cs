using WebApplication2.DTOs;

namespace WebApplication2.Services;

public interface IDbService
{
    Task<ClientDto> GetClientByIdAsync(int clientId);
    Task AddClientWithRentalAsync(ClientDto clientDto);
}
