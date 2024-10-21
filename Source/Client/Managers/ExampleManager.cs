using Shared;
using System.Reflection;

// MAKE SURE THE NAMESPACE OF THE MANAGERS IS GameClient for the CLIENT

namespace GameClient
{
    public static class ExampleManager
    {
        // This function (ParsePacket) is the one in charge of automatically executing the code that gets sent to your managers
        // In the CLIENT, if must only accept the Packet class as the parameters

        public static void ParsePacket(Packet packet)
        {
            // The Serializer.ConvertBytesToObject(packet.contents) function returns the object that was sent over the network.
            // Make sure you are parsing the correct object that it's expected, otherwise it will throw an exception.
            // In this case, ExampleData is expected so we parse it to that class.

            ExampleData data = Serializer.ConvertBytesToObject<ExampleData>(packet.contents);

            // For testing purposes, we log the content of this specific packet.

            Logger.Warning(data._toLog);
        }

        public static void SendExamplePacket(ExampleData data)
        {
            // We create the packet we want to send using this function.
            // We pass it the manager in charge of it and the data that it needs to carry.

            Packet packet = Packet.CreateModdedPacketFromObject(nameof(ExampleManager), data);

            // Finally, we enqueue it in the listener so it gets automatically sent.

            Network.listener.EnqueuePacket(packet);
        }
    }
}
