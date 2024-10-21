using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    [RTStartup] //Entry point
    public static class Main 
    {
        static Main()
        {
            Logger.Warning($"Your custom assembly {Assembly.GetExecutingAssembly().GetName().Name} was loaded!");
        }
    }
}
