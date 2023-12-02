using Dapper.Contrib.Extensions;
using System.Text;

namespace adoblog.Models;

[Table("Post")]
public class Post
{
    public Post()
    {
        Tags = new();
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Body { get; set; }
    public string Slug { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public Category Category { get; set; }
    public User Author { get; set; }
    public List<Tag> Tags { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{Title}");
        if (Category != null)
            sb.Append($" {Category?.Id}-{Category?.Name}");

        if(Tags.Count > 0)
        {
            sb.Append(" [");
            for (int i = 0; i < Tags.Count; i++)
            {
                sb.Append($"{Tags[i]}{(i < Tags.Count-1 ? ", " : "")}");
            }
            sb.Append(']');
        }
        return sb.ToString();
    }
}
