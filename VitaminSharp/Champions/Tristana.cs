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

            W.SetSkillshot(50.0f, 260.0f, 1400.0f, true, SkillshotType.SkillshotCircle);

            Game.PrintChat("<font color = \"##00D8FF\"> [VlitaminSharp] " + name + " Made by kywooo </font> Korean ");
            Game.PrintChat("<font color = \"##00D8FF\"> [VlitaminSharp] " + name + " Good luck! </font>");

            //moving = new Orbwalking.Orbwalker(menu.SubMenu(name).AddSubMenu(
            //    new Menu("Orbwalker", "Orbwalker", true)));

            //TargetSelector.AddToMenu(menu.SubMenu(name).AddSubMenu(
            //    new Menu("Target Selector", "Target Selector", true)));

            Init();
            OnMenu();
        }

        public override void OnMenu()
        {


            menu.AddToMainMenu();

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

            var movingMenu = new Menu("OrbWalker", "orbWalker", true);
            moving = new Orbwalking.Orbwalker(movingMenu);
            menu.SubMenu(name).AddSubMenu(movingMenu);

            var TargetMenu = new Menu("TargetSelector", "targetselector", true);
            TargetSelector.AddToMenu(TargetMenu);
            menu.SubMenu(name).AddSubMenu(TargetMenu);


        }

        public override void OnUpdate()
        {
           
        }

        public override void OnDraw()
        {

        }

        #region Events
        protected override void OnCombo()
        {
            var Targets = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical);

            var Target_E = moving.GetTarget();

            //var Target_R = moving.GetTarget();

            if(Targets == null || !Targets.IsValidTarget())
            {
                return;
            }

            if(menu.Item("ComboQ",true).GetValue<bool>())
            {
                if(Q.IsReady() && Targets.IsValidTarget(Q.Range))
                {
                    Q.Cast();
                }
            }
            
            if(menu.Item("ComboE",true).GetValue<bool>())
            {
                if(E.IsReady() && Target_E != null || Targets.IsValidTarget(E.Range))
                {
                    E.Cast();
                }
            }
            /// <summary>
            /// 궁,w 스스로 쓰자(실력이 딸려서 못짜겠다.)
            /// </summary>

        }

        protected override void OnHarass()
        {
            var Targets = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical);

            var Target_E = moving.GetTarget();

            if(menu.Item("HarassQ",true).GetValue<bool>())
            {
                if(Q.IsReady() && Targets.IsValidTarget(Q.Range))
                {
                    Q.Cast();
                }
            }

            if(menu.Item("HarassE",true).GetValue<bool>())
            {
                if(E.IsReady() && Targets.IsValidTarget(E.Range))
                {
                    E.Cast((Obj_AI_Hero)Target_E);
                }
            }
        }

        protected override void OnLaneClear()
        {

        }

        protected override void OnJungleClear()
        {
            var Monster = MinionManager.GetMinions(hero.ServerPosition, Orbwalking.GetRealAutoAttackRange(hero),
                MinionTypes.All, MinionTeam.Neutral, MinionOrderTypes.MaxHealth);

            if(Q.IsReady() && menu.Item("JungleClearQ",true).GetValue<bool>())
            {
                Q.Cast();
            }

            if(E.IsReady() && menu.Item("JungleClearE",true).GetValue<bool>())
            {
                E.Cast();
            }
        }
        #endregion
    }
}
