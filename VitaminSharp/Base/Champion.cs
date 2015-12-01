using System;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using System.Linq;

namespace VitaminSharp.Base
{
    public abstract class Champion
    {
        protected string name;
        protected Obj_AI_Hero hero { get { return ObjectManager.Player; } }
        protected Spell Q, W, E, R;
        protected Orbwalking.Orbwalker orbWalker;
        protected Menu menu;

        public abstract void OnLoad(EventArgs args);
        public void Init(string displayName, string name, bool rootMenu)
        {
            menu = new Menu(displayName, name, rootMenu);
            Game.OnUpdate += Update;
        }

        public abstract void OnMenu();
        public abstract void OnDrawArage(EventArgs args);
        public void Update(EventArgs args)
        {
            if (hero.IsDead)
            {
                return;
            }

            switch (orbWalker.ActiveMode)
            {
                case Orbwalking.OrbwalkingMode.Combo:
                    OnCombo();
                    break;

                case Orbwalking.OrbwalkingMode.Mixed:
                    OnMixed();
                    break;

                case Orbwalking.OrbwalkingMode.LaneClear:
                    OnLaneClear();
                    break;

                case Orbwalking.OrbwalkingMode.LastHit:
                    OnLastHit();
                    break;
            }
        }

        protected abstract void OnLastHit();
        protected abstract void OnMixed();
        protected abstract void OnLaneClear();
        protected abstract void OnCombo();
    }
}
