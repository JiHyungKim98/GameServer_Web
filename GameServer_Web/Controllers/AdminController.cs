using Microsoft.AspNetCore.Mvc;
using GameServer_Web.Model.HttpCommand;
using GameServer_Web.Service;

namespace GameServer_Web.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class AdminController : ControllerBase
{
    private readonly ILogger<AdminController> _logger;
    private IRankingService _rankingService;
    private IAccountService _accountService;

    public AdminController(ILogger<AdminController> logger, IRankingService rankingService, IAccountService accountService)
    {
        _logger = logger;
        _rankingService = rankingService;
        _accountService = accountService;
    }

    [HttpPost("GetRanking")]
    public List<UserInfo> AllUserList()
    {
        var userInfo = _rankingService.AllUserInfo();

        return userInfo;
    }
}
