using adoblog.Models;
using adoblog.Repositories;

namespace adoblog.Screens.UserScreen;

public class CreateUserScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Criar Usuario");
        Console.WriteLine("-------------");
        Console.Write("Nome:");
        var name = Console.ReadLine();
        Console.Write("Email:");
        var email = Console.ReadLine();
        Console.Write("Bio:");
        var bio = Console.ReadLine();
        Console.Write("Image:");
        var image = Console.ReadLine();
        Console.Write("Slug:");
        var slug = Console.ReadLine();
        Console.Write("Password:");
        var password = Console.ReadLine();


        Create(new User
        {
            Name = name,
            Email = email,
            Bio = bio,
            Image = image,
            Slug = slug,
            PasswordHash = password
        });

        Console.ReadKey();
        MenuUserScreen.Load();
    }

    private static void Create(User user)
    {
        try
        {
            new Repository<User>().Create(user);
            Console.WriteLine("Usuario criado com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi possivel criar usuario.");
            Console.WriteLine(ex.Message);
        }
    }
}