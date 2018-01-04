using System;
namespace ProjectTracker
{
    public class Task: ITask
    {
        private int _id;
        public Task(int id)
        {
            _id = id;
        }
        public Task(int id, TaskDescription td): this(id){
            description = td;
        }

        public TaskDescription description { get; set; }

        public int uniqueId => _id;

        public override string ToString()
        {
            return string.Format("Task: {0}", description);
        }
    }
}
