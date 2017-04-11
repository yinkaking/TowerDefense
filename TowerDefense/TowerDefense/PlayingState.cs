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
        GameObjectList ufos, cannons;

        public PlayingState()
        {
            ufos = new GameObjectList();
            cannons = new GameObjectList();
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
    }
}
