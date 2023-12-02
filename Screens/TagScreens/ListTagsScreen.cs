using adoblog.Models;
using adoblog.Repositories;

namespace adoblog.Screens.TagScreens;

public class ListTagsScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Lista de Tags");
        Console.WriteLine("-------------");
        List();
        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    private static void List()
    {
        List<Tag> tags = new Repository<Tag>().Get();
        foreach (var tag in tags)
        {
            Console.WriteLine(tag);
        }
    }
}