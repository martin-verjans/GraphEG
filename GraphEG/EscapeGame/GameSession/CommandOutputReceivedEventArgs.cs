using System;

namespace GraphEG.EscapeGame.GameSession
{
    public class CommandOutputReceivedEventArgs : EventArgs
    {
        public string Command { get; }
        public string Output { get; }
        public CommandOutputReceivedEventArgs(string command, string output)
        {
            Command = command;
            Output = output;
        }
    }
}
