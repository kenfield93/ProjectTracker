using System;
namespace ProjectTracker
{
    //Any class that needs needs a repository will use this to get it so we can commit it 
    public interface IUnitOfWork
    {
        
        
        IAssignmentRepository Assignments { get; }
        IRepository<ITask> Tasks { get;  }
        IRepository<IUser> Users { get; }
        void Commit();
        
    }
}
