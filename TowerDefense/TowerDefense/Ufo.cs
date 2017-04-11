using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    class Ufo : RotatingSpriteGameObject
    {


        public Ufo(Vector2 startPos, GameObject targetObject, string assetname = "spr_ufo", int layer = 0, string id = "", int sheetIndex = 0) : base(assetname, layer, id, sheetIndex)
        {
            this.Origin = this.Sprite.Center;
            this.Position = startPos;
            this.targetObject = targetObject;
            this.LookAt(this.targetObject);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.Velocity = (AngularDirection * 50);
        }
    }
}
