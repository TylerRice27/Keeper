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

        internal List<Keep> Get(string userId)
        {
            List<Keep> keeps = _repo.Get();
            return keeps;
        }

        internal Keep Get(int id, string userId)
        {
            Keep foundKeep = _repo.Get(id);

            if (foundKeep == null)
            {
                throw new Exception("Invaild Id");
            }
            // if (foundKeep.CreatorId != userId)
            // {
            //     _repo.increaseView(foundKeep);

            // }

            return foundKeep;
        }
        internal Keep Edit(Keep keep)
        {
            Keep original = Get(keep.Id, keep.CreatorId);
            if (keep.CreatorId != original.CreatorId)
            {
                throw new Exception("You can not edit this Keep, You don't own this Keep");
            }

            // original.Views++;
            original.Views = keep.Views ?? original.Views;
            original.Name = keep.Name ?? original.Name;
            original.Description = keep.Description ?? original.Description;
            original.Img = keep.Img ?? original.Img;

            _repo.Edit(original);
            return original;


        }


        internal List<Keep> GetKeepsByCreatorId(string id)
        {
            return _repo.GetAllKeepsByCreatorId(id);
        }

        internal void Delete(int id, string userId)
        {
            Keep foundKeep = Get(id, userId);
            if (userId != foundKeep.CreatorId)
            {
                throw new Exception("You can not delete this keep");

            }

            _repo.Delete(id);
        }
    }
}