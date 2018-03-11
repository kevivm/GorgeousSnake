namespace GorgeousSnake
{
    //TODO: Put one entity in one file.
    public class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Level { get; set; }
        public static int Points { get; set; }
        public static bool IsGameOver { get; set; }
        public static string PathToStatisticFile { get; set; }
        public static int BodyCount { get; set; }

        public static Direction Direction { get; set; }

        public Settings()
        {
            Width = 32;
            Height = 32;
            Speed = 5;
            Score = 0;
            Points = 300;
            Level = 1;
            BodyCount = 3;
            IsGameOver = false;
            Direction = Direction.Down;
            PathToStatisticFile = "stat.json";
        }
    }
}
