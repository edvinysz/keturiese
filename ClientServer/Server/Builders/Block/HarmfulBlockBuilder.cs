using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.AbstractFactory;

namespace Server.Builders.Block
{
    public class HarmfulBlockBuilder : IBlockBuilder
    {
        EnemyBlock enemyBlock = null;

        public Models.Block build()
        {
            return enemyBlock;
        }

        public IBlockBuilder create()
        {
            BlockFactory factory = new EnemyBlockFactory();
            enemyBlock = factory.CreateEnemyBlock("Deadly");

            return this;
        }

        public IBlockBuilder setDamage(int damage)
        {
            enemyBlock.Damage = damage;

            return this;
        }

        public IBlockBuilder setHeight(int height)
        {
            enemyBlock.Height = height;

            return this;
        }

        public IBlockBuilder setId(long id)
        {
            enemyBlock.Id = id;

            return this;
        }

        public IBlockBuilder setImageId(long imageId)
        {
            enemyBlock.ImageId = imageId;

            return this;
        }

        public IBlockBuilder setName(string name)
        {
            enemyBlock.Name = name;

            return this;
        }

        public IBlockBuilder setWidth(int width)
        {
            enemyBlock.Width = width;

            return this;
        }
    }
}