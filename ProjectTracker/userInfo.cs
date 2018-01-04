using System;

namespace ProjectTracker
{

    public struct userInfo
    {
        
        string firstName { get; set; }
        string lastName { get; set; }
        OrgRoles role { get; set; } 

 
        public userInfo( string fN, string lN) {
            firstName = fN; lastName = lN;
            role = OrgRoles.Default;
        }
        public userInfo(string fN, string lN, OrgRoles r): this( fN, lN){
            role = r;    
        }

        public override string ToString()
        {
            return string.Format(firstName + lastName);
        }

    }
}
