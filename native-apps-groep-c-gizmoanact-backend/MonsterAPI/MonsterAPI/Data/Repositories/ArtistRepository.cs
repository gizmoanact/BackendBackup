using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MonsterAPI.Model.Interface;
using MonsterAPI.Model.Model_EF;

namespace MonsterAPI.Data.Repositories

{
    public class ArtistRepository : IArtistRepository
    {

        private readonly DbSet<Artist> _artists;
        private readonly DbContext _context;

        public ArtistRepository(ApplicationDBContext context)
        {
            _context = context;
            _artists = context.Artisten;
        }

        public void Add(Artist artist)
        {
            _artists.Add(artist);
        }

        public IEnumerable<Artist> GetAll()
        {
            return _artists.ToList();
        }

        public Artist GetById(long id)
        {
            return _artists.FirstOrDefault(a => a.ID == id);
        }

        public IEnumerable<Artist> GetGroeps()
        {
            return _artists.Where(a => a.groep.Equals("true")).ToList();
        }

        public void Remove(Artist artist)
        {
            _artists.Remove(artist);
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Artist artist)
        {
            _artists.Update(artist);
        }
    }
}
