using System.Security.Claims;
using HttpClients.ClientInterfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace WebApp.auth;

public class CustomAuthProvider: AuthenticationStateProvider
{
    private readonly ILoginService loginService;

    public CustomAuthProvider(ILoginService loginService)
    {
        this.loginService = loginService;
        loginService.OnAuthStateChanged += AuthStateChanged;
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await loginService.GetAuthAsync();
        
        return new AuthenticationState(principal);
    }
    
    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
}