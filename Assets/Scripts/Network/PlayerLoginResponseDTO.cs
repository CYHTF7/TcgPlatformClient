using System;

public class PlayerLoginResponseDTO
{
    public PlayerProfileDTO PlayerProfile { get; set; }
    public AuthPlayerProfileDTO AuthPlayerProfile { get; set; }
}

public class PlayerProfileDTO
{
    //public int Id { get; set; }
    public string Nickname { get; set; }
    public int Level { get; set; }
    public int Gold { get; set; }
    public int Experience { get; set; }
    public string AvatarPath { get; set; }
    public int BattlesPlayed { get; set; }
    public string RefreshTokenHash { get; set; }   
}

public class AuthPlayerProfileDTO
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}

