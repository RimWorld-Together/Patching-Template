using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient //Make sure the namespace is exactly GameClient
{
    public static class ExampleManager
    {
        public static void ParsePacket(Packet packet)  //This function is the entry point of any packets.
        {
            ExamplePacket example = Serializer.ConvertBytesToObject<ExamplePacket>(packet.contents); //We use this function to convert our packet into an object
            Logger.Error(example._toLog);
        }
    }
}
