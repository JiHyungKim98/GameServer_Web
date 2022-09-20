using GameServer_Web.Model;

namespace GameServer_Web.Repository;

public class AccountByMemory : IAccountRepository
{
    private Dictionary<string, Account> _accountDic { get; set; }
    public AccountByMemory()
    {
        _accountDic = new Dictionary<string, Account>();
    }
    public bool isExist(string id)
    {
        if (_accountDic.ContainsKey(id))
            return true;
        return false;
    }

    public List<Account> GetAccount(string id)
    {
        return _accountDic.Where(x => x.Key == id).Select(x => x.Value).ToList();
    }
    public void CreateAccounts(string id, string password)
    {
        Account account = new Account();
        account.id = id;
        account.Password = password;
        account.CreateAt = DateTime.Now;

        _accountDic.Add(account.id, account);
    }
}
