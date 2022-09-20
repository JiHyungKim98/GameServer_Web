using GameServer_Web.Model.HttpCommand;
using GameServer_Web.Model;
namespace GameServer_Web.Service;


public interface IAccountService
{
    bool isExist(string id);
    LoginResponse Login(LoginRequest loginRequest);
    AccountCreateResponse Create(AccountCreateRequest createRequest);
}
