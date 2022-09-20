namespace GameServer_Web.Model.HttpCommand;

public class LoginRequest
{
    public string id { get; set; }
    public string Password { get; set; }
}

public class LoginResponse
{
    public string Result { get; set; }
}

public class AccountCreateRequest
{
    public string id { get; set; }
    public string Password { get; set; }
}

public class AccountCreateResponse
{
    public string Result { get; set; }
}

public class UserInfo
{
    public string id { get; set; }
    public int Score { get; set; }
    public int Ranking { get; set; }
}