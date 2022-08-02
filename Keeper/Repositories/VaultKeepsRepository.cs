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
            // vaultKeepData.KeepId++;
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
        internal VaultKeep Get(int id)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE id = @id";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
        }

        internal VaultKeep GetKeeps(int id, string userId)
        {
            string sql = @"
            SELECT * FROM 
            WHERE VaultKeepId = @id AND creatorId = @userId
            ";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id, userId });
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @Id LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}