using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace adoblog.Repositories;

public class Repository<TModel> where TModel : class
{
    protected readonly SqlConnection _connection;

    public Repository() => _connection = Database.Connection;

    public List<TModel> Get() => (List<TModel>)_connection.GetAll<TModel>();

    public TModel Get(int id) => _connection.Get<TModel>(id);

    public void Create(TModel model) => _connection.Insert(model);

    public void Update(TModel model) => _connection.Update(model);

    public void Delete(int id)
    {
        if (id == 0) return;

        TModel model = _connection.Get<TModel>(id);
        _connection.Delete(model);
    }

    public void Delete(TModel entity)
    {
        _connection.Delete(entity);
    }
}
