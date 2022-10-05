using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starter
{
    class DownloadMinecraft
    {
        private readonly MinecraftIndex index;
        private readonly DirMinecraft dir;

        public DownloadMinecraft(
            DirMinecraft dir,
            MinecraftIndex index
        ){
            this.dir = dir;
            this.index = index;
        }
    }
}
