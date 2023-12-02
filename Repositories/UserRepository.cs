using adoblog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace adoblog.Repositories;

public class UserRepository : Repository<User>
{
    public UserRepository(SqlConnection connection) : base(connection)
    {
    }

    public List<User> ReadWithRole()
    {
        var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

        var users = new List<User>();
        _connection.Query<User, Role, User>(
            query,
            (user, role) =>
            {
                var usr = users.FirstOrDefault(x => x.Id == user.Id);
                if (usr == null)
                {
                    usr = user;
                    users?.Add(usr);
                }
                if (role != null)
                    usr?.Roles.Add(role);

                return user;
            }, splitOn: "Id");
        return users;
    }

    public int LinkUserToRole(int userId, int roleId)
    {
        var query = @"Insert Into UserRole Values(@userId, @roleId)";

        return _connection.Execute(query, new { userId, roleId });
    }
}


#region OldUserRepository
//public class UserRepository
//{
//    private readonly SqlConnection _connection;

//    public UserRepository(SqlConnection connection)
//    {
//        _connection = connection;
//    }

//    public List<User> Get() => (List<User>)_connection.GetAll<User>();

//    public User Get(int id) => _connection.Get<User>(id);

//    public void Create(User user) => _connection.Insert(user);

//    public void Update(User user) => _connection.Update(user);

//    public void Delete(int id)
//    {
//        if (id == 0) return;

//        User user = _connection.Get<User>(id);
//        _connection.Delete<User>(user);
//    }

//    public void Delete(User user)
//    {
//        if (user.Id != 0)
//            _connection.Delete<User>(user);
//    }
//}
#endregion