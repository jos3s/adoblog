using adoblog.Repositories;

namespace adoblog.Screens.ReportScreens;

public class ListCategoriesWithCountPostScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Listagem de categorias com quantidade de posts");
        Console.WriteLine("----------------------------------------------");
        List();
        Console.ReadKey();
        MenuReportScreen.Load();
    }

    private static void List()
    {
        var categories = new CategoryRepository().ReadWithPosts();
        foreach (var category in categories)
        {
            Console.WriteLine($"{category.Name} - {category.Posts.Count}");
        }
    }
}