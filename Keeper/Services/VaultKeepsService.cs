using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class VaultKeepsService
    {
        private readonly VaultsRepository _vr;

        private readonly KeepsRepository _kr;
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultsRepository vr, KeepsRepository kr, VaultKeepsRepository repo)
        {
            _vr = vr;
            _kr = kr;
            _repo = repo;
        }

        internal VaultKeep Create(VaultKeep vaultKeepData, string userId)
        {

            Vault vault = _vr.Get(vaultKeepData.VaultId);
            // if (true)
            // {

            // }


            Keep keep = _kr.Get(vaultKeepData.KeepId);

            _kr.increaseKept(keep);



            if (vault.CreatorId != userId)
            {
                throw new Exception("You can not create a keep within this Vault");
            }


            return _repo.Create(vaultKeepData);

        }

        internal List<VaultKeepViewModel> GetByVaultId(int id, string userId)
        {

            Vault vaults = _vr.Get(id);

            List<VaultKeepViewModel> keeps = _repo.GetByVaultId(id);

            if (vaults == null)
            {
                throw new Exception("keep not found");
            }
            if (vaults.IsPrivate && vaults.CreatorId != userId)
            {
                throw new Exception("This is Private");

            }
            return keeps;

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
            Keep keep = _kr.Get(found.KeepId);
            _kr.decreaseKept(keep);
            _repo.Delete(id);



        }


    }
}