using System;
namespace ProjectTracker
{
    public class FileUnitOfWork : IUnitOfWork
    {
        private readonly IAssignmentRepository _assignments;
        private readonly IRepository<ITask> _tasks;
        private readonly IRepository<IUser> _users;

        public FileUnitOfWork( IAssignmentRepository a, IRepository<ITask> t, IRepository<IUser> u)
        {
            _assignments = a;
            _tasks = t;
            _users = u;
        }

        public IAssignmentRepository Assignments
        {
            get { return _assignments; }
        }
        public IRepository<ITask> Tasks 
        {
            get { return _tasks; }
        }
        public IRepository<IUser> Users
        {
            get { return _users;  }
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
