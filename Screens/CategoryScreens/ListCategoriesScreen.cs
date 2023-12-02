using adoblog.Models;
using adoblog.Repositories;

namespace adoblog.Screens.CategoryScreens;

public class ListCategoriesScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Listar Categorias");
        Console.WriteLine("-----------------");
        List();
        Console.ReadKey();
        MenuCategoryScreen.Load();
    }

    private static void List()
    {
        List<Category> categories = new Repository<Category>().Get();
        foreach (var item in categories)
        {
            Console.WriteLine(item);
        }
    }
}