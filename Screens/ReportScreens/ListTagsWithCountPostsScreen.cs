using adoblog.Repositories;

namespace adoblog.Screens.ReportScreens;

public class ListTagsWithCountPostsScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Listagem de tags com quantidade de posts");
        Console.WriteLine("-----------------");
        List();
        Console.ReadKey();
        MenuReportScreen.Load();
    }

    private static void List()
    {
        var tags = new TagRepository().ReadTagWithPosts();
        foreach (var tag in tags)
        {
            Console.WriteLine($"{tag.Name} - {tag.Posts.Count}");
        }
    }
}