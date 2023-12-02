using adoblog.Repositories;

namespace adoblog.Screens.ReportScreens
{
    public class ListPostWithTagsScreen : IMenu
    {
        public static void Load()
        {

            Console.Clear();
            Console.WriteLine("Listagem de posts com suas tags");
            Console.WriteLine("----------------------------------------------");
            List();
            Console.ReadKey();
            MenuReportScreen.Load();
        }

        private static void List()
        {
            var posts = new PostRepository().ReadWithTags();
            foreach (var post in posts)
            {
                Console.WriteLine($"{post}");
            }
        }
    }
}