using GameServer;
using ServerPatch;
using Shared;

namespace ServerPatch
{
    // MAKE SURE THIS CLASS IS ALWAYS NAMED 'CommandStorage'.

    public static class CommandStorage
    {
        // We make a new command with the name "sendtestpacket" that takes 2 arguments.
        // The function "SendTestMessageAction" will be executed as the command action.

        private static readonly ServerCommand sendTestMessageCommand = new ServerCommand("sendtestpacket", 2, 
            "Send a test packet. Takes an user and a message as arguments",
            SendTestMessageAction);

        // MAKE SURE THIS FIELD IS ALWAYS NAMED 'serverCommands'.
        // All commands listed in here will be added to the server the moment the assembly loads.

        public static readonly List<ServerCommand> serverCommands = new List<ServerCommand>
        {
            sendTestMessageCommand
        };

        // This is the action that the "sendtestpacket" command will execute.

        public static void SendTestMessageAction() 
        {
            // We make a new "ExampleData" instance to put inside our packet.

            ExampleData data = new ExampleData();

            // We grab the first argument passed by the command.

            string username = CommandManager.commandParameters[0]; 

            // We grab the second argument passed by the command.

            data._toLog = CommandManager.commandParameters[1];

            // In this case, since we need a client for this command, we search it and send the command if found.

            ServerClient toFind = NetworkHelper.GetConnectedClientFromUsername(username);
            if (toFind == null) Logger.Error($"User '{username}' did not exist");
            else ExampleManager.SendExamplePacket(data, toFind);
        }
    }
}