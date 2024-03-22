namespace SteamEngine.SteamEngine
{
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2()
        {
            X = Zero().X;
            Y = Zero().Y;
        }

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2) 
        {
            return new Vector2() { X = v1.X + v2.X, Y = v1.Y + v2.Y };
        }

        public static Vector2 operator *(Vector2 v, int mult)
        {
            return new Vector2() { X = v.X * mult, Y = v.Y * mult };
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2() { X = v1.X - v2.X, Y = v1.Y - v2.Y };
        }

        /// <summary>
        /// Returns Vector 2 with X & Y as 0
        /// </summary>
        /// <returns>Vector2</returns>
        public static Vector2 Zero() { return new Vector2(0, 0);}

        /// <summary>
        /// Same as Vector2(0, -1)
        /// </summary>
        /// <returns>Vector2</returns>
        public static Vector2 Up = new Vector2(0, -1);

        /// <summary>
        /// Same as Vector2(0, 1)
        /// </summary>
        /// <returns>Vector2</returns>
        public static Vector2 Down = new Vector2(0, 1);

        /// <summary>
        /// Same as Vector2(-1, 0)
        /// </summary>
        /// <returns>Vector2</returns>
        public static Vector2 Left = new Vector2(-1, 0);

        /// <summary>
        /// Same as Vector2(1, 0)
        /// </summary>
        /// <returns>Vector2</returns>
        public static Vector2 Right = new Vector2(1, 0);

        /// <summary>
        /// Returns a Vector2 with random X and Y values
        /// </summary>
        /// <returns>Vector2</returns>
        public static Vector2 Rand(int xMax, int yMax)
        {
            Random r = new Random();
            int randX = r.Next(xMax);
            int randY = r.Next(yMax);

            return new Vector2(randX, randY);
        }
    }
}
