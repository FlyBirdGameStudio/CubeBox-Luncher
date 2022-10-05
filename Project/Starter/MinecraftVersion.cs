using Newtonsoft.Json.Linq;
using Starter.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Starter
{
    public enum MinecraftType
    {
        release,
        snapshot,
        old_beta,
        old_alpha
    }

    public class MinecraftVersion
    {
        private readonly QueueResult queue = new QueueResult(
            "https://piston-meta.mojang.com/mc/game/version_manifest.json"
            );

        private readonly List<MinecraftType> QueueResult = new List<MinecraftType>();

        public MinecraftVersion()
        {
            QueueResult.Clear();
        }

        public void Queue()
        {
            queue.Queue();
        }

        public Task<List<MinecraftIndex>> ParseData(MinecraftType type)
        {
            var task = new Task<List<MinecraftIndex>>(() =>
            {
                List<MinecraftIndex> resultList = new List<MinecraftIndex>();
                JObject root = JObject.Parse(queue.GetResult());
                JArray versions = (JArray)root["versions"];
                foreach (JObject item in versions)
                {
                    if (item["type"].ToString() == type.ToString())
                    {
                        resultList.Add(new MinecraftIndex((string)item["id"], (string)item["time"], (string)item["url"], type));
                    }
                }
                GC.Collect();
                return resultList;
            });
            task.Start();
            return task;
        }
    }

    public class MinecraftIndex
    {
        public readonly string Name;
        public readonly string Date;
        public readonly string Url;
        public readonly MinecraftType Type;

        public MinecraftIndex(
            string name,
            string data,
            string url,
            MinecraftType type
            )
        {
            this.Name = name;
            this.Date = data;
            this.Url = url;
            this.Type = type;
        }
    }
}
