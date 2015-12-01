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
            Champion tris = new Champion();

            switch(ObjectManager.Player.ChampionName.ToLowerInvariant())
            {
                case "tristana":
                    tris = new Tristana();
                    break;
            }
            CustomEvents.Game.OnGameLoad += tris.OnLoad;
        }
    }
}
