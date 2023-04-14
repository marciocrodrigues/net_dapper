using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Blog.Repositories
{
    public class Repository<TModel> where TModel : BaseModel
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
            => _connection = connection;

        public IEnumerable<TModel> Get()
            => _connection.GetAll<TModel>();

        public TModel GetById(int id)
            => _connection.Get<TModel>(id);

        public void Create(TModel tModel)
        {
            tModel.Id = 0;
            _connection.Insert<TModel>(tModel);
        }

        public void Update(int id, TModel tModel)
        {
            if (tModel.Id != 0)
            {
                _connection.Update<TModel>(tModel);
            }
        }

        public void Delete(int id)
        {
            if (id == 0)
                return;

            var tModel = _connection.Get<TModel>(id);
            _connection.Delete<TModel>(tModel);
        }
    }
}
