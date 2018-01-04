using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProjectTracker
{
    public class AssignmentManager: IAssignmentCollection
    {
        IDictionary<int, IAssignment> map;
        IUnitOfWork _unitOfWork;
        IAssignmentRepository _repo;

        #region Constructors
        public AssignmentManager(){
            map = new Dictionary<int, IAssignment>();

        }
        public AssignmentManager(IDictionary<int, IAssignment> m){
            map = m;
        }
        public AssignmentManager(IAssignmentRepository r): this(){
            Init(r);
         
        }
        public AssignmentManager(IAssignmentRepository r, IDictionary<int, IAssignment> m){
            map = m;
            Init(r);
        }

        public void Init(IAssignmentRepository r){
            _repo = r;
            var collection = r.GetCollection();
            foreach (IAssignment a in collection)
            {
                this[a.uniqueId] = a;
            }
        }
        #endregion
        public IEnumerator GetEnumerator(){
            return ((IEnumerable)map).GetEnumerator();
        } 

        public IAssignment this[int i]{
            get
            {
                IAssignment a = null;
                map.TryGetValue(i, out a);
                return a;
            }
            set
            {
                map[i] = value;
            }
            
        }

        public IEnumerable<IUser>  getUsersAssignedToTask(ITask t){
            return getUsersAssignedToTask(t.uniqueId);
        }
        public IEnumerable<IUser> getUsersAssignedToTask(int taskId){
            IAssignment a = this[taskId];
            return a.GetUsers();
        }
        public IEnumerable<ITask>  getTasksAssignedToUser(IUser u){
            return getTasksAssignedToUser(u.uniqueId);
        }
        /*
         * TODO: consider add another datastructure for fast lookup. Equivalent to building another index for database
         * or probably better, consider chaning assignments List<IUser> to a hash table to got O(1) look up by id
         */ 
        public IEnumerable<ITask>  getTasksAssignedToUser(int userId){
            IList<ITask> tasks = new List<ITask>();
            foreach( IAssignment ass in map.Values){
                foreach(IUser u in ass.GetUsers()){
                    if (u.uniqueId == userId)
                        tasks.Add(ass.task);
                }   
            }
            return tasks;    
        }
        
        IAssignmentCollection FilterUsers(Func< IAssignment ,bool> cb){

            IDictionary<int, IAssignment> mapOfSubset = (IDictionary<int, IAssignment>)Activator.CreateInstance(map.GetType());
            foreach( var pair in map){
                if (cb(pair.Value)){
                    mapOfSubset.Add(pair.Key, pair.Value);
                }
            }
               return new AssignmentManager(mapOfSubset);
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine("AssignmentManager:");
            foreach( IAssignment a in map.Values ){
                b.Append("\n\t");
                b.Append(a.task.ToString());
                foreach(IUser u in a.GetUsers()){
                    b.Append("\n\t\t");
                    b.Append(u.ToString());
                }
            }
            return b.ToString();
        }
    }
}
