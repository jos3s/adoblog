using adoblog.Models;
using Dapper;

namespace adoblog.Repositories;

public class CategoryRepository : Repository<Category>
{
    public CategoryRepository() : base()
    {
    }

    public List<Category> ReadWithPosts()
    {
        var query = @"Select *
                    From Category as C
                    Inner Join Post as P on P.CategoryId = C.Id";

        var categories = new List<Category>();

        _connection.Query<Category, Post, Category>(
            query,
            (category, post) =>
            {
                var categ = categories.Where(x => x.Id == category.Id).FirstOrDefault();
                if (categ == null)
                {
                    categ = category;
                    categories.Add(category);
                }
                categ.Posts.Add(post);
                return category;
            }, splitOn: "Id");

        return categories.ToList();
    }

    public Category ReadWithPosts(int categoryId)
    {
        var query = @"SELECT * 
            FROM [Category]
            Where Id = @CategoryId; 
            SELECT * 
            FROM [Post]
            Where CategoryId = @CategoryId";

        using (var multi = _connection.QueryMultiple(query, new { CategoryId = categoryId }))
        {
            var category = multi.Read<Category>();
            var posts = multi.Read<Post>();

            foreach (var item in posts)
            {
                category.FirstOrDefault().Posts.Add(item);
            }
            return category.FirstOrDefault();
        }
    }

}
