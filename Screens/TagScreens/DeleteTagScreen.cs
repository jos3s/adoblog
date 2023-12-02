using adoblog.Models;
using adoblog.Repositories;

namespace adoblog.Screens.TagScreens;

public class DeleteTagScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Deletar Tag");
        Console.WriteLine("---------");
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
            new Repository<Tag>().Delete(id);
            Console.WriteLine("Tag deletada com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi deletar a tag.");
            Console.WriteLine(ex.Message);
        }
    }
}