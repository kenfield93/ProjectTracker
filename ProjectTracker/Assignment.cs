using System;
using System.Collections.Generic;
namespace ProjectTracker
{
    /*
     * Invariants to maintain:
     * No null objects in _users. And every assignment needs a task
     */ 
    public class Assignment: IAssignment
    { 
        //TODO think about making this a map for O(1) lookup of employee by id 
        private IList<IUser> _users = new List<IUser>();
        public ITask task { get; }
        public bool isComplete { get; set; }
        public bool isActive { get { return !isComplete; }}
        private int ttl; 
        readonly DateTime assignedDate;
        // need to check that date change is legal ( ex: that day hasn't happened yet) 
        public DateTime dueDate { 
            get => dueDate; 
            set{
                dueDate = value;
                this.CalculateTTL();
            }
        }

        public Assignment(ITask t)
        {
            assignedDate = DateTime.Today;
            isComplete = false;
            task = t;
        }
        public Assignment(ITask t, DateTime d): this(t){
            assignedDate = d;
        }


        public int DaysUntilDue() { return ttl; }
        public void AddUser(IUser user){ if( user != null ) _users.Add(user); }

        public IEnumerable<IUser> GetUsers(){
            return _users;
        }

        public IUser GetUser(IUser u){
            return GetUser(u.uniqueId);
        }
        public IUser GetUser(int id){
            foreach(IUser u in _users){
                if (u.uniqueId == id)
                    return u;
            }
            // TODO think about making NullUser in the future
            // don't see the point right now since IUser is basically just data 
            return null;
        }
        public TaskDescription GetDescription(){
            return task.description;
        }

        bool IsDue(){
            return DateTime.Today >= assignedDate;
        }

        private void CalculateTTL()
        {
            ttl = (dueDate - assignedDate).Days;
        }


    }
}
