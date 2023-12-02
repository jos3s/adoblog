using adoblog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace adoblog.Repositories;

public class TagRepository : Repository<Tag>
{
    public TagRepository(SqlConnection connection) : base(connection)
    {
    }

    public List<Tag> ReadTagWithPosts()
    {
        var query = @"Select * 
                    From Tag
                    INNER JOIN Post ON Post.CategoryId = Tag.Id";


        var tags = new List<Tag>();
        _connection.Query<Tag, Post, Tag>(
            query,
            (tag, post) =>
            {
                var t = tags.Where(x=> x.Id == tag.Id).FirstOrDefault();
                if(t == null)
                {
                    t = tag;
                    tags.Add(t);
                }
                t.Posts.Add(post);

                return tag;
            }, splitOn: "Id" );

        return tags;
    }
}
