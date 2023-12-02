using adoblog.Models;
using adoblog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

public class Program
{
    private const string CONNECTION_STRING = @"Server=localhost, 1433;Database=baltaBlog;User Id=sa; Password=1q2w3e4r@#$; Trusted_Connection=False; TrustServerCertificate=True;";

    private static void Main(string[] args)
    {
        var sqlconnection = new SqlConnection(CONNECTION_STRING);

        sqlconnection.Open();
        //CreateUser(sqlconnection);
        //ReadUsers(sqlconnection);
        //ReadRoles(sqlconnection);
        //ReadTags(sqlconnection);
        LinkUserToRole(sqlconnection);
        ReadUsersWithRoles(sqlconnection);
        sqlconnection.Close();
    }

    private static void ReadUsers(SqlConnection connection)
    {
        var users = new Repository<User>(connection).Get();
        foreach (var item in users)
            Console.WriteLine(item);
    }

    private static void ReadRoles(SqlConnection connection)
    {
        var roles = new Repository<Role>(connection).Get();
        foreach (var item in roles)
            Console.WriteLine(item.Name);
    }
    
    private static void ReadTags(SqlConnection connection)
    {
        var tags = new Repository<Tag>(connection).Get();
        foreach (var item in tags)
            Console.WriteLine(item.Name);
    }

    private static void ReadUser(SqlConnection connection)
    {
        var user = new Repository<User>(connection).Get(2);
        Console.WriteLine(user?.Email);
    }

    #region creates
    private static void CreateUser(SqlConnection connection)
    {
        var user = new User
        {
            Bio = "",
            Email = "andre@balta.io",
            Image = "https://balta.io/andrebaltieri.jpg",
            Name = "André Baltieri",
            Slug = Guid.NewGuid().ToString(),
            PasswordHash = Guid.NewGuid().ToString()
        };

        new Repository<User>(connection).Create(user);
    }

    private static void CreateRole(SqlConnection connection)
    {
        var role = new Role
        {
            Name = "Role Novo",
            Slug = Guid.NewGuid().ToString(),

        };

        new Repository<Role>(connection).Create(role);
    }

    private static void CreateCategory(SqlConnection connection)
    {
        var category = new Category
        {
            Name = "Categoria Nova",
            Slug = Guid.NewGuid().ToString(),

        };

        new Repository<Category>(connection).Create(category);
    }

    private static void CreateTag(SqlConnection connection)
    {
        var tag = new Tag
        {
            Name = "Tag Nova",
            Slug = Guid.NewGuid().ToString(),

        };

        new Repository<Tag>(connection).Create(tag);
    }

    private static void CreatePost(SqlConnection connection)
    {
        var post = new Post
        {
            Title = "Post Nova",
            Slug = Guid.NewGuid().ToString(),
            Body = "",
            CreateDate = DateTime.Now,
            LastUpdateDate = DateTime.Now,
            Summary = "",

        };

        new Repository<Post>(connection).Create(post);
    } 
    #endregion

    private static void LinkUserToRole(SqlConnection connection)
    {
        var rows = new UserRepository(connection).LinkUserToRole(userId: 1, roleId: 3);
        Console.WriteLine($"{rows} linhas afetadas");
    }

    private static void LinkPostToTag(SqlConnection connection)
    {
        var rows = new PostRepository(connection).LinkPostToTag(postId: 1, tagId: 2);
        Console.WriteLine($"{rows} linhas afetadas");
    }

    #region lists
    private static void ReadUsersWithRoles(SqlConnection connection)
    {
        var repository = new UserRepository(connection);
        var users = repository.ReadWithRole();

        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }

    private static void ReadCategoriesWithCountPosts(SqlConnection connection)
    {
        var categories = new CategoryRepository(connection).ReadWithPosts();
        foreach (var category in categories)
        {
            Console.WriteLine($"{category.Name} - {category.Posts.Count}");
        }
    }

    private static void ReadTagsWithCountPosts(SqlConnection connection)
    {
        var tags = new TagRepository(connection).ReadTagWithPosts();
        foreach (var tag in tags)
        {
            Console.WriteLine($"{tag.Name} - {tag.Posts.Count}");
        }
    }

    private static void ReadPostWithCategory(SqlConnection connection)
    {
        var posts = new PostRepository(connection).ReadWithCategory();
        foreach (var post in posts)
        {
            Console.WriteLine(post);
        }
    }

    private static void ReadPostWithTags(SqlConnection connection)
    {
        var posts = new PostRepository(connection).ReadWithTags();
        foreach (var post in posts)
        {
            Console.WriteLine($"{post}");
        }
    }

    private static void ReadCategoryWithPosts(SqlConnection connection)
    {
        Category category = new CategoryRepository(connection).ReadWithPosts(categoryId: 1);

        Console.WriteLine(category);
    } 
    #endregion

}