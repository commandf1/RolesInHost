using AmongUs.GameOptions;

namespace RolesInHost.Role;

public class Role
{
    public Role(string name, string displayName)
    {
        Name = name;
        Color = "#FFFFF";
        CanKill = false;
        KillColdDown = 20;
        DisplayName = displayName;
        Group = RoleGroup.Crewmate;
        BaseRole = RoleTypes.Crewmate;
    }

    public string Name { get; }

    public string DisplayName { get; set; }

    public string Color { get; set; }

    public bool CanKill { get; set; }

    public byte KillColdDown { get; set; }

    public RoleGroup Group { get; }

    public RoleTypes BaseRole { get; set; }

}