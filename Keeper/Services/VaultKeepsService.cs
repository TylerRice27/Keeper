using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        internal VaultKeep Create(VaultKeep vaultKeepData)
        {
            return _repo.Create(vaultKeepData);
        }

        internal List<VaultKeepViewModel> GetByVaultId(int id)
        {
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