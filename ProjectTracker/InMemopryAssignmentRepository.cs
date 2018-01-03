using System;
using System.Collections.Generic;

namespace ProjectTracker
{
    public class InMemopryAssignmentRepository: IAssignmentRepository
    {
        private IRepository<IUser> _userRepo;
        private IRepository<ITask> _taskRepo;
        private AssignmentManager assignment;
        public InMemopryAssignmentRepository(IRepository<IUser> u, IRepository<ITask> t)
        {
            _userRepo = u;
            _taskRepo = t;
        }

        private void Init(IRepository<IUser> uRepo, IRepository<ITask> tRepo){
            // assignemnt file should have 
            //DateTime dueDate, bool isComplete, ITask task, IE 
        }
        public IRepository<IUser> Users => _userRepo;

        public IRepository<ITask> Tasks => _taskRepo;

        public IAssignment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAssignment> GetCollection()
        {
            throw new NotImplementedException();
        }

        public void Push(IAssignment ele)
        {
            throw new NotImplementedException();
        }

        public void Put(IAssignment ele)
        {
            throw new NotImplementedException();
        }
    }
}
