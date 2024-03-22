using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamEngine.SteamEngine
{
    public class Sprite2D
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Path = "";
        public string Tag = "";
        public Bitmap Sprite = null;

        public Sprite2D(Vector2 Position, Vector2 Scale, string Path, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Path = Path;
            this.Tag = Tag;

            Image tmp = Image.FromFile($"Assets/Sprites/{Path}");
            Bitmap sprite = new Bitmap(tmp);
            Sprite = sprite;

            SteamEngine.RegisterSprite(this);
            Log.Info($"[SPRITE2D]({Tag}) - Created!");
        }

        public Sprite2D(Vector2 Position, Vector2 Scale, Bitmap Sprite, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;
            this.Sprite = Sprite;

            SteamEngine.RegisterSprite(this);
            Log.Info($"[SPRITE2D]({Tag}) - Created!");
        }

        /*public bool IsColliding( Sprite2D a, Sprite2D b )
        {
            if (a.Position.X < b.Position.X + b.Scale.X &&
                a.Position.X + a.Scale.X > b.Position.X &&
                a.Position.Y < b.Position.Y + b.Scale.Y &&
                a.Position.Y + a.Scale.Y > b.Position.Y) { return true; }

            return false;
        }*/

        public void DestroySelf()
        {
            SteamEngine.UnregisterSprite(this);
            Log.Info($"[SHAPE2D]({Tag}) - Destroyed!");
        }
    }
}
