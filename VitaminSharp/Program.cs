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
            Champion champ = new Champion();

            switch(ObjectManager.Player.ChampionName.ToLowerInvariant())
            {
                case "tristana":
                    champ = new Tristana();
                    break;
                case "Azir":
                    champ = new Azir();
                    break;
                    
            }
            CustomEvents.Game.OnGameLoad += champ.OnLoad;
        }
    }
}
