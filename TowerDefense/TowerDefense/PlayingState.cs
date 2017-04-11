using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    class PlayingState : GameObjectList
    {

        SpriteGameObject homeBase;
        GameObjectList ufos, cannons, bullets;

        public PlayingState()
        {
            ufos = new GameObjectList();
            cannons = new GameObjectList();
            bullets = new GameObjectList();
            homeBase = new SpriteGameObject("spr_homebase");
            homeBase.Origin = homeBase.Sprite.Center;
            homeBase.Position = new Vector2(900, 340);

            ufos.Add(new Ufo(new Vector2(20, 20), this.homeBase));
            ufos.Add(new Ufo(new Vector2(-100, 600), this.homeBase));
            ufos.Add(new Ufo(new Vector2(-300, 300), this.homeBase));
            ufos.Add(new Ufo(new Vector2(800, -500), this.homeBase));
            ufos.Add(new Ufo(new Vector2(700, 1000), this.homeBase));

            this.Add(new SpriteGameObject("spr_background"));
            this.Add(homeBase);
            this.Add(ufos);
            this.Add(bullets);
            this.Add(cannons);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if(inputHelper.MouseLeftButtonPressed())
            {
                cannons.Add(new AutoFireCannon(inputHelper.MousePosition));
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (AutoFireCannon cannon in cannons.Objects)
            {
                if (cannon.HasFired)
                {
                    this.bullets.Add(new Bullet(cannon.Position, (cannon.AngularDirection * 120)));
                }

                cannon.LookAt(ufos.Objects.Where(x => 
                {
                    if (x.Visible == true)
                    {
                        return true;
                    }
                    return false;
                }).FirstOrDefault());
            }

            foreach (Ufo ufo in ufos.Objects)
            {
                if (ufo.CollidesWith(homeBase) && ufo.Visible)
                {
                    TowerDefense.GameStateManager.SwitchTo(TowerDefense.GAMEOVERSTATE);
                }
                foreach (Bullet bullet in bullets.Objects)
                {
                    if (bullet.CollidesWith(ufo))
                    {
                        bullet.Visible = false;
                        ufo.Visible = false;
                    }
                }
                
            }

            if(ufos.Objects.All(x =>
            {
                if(x.Visible == false)
                {
                    return true;
                }
                return false;
            }))
            {
                TowerDefense.GameStateManager.SwitchTo(TowerDefense.WINSTATE);
            }
        }


    }
}
