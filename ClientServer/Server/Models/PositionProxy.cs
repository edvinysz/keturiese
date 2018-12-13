using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class PositionProxy : GetPositionData
    {
       StartingPosition poz = new StartingPosition();

       public int getPositionX()
        {
            return poz.getPositionX();
        }

        public int getPositionY()
        {
            return poz.getPositionY();
        }

        public void setPositionX(int x)
        {
            poz.setPositionX(x);
        }

        public void setPositionY(int y)
        {
            poz.setPositionY(y);
        }
    }
}
