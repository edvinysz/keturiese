using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public interface GetPositionData
    {
        int getPositionX();
        int getPositionY();

        //void setPositionX(int x);
        //void setPositionY(int y);
    }
}
