using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class KeepsService
    {

        private readonly KeepsRepository _repo;

        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }

        internal Keep Create(Keep keepData)
        {
            return _repo.Create(keepData);
        }

        internal List<Keep> Get()
        {
            return _repo.Get();
        }
    }
}