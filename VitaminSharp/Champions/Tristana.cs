using System;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using System.Linq;
using VitaminSharp.Base;

namespace VitaminSharp.Champions
{
    class Tristana
        :Champion
    {
        public override void OnLoad(EventArgs args)
        {
            name = "Tristana";

            Q = new Spell(SpellSlot.Q, 703f);
            W = new Spell(SpellSlot.W, 900f);
            E = new Spell(SpellSlot.E, 703f);
            R = new Spell(SpellSlot.R, 703f);

            W.SetSkillshot(50.0f, 260.0f, 1400.0f, false, SkillshotType.SkillshotCircle);

            Game.PrintChat("<font color = \"##00D8FF\"> [VlitaminSharp] " + name + " Made by kywooo </font> Korean ");
            Game.PrintChat("<font color = \"##00D8FF\"> [VlitaminSharp] " + name + " Good luck! </font>");
            Init();
            OnMenu();
        }

        public override void OnMenu()
        {
            var movingMenu = new Menu("OrbWalker", "orbWalker",true);
            moving = new Orbwalking.Orbwalker(movingMenu);
            menu.AddSubMenu(movingMenu);

            var TargetMenu = new Menu("TargetSelector", "targetselector", true);
            TargetSelector.AddToMenu(TargetMenu);
            menu.AddSubMenu(TargetMenu);


            menu.SubMenu(name).SubMenu("Combo").AddItem(new MenuItem("ComboQ", "UseQ", true).SetValue(true));
            menu.SubMenu(name).SubMenu("Combo").AddItem(new MenuItem("ComboW", "UseW", true).SetValue(false));
            menu.SubMenu(name).SubMenu("Combo").AddItem(new MenuItem("ComboE", "UseE", true).SetValue(true));
            menu.SubMenu(name).SubMenu("Combo").AddItem(new MenuItem("ComboR", "UseR", true).SetValue(true));

            menu.SubMenu(name).SubMenu("Harass").AddItem(new MenuItem("HarassQ", "UseQ", true).SetValue(true));
            menu.SubMenu(name).SubMenu("Harass").AddItem(new MenuItem("HarassE", "UseE", true).SetValue(true));

            menu.SubMenu(name).SubMenu("LaneClear").AddItem(new MenuItem("LaneClearQ", "UseQ", true).SetValue(false));
            menu.SubMenu(name).SubMenu("LaneClear").AddItem(new MenuItem("LaneClearE", "UseE", true).SetValue(false));

            menu.SubMenu(name).SubMenu("JungleClear").AddItem(new MenuItem("JungleClearQ", "UseQ", true).SetValue(true));
            menu.SubMenu(name).SubMenu("JungleClear").AddItem(new MenuItem("JungleClearE", "UseE", true).SetValue(true));

            menu.SubMenu(name).SubMenu("Creadits : kywooo");


            menu.AddToMainMenu();
        }

        public override void OnUpdate()
        {

        }

        public override void OnDraw()
        {

        }

        #region Events
        protected override void OnCombo(bool UseQ, bool UseW, bool UseE, bool UseR)
        {
            var targeting = TargetSelector.GetTarget(E.Range, TargetSelector.DamageType.Physical);

            if(targeting == null || targeting.IsValidTarget())
            {
                return;
            }

            if(Q.IsReady() && UseQ)
            {
                Q.Cast();
            }

        }

        protected override void OnHarass(bool UseQ, bool UseE)
        {
            if (Q.IsReady() && UseQ)
            {
                Q.Cast();
            }
        }

        protected override void OnLaneClear(bool UseQ, bool UseE)
        {
            

            if(Q.IsReady() && UseQ)
            {
                Q.Cast();
            }
        }

        protected override void OnLastHit()
        {

        }
        #endregion
    }
}
