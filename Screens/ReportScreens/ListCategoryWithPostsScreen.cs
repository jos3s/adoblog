
using adoblog.Models;
using adoblog.Repositories;
using Microsoft.Data.SqlClient;

namespace adoblog.Screens.ReportScreens
{
    public class ListCategoryWithPostsScreen : IMenu
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Listagem de categoria com seus posts");
            Console.WriteLine("------------------------------------");
            List();
            Console.ReadKey();
            MenuReportScreen.Load();
        }

        private static void List()
        {
            Category category = new CategoryRepository().ReadWithPosts(categoryId: 1);

            Console.WriteLine(category);
        }
    }
}