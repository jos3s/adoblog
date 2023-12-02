using adoblog.Screens.CategoryScreens;
using adoblog.Screens.ReportScreens;
using adoblog.Screens.TagScreens;
using adoblog.Screens.UserScreen;

namespace adoblog.Screens;

public class MenuScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Blog");
        Console.WriteLine("-----------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Gestão de usuário");
        Console.WriteLine("2 - Gestão de perfil");
        Console.WriteLine("3 - Gestão de categoria");
        Console.WriteLine("4 - Gestão de tag");
        Console.WriteLine("5 - Vincular perfil/usuário");
        Console.WriteLine("6 - Vincular post/tag");
        Console.WriteLine("7 - Relatórios");
        Console.WriteLine();
        Console.WriteLine();
        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1:
                MenuUserScreen.Load();
                break;
            case 2:
                MenuRoleScreen.Load();
                break;
            case 3:
                MenuCategoryScreen.Load();
                break;
            case 4:
                MenuTagScreen.Load();
                break;
            case 7:
                MenuReportScreen.Load();
                break;
            default: 
                Load(); 
                break;
        }
    }

}
