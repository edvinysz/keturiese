﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class EnemyBlock : Block
    {
        public EnemyBlock(long id, string n, long img, int h, int w, int dmg) : base(id, n, img, h, w, dmg)
        {
        }
    }
}
