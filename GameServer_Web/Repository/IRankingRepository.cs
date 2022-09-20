using GameServer_Web.Model.HttpCommand;

namespace GameServer_Web.Repository;

public interface IRankingRepository
{
    public List<UserInfo> AllUserInfo();
    bool AddRanking(string id, int score);
    public List<UserInfo> GetRanking(string id);
}
