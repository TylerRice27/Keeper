using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        internal List<VaultKeepViewModel> GetByVaultId(int id)
        {
            string sql = @"
            SELECT
            a.*,
            k.*,
            vk.id AS VaultKeepId
            FROM vaultkeeps vk
            JOIN keeps k on k.id = vk.keepId
            JOIN accounts a ON a.id = vk.creatorId
            WHERE vk.vaultId = @id
            ";
            return _db.Query<Profile, VaultKeepViewModel, VaultKeepViewModel>(sql, (prof, vkvkm) =>
            {
                vkvkm.Creator = prof;
                return vkvkm;
            }, new { id }).ToList();
        }



    }
}