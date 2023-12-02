namespace adoblog.Screens.UserScreen;

public class MenuUserScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestao de Usuarios");
        Console.WriteLine();
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 - Listar Usuarios");
        Console.WriteLine("2 - Criar Usuario");
        Console.WriteLine("3 - Atualizar Usuario");
        Console.WriteLine("4 - Deletar Usuario");
        Console.WriteLine("5 - Voltar ");
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                ListUsersScreen.Load();
                break;
            case 2:
                CreateUserScreen.Load();
                break;
            case 3:
                UpdateUserScreen.Load();
                break;
            case 4:
                DeleteUserScreen.Load();
                break;
            case 5:
                MenuScreen.Load();
                break;
            default: Load(); break;
        }
    }
}
