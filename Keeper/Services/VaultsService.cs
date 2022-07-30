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

        private readonly KeepsRepository _kr;

        private readonly VaultKeepsRepository _vksRepo;

        public VaultsService(AccountService acs, VaultsRepository repo, KeepsRepository kr, VaultKeepsRepository vksRepo)
        {
            _acs = acs;
            _repo = repo;
            _kr = kr;
            _vksRepo = vksRepo;
        }




        // internal List<Vault> Get()
        // {
        //     List<Vault> foundVault = _repo.Get();
        //     if (foundVault == null)
        //     {
        //         throw new Exception("Invaild Id");
        //     }

        //     // foundVaults.FindAll(v => v.IsPrivate == false);
        //     return foundVault;
        // }

        internal Vault Get(int id)
        {
            Vault found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid ID");
            }
            return found;
        }

        internal Vault GetPrivateVaults(int id, string userId)
        {
            Vault found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid ID");
            }
            if (found.IsPrivate && found.CreatorId != userId)
            {
                // Keep keep = _kr.Get(id, userId);

                // VaultKeep vaultKeep = _vksRepo.GetKeeps(id, userId);

                // if (keep == null)
                // {

                throw new Exception("This is Private");
                // }

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
            if (vault.CreatorId != original.CreatorId)
            {
                throw new Exception("You can not edit this Vault, You don't own this Vault");
            }
            original.Name = vault.Name ?? original.Name;
            original.Description = vault.Description ?? original.Description;
            // original.IsPrivate = vault.IsPrivate ?? original.IsPrivate;

            _repo.Edit(original);
            return original;
        }

        internal void Delete(int id, string userId)
        {
            Vault foundVault = Get(id);
            if (userId != foundVault.CreatorId)
            {
                throw new Exception("You can not delete this Vault");

            }
            _repo.Delete(id);
        }

        internal List<Vault> GetMyVaults(string accountId)
        {
            _acs.GetProfileById(accountId);
            return _repo.GetMyVaults(accountId);
        }

        internal List<Vault> GetVaultsByCreatorId(string id)
        {


            List<Vault> found = _repo.GetAllVaultsByCreatorId(id);


            return found.FindAll(f => f.IsPrivate == false);
        }
    }
}