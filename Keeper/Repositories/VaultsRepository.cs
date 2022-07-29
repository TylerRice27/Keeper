using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keeper.Models;

namespace Keeper.Repositories
{
    public class VaultsRepository
    {

        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Vault> Get()
        {
            string sql = "SELECT * FROM vaults";
            return _db.Query<Vault>(sql).ToList();

        }
    }
}