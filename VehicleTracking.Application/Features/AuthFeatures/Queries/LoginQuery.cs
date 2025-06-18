using MediatR;
using VehicleTracking.Application.IServices;

namespace VehicleTracking.Application.Features.AuthFeatures.Queries;

public record LoginQuery() : IRequest<string>;

public class Handler : IRequestHandler<LoginQuery, string>
{
    private readonly IAuthService _authService;
    public Handler(IAuthService authService) => _authService = authService;
    public Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var token = _authService.GenerateToken();
        return Task.FromResult(token); 
    }
}

