using HarmonyLib;
using Hazel;

namespace RolesInHost.Modules;

public static class PlayerControlModule
{
    public static Role.Role? GetRole(this PlayerControl playerControl)
    {
        if (playerControl == null)
        {
            return null;
        }

        return Main.PlayerStates.GetValueSafe(playerControl.PlayerId).Role;
    }

    public static void SetDead(this PlayerControl playerControl)
    {
        if (AmongUsClient.Instance.AmHost)
        {
            playerControl.RpcMurderPlayer(playerControl);
        }
    }

}
