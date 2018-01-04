using System;
using System.Collections.Generic;

namespace ProjectTracker
{
    //TODO need to make clones of everything so we aren't keeping a reference to og object
    // this way we can mock a file or database repository
    public class InMemoryUserRepository : IRepository<IUser>
    {
        
        List<IUser> users = new List<IUser>(){new User(1, new userInfo("kyle ", "enfield", OrgRoles.Engineer)), 
            new User(2, new userInfo("eli", "phelps")), new User( 3, new userInfo("Carlos", "Lopez", OrgRoles.DevOps))};

        public InMemoryUserRepository()
        {}
        public InMemoryUserRepository(List<IUser> u) => users = u;


        public IUser GetById(int id)
        {
            foreach( var u in users) {
                if (u.uniqueId == id) return u;
            }
                
            return null;
        }
        public IEnumerable<IUser> GetCollection()
        {
            return users;
        }

        public void Push(IUser u)
        {
            users.Add(u);
        }
        public void Put(IUser u)
        {
            int indexOf = -1;
            for (int i = 0; i < users.Count; i++){
                if (users[i].uniqueId == u.uniqueId)
                    indexOf = i;
            }
            if (indexOf < 0) return;
            users.RemoveAt(indexOf);
            Push(u);
        }


    }
}
