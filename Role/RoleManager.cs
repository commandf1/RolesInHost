namespace RolesInHost.Role;

public class RoleManager
{
    private static List<Role> Roles = new();

    public static void RegisterRoles(Role[] roles)
    {
        foreach (var role in roles)
        {
            Roles.Add(role);
        }
    }

    public static List<Role> getRoles()
    {
        return Roles;
    }
}