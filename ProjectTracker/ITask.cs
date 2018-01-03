using System;
namespace ProjectTracker
{
    public interface ITask
    {
        TaskDescription description{ 
            get; set;
        }
        int uniqueId{
            get;
        }
  
    }

    
    }
    
}
