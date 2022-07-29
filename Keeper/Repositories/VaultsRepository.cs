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
            string sql = @"SELECT
            a.*,
            v.*
            FROM vaults v
            JOIN accounts a ON a.id = v.creatorId;";

            return _db.Query<Profile, Vault, Vault>(sql, (prof, vault) =>
            {
                vault.Creator = prof;
                return vault;
            }).ToList();

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
    }
}