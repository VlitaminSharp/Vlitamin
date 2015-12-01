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

            Game.PrintChat("<font color = \"##00D8FF\"> [VlitaminSharp] Tristana Init </font> Korean ");
            Init();
            OnMenu();
        }

        public override void OnMenu()
        {
            menu.SubMenu("Test").AddItem(new MenuItem("ComboQ", "CUseQ", true).SetValue(true));
            menu.SubMenu("Test").AddItem(new MenuItem("ComboW", "CUseW", true).SetValue(false));
            menu.SubMenu("Test").AddItem(new MenuItem("ComboE", "CUseE", true).SetValue(true));
            menu.SubMenu("Test").AddItem(new MenuItem("ComboR", "CUseR", true).SetValue(true));

            menu.SubMenu("Test").AddItem(new MenuItem("HarassQ", "HUseQ", true).SetValue(true));
            menu.SubMenu("Test").AddItem(new MenuItem("HarassE", "HUseE", true).SetValue(true));

            menu.SubMenu("Test").AddItem(new MenuItem("LaneClearQ", "LUseQ", true).SetValue(false));
            menu.SubMenu("Test").AddItem(new MenuItem("LaneClearE", "LUseE", true).SetValue(false));

            menu.SubMenu("Test").AddItem(new MenuItem("JugleClearQ", "JUseQ", true).SetValue(false));
            menu.SubMenu("Test").AddItem(new MenuItem("JugleClearE", "JUseE", true).SetValue(false));
            menu.AddToMainMenu();
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

        }

        protected override void OnHarass()
        {

        }

        protected override void OnLaneClear()
        {

        }

        protected override void OnLastHit()
        {

        }
        #endregion
    }
}
