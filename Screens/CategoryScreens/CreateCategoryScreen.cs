using adoblog.Models;
using adoblog.Repositories;
using adoblog.Screens.TagScreens;

namespace adoblog.Screens.CategoryScreens;

public class CreateCategoryScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Nova Categoria");
        Console.WriteLine("---------");
        Console.Write("Nome: ");
        var Name = Console.ReadLine();
        Console.Write("Slug: ");
        var Slug = Console.ReadLine();

        Create(new Category { Name = Name, Slug = Slug });

        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    private static void Create(Category category)
    {
        try
        {
            new Repository<Category>().Create(category);
            Console.WriteLine("Categoria criada com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi possivel criar categoria");
            Console.WriteLine(ex.Message);
        }
    }
}