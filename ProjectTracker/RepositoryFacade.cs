using System;
using System.Collections.Generic;

namespace ProjectTracker
{
    // TODO: refactor out into Lazy Loader class or design
    public class funcObj<T>{

        public funcObj(Action<T> f, T a){
            func = f;
            arg = a;
        }
        Action<T> func;
		T arg;
        public void Apply() { func(arg); }
    }

    public class RepositoryFacade<T>: IRepository<T>
    {
        
        public RepositoryFacade(IRepository<T> r)
        {
            _repository = r;
        }

        private List<funcObj<T>> funcList = new List<funcObj<T>>();

        private IRepository<T> _repository;
        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<T> GetCollection()
        {
            return _repository.GetCollection();
        }

        public void Push(T ele)
        {
            funcList.Add(new funcObj<T>(_repository.Push, ele));
        }

        public void Put(T ele)
        {
            funcList.Add(new funcObj<T>(_repository.Put, ele));
        }

        public void Commit(){
            foreach(var func in funcList){
                func.Apply();
            }
        }
    }
}
