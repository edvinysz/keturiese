﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public interface IBlock
    {
        string getName();

        int getDamage();
    }
}
