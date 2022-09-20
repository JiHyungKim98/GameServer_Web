using GameServer_Web.Model.HttpCommand;
using GameServer_Web.Model;
using GameServer_Web.Repository;

namespace GameServer_Web.Service;

public class AccountService : IAccountService
{
    public IAccountRepository _accountRepository { get; set; }

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    public bool isExist(string id)
    {
        if (_accountRepository.isExist(id))
            return true;
        return false;
    }


    public LoginResponse Login(LoginRequest loginRequest)
    {
        LoginResponse response = new LoginResponse();
        // 로그인 하는데 정보가 없는 경우
        if (!_accountRepository.isExist(loginRequest.id))
        {
            response.Result = "Unknown Account!";
        }

        // 로그인 하는데 정보가 있는 경우
        else
        {
            // 비밀번호 확인
            string pass = _accountRepository.GetAccount(loginRequest.id).Select(x => x.Password).First();

            if (loginRequest.Password.Equals(pass)) // 비밀번호 일치
            {
                response.Result = "Login Success!";
            }
            else // 비밀번호 불일치
            {
                response.Result = "Password wrong!";
            }
        }
        return response;
    }

    public AccountCreateResponse Create(AccountCreateRequest accountCreateRequest)
    {
        AccountCreateResponse response = new AccountCreateResponse();

        // 이미 있는 계정인지 확인
        if (_accountRepository.isExist(accountCreateRequest.id))
        {
            // 이미 있는 계정이라고 메세지
            response.Result = "Already exists";
        }
        // 없는 계정이면
        else
        {
            _accountRepository.CreateAccounts(accountCreateRequest.id, accountCreateRequest.Password);

            response.Result = "ID has been created";

        }
        return response;
    }

}
