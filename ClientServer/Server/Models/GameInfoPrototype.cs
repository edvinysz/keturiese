using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class GameInfoPrototype : GameInfo
    {
        private long _Id;
        private string _GameTitle;
        private long _MapId;
        private double _GameTime;
        private long _Player1Id;
        private long _Player2Id;
        private long _Player3Id;
        private long _Player4Id;
        private int _ConnectedPlayersCount;
        private long _ResultTableId;
        private bool _HasStarted;
        private bool _HasEnded;

        public GameInfoPrototype(int Id, string GameTitle, long MapId, double GameTime, long Player1Id, long Player2Id, long Player3Id, long Player4Id, int ConnectedPlayersCount, long ResultTableId, bool HasStarted, bool HasEnded)
        {
            this._Id = Id;
            this._GameTitle = GameTitle;
            this._MapId = MapId;
            this._GameTime = GameTime;
            this._Player1Id = Player1Id;
            this._Player2Id = Player2Id;
            this._Player3Id = Player3Id;
            this._Player4Id = Player4Id;
            this._ConnectedPlayersCount = ConnectedPlayersCount;
            this._ResultTableId = ResultTableId;
            this._HasStarted = HasStarted;
            this._HasEnded = HasEnded;
        }

        //shallow copy
        public override GameInfo Clone()
        {
            Console.WriteLine("Cloning: {0,12},{1,12},{2,12},{3,12},{4,12},{5,12},{6,12},{7,12},{8,12},{9,12},{10,12},{11,12}",
                _Id, _GameTitle, _MapId, _GameTime, _Player1Id, _Player2Id, _Player3Id, _Player4Id, _ConnectedPlayersCount, _ResultTableId, _HasStarted, _HasEnded);
            return this.MemberwiseClone() as GameInfo;
        }
    }

    //prototype manager
    class Manager
    {
        private Dictionary<string, GameInfo> _games = new Dictionary<string, GameInfo>();

        //indexer
        public GameInfo this[string key]
        {
            get { return _games[key]; }
            set { _games.Add(key, value); }
        }
    }
}
