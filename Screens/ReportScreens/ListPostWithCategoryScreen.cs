using adoblog.Repositories;

namespace adoblog.Screens.ReportScreens;

public class ListPostWithCategoryScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Listagem de posts com sua categoria");
        Console.WriteLine("-----------------------------------");
        List();
        Console.ReadKey();
        MenuReportScreen.Load();
    }

    private static void List()
    {
        var posts = new PostRepository().ReadWithCategory();
        foreach (var post in posts)
        {
            Console.WriteLine(post);
        }
    }
}