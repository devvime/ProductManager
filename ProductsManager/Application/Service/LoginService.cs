using ProductsManager.Application.Helper;
using ProductsManager.Application.Interface;
using ProductsManager.Application.Model;

namespace ProductsManager.Application.Service;

public class LoginService : ILoginService
{
    private readonly ICreateUserToken _createUserToken;

    public LoginService(ICreateUserToken createUserToken)
    {
        _createUserToken = createUserToken;
    }

    public string Execute(Login request)
    {
        // TO DO: lOGIN UseCase
        var token = _createUserToken.Execute(request);
        return token;
    }
}
