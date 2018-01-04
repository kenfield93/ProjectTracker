using System;
using System.Collections.Generic;
namespace ProjectTracker
{
    public interface IAssignment
    {
        DateTime dueDate { get; set; }
        bool isComplete { get; set; }
        ITask task { get; }
        int uniqueId { get; }
        int  DaysUntilDue();
        void AddUser(IUser u);
        IUser GetUser(IUser u);
        IEnumerable<IUser> GetUsers();
        TaskDescription GetDescription();
    }
}
