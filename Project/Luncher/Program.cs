using FUI;
using Starter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luncher
{ 
    class Program
    {
        public static void Main(string[] args)
        {
            Test();
            Console.ReadKey();
        }

        public static async void Test()
        {
            Minecraft minecraft = new Minecraft();
            MinecraftVersion version = new MinecraftVersion();
            version.Queue();
            var result = await version.ParseData(MinecraftType.release);
            foreach (var minecraftIndex in result)
            {
                Console.WriteLine(minecraftIndex.Name);
            }
        }
    }
}
