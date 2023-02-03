namespace RolesInHost.Modules;

public class PlayerState
{
    public byte Id { get; }
    public Role.Role Role { get; set; }

    public PlayerState(PlayerControl player)
    {
        Id = player.PlayerId;
    }
}