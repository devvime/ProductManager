using ProductsManager.Application.Model;

namespace ProductsManager.Application.Interface;

public interface ILoginService
{
    public bool Execute(Login request);
}