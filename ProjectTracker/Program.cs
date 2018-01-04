using System;

namespace ProjectTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IRepository<IUser> uRepo = new InMemoryUserRepository();
            IRepository<ITask> tRepo = new InMemoryTaskRepository();
            IAssignmentRepository aRepo = new InMemopryAssignmentRepository(uRepo, tRepo);
            AssignmentManager man = new AssignmentManager(aRepo);

            Console.WriteLine(man);

        }
    }
}
