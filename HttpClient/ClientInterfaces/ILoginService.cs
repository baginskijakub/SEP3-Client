using System.Security.Claims;
using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface ILoginService
{
    public Task LoginAsync(LoginDto dto);
    public Task LogoutAsync();

    public Task<User> GetDriverByIdAsync(int id);
    public Task RegisterAsync(RegisterDto dto);
    public Task<ClaimsPrincipal> GetAuthAsync();

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }

    public Task UpdateUserLicense(UpdateLicenseDto dto);
}