using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MonsterAPI.Model.Interface;
using MonsterAPI.Model.Model_EF;

namespace MonsterAPI.Data.Repositories

{
    public class LiedjeRepository : ILiedjeRepository
    {

        private readonly DbSet<Liedje> _liedjes;
        private readonly DbContext _context;

        public LiedjeRepository(ApplicationDBContext context)
        {
            _context = context;
            _liedjes = context.Liedjes;
        }

        public void Add(Liedje liedje)
        {
            _liedjes.Add(liedje);
        }

        public IEnumerable<Liedje> GetAll()
        {
            return _liedjes.ToList();
        }

        public Liedje GetById(long id)
        {
            return _liedjes.FirstOrDefault(l => l.ID == id);
        }
        public IEnumerable<Liedje> GeefById(long id)
        {
            Liedje hier = GetById(id);
            return _liedjes.Where(l => l.genre == hier.genre && l.taal == hier.taal && l.ID != id).Take(3).ToList();
        }

        public void Remove(Liedje liedje)
        {
            _liedjes.Remove(liedje);
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Liedje liedje)
        {
            _liedjes.Update(liedje);
        }
        public long geeByTitle(string title)
        {
            return _liedjes.Where(l => l.title.Equals(title)).FirstOrDefault().ID;
        }
    }
}
