using System;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using System.Linq;

namespace VitaminSharp.Base
{
    public class Champion
    {
        protected string name;
        protected Obj_AI_Hero hero { get { return ObjectManager.Player; } }
        protected Spell Q, W, E, R;
        protected Orbwalking.Orbwalker moving;
        protected Menu menu;

        protected virtual void OnCombo() { }
        protected virtual void OnHarass() { }
        protected virtual void OnLaneClear() { }
        protected virtual void OnLastHit() { }

        public virtual void OnLoad(EventArgs args) { }
        public virtual void OnMenu() { }
        public virtual void OnUpdate() { }
        public virtual void OnDraw() { }

        public void Init()
        {
            menu = new Menu(name, name, true);
            Game.OnUpdate += Update;
            Drawing.OnDraw += Draw;
        }

        public void Draw(EventArgs args)
        {
            if (hero.IsDead)
            {
                return;
            }

            OnDraw();
        }

        public void Update(EventArgs args)
        {
            if (hero.IsDead)
            {
                return;
            }

            switch(moving.ActiveMode)
            {
                case Orbwalking.OrbwalkingMode.Combo:
                    OnCombo();
                    break;

                case Orbwalking.OrbwalkingMode.Mixed:
                    OnHarass();
                    break;

                case Orbwalking.OrbwalkingMode.LaneClear:
                    OnLaneClear();
                    break;

                case Orbwalking.OrbwalkingMode.LastHit:
                    OnLastHit();
                    break;
            }

            OnUpdate();
        }
    }
}
