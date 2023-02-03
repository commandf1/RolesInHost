using HarmonyLib;
using InnerNet;

namespace RolesInHost.Listener;

public interface IListener
{
    void OnPlayerMurderPlayer(PlayerControl killer, PlayerControl target) { }
    void OnGameJoined(AmongUsClient client) { }
    void OnPlayerJoined(AmongUsClient amongUsClient, [HarmonyArgument(0)] ClientData client) { }
    void OnPlayerLeft(AmongUsClient amongUsClient, [HarmonyArgument(0)] ClientData data, [HarmonyArgument(1)] DisconnectReasons reason) { }
}
