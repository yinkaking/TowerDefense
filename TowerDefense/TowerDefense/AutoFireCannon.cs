using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    class AutoFireCannon : RotatingSpriteGameObject
    {
        private int cooldownTimer;

        public AutoFireCannon(Vector2 startPos, string assetname = "spr_cannon", int layer = 0, string id = "", int sheetIndex = 0) : base(assetname, layer, id, sheetIndex)
        {
            this.Position = startPos;
            this.Origin = new Vector2(16, 16);
        }

        public bool HasFired
        {
            get
            {
                cooldownTimer++;
                if(cooldownTimer >= 150)
                {
                    cooldownTimer = 0;
                    return true;
                }

                return false;
            }
        }
    }
}
