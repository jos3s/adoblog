using adoblog.Repositories;

namespace adoblog.Screens.ReportScreens;

public class ListUsersWithRolesScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Lista de Usuarios");
        Console.WriteLine("-----------------");
        List();
        Console.ReadKey();
        MenuReportScreen.Load();
    }

    private static void List()
    {
        var users = new UserRepository().ReadWithRole();

        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }
}