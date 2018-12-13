using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Block : Position, IBlock
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ImageId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Damage { get; set; }
        public void setId(long id) { Id = id; }
        public void setName(string name) { Name = name; }
        public void setImageId(long id) { ImageId = id; }
        public void setHeight(int h) { Height = h; }
        public void setWidth(int w) { Width = w; }
        public bool needDamage()
        {
            if (Name=="Deadly"||Name=="Harmless") return true;
            return false;
        }
        public void setDamage(int dmg) { Damage = dmg; }
        public Block createBlockTemplate(string name, int h, int w, int dmg)
        {
            setName(name);
            setHeight(h);
            setWidth(w);
            if (needDamage())
                setDamage(dmg);
            return this;
        }

        public Block(long id, string n, long img, int h, int w, int dmg)
        {
            Id = id;
            Name = n;
            ImageId = img;
            Width = w;
            Height = h;
            Damage = dmg;
        }

        protected Block(long id)
        {
            Id = id;
        }

        public Block() { }

        public string getName()
        {
            return this.Name;
        }

        public int getDamage()
        {
            return this.Damage;
        }

        public override string ToString()
        {
            return "Block info | Id: " + Id + ", Name: " + Name + ", ImageId: " 
                + ImageId + ", Width: " + Width + ", Height: " + Height + ", Damage: " + Damage;
        }
    }
}
