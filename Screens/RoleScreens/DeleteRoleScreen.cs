using adoblog.Models;
using adoblog.Repositories;

namespace adoblog.Screens.TagScreens;

public class DeleteRoleScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Deletar Perfil");
        Console.WriteLine("--------------");
        Console.Write("Id: ");
        var Id = Console.ReadLine();
        Delete(int.Parse(Id));
        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    private static void Delete(int id)
    {
        try
        {
            new Repository<Role>().Delete(id);
            Console.WriteLine("Perfil deletada com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi deletar o perfil.");
            Console.WriteLine(ex.Message);
        }
    }
}