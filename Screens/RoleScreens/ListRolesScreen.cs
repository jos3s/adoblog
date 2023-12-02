using adoblog.Models;
using adoblog.Repositories;

namespace adoblog.Screens.TagScreens;

public class ListRolesScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Lista de Perfils");
        Console.WriteLine("----------------");
        List();
        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    private static void List()
    {
        List<Role> roles = new Repository<Role>().Get();
        foreach (var role in roles)
        {
            Console.WriteLine(role);
        }
    }
}