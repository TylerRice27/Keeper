using System;
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

        internal Keep Get(int id)
        {
            Keep foundKeep = _repo.Get(id);
            if (foundKeep == null)
            {
                throw new Exception("Invaild Id");
            }

            return foundKeep;
        }

        internal Keep Edit(Keep keep)
        {
            Keep original = Get(keep.Id);
            original.Name = keep.Name ?? original.Name;
            original.Description = keep.Description ?? original.Description;
            original.Img = keep.Img ?? original.Img;

            _repo.Edit(original);
            return original;


        }

        internal void Delete(int id)
        {
            Keep foundKeep = Get(id);
            _repo.Delete(id);
        }
    }
}