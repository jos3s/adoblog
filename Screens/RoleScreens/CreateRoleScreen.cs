using adoblog.Models;
using adoblog.Repositories;

namespace adoblog.Screens.TagScreens;

public class CreateRoleScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Novo Perfil");
        Console.WriteLine("----------");
        Console.Write("Nome: ");
        var Name = Console.ReadLine();
        Console.Write("Slug: ");
        var Slug = Console.ReadLine();

        Create(new Role { Name = Name, Slug = Slug });

        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    public static void Create(Role role)
    {
        try
        {
            new Repository<Role>().Create(role);
            Console.WriteLine("Perfil criada com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi possivel criar o perfil.");
            Console.WriteLine(ex.Message);
        }
    }
}