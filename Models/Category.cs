using Dapper.Contrib.Extensions;
using System.Data;
using System.Text;

namespace adoblog.Models;

[Table("Category")]
public class Category
{
    public Category()
    {
        Posts = new();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }

    [Write(false)]
    public List<Post> Posts { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{Name}");
        foreach (var post in Posts)
        {
            sb.AppendLine($"- {post.ToString()}");
        }
        return sb.ToString();
    }
}
