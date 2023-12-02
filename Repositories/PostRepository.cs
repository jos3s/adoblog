using adoblog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace adoblog.Repositories
{
    internal class PostRepository : Repository<Post>
    {
        public PostRepository(SqlConnection connection) : base(connection)
        {
        }

        public List<Post> ReadWithCategory()
        {
            var query = @"Select  
                            Post.* ,
                            c.Id,
                            [c].Name
                        from Post 
	                    inner join Category as c on c.Id = Post.CategoryId";

            var posts = _connection.Query<Post, Category, Post>(
                query,
                (post, category) =>
                {
                    post.Category = category;
                    return post;
                }, splitOn: "Id");
            return posts.ToList();
        }

        public List<Post> ReadWithTags()
        {
            var query = @"SELECT * 
                        FROM Post
                        INNER JOIN PostTag ON PostTag.PostId = Post.Id
                        INNER JOIN Tag ON Tag.Id = PostTag.TagId";

            var posts = new List<Post>();
            _connection.Query<Post, Tag, Post>(
                query,
                (post, tag) =>
                {
                    var pos = posts.Where(x=>x.Id == post.Id).FirstOrDefault();
                    if(pos == null)
                    {
                        pos = post;
                        posts.Add(pos);
                    }
                    pos.Tags.Add(tag);
                    return post;
                }, splitOn: "Id");
            return posts.ToList();
        }

        public int LinkPostToTag(int postId, int tagId)
        {
            var query = @"Insert Into PostTag Values(@postId, @tagId)";

            return _connection.Execute(query, new { postId, tagId });
        }
    }
}
