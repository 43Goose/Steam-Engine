using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SteamEngine.SteamEngine;

namespace SteamEngine
{
    class Demo : SteamEngine.SteamEngine
    {
        public Demo() : base(new Vector2(512, 512), "Steam Engine Demo") { }

        public override void OnLoad()
        {
            Console.WriteLine("Yippeeeee");
            BackgroundColor = Color.Black;
        }

        public override void OnDraw()
        {

        }

        int frame = 0;
        public override void OnUpdate()
        {
            Console.WriteLine($"Frame count: {frame}");
            frame++;
        }
    }
}
