using System.ComponentModel.DataAnnotations.Schema;

namespace adoblog.Models;

[Table("[Role]")]
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Name}";
    }
}
