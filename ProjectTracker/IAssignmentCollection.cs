using System.Collections;

namespace ProjectTracker
{
    public interface IAssignmentCollection: IEnumerable
    {
        void Init(IAssignmentRepository a); 
    }
}