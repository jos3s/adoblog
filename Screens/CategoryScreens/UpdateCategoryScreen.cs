using adoblog.Models;
using adoblog.Repositories;
using adoblog.Screens.TagScreens;

namespace adoblog.Screens.CategoryScreens
{
    internal class UpdateCategoryScreen : IMenu
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Categoria");
            Console.WriteLine("---------");
            Console.Write("Id: ");
            var Id = Console.ReadLine();
            Console.Write("Nome: ");
            var Name = Console.ReadLine();
            Console.Write("Slug: ");
            var Slug = Console.ReadLine();

            Update(new Category { Id =int.Parse(Id), Name = Name, Slug = Slug });

            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void Update(Category category)
        {
            try
            {
                new Repository<Category>().Update(category);
                Console.WriteLine("Categoria atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nao foi possivel atualizar a categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}