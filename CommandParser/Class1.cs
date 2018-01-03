using System;

namespace CommandParser
{
    public class Parser
    {
        char[] splitSymbols = new char[] { '\n', ' ', ',', '\t', '\r' };
        public void Parse(string command){
            command = command.Trim();
            string[] commands = command.Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries);

        }
    }
}
