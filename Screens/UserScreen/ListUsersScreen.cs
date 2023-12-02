using adoblog.Models;
using adoblog.Repositories;
using adoblog.Screens.CategoryScreens;

namespace adoblog.Screens.UserScreen;

public class ListUsersScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Listar Usuarios");
        Console.WriteLine("-----------------");
        List();
        Console.ReadKey();
        MenuCategoryScreen.Load();
    }

    public static void List()
    {
        List<User> users = new Repository<User>().Get();
        foreach (var item in users)
            Console.WriteLine(item);
    }
}
