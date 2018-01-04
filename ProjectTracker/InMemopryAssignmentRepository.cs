using System;
using System.Collections.Generic;

namespace ProjectTracker
{

    public class InMemopryAssignmentRepository: IAssignmentRepository
    {
        private IRepository<IUser> _userRepo;
        private IRepository<ITask> _taskRepo;
        private List<IAssignment> ass;


        public InMemopryAssignmentRepository(IRepository<IUser> u, IRepository<ITask> t)
        {
            
            _userRepo = u;
            _taskRepo = t;
            ass = new List<IAssignment>(){
                new Assignment( new Task(1, new TaskDescription("fixing a fence")), DateTime.Now, new List<IUser>(){
                    new User(1, new userInfo("kyle", "enfield")), new User(2, new userInfo("eli", "phelps") )
                }),
                new Assignment( new Task(2, new TaskDescription("doing something")), DateTime.Now, new List<IUser>(){
                    new User(1, new userInfo("kyle", "enfield")), new User(3, new  userInfo("jim", "bob") )
                })
            };
        }


        public IRepository<IUser> Users => _userRepo;

        public IRepository<ITask> Tasks => _taskRepo;

        public IAssignment GetById(int id)
        {
            foreach(var a in ass){
                if (a.uniqueId == id)
                    return a;
            }
            return null;
        }

        public IEnumerable<IAssignment> GetCollection()
        {
            return ass;
        }

        public void Push(IAssignment ele)
        {
            ass.Add(ele);
        }

        public void Put(IAssignment ele)
        {
            for (var i = 0; i < ass.Count; i++){
                if (ass[i].uniqueId == ele.uniqueId)
                    ass[i] = ele;
            }
        }
    }
}
