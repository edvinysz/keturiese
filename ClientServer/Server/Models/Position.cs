using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public abstract class Position
    {
        public abstract long Id { get; set; }
        public abstract string Type { get; }
        public abstract int PositionX { get; set; }
        public abstract int PositionY { get; set; }
    }

    /// <summary>
    /// Factory pattern - Edvinas
    /// </summary>

    class StartingPosition : Position
    {
        private long _Id;
        private int _PositionX = 10;
        private int _PositionY = 10;

        public override string Type
        {
            get { return "Start"; }
        }

        public override int PositionX
        {
            get { return _PositionX; }
            set { _PositionX = value; }
        }

        public override int PositionY
        {
            get { return _PositionY; }
            set { _PositionY = value; }
        }

        public override long Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    }

    class Zero : Position
    {
        private long _Id;
        private int _PositionX = 0;
        private int _PositionY = 0;

        public override string Type
        {
            get { return "Zero"; }
        }

        public override int PositionX
        {
            get { return _PositionX; }
            set { _PositionX = value; }
        }

        public override int PositionY
        {
            get { return _PositionY; }
            set { _PositionY = value; }
        }

        public override long Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    }

    class StartingInSky : Position
    {
        private long _Id;
        private int _PositionX = 0;
        private int _PositionY = 100;

        public override string Type
        {
            get { return "InTheSky"; }
        }

        public override int PositionX
        {
            get { return _PositionX; }
            set { _PositionX = value; }
        }

        public override int PositionY
        {
            get { return _PositionY; }
            set { _PositionY = value; }
        }

        public override long Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    }

    public static class Factory
    {
        /// <summary>
        /// Decides which class to instantiate.
        /// </summary>
        public static Position Get(int id) // 0 - Starting possition(10;10) , 1 - Zero(0;0) , 2 - Starting in Sky(0;100)
        {
            switch (id)
            {
                case 0:
                    return new StartingPosition();
                case 1:
                    return new Zero();
                case 2:
                    return new StartingInSky();
                default:
                    return new StartingPosition();
            }
        }
    }
}
