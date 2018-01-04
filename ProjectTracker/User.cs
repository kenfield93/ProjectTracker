using System;
namespace ProjectTracker
{
    public  class User: IUser
    {
        int _uniqueId;
        userInfo _info;

        public User(int id, userInfo u)
        {
            _uniqueId = id;
            _info = u;
        }

        public int uniqueId => _uniqueId;
        public override string ToString()
        {
            return string.Format("User: {0} ", _info.ToString());
        }
    }
}
