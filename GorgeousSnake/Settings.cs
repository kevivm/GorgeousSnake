using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorgeousSnake
{
    //TODO: Put one entity in one file.
    public enum Direction //TODO:
    {
        Up,
        Down,
        Left,
        Right
    };

    public class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Level { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static string path { get; set; }
        public static int bodyCount { get; set; }

        public static Direction direction { get; set; }

        public Settings()
        {
            Width = 32;
            Height = 32;
            Speed = 5;
            Score = 0;
            Points = 300;
            Level = 1;
            bodyCount = 3;
            GameOver = false;
            direction = Direction.Down;
            path = "stat.json";
        }
    }
}
