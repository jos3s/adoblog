using adoblog.Models;
using adoblog.Repositories;

namespace adoblog.Screens.TagScreens;

public class CreateTagScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Nova Tag");
        Console.WriteLine("---------");
        Console.Write("Nome: ");
        var Name = Console.ReadLine();
        Console.Write("Slug: ");
        var Slug = Console.ReadLine();

        Create(new Tag { Name = Name, Slug = Slug });

        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    public static void Create(Tag tag)
    {
        try
        {
            new Repository<Tag>().Create(tag);
            Console.WriteLine("Tag criada com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi possivel criar a tag.");
            Console.WriteLine(ex.Message);
        }
    }
}