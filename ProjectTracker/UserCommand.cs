using System;
using System.Collections.Generic;
namespace ProjectTracker
{
    public class UserCommand
    {
        private const string name = "add";
        private List<UserCommand> _commands;
        public UserCommand( List<UserCommand> coms)
        {
            this._commands = coms;
        }

        public void executeCommandPipeLine(){
            UserCommand currCommand = _commands[0];
            _commands.RemoveAt(0);


        }


    }
}
