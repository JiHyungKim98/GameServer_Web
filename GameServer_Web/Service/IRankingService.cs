using GameServer_Web.Model.HttpCommand;

namespace GameServer_Web.Service;

public interface IRankingService
{
    public List<string> GetRanking(string id);
    public List<UserInfo> AllUserInfo();
    public bool AddRanking(string id, int score);
}
