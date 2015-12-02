using System;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using System.Linq;
using VitaminSharp.Base;

namespace VitaminSharp.Champions
{
    class Azir
        :Champion
    {
        public override void OnLoad(EventArgs args)
        {
            name = "Azir";

            Q = new Spell(SpellSlot.Q, 810f);
            W = new Spell(SpellSlot.W, 530f);
            E = new Spell(SpellSlot.E, 1200f);
            R = new Spell(SpellSlot.R, 260f);



            Game.PrintChat("<font color = \"##00D8FF\"> [VlitaminSharp] " + name + " Made by kywooo </font> Korean ");
            Game.PrintChat("<font color = \"##00D8FF\"> [VlitaminSharp] " + name + " Good luck! </font>");

            Init();
            OnMenu();

        }

        public override void OnMenu()
        {
            menu.SubMenu(name).SubMenu("Combo").AddItem(new MenuItem("ComboQ", "UseQ", true).SetValue(true));
            menu.SubMenu(name).SubMenu("Combo").AddItem(new MenuItem("ComboW", "UseW", true).SetValue(false));
            menu.SubMenu(name).SubMenu("Combo").AddItem(new MenuItem("ComboE", "UseE", true).SetValue(true));
            menu.SubMenu(name).SubMenu("Combo").AddItem(new MenuItem("ComboR", "UseR", true).SetValue(true));

            menu.SubMenu(name).SubMenu("Harass").AddItem(new MenuItem("HarassQ", "UseQ", true).SetValue(true));
            menu.SubMenu(name).SubMenu("Harass").AddItem(new MenuItem("HarassE", "UseE", true).SetValue(true));

            menu.SubMenu(name).SubMenu("LaneClear").AddItem(new MenuItem("LaneClearQ", "UseQ", true).SetValue(false));
            menu.SubMenu(name).SubMenu("LaneClear").AddItem(new MenuItem("LaneClearW", "UseW", true).SetValue(false));
            menu.SubMenu(name).SubMenu("LaneClear").AddItem(new MenuItem("LaneClearE", "UseE", true).SetValue(false));

            menu.SubMenu(name).SubMenu("JungleClear").AddItem(new MenuItem("JungleClearQ", "UseQ", true).SetValue(true));
            menu.SubMenu(name).SubMenu("JungleClear").AddItem(new MenuItem("JungleClearE", "UseE", true).SetValue(true));

            menu.SubMenu(name).SubMenu("Creadits : kywooo");


            menu.AddToMainMenu();

            var movingMenu = new Menu("OrbWalker", "orbWalker", true);
            moving = new Orbwalking.Orbwalker(movingMenu);
            menu.AddSubMenu(movingMenu);

            var TargetMenu = new Menu("TargetSelector", "targetselector", true);
            TargetSelector.AddToMenu(TargetMenu);
            menu.AddSubMenu(TargetMenu);
        }

        public override void OnUpdate()
        {

        }

        public override void OnDraw()
        {

        }

        protected override void OnCombo()
        {

        }

        protected override void OnHarass()
        {
        
        }

    }
}
