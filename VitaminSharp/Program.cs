using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using VitaminSharp.Base;
using VitaminSharp.Champions;

namespace VitaminSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Tristana tris = new Tristana();
            CustomEvents.Game.OnGameLoad += tris.OnLoad;
        }
    }
}
