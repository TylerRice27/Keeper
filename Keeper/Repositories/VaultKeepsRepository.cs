using System.Data;
using Dapper;
using Keeper.Models;

namespace Keeper.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeep Create(VaultKeep vaultKeepData)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (keepId, vaultId, creatorId)
            VALUES
            (@KeepId, @VaultId, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
            vaultKeepData.Id = id;
            return vaultKeepData;
        }
    }
}