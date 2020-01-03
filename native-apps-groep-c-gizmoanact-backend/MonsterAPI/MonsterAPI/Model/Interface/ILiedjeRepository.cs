using System;
using System.Collections.Generic;
using MonsterAPI.Model.Model_EF;

namespace MonsterAPI.Model.Interface
{
    public interface ILiedjeRepository
    {
        void Add(Liedje liedje);
        void Remove(Liedje liedje);
        IEnumerable<Liedje> GetAll();
        Liedje GetById(long id);
        void saveChanges();
        void Update(Liedje liedje);
        IEnumerable<Liedje> GeefById(long id);
        long geeByTitle(string title);
    }
}
