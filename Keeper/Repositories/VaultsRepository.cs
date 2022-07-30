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

        internal Vault Get(int id)
        {
            string sql = @"
            SELECT
            a.*,
            v.*
            FROM vaults v
            JOIN accounts a ON a.id = v.creatorId
            WHERE v.id = @id";

            return _db.Query<Profile, Vault, Vault>(sql, (prof, vault) =>
            {
                vault.Creator = prof;
                return vault;
            }, new { id }).FirstOrDefault();

        }


        internal Vault Create(Vault vaultData)
        {
            string sql = @"
           INSERT INTO vaults
           (name, description, isPrivate, creatorId)
           VALUES
           (@Name, @Description, @IsPrivate, @CreatorId);
           SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, vaultData);
            vaultData.Id = id;
            return vaultData;
        }

        internal void Edit(Vault original)
        {
            string sql = @"
            UPDATE vaults
            SET
            name = @Name,
            description = @Description,
            isPrivate = @IsPrivate
            WHERE id =@Id;";

            _db.Execute(sql, original);
        }

        internal List<Vault> GetAllVaultsByCreatorId(string id)
        {
            string sql = @"
            SELECT v.*,
            a.*
            FROM vaults v
            JOIN accounts a ON a.id = v.creatorId
            WHERE creatorId = @id";

            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;

                return vault;
            }, new { id }).ToList();
        }

        internal List<Vault> GetMyVaults(string creatorId)
        {
            string sql = @"
            SELECT
            v.*,
            a.*
            FROM vaults v
            JOIN accounts a ON a.id = v.creatorId
            WHERE v.creatorId = @creatorId
            ";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, prof) =>
            {
                vault.Creator = prof;
                return vault;

            }, new { creatorId }).ToList();
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}