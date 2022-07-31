using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class VaultKeepsService
    {
        private readonly VaultsRepository _vr;
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultsRepository vr, VaultKeepsRepository repo)
        {
            _vr = vr;
            _repo = repo;
        }

        internal VaultKeep Create(VaultKeep vaultKeepData)
        {
            // VaultKeep exists = _repo.Create(vaultKeepData);
            // if (exists != null)
            // {
            //     return exists;
            // }
            // if (vaultKeepData.CreatorId != userId)
            // {
            //     throw new Exception("You can not create a keep within this Vault");
            // }
            return _repo.Create(vaultKeepData);
        }

        internal List<VaultKeepViewModel> GetByVaultId(int id, string userId)
        {

            // Vault vaults = _vr.Get(id);

            // List<VaultKeepViewModel> keeps = _repo.GetByVaultId(id);
            // VaultKeep vk = _repo.GetByVaultId(id);

            // return keeps.FindAll(k => k.VaultKeepId && vaults.IsPrivate == false || k.CreatorId == userId);
            // if (keeps == null)
            // {
            //     throw new Exception("Invalid ID");
            // }
            // if (keeps. != userId)
            // {
            //     throw new Exception("This is Private");

            // }


            // return keeps;




            return _repo.GetByVaultId(id);
        }

        internal void Delete(int id, string userId)
        {
            VaultKeep found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");

            }
            if (found.CreatorId != userId)
            {
                throw new Exception("Invalid Access");

            }
            _repo.Delete(id);
        }


    }
}