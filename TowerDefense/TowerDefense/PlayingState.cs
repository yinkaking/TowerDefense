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

        public PlayingState()
        {
            homeBase = new SpriteGameObject("spr_homebase");
            homeBase.Origin = homeBase.Sprite.Center;
            homeBase.Position = new Vector2(900, 340);

            this.Add(new SpriteGameObject("spr_background"));
            this.Add(homeBase);
        }
    }
}
