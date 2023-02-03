using RolesInHost.Listener;
using RolesInHost.Modules;

namespace RolesInHost.Role.Roles;

public class Bait : Role, IListener
{
    public Bait() : base("Bait", "诱饵")
    {
        Color = "#00f7ff";
    }

    public void OnPlayerMurderPlayer(PlayerControl killer, PlayerControl target)
    {
        if (target.GetRole() is not Bait)
        {
            return;
        }

        killer.CmdReportDeadBody(killer.Data);
    }
}
