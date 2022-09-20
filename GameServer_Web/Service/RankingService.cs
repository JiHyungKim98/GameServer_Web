using GameServer_Web.Model.HttpCommand;
using GameServer_Web.Repository;

namespace GameServer_Web.Service;
public class RankingService : IRankingService
{
    public IAccountService _accountService { get; set; }
    public IRankingRepository _rankingRepository { get; set; }

    public RankingService(IAccountService accountService, IRankingRepository rankingRepository)
    {
        _accountService = accountService;
        _rankingRepository = rankingRepository;
    }
    public List<UserInfo> AllUserInfo()
    {
        return _rankingRepository.AllUserInfo();
    }
    public List<string> GetRanking(string id)
    {
        List<string> userRankings = new List<string>();
        // ID Exist
        if (_accountService.isExist(id))
        {
            var info = _rankingRepository.GetRanking(id);
            string ID = info.Select(x => x.id).First();
            int Score = info.Select(x => x.Score).First();
            int Rank = info.Select(x => x.Ranking).First();

            userRankings.Add(ID);
            userRankings.Add(Score.ToString());
            userRankings.Add(Rank.ToString());
        }

        // UnKnown ID
        else
        {
            userRankings.Add("Unknown Account!");
        }
        return userRankings;
    }

    public bool AddRanking(string id, int score)
    {
        // !ID Exist
        if (!_accountService.isExist(id))
        {
            return false;
        }

        // ID Exist
        else
        {
            // No Ranking Info
            var info = _rankingRepository.GetRanking(id);
            int Score = info.Select(x => x.Score).First();

            // 기록 갱신인 경우
            if (score > Score)
                _rankingRepository.AddRanking(id, score);

            return true;
        }
    }
}
