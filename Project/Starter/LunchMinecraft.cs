using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starter
{
    class LunchMinecraft
    {
        private readonly MinecraftIndex index;
        private readonly DirMinecraft dir;

        public LunchMinecraft(
            MinecraftIndex index,
            DirMinecraft dir
        ){
            this.index = index;
            this.dir = dir;
        }
    }
}
