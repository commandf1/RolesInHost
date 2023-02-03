using HarmonyLib;
using RolesInHost.Listener;

namespace RolesInHost.Patch.Patches;

public abstract class GamePatch
{
    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnGameJoined))]
    class OnGameJoinedPatch
    {
        public static void Postfix(AmongUsClient __instance)
        {
            foreach (var listener in ListenerManager.GetListeners())
            {
                listener.OnGameJoined(__instance);
            }
        }
    }
}
