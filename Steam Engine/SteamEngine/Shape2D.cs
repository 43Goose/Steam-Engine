using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamEngine.SteamEngine
{
    public class Shape2D
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public Color Color = Color.White;
        public string Tag = "";

        public Shape2D(Vector2 Position, Vector2 Scale, Color Color, string Tag) 
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;
            this.Color = Color;

            SteamEngine.RegisterShape(this);
            Log.Info($"[SHAPE2D]({Tag}) - Created!");
        }

        public bool IsColliding(Shape2D t)
        {
            if (this.Position.X < t.Position.X + t.Scale.X &&
                this.Position.X + this.Scale.X > t.Position.X &&
                this.Position.Y < t.Position.Y + t.Scale.Y &&
                this.Position.Y + this.Scale.Y > t.Position.Y) { return true; }

            return false;
        }

        public bool IsColliding(List<Shape2D> targets)
        {
            foreach (Shape2D t in targets)
            {
                if (this.Position.X < t.Position.X + t.Scale.X &&
                this.Position.X + this.Scale.X > t.Position.X &&
                this.Position.Y < t.Position.Y + t.Scale.Y &&
                this.Position.Y + this.Scale.Y > t.Position.Y) { return true; }
            }

            return false;
        }

        public void DestroySelf()
        {
            SteamEngine.UnregisterShape(this);
            Log.Info($"[SHAPE2D]({Tag}) - Destroyed!");
        }
    }
}
