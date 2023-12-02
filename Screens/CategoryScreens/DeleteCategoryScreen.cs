using adoblog.Models;
using adoblog.Repositories;

namespace adoblog.Screens.CategoryScreens;

public class DeleteCategoryScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Deletar Categoria");
        Console.WriteLine("---------");
        Console.Write("Id: ");
        var Id = Console.ReadLine();
        Delete(int.Parse(Id));
        Console.ReadKey();
    }

    private static void Delete(int id)
    {
        try
        {
            new Repository<Category>().Delete(id);
            Console.WriteLine("Categoria deletada com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi possivel deletar categoria.");
            Console.WriteLine(ex.Message);
        }
    }
}