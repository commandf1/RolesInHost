namespace RolesInHost.Listener;

public class ListenerManager
{
    private static List<IListener> Listeners = new();

    public static void RegisterListeners(IListener[] listeners)
    {
        foreach (var listener in listeners)
        {
            Listeners.Add(listener);
        }
    }

    public static List<IListener> GetListeners()
    {
        return Listeners;
    }

}