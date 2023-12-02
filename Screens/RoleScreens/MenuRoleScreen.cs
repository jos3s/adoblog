namespace adoblog.Screens.TagScreens;

public class MenuRoleScreen : IMenu
{

    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestao de Perfils");
        Console.WriteLine();
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 - Listar Perfils");
        Console.WriteLine("2 - Criar Perfil");
        Console.WriteLine("3 - Atualizar Perfil");
        Console.WriteLine("4 - Deletar Perfil");
        Console.WriteLine("5 - Voltar");
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                ListRolesScreen.Load();
                break;
            case 2:
                CreateRoleScreen.Load(); 
                break;
            case 3:
                UpdateRoleScreen.Load(); 
                break;
            case 4:
                DeleteRoleScreen.Load(); 
                break;
            case 5:
                MenuScreen.Load(); 
                break;
            default: Load(); break;
        }
    }
}
