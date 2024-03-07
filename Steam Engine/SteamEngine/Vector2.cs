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

        /// <summary>
        /// Returns Vector 2 with X & Y as 0
        /// </summary>
        /// <returns>Vector2</returns>
        public static Vector2 Zero() { return new Vector2(0, 0);}
    }
}
