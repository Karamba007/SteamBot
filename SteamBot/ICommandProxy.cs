using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamBot
{
    public interface ICommandProxy
    {

        /// <summary>
        /// This can listen on its own thread if it needs to; basically, it
        /// should grab incoming connections and calls 
        /// <see cref="Command.newConnection"/> when it finds a new connection.
        /// 
        /// This also listens for new commands and sends the new command as
        /// a packaged <see cref="Command.Data"/> to command.
        /// </summary>
        /// <param name="botRunner"></param>
        void Listen(IBotRunner botRunner);

        /// <summary>
        /// Handle an error and respond with it.
        /// </summary>
        /// <param name="error"></param>
        void HandleError(Command.Connection connection, Command.ErrorCode error);

        /// <summary>
        /// Send a response to the connection.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="response"></param>
        void SendResponse(Command.Connection connection, Command.Response response);

    }
}
