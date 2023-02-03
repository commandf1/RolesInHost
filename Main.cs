using BepInEx;
using BepInEx.IL2CPP;
using RolesInHost.Listener;
using RolesInHost.Modules;
using RolesInHost.Role.Roles;

namespace RolesInHost;

[BepInPlugin(PluginGuid, "Roles In Host", PluginVersion)]
// [BepInIncompatibility(PluginGuid)]
[BepInProcess("Among Us.exe")]
public class Main : BasePlugin
{
    public const string Name = "RolesInHost";
    public const string PluginGuid = "space.commandf1.rolesinhost";
    public const string PluginVersion = "1.0.0";

    public static Main Instance = null!;

    public static readonly List<Role.Role> Roles = new();

    public static readonly Dictionary<byte, PlayerState> PlayerStates = new();

    public static IEnumerable<PlayerControl> AllPlayerControls =>
        PlayerControl.AllPlayerControls.ToArray().Where(p => p != null);

    public override void Load()
    {
        Instance = this;

        // start to load

        // start to register roles
        Roles.Clear();
        Role.Role[] roles = { new Bait() };
        foreach (var role in roles) Roles.Add(role);
        
        RegisterRolesWithListeners(roles);
    }

    private static void RegisterRolesWithListeners(Role.Role[] roles)
    {
        Role.RoleManager.RegisterRoles(roles);
        // ListenerManager.RegisterListeners(roles);
        foreach (var role in roles)
        {
            ListenerManager.RegisterListeners(new IListener[] { (IListener) role });
        }
    }

}
