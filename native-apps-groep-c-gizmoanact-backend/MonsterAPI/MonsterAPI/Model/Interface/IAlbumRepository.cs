using System;
using System.Collections.Generic;
using MonsterAPI.Model.Model_EF;

namespace MonsterAPI.Model.Interface
{
    public interface IAlbumRepository
    {
        void Add(Album album);
        void Remove(Album album);
        IEnumerable<Album> GetAll();
        Album GetById(long id);
        void saveChanges();
        void Update(Album album);
    }
}
