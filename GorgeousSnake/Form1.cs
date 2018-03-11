using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace GorgeousSnake
{
    public partial class Form1 : Form
    {
        //TODO: Snake could be a class and object. Game also (and have timers inside).
        private List<Point> _snake = new List<Point>(); //TODO: private fields are named using camelCase.
        private Point _food = new Point(); //TODO: why didn't you create Food class and object?
        private bool _isLblGameOver = false;
        private string _username = String.Empty;

        public Form1()
        {
            InitializeComponent();

            //set settings to default
            new Settings();

            //set timer settings
            GameTimer.Interval = 1000 / Settings.Speed;
            GameTimer.Tick += UpdateEvents;
            GameTimer.Start();

            timerStatus.Interval = 3;
            timerStatus.Tick += StatusGame;
            timerStatus.Start();

            this.GetUserName();
            MessageBox.Show("Game Controls:\n Space - Play/Pause");

            //Start New Game
            NewGame();
        }


        public void StatusGame(object sender, EventArgs e)
        {
            if (Input.IsKeyPressed(Keys.Space))
            {
                if (GameTimer.Enabled)
                {
                    GameTimer.Stop();
                }
                else
                {
                    GameTimer.Start();
                }
            }
        }

        private void NewGame()
        {
            Cursor.Current = Cursors.Default;

            if (!GameTimer.Enabled)
            {
                GameTimer.Start();
            }

            lblGameOVer.Visible = false;
            //set Settings to default
            new Settings();
            this.lblSpeed.Text = Settings.Level.ToString();
            GameTimer.Interval = 1000 / Settings.Speed;

            //set food remaining
            this.countBody.Text = "0";

            // Create new player object
            _snake.Clear();
            Point head = new Point { X = 10, Y = 5 }; //TODO: why didn't you create Head class and object?

            _snake.Add(head);
            GenerateStartBody();

            lblScore.Text = Settings.Score.ToString();
            GenerateFood();
        }

        public void GenerateStartBody()
        {
            for (int i = 0; i < Settings.BodyCount; i++)
            {
                //Add circle to body
                Point circle = new Point
                {
                    X = _snake[_snake.Count - 1].X,
                    Y = _snake[_snake.Count - 1].Y
                };
                _snake.Add(circle);
            }
        }

        // place random food game
        private void GenerateFood()
        {
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            Random random = new Random();
            _food = new Point { X = random.Next(0, maxXPos), Y = random.Next(0, maxYPos) };
        }

        private void UpdateEvents(object sender, EventArgs e)
        {
            //Check for game over
            if (Settings.IsGameOver)
            {
                //check if enter pressed
                if (Input.IsKeyPressed(Keys.Enter))
                {
                    NewGame();
                }
            }
            else
            {
                if (Input.IsKeyPressed(Keys.Right) && Settings.Direction != Direction.Left)
                    Settings.Direction = Direction.Right;
                else if (Input.IsKeyPressed(Keys.Left) && Settings.Direction != Direction.Right)
                    Settings.Direction = Direction.Left;
                else if (Input.IsKeyPressed(Keys.Up) && Settings.Direction != Direction.Down)
                    Settings.Direction = Direction.Up;
                else if (Input.IsKeyPressed(Keys.Down) && Settings.Direction != Direction.Up)
                    Settings.Direction = Direction.Down;

                MovePlayer();
            }

            pbCanvas.Invalidate();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Settings.IsGameOver)
            {
                //Draw snake //TODO: draw methods should belong to the correspondant classes.
                for (int i = 0; i < _snake.Count; i++)
                {
                    Brush snakeColour;
                    if (i == 0)
                    {
                        Bitmap theImageHead = new Bitmap("head.gif");
                        Image smallImageHead = new Bitmap(theImageHead, new Size(32, 32));
                        Brush tBrushHead = new TextureBrush(smallImageHead, new Rectangle(0, 0, smallImageHead.Width, smallImageHead.Height));

                        //snakeColour = Brushes.GreenYellow; //head
                        snakeColour = tBrushHead;
                    }
                    else
                    {
                        Bitmap theImageBody = new Bitmap("body.png");
                        Image smallImageBody = new Bitmap(theImageBody, new Size(32, 32));
                        Brush tBrushBody = new TextureBrush(smallImageBody, new Rectangle(0, 0, smallImageBody.Width, smallImageBody.Height));

                        //snakeColour = Brushes.Green; //body
                        snakeColour = tBrushBody; //body
                    }

                    //Draw snake
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(_snake[i].X * Settings.Width,
                                      _snake[i].Y * Settings.Height,
                                      Settings.Width, Settings.Height));

                    //Draw Food
                    Bitmap theImage = new Bitmap("apple.png");
                    Image smallImage = new Bitmap(theImage, new Size(32, 32));
                    Brush tBrush = new TextureBrush(smallImage, new Rectangle(0, 0, smallImage.Width, smallImage.Height));

                    canvas.FillEllipse(tBrush,
                        new Rectangle(_food.X * Settings.Width,
                             _food.Y * Settings.Height, Settings.Width, Settings.Height));
                }
            }
            else
            {
                string gameOver = "Game Over \n Your final score is: " + Settings.Score + "\nPress Enter to try again!";
                lblGameOVer.Text = gameOver;
                lblGameOVer.Visible = true;
                timerLabel.Start();
            }
        }

        private void MovePlayer()
        {
            for (int i = _snake.Count - 1; i >= 0; i--)
            {
                //move head
                if (i == 0)
                {
                    switch (Settings.Direction)
                    {
                        case Direction.Right:
                            _snake[i].X++;
                            break;
                        case Direction.Left:
                            _snake[i].X--;
                            break;
                        case Direction.Up:
                            _snake[i].Y--;
                            break;
                        case Direction.Down:
                            _snake[i].Y++;
                            break;
                    }

                    int maxXPos = pbCanvas.Size.Width / Settings.Width;
                    int maxYPos = pbCanvas.Size.Height / Settings.Height;

                    if (_snake[i].X < 0 || _snake[i].Y < 0
                        || _snake[i].X >= maxXPos || _snake[i].Y >= maxYPos)
                    {
                        Die();
                    }

                    for (int j = 1; j < _snake.Count; j++)
                    {
                        if (_snake[i].X == _snake[j].X &&
                           _snake[i].Y == _snake[j].Y)
                        {
                            Die();
                        }
                    }

                    //if Snake take food
                    if (_snake[0].X == _food.X && _snake[0].Y == _food.Y)
                    {
                        TakeFood();
                    }
                }
                else
                {
                    //Move body
                    _snake[i].X = _snake[i - 1].X;
                    _snake[i].Y = _snake[i - 1].Y;
                }
            }
        }

        private void TakeFood()
        {
            //Add circle to body
            Point point = new Point
            {
                X = _snake[_snake.Count - 1].X,
                Y = _snake[_snake.Count - 1].Y
            };

            _snake.Add(point);

            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "1.wav";
            player.Play();

            //Update Score
            Settings.Score += Settings.Points;
            lblScore.Text = Settings.Score.ToString();

            this.countBody.Text = (_snake.Count - Settings.BodyCount - 1).ToString();

            if (_snake.Count % 2 == 0)
            {
                Settings.Speed += 1;
                int lblSpeed = Convert.ToInt32(this.lblSpeed.Text);

                this.GameTimer.Interval = 1000 / Settings.Speed;

                this.lblSpeed.Text = (lblSpeed + 1).ToString();
                Settings.Level = Convert.ToInt32(this.lblSpeed.Text);
            }

            GenerateFood();
        }

        private void Die()
        {
            Statistics.ScoreThisUser.Clear();
            Statistics.ScoreThisUser.Add("Name", this._username);
            Statistics.ScoreThisUser.Add("Score", Settings.Score.ToString());
            Statistics.ScoreThisUser.Add("Level", Settings.Level.ToString());
            Statistics.AddScore(this._username);
            Settings.IsGameOver = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void timerLabel_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;

            if (this._isLblGameOver == false)
            {
                this.lblGameOVer.ForeColor = Color.Black;
                this._isLblGameOver = true;
            }
            else
            {
                this.lblGameOVer.ForeColor = Color.Red;
                this._isLblGameOver = false;
            }
        }

        private void lblGameOVer_Click_1(object sender, EventArgs e)
        {
            NewGame();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Paul 2018(C)");
        }

        private void statsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameTimer.Stop();
            Statistics.GetScore();
        }

        //get Username from keyboard
        private string GetUserName()
        {
            //while username is not be empted
            while (String.IsNullOrEmpty(this._username))
            {
                this._username = Microsoft.VisualBasic.Interaction.InputBox("What is your name? ");
            }

            return this._username;
        }

        private void lblGameOVer_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
