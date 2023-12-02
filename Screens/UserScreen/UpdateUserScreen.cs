using adoblog.Models;
using adoblog.Repositories;

namespace adoblog.Screens.UserScreen;

internal class UpdateUserScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Atualizar Usuario");
        Console.WriteLine("-----------------");
        Console.Write("Id:");
        var id = Console.ReadLine();
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


        Update(new User
        {
            Id = int.Parse(id),
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

    private static void Update(User user)
    {
        try
        {
            new Repository<User>().Create(user);
            Console.WriteLine("Usuario atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi possivel atualizar o usuario.");
            Console.WriteLine(ex.Message);
        }
    }
}