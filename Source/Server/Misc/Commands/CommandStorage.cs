using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
namespace GameServer
{
    public static class CommandStorage
    {
        private static readonly ServerCommand sendTestMessage = new ServerCommand("sendtestpacket", 2, //We make a new command with the name sendtestpacket that takes 2 argument
        "Send a test packet. Takes an user and a message as arguments", //Description
        SendTestMessageAction); //Action to execute

        public static List<ServerCommand> serverCommands = new List<ServerCommand> //All commands in here will be sent to the server when loading your assembly
        {
            sendTestMessage
        };

        public static void SendTestMessageAction() 
        {
            ExamplePacket data = new ExamplePacket(); //We make a new object to put inside our packet
            string username = CommandManager.commandParameters[0]; //We grab the first argument
            data._toLog = CommandManager.commandParameters[1]; //We grab the second argument
            ServerClient client = Network.connectedClients.Where(S => S.userFile.Username == username).FirstOrDefault(); //We check if the user is connected and grab his client
            if (client == null)
            {
                Logger.Error($"Specified user did not exist");
                return;
            }
            ExampleManager.SendExamplePacket(data, client);
        }
    }
}