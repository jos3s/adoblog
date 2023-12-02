using Dapper.Contrib.Extensions;
using System.Text;

namespace adoblog.Models;

[Table("[User]")]
public class User
{
    public User() => Roles = new();

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Bio { get; set; }
    public string Image { get; set; }
    public string Slug { get; set; }
    [Write(false)]
    public List<Role> Roles { get; set; }

    public override string ToString()
    {
        if(Roles.Count == 0)  return $"{Name}, {Email}";

        StringBuilder sb = new StringBuilder();
        sb.Append($"{Name}, {Email}");
        foreach (Role role in Roles)
        {
            sb.Append($", {role.ToString()}");
        }
        return sb.ToString();
    }
}
