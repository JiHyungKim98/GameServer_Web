using GameServer_Web.Model;

namespace GameServer_Web.Repository;

public interface IAccountRepository
{
    public List<Account> GetAccount(string id);
    public void CreateAccounts(string id, string password);
    bool isExist(string id);
}
