using System;
using System.Collections.Generic;
using MonsterAPI.Model.Model_EF;

namespace MonsterAPI.Model.Interface
{
    public interface IArtistRepository
    {
        void Add(Artist artist);
        void Remove(Artist artist);
        IEnumerable<Artist> GetAll();
        IEnumerable<Artist> GetGroeps();
        Artist GetById(long id);
        void saveChanges();
        void Update(Artist artist);
    }
}
