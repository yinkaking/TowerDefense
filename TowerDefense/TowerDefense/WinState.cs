using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    class WinState : SpriteGameObject
    {
        public WinState(string assetname = "spr_win", int layer = 0, string id = "", int sheetIndex = 0) : base(assetname, layer, id, sheetIndex)
        {
        }
    }
}
