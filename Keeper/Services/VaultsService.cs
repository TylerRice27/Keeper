using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{

    public class VaultsService
    {

        private readonly AccountService _acs;

        private readonly VaultsRepository _repo;

        public VaultsService(AccountService acs, VaultsRepository repo)
        {
            _acs = acs;
            _repo = repo;
        }

        internal List<Vault> Get(string userId)
        {
            List<Vault> foundVaults = _repo.Get();
            // if (foundVault == null)
            // {
            //     throw new Exception("Invaild Id");
            // }

            return foundVaults.FindAll(v => v.IsPrivate == true || v.CreatorId == userId);
        }

        internal Vault Get(int id)
        {
            Vault found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid ID");
            }
            return found;
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

        internal Vault Edit(Vault vault)
        {
            Vault original = Get(vault.Id);
            original.Name = vault.Name ?? original.Name;
            original.Description = vault.Description ?? original.Description;
            original.IsPrivate = vault.IsPrivate ?? original.IsPrivate;

            _repo.Edit(original);
            return original;
        }

        internal void Delete(int id)
        {
            Vault foundVault = Get(id);
            _repo.Delete(id);
        }

        internal List<Vault> GetMyVaults(string accountId)
        {
            _acs.GetProfileById(accountId);
            return _repo.GetMyVaults(accountId);
        }

        internal List<Vault> GetVaultsByCreatorId(string id)
        {
            return _repo.GetAllVaultsByCreatorId(id);
        }
    }
}