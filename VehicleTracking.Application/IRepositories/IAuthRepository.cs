using VehicleTracking.Domain.Entities;

namespace VehicleTracking.Application.IRepositories;

public interface IAuthRepository
{
    ApiClient GetByUsernameAndToken();
}
