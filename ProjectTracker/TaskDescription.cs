using System;
namespace ProjectTracker
{
    public struct TaskDescription
    {
        public TaskDescription(string s) => description = s;
        string description;
        public override string ToString()
        {
            return string.Format( description );
        }
    }


}
