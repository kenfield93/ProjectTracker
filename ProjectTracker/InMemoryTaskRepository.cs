using System;
using System.Collections.Generic;

namespace ProjectTracker
{
    public class InMemoryTaskRepository: IRepository<ITask>
    {
        public InMemoryTaskRepository()
        {
        }

        public ITask GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITask> GetCollection()
        {
            throw new NotImplementedException();
        }

        public void Push(ITask ele)
        {
            throw new NotImplementedException();
        }

        public void Put(ITask ele)
        {
            throw new NotImplementedException();
        }
    }
}
