using System;
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

        internal Vault Get(int id)
        {
            Vault foundVault = _repo.Get(id);
            if (foundVault == null)
            {
                throw new Exception("Invaild Id");
            }

            return foundVault;
        }

        // internal List<Vault> Get(string userId)
        // {
        //     List<Vault> vaults = _repo.Get();
        //     return vaults;

        // }

        internal Vault Create(Vault vaultData)
        {
            return _repo.Create(vaultData);
        }
    }
}