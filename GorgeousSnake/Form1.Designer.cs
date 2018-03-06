namespace GorgeousSnake
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblGameOVer = new System.Windows.Forms.Label();
            this.countBody = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.InfoBar = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Timer(this.components);
            this.startNewGame = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюИгрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.InfoBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.Color.Black;
            this.pbCanvas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbCanvas.BackgroundImage")));
            this.pbCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCanvas.Location = new System.Drawing.Point(19, 39);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(767, 576);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Score:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScore.ForeColor = System.Drawing.Color.SpringGreen;
            this.lblScore.Location = new System.Drawing.Point(69, 32);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(36, 37);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "0";
            // 
            // lblGameOVer
            // 
            this.lblGameOVer.AutoSize = true;
            this.lblGameOVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGameOVer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGameOVer.Location = new System.Drawing.Point(31, 85);
            this.lblGameOVer.Name = "lblGameOVer";
            this.lblGameOVer.Size = new System.Drawing.Size(197, 39);
            this.lblGameOVer.TabIndex = 3;
            this.lblGameOVer.Text = "Game Over";
            this.lblGameOVer.Visible = false;
            this.lblGameOVer.Click += new System.EventHandler(this.lblGameOVer_Click_1);
            this.lblGameOVer.MouseLeave += new System.EventHandler(this.lblGameOVer_MouseLeave);
            this.lblGameOVer.MouseHover += new System.EventHandler(this.lblGameOVer_MouseHover);
            // 
            // countBody
            // 
            this.countBody.AutoSize = true;
            this.countBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countBody.ForeColor = System.Drawing.Color.SpringGreen;
            this.countBody.Location = new System.Drawing.Point(480, 32);
            this.countBody.Name = "countBody";
            this.countBody.Size = new System.Drawing.Size(36, 37);
            this.countBody.TabIndex = 4;
            this.countBody.Text = "0";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSpeed.ForeColor = System.Drawing.Color.SpringGreen;
            this.lblSpeed.Location = new System.Drawing.Point(212, 32);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(34, 37);
            this.lblSpeed.TabIndex = 5;
            this.lblSpeed.Text = "1";
            // 
            // InfoBar
            // 
            this.InfoBar.BackColor = System.Drawing.Color.ForestGreen;
            this.InfoBar.Controls.Add(this.label3);
            this.InfoBar.Controls.Add(this.countBody);
            this.InfoBar.Controls.Add(this.label2);
            this.InfoBar.Controls.Add(this.lblSpeed);
            this.InfoBar.Controls.Add(this.label1);
            this.InfoBar.Controls.Add(this.lblScore);
            this.InfoBar.Location = new System.Drawing.Point(12, 637);
            this.InfoBar.Name = "InfoBar";
            this.InfoBar.Size = new System.Drawing.Size(767, 69);
            this.InfoBar.TabIndex = 6;
            this.InfoBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(303, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Food Remaining:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(150, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Level:";
            // 
            // timerLabel
            // 
            this.timerLabel.Interval = 400;
            this.timerLabel.Tick += new System.EventHandler(this.timerLabel_Tick);
            // 
            // startNewGame
            // 
            this.startNewGame.Location = new System.Drawing.Point(319, 237);
            this.startNewGame.Name = "startNewGame";
            this.startNewGame.Size = new System.Drawing.Size(130, 55);
            this.startNewGame.TabIndex = 7;
            this.startNewGame.Text = "Start New Game";
            this.startNewGame.UseVisualStyleBackColor = true;
            this.startNewGame.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюИгрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(820, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюИгрыToolStripMenuItem
            // 
            this.менюИгрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.statsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.менюИгрыToolStripMenuItem.Name = "менюИгрыToolStripMenuItem";
            this.менюИгрыToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.менюИгрыToolStripMenuItem.Text = "Game Menu";
            this.менюИгрыToolStripMenuItem.Click += new System.EventHandler(this.менюИгрыToolStripMenuItem_Click);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statsToolStripMenuItem
            // 
            this.statsToolStripMenuItem.Name = "statsToolStripMenuItem";
            this.statsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.statsToolStripMenuItem.Text = "Stats";
            this.statsToolStripMenuItem.Click += new System.EventHandler(this.statsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(820, 718);
            this.Controls.Add(this.startNewGame);
            this.Controls.Add(this.InfoBar);
            this.Controls.Add(this.lblGameOVer);
            this.Controls.Add(this.pbCanvas);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.InfoBar.ResumeLayout(false);
            this.InfoBar.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lblGameOVer;
        private System.Windows.Forms.Label countBody;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Panel InfoBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerLabel;
        private System.Windows.Forms.Button startNewGame;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюИгрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statsToolStripMenuItem;
        private System.Windows.Forms.Timer timerStatus;
    }
}

