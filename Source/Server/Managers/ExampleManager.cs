using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameServer //Make sure the namespace is exactly GameServer
{
    public static class ExampleManager
    {
        public static void ParsePacket(Packet packet) //This function is the entry point of packets
        {
            ExamplePacket example = Serializer.ConvertBytesToObject<ExamplePacket>(packet.contents); //We use this function to convert our packet into an object
            Logger.Error(example._toLog);
        }

        public static void SendExamplePacket(ExamplePacket data, ServerClient client)
        {
            ModdedData moddedData = new ModdedData(Assembly.GetCallingAssembly().GetName().Name); //We tell the packet what assembly to look for.
            //To target the Rimworld Together assembly, simple put "GameClient or "GameServer"
            Packet packet = Packet.CreatePacketFromObject( //We use this function to create a packet out of an object
                nameof(ExampleManager), //Name of the manager you want to reach on the other side.
                data, //The actual data to pass.
                false, //Should reserve the main thread. This is rarely required.
                moddedData); //By default, if left empty, it will target an assembly with the same name as the current one.
            client.listener.EnqueuePacket(packet); //We send the packet to the client we grabbed earlier
        }
    }
}
