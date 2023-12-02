using adoblog.Models;
using adoblog.Repositories;
using adoblog.Screens.CategoryScreens;
using Microsoft.Data.SqlClient;

namespace adoblog.Screens.ReportScreens;

public class MenuReportScreen : ListTagsWithCountPostsScreen, IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Relatorios");
        Console.WriteLine();
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 - Listar os usuarios (Nome, Email e Perfils)");
        Console.WriteLine("2 - Listar categorias com quantidade de posts");
        Console.WriteLine("3 - Listar tags com quantidade de posts");
        Console.WriteLine("4 - Listar post de uma Categoria");
        Console.WriteLine("5 - Listar todos os posts com sua categoria");
        Console.WriteLine("6 - Listar todos os posts com suas tags");
        Console.WriteLine("7 - Voltar ");
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                ListUsersWithRolesScreen.Load();
                break;
            case 2:
                ListCategoriesWithCountPostScreen.Load();
                break;
            case 3:
                ListTagsWithCountPostsScreen.Load();
                break;
            case 4:
                ListPostWithCategoryScreen.Load();
                break;
            case 5:
                ListPostWithTagsScreen.Load();
                break;
            case 6:
                ListCategoryWithPostsScreen.Load();
                break;
            case 7:
                MenuScreen.Load();
                break;
            default: Load(); break;
        }
    }

}
