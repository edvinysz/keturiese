using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelBlock = Server.Models.Block;

namespace Server.Builders.Block
{
    public interface IBlockBuilder
    {
        IBlockBuilder setId(long id);

        IBlockBuilder setName(string name);

        IBlockBuilder setImageId(long imageId);

        IBlockBuilder setHeight(int height);

        IBlockBuilder setWidth(int width);

        IBlockBuilder setDamage(int damage);

        ModelBlock build();
    }
}
