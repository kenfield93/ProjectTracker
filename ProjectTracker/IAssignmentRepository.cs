using System;
using System.Collections;
namespace ProjectTracker
{
    public interface IAssignmentRepository : IRepository<IAssignment>
    {
        IRepository<IUser> Users { get; }
        IRepository<ITask> Tasks { get; }


    }
}
