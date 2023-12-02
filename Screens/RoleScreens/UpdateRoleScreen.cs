using adoblog.Models;
using adoblog.Repositories;

namespace adoblog.Screens.TagScreens;

public class UpdateRoleScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Atualizando Perfil");
        Console.WriteLine("--------------------");
        Console.Write("Id: ");
        var id = Console.ReadLine();

        Console.Write("Nome: ");
        var name = Console.ReadLine();

        Console.Write("Slug: ");
        var slug = Console.ReadLine();

        Update(new Role
        {
            Id = int.Parse(id),
            Name = name,
            Slug = slug
        });
        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    public static void Update(Role role)
    {
        try
        {
            new Repository<Role>().Update(role);
            Console.WriteLine("Cargo atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar o cargo");
            Console.WriteLine(ex.Message);
        }
    }
}