using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MonsterAPI.Model.Interface;
using MonsterAPI.Model.Model_EF;

namespace MonsterAPI.Data.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly DbSet<Album> _albums;
        private readonly DbContext _context;

        public AlbumRepository(ApplicationDBContext context)
        {
            _context = context;
           // _albums = context.Albums;
        }

        public void Add(Album album)
        {
            _albums.Add(album);
        }

        public IEnumerable<Album> GetAll()
        {
            return _albums.ToList();
        }

        public Album GetById(long id)
        {
            return _albums.FirstOrDefault(a => a.ID == id);
        }

        public void Remove(Album album)
        {
            _albums.Remove(album);
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Album album)
        {
            _albums.Update(album);
        }
    }
}
