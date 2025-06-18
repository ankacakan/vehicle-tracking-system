using Microsoft.Extensions.Configuration;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Domain.Entities;

namespace VehicleTracking.Persistence.Repositories;

public class AuthRepository(IConfiguration configuration) : IAuthRepository
{
    private readonly IConfiguration _config = configuration;

    public ApiClient GetByUsernameAndToken()
    {

        var userClient = _config.GetSection("ApiClient");
        ApiClient apiClient = new()
        {
            Token = userClient["Token"]!,
            Username= userClient["UserName"]!
        };
        return  apiClient;
    }
}