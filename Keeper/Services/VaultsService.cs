using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{

    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }

        internal List<Vault> Get(string userId)
        {
            List<Vault> vaults = _repo.Get();
            return vaults;

        }

        internal Vault Create(Vault vaultData)
        {
            return _repo.Create(vaultData);
        }
    }
}