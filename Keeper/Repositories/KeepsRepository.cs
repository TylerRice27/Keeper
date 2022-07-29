using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keeper.Models;

namespace Keeper.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Keep Create(Keep keepData)
        {
            string sql = @"
          INSERT INTO keeps
          (name, description, img, creatorId)
          VALUES
          (@Name, @Description, @Img, @CreatorId);  
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, keepData);
            keepData.Id = id;
            return keepData;

        }

        internal List<Keep> Get()
        {
            string sql = "SELECT * FROM keeps";
            return _db.Query<Keep>(sql).ToList();
        }
    }
}