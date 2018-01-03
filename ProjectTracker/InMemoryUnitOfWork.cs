using System;
namespace ProjectTracker
{
    public class InMemoryUnitOfWork: IUnitOfWork
    {
        //Figure out how to do commit. For in memory maybe just implement Command pattern 
        // need something like lazy loading

        public InMemoryUnitOfWork()
        {
        }


        public IAssignmentRepository Assignments => throw new NotImplementedException();

        public IRepository<ITask> Tasks { get; } = new RepositoryFacade<ITask>(new InMemoryTaskRepository());

        public IRepository<IUser> Users { get; } = new RepositoryFacade<IUser>( new InMemoryUserRepository());

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
