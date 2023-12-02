namespace adoblog.Screens.TagScreens;

public class MenuTagScreen : IMenu
{

    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestao de Tags");
        Console.WriteLine();
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 - Listar Tags");
        Console.WriteLine("2 - Criar Tags");
        Console.WriteLine("3 - Atualizar Tags");
        Console.WriteLine("4 - Deletar Tags");
        Console.WriteLine("5 - Voltar ");
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                ListTagsScreen.Load();
                break;
            case 2:
                CreateTagScreen.Load(); 
                break;
            case 3:
                UpdateTagScreen.Load(); 
                break;
            case 4:
                DeleteTagScreen.Load(); 
                break;
            case 5:
                MenuScreen.Load(); 
                break;
            default: Load(); break;
        }
    }
}
