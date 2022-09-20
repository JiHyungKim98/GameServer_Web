using Microsoft.AspNetCore.Mvc;
using GameServer_Web.Model.HttpCommand;
using GameServer_Web.Service;

namespace GameServer_Web.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private IAccountService _accountService;
    private IRankingService _rankingService;

    public AccountController(ILogger<AccountController> logger, IAccountService accountService, IRankingService rankingService)
    {
        _logger = logger;
        _accountService = accountService;
        _rankingService = rankingService;

    }

    [HttpPost("Login")]
    public LoginResponse Login(LoginRequest loginRequest)
    {
        return _accountService.Login(loginRequest);
    }

    [HttpPost("Create")]
    public AccountCreateResponse Create(AccountCreateRequest accountCreateRequest)
    {
        return _accountService.Create(accountCreateRequest);
    }
}
