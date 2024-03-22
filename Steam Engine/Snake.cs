using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SteamEngine.SteamEngine;

namespace SteamEngine
{
    class Snake : SteamEngine.SteamEngine
    {
        Shape2D player = null;
        List<Shape2D> tail = new List<Shape2D> ();
        Shape2D food = null;
        Bitmap endSprite = new Bitmap(Image.FromFile($"Assets/Sprites/SadSnek.png"));
        Vector2 dir = new Vector2(1, 0);
        float speed = 40;
        DateTime lastMoved = DateTime.Now;
        int gridSize = 30;
        Vector2 prevPos = null;

        public Snake() : base(new Vector2(616, 640), "Steam Engine Snake") { } //516 540

        public override void OnLoad()
        {
            BackgroundColor = Color.Black;

            player = new Shape2D(ConvertGridCoordToVector2(0, 0, 20), new Vector2(20, 20), Color.White, "player");

            food = new Shape2D(NewFoodPos(), new Vector2(14, 14), Color.Red, "food");
        }

        public override void OnDraw() { }

        public override void OnUpdate()
        {
            if(DateTime.Now >= lastMoved + TimeSpan.FromSeconds(10f / speed))
            {
                Move();
            }

            if(player.IsColliding(food))
            {
                food.Position = NewFoodPos();
                Vector2 newTailPos = tail.Count < 1 ? player.Position - (dir * gridSize) : prevPos;
                tail.Add(new Shape2D(newTailPos, new Vector2(20, 20), Color.White, "tail"));
            } else if(player.IsColliding(tail) || isOutOfBounds())
            {
                endGame();
            }
        }

        bool isOutOfBounds()
        {
            if (player.Position.X > 20 * gridSize || player.Position.X < 0 || player.Position.Y > 20 * gridSize || player.Position.Y < 0) 
            {
                return true;
            } else
            {
                return false;
            }
        }

        void endGame()
        {
            foreach(Shape2D t in tail) 
            {
                t.DestroySelf();
            }
            player.DestroySelf();
            food.DestroySelf();

            new Sprite2D(ConvertGridCoordToVector2(9, 9, 300), new Vector2(300, 300), endSprite, "endgamesign");
        }

        void Move()
        {
            prevPos = player.Position;
            player.Position += dir * gridSize;

            foreach (Shape2D t in tail)
            {
                Vector2 curTPos = t.Position;
                t.Position = prevPos;
                prevPos = curTPos;
            }

            lastMoved = DateTime.Now;
        }

        Vector2 NewFoodPos()
        {
            Vector2 newPos = Vector2.Rand(20, 20);
            return ConvertGridCoordToVector2((int)newPos.X, (int)newPos.Y, 14);
        }

        Vector2 ConvertGridCoordToVector2(int x, int y, int objScale)
        {
            float offset = (gridSize - objScale) / 2;
            return new Vector2((x * gridSize) + offset, (y * gridSize) + offset);
        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    dir = Vector2.Up;
                    break;
                case Keys.S:
                    dir = Vector2.Down;
                    break;
                case Keys.A:
                    dir = Vector2.Left;
                    break;
                case Keys.D:
                    dir = Vector2.Right;
                    break;
                default:
                    break;
            }
        }

        public override void GetKeyUp(KeyEventArgs e) { }
    }
}
