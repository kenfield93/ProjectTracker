using System;
using System.Collections.Generic;

namespace ProjectTracker
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetCollection();
        void Push(T ele);
        void Put(T ele);
    }
}
