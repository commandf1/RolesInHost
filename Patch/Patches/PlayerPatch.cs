using HarmonyLib;
using InnerNet;
using RolesInHost.Listener;

namespace RolesInHost.Patch.Patches;

public abstract class PlayerPatch : Patch
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.MurderPlayer))]
    class MurderPlayerPatch
    {
        public static void Postfix(PlayerControl __instance, [HarmonyArgument(0)] PlayerControl target)
        {
            // if (!target.Data.IsDead || !AmongUsClient.Instance.AmHost) return;
            
            PlayerControl killer = __instance;

            foreach (var listener in ListenerManager.GetListeners())
            {
                listener.OnPlayerMurderPlayer(killer, target);
            }
            
            /*
            foreach (var role in Role.RoleManager.getRoles())
            {
                if (role is not IListener listener)
                {
                    continue;
                }
                
                listener.OnPlayerMurderPlayer(__instance, target);
            }
            */
        }
    }

    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnPlayerJoined))]
    class OnPlayerJoinedPatch
    {
        public static void Postfix(AmongUsClient __instance, [HarmonyArgument(0)] ClientData client)
        {
            foreach (var listener in ListenerManager.GetListeners())
            {
                listener.OnPlayerJoined(__instance, client);
            }
        }
    }
    
    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnPlayerLeft))]
    class OnPlayerLeftPatch
    {
        public static void Postfix(AmongUsClient __instance, [HarmonyArgument(0)] ClientData data, [HarmonyArgument(1)] DisconnectReasons reason)
        {
            foreach (var listener in ListenerManager.GetListeners())
            {
                listener.OnPlayerLeft(__instance, data, reason);
            }
        }
    }

}