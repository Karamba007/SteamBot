using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamBot.CommandHandler
{
    static class Basic : ICommandHandler
    {

        static public void GiveName(Command.Connection connection, Command.Data data)
        {

        }

        static public void RegisterCommands() 
        {
            Command.HandleCommand("whoami", new Command.CommandStringHandler(GiveName));
        }

    }
}
