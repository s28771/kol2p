using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;

namespace WebApplication2.Services;

public class DbService : IDbService
{
    private readonly DataContext _context;

    public DbService(DataContext context)
    {
        _context = context;
    }

    public async Task<ClientDto> GetClientByIdAsync(int clientId)
    {
        var client = await _context.Clients
            .Include(c => c.CarRentals)
            .ThenInclude(cr => cr.Car)
            .ThenInclude(c => c.Color)
            .Include(c => c.CarRentals)
            .ThenInclude(cr => cr.Car)
            .ThenInclude(c => c.Model)
            .FirstOrDefaultAsync(c => c.IdClient == clientId);

        if (client == null) return null;

        var clientDto = new ClientDto
        {
            Id = client.IdClient,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Address = client.Adress,
            Rentals = client.CarRentals.Select(cr => new RentalDto
            {
                Vin = cr.Car.VIN,
                Color = cr.Car.Color.Name,
                Model = cr.Car.Model.Name,
                DateFrom = cr.DateFrom,
                DateTo = cr.DateTo,
                TotalPrice = cr.TotalPrice
            }).ToList()
        };

        return clientDto;
    }

    public async Task AddClientWithRentalAsync(ClientDto clientDto)
    {
        var car = await _context.Cars.FindAsync(clientDto.Rental.CarId);
        if (car == null) throw new Exception("Car not found");

        var client = new Client
        {
            FirstName = clientDto.FirstName,
            LastName = clientDto.LastName,
            Adress = clientDto.Address
        };

        var days = (clientDto.Rental.DateTo - clientDto.Rental.DateFrom).Days;
        var totalPrice = days * car.PricePerDay;

        var carRental = new Car_Rental
        {
            Car = car,
            DateFrom = clientDto.Rental.DateFrom,
            DateTo = clientDto.Rental.DateTo,
            TotalPrice = totalPrice,
            Disscount = clientDto.Rental.Disscount
        };

        client.CarRentals = new List<Car_Rental> { carRental };

        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
    }
}
