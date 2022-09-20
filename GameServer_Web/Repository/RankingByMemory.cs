using GameServer_Web.Model.HttpCommand;

namespace GameServer_Web.Repository;

public class RankingByMemory : IRankingRepository
{
    private List<UserInfo> _rankingList { get; set; }


    public RankingByMemory()
    {
        _rankingList = new List<UserInfo>();
    }
    public List<UserInfo> AllUserInfo()
    {
        return _rankingList;
    }
    public bool AddRanking(string id, int score)
    {
        _rankingList.Find(x => x.id == id).Score = score;
        return true;
    }
    public List<UserInfo> GetRanking(string id)
    {
        var idLst = _rankingList.Select(x => x.id);

        if (!idLst.Contains(id))
            _rankingList.Add(new UserInfo() { id = id, Score = 0, Ranking = 0 });

        return _rankingList.Where(x => x.id == id).ToList();
    }
}
