using adoblog.Models;
using adoblog.Repositories;

namespace adoblog.Screens.UserScreen;

public class DeleteUserScreen : IMenu
{
    public static void Load()
    {
        Console.WriteLine("Deletar Usuario");
        Console.WriteLine("---------------");
        Console.Write("Id:");
        var Id = Console.ReadLine();
        Delete(int.Parse(Id));
        Console.ReadKey();
        MenuUserScreen.Load();
    }

    public static void Delete(int id) 
    { 
        try
        {
            new Repository<User>().Delete(id);
            Console.WriteLine("Usuario deletado com sucesso.");
        } catch (Exception ex)
        {
            Console.WriteLine("Nao foi possivel deletar o usuario.");
            Console.WriteLine(ex.Message);
        }
    }
}