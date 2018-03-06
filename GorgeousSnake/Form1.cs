using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.IO;

namespace GorgeousSnake
{
    public partial class Form1 : Form
    {
        //TODO: Snake could be a class and object. Game also (and have timers inside).
        private List<Circle> Snake = new List<Circle>(); //TODO: private fields are named using camelCase.
        private Circle food = new Circle(); //TODO: why didn't you create Food class and object?
        private bool isLblGameOver = false;
        private string userName = "";

        public Form1()
        {
            InitializeComponent();

            //set settings to default
            new Settings();

            //set timer settings
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateEvents;
            gameTimer.Start();

            timerStatus.Interval = 3;
            timerStatus.Tick += StatusGame;
            timerStatus.Start();

            this.getUsername();
            MessageBox.Show("Game Controls:\n Space - Play/Pause");


            //Start New Game
            NewGame();
        }


        public void StatusGame(object sender, EventArgs e)
        {
            if (Input.KeyPressed(Keys.Space))
            {
                if (gameTimer.Enabled)
                {
                    gameTimer.Stop();
                }
                else
                {
                    gameTimer.Start();
                }
            }

        }


        private void NewGame()
        {
            Cursor.Current = Cursors.Default;

            if (!gameTimer.Enabled)
            {
                gameTimer.Start();
            }

            lblGameOVer.Visible = false;
            //set Settings to default
            new Settings();
            this.lblSpeed.Text = Settings.Level.ToString();
            gameTimer.Interval = 1000 / Settings.Speed;

            //set food remaining
            this.countBody.Text = "0";

            // Create new player object
            Snake.Clear();
            Circle head = new Circle { X = 10, Y = 5 }; //TODO: why didn't you create Head class and object?

            Snake.Add(head);
            GenerateStartBody();

            lblScore.Text = Settings.Score.ToString();
            GenerateFood();
        }


        public void GenerateStartBody()
        {
            for (int i = 0; i < Settings.bodyCount; i++)
            {
                //Add circle to body
                Circle circle = new Circle
                {
                    X = Snake[Snake.Count - 1].X,
                    Y = Snake[Snake.Count - 1].Y
                };
                Snake.Add(circle);
            }
        }


        // place random food game
        private void GenerateFood()
        {
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            Random random = new Random();
            food = new Circle { X = random.Next(0, maxXPos), Y = random.Next(0, maxYPos) };
        }

        private void UpdateEvents(object sender, EventArgs e)
        {
            //Check for game over
            if (Settings.GameOver)
            {

                //check if enter pressed
                if (Input.KeyPressed(Keys.Enter))
                {
                    NewGame();
                }
            }
            else
            {
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

                MovePlayer();
            }

            pbCanvas.Invalidate();

        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Settings.GameOver)
            {

                //Draw snake //TODO: draw methods should belong to the correspondant classes.
                for (int i = 0; i < Snake.Count; i++)
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
                        new Rectangle(Snake[i].X * Settings.Width,
                                      Snake[i].Y * Settings.Height,
                                      Settings.Width, Settings.Height));

                    //Draw Food
                    Bitmap theImage = new Bitmap("apple.png");
                    Image smallImage = new Bitmap(theImage, new Size(32,32));
                    Brush tBrush = new TextureBrush(smallImage, new Rectangle(0, 0, smallImage.Width, smallImage.Height));



                    canvas.FillEllipse(tBrush,
                        new Rectangle(food.X * Settings.Width,
                             food.Y * Settings.Height, Settings.Width, Settings.Height));
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
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //move head
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                    }

                    int maxXPos = pbCanvas.Size.Width / Settings.Width;
                    int maxYPos = pbCanvas.Size.Height / Settings.Height;

                    if (Snake[i].X < 0 || Snake[i].Y < 0
                        || Snake[i].X >= maxXPos || Snake[i].Y >= maxYPos)
                    {
                        Die();
                    }

                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X &&
                           Snake[i].Y == Snake[j].Y)
                        {
                            Die();
                        }
                    }

                    //if Snake take food
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        TakeFood();
                    }

                }
                else
                {
                    //Move body
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }

            }
        }


        private void TakeFood()
        {
            //Add circle to body
            Circle circle = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(circle);

            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "1.wav";
            player.Play();

            //Update Score
            Settings.Score += Settings.Points;
            lblScore.Text = Settings.Score.ToString();

            this.countBody.Text = (Snake.Count - Settings.bodyCount - 1).ToString();
            if (Snake.Count % 2 == 0)
            {
                Settings.Speed += 1;

                int lblSpeed = Convert.ToInt32(this.lblSpeed.Text);

                this.gameTimer.Interval = 1000 / Settings.Speed;
                this.lblSpeed.Text = (lblSpeed + 1).ToString();
                Settings.Level = Convert.ToInt32(this.lblSpeed.Text);
            }


            GenerateFood();

        }

        private void Die()
        {
            Stat.totalScore.Clear();
            Stat.totalScore.Add("Name", this.userName);
            Stat.totalScore.Add("Score", Settings.Score.ToString());
            Stat.totalScore.Add("Level", Settings.Level.ToString());
            Stat.addScore(this.userName);
            Settings.GameOver = true;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void lblGameOver_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void timerLabel_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
            if (this.isLblGameOver == false)
            {
                this.lblGameOVer.ForeColor = Color.Black;
                this.isLblGameOver = true;
            }
            else
            {
                this.lblGameOVer.ForeColor = Color.Red;
                this.isLblGameOver = false;
            }

        }

        private void lblGameOVer_Click_1(object sender, EventArgs e)
        {
            NewGame();
        }

        private void менюИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Menu New Game click
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Menu About click
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Paul 2018(C)");
        }


        //Menu stats click
        private void statsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();
            Stat.getScore();
        }

        //get Username from keyboard
        private string getUsername()
        {
            //while username is not be empted
            while (this.userName == "")
            {
                this.userName = Microsoft.VisualBasic.Interaction.InputBox("What is your name? ");
            }

            return this.userName;
        }

        private void lblGameOVer_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void lblGameOVer_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
