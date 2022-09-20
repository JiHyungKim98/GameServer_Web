using Microsoft.AspNetCore.Mvc;
using GameServer_Web.Service;

namespace GameServer_Web.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class RankingController : ControllerBase
{
    private readonly ILogger<RankingController> _logger;
    private IAccountService _accountService;
    private IRankingService _rankingService;


    public RankingController(ILogger<RankingController> logger, IAccountService accountService, IRankingService rankingService)
    {
        _logger = logger;
        _accountService = accountService;
        _rankingService = rankingService;
    }

    [HttpPost("GetRanking")]
    public List<string> GetRankings(string id)
    {
        List<string> response = new List<string>();
        // User input Wrong
        if (id == null)
        {
            response.Add("Input is Empty!");
        }
        // User input Right
        else
        {
            var tmp = _rankingService.GetRanking(id);

            if (tmp.Count > 1)
            {
                response.Add("ID : " + tmp[0]);
                response.Add("Score : " + tmp[1]);
                response.Add("Ranking : " + tmp[2]);
            }
            else
                response.Add(tmp[0]);
        }
        return response;
    }

    [HttpPost("AddRanking")]
    public string AddRanking(string id, int score)
    {
        // User input Wrong
        if (id == null || score == 0)
        {
            return "Wrong Input!";
        }
        // User input Right
        else
        {
            // Unknown ID
            if (!_rankingService.AddRanking(id, score))
            {
                return "Unknown Account";
            }
            else
            {
                return "Ranking Update Success!";
            }
        }
    }
}
