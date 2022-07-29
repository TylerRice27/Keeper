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

        internal Keep Get(int id)
        {
            string sql = "SELECT * FROM keeps WHERE id =@id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }

        internal List<Keep> Get()
        {
            string sql = "SELECT * FROM keeps";
            return _db.Query<Keep>(sql).ToList();
        }

        internal void Edit(Keep original)
        {
            string sql = @"
            UPDATE keeps
            SET 
            name = @Name,
            description = @Description,
            img = @Img
            WHERE id =@Id;";

            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}