using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SteamBot
{
    public class Command
    {

        string password;
        ICommandProxy proxy;

        public Command(ICommandProxy commandProxy, string password)
        {
            this.password = password;
            proxy = commandProxy;
        }

        public void Listen(IBotRunner runner)
        {
            proxy.Listen(runner);
        }

        static public void HandleCommand(string command, CommandStringHandler handler)
        {
            CommandList.Add(command, handler);
        }

        static public void LoadCommands()
        {
            CommandHandler.Basic.RegisterCommands();
        }

        public void HandleData(Connection connection, Data data)
        {
            if (data.Password == password)
            {
                connection.Authenticated = true;
            }

            CommandStringHandler handler = CommandList[data.Command];

            if (handler != null)
            {
                handler(connection, data);
            }
            else
            {
                connection.commandProxy.HandleError(connection, ErrorCode.ENoCommand);
            }
        }

        public delegate void CommandStringHandler(Connection connection, Data data);

        static Dictionary<string, CommandStringHandler> CommandList = 
            new Dictionary<string, CommandStringHandler>();

        public class Data
        {
            public string Command { get; set; }
            public string[] Arguments { get; set; }
            public string Password { get; set; }
            public string Bot { get; set; }
        }

        public class Response
        {
            public bool Success { get; set; }
            public object Data { get; set; }
        }

        public class Connection
        {
            public ICommandProxy commandProxy { get; set; }
            public dynamic ProxyConnection { get; set; }
            public bool Authenticated { get; set; }
        }

        public enum ErrorCode
        {
            ENoCommand
        }

    }

}
