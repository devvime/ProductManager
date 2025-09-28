using ProductsManager.Application.Model;

namespace ProductsManager.Application.Interface;

public interface ICreateUserToken
{
    public string Execute(Login request);
}