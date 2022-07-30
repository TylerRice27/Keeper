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
    }
}