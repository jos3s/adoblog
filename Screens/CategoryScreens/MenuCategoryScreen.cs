namespace adoblog.Screens.CategoryScreens;

public class MenuCategoryScreen : IMenu
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestao de Categorias");
        Console.WriteLine();
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 - Listar Categoria");
        Console.WriteLine("2 - Criar Categoria");
        Console.WriteLine("3 - Atualizar Categoria");
        Console.WriteLine("4 - Deletar Categorias");
        Console.WriteLine("5 - Voltar ");
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                ListCategoriesScreen.Load();
                break;
            case 2:
                CreateCategoryScreen.Load();
                break;
            case 3:
                UpdateCategoryScreen.Load();
                break;
            case 4:
                DeleteCategoryScreen.Load();
                break;
            case 5:
                MenuScreen.Load();
                break;
            default: Load(); break;
        }
    }
}
