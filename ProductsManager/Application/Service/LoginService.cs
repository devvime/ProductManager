using ProductsManager.Application.Interface;
using ProductsManager.Application.Model;

namespace ProductsManager.Application.Service;

public class LoginService(IConfiguration config) : ILoginService
{
    private readonly IConfiguration config = config;

    public bool Execute(Login request)
    {
        return false;
    }
}