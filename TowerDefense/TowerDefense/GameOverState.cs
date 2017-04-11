using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    class GameOverState : SpriteGameObject
    {
        public GameOverState(string assetname = "spr_gameover", int layer = 0, string id = "", int sheetIndex = 0) : base(assetname, layer, id, sheetIndex)
        {
        }
    }
}
