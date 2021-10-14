using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Seminarski
{
    public partial class Forma : Form
    {
        private CustomPicture ship;
        private bool gameStopped = true, leftMovement, rightMovement, upMovement, downMovement;
        private int gameMode=1, eggSpeed = 2, shipSpeed = 10, bulletSpeed = 50, chickenSpeed = 2, 
            pictureIndex = 0, temp = 1, score, lives=3, chickenLife=3, eggFrequency = 100;
        private List<CustomPicture> bullets = new List<CustomPicture>();
        private List<Bitmap> chickenImageList = new List<Bitmap>();
        private List<Bitmap> brokenEggList = new List<Bitmap>();
        private CustomPicture[,] chickenMatrix = new CustomPicture[3, 8];
        private Bitmap originalPictureChicken = Properties.Resources.crvenoPile;
        private Bitmap originalPictureBrokenEgg = Properties.Resources.slomljenoJaje;
        private Button startButton = new Button();
        private Button options = new Button();
        private Button easy, medium, hard;
        private Random rand = new Random();
        private List<CustomPicture> listEggs = new List<CustomPicture>();


        public Forma()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Width = 900;
            this.Height = 600;
            SetButtons();
            CutPicture(originalPictureChicken, chickenImageList, 10);
            CutPicture(originalPictureBrokenEgg, brokenEggList, 8);
            modeLabel.Font = livesLabel.Font;
            modeLabel.Text = "Mod: Lako";
            Controls.Add(modeLabel);
            this.Icon = Icon.FromHandle(chickenImageList[9].GetHicon());

        }

        private void SetButtons()
        {
            CreateButton(options, "Opcije ", 200);
            CreateButton(startButton, "Start", 100);
            startButton.Click += new EventHandler(StartGame);
            options.Click += new EventHandler(ShowOptions);
            
        }

        private void EasyMode(Object sender, EventArgs e)
        {
            
            gameMode = 1;
            Controls.Remove(easy);
            Controls.Remove(medium);
            Controls.Remove(hard);
            Controls.Add(startButton);
            Controls.Add(options);
            modeLabel.Text = "Mod: Lako";
            Controls.Add(modeLabel);
        }

        private void MediumMode(Object sender, EventArgs e)
        {
            
            gameMode = 2;
            Controls.Remove(easy);
            Controls.Remove(medium);
            Controls.Remove(hard);
            Controls.Add(startButton);
            Controls.Add(options);
            modeLabel.Text = "Mod: Srednje";
            Controls.Add(modeLabel);
        }

        private void HardMode(Object sender, EventArgs e)
        {
            
            gameMode = 3;
            Controls.Remove(easy);
            Controls.Remove(medium);
            Controls.Remove(hard);
            Controls.Add(startButton);
            Controls.Add(options);
            modeLabel.Text = "Mod: Tesko";
            Controls.Add(modeLabel);
        }
        
        private void ShowOptions(Object sender, EventArgs e)
        {
            
            Controls.Remove(startButton);
            Controls.Remove(options);
            Controls.Remove(modeLabel);
            easy = new Button();
            medium = new Button();
            hard = new Button();
            CreateButton(easy, "Lako", 100);
            CreateButton(medium, "Srednje", 200);
            CreateButton(hard, "Tesko", 300);
            easy.Click += new EventHandler(EasyMode);
            medium.Click += new EventHandler(MediumMode);
            hard.Click += new EventHandler(HardMode);
        }

        private void StartGame(Object sender, EventArgs e)
        {
            if (gameMode == 1)
            {
                lives = 3;
                chickenLife = 3;
                chickenSpeed = 2;
                eggSpeed = 2;
                eggFrequency = 100;
            }
            else if (gameMode == 2)
            {
                lives = 2;
                chickenLife = 5;
                chickenSpeed = 3;
                eggSpeed = 4;
                eggFrequency = 80;
            }
            else
            {
                lives = 2;
                chickenLife = 10;
                chickenSpeed = 4;
                eggSpeed = 6;
                eggFrequency = 40;
            }
            gameStopped = false;
            upMovement = false;
            downMovement = false;
            leftMovement = false;
            rightMovement = false;
            Controls.Remove(startButton);
            Controls.Remove(options);
            Controls.Add(scoreLabel);
            Controls.Add(livesLabel);
            Controls.Remove(modeLabel);
            CreateShip();
            CreateChicken();
            eggTimer.Start();
            chickenTimer.Start();
            shipTimer.Start();
            bulletTimer.Start();
            score = 0;
            scoreLabel.Text = "Rezultat : "+score;
            livesLabel.Text = "Zivot : "+lives;
            livesLabel.Top = scoreLabel.Top;
            livesLabel.Font = scoreLabel.Font;
            scoreLabel.BackColor = Color.Transparent;


        }

        private void StopGame()
        {
            gameStopped = true;
            Controls.Add(startButton);
            Controls.Add(options);
            Controls.Add(modeLabel);
            Controls.Remove(ship);
            Controls.Remove(scoreLabel);
            Controls.Remove(livesLabel);
            chickenTimer.Stop();
            shipTimer.Stop();
            bulletTimer.Stop();
            eggTimer.Stop();
            for (int i=0;i<3;i++)
                for (int j=0;j<8;j++)
                    Controls.Remove(chickenMatrix[i,j]);
            foreach (CustomPicture egg in listEggs) Controls.Remove(egg);
            foreach (CustomPicture bullet in bullets) Controls.Remove(bullet);
            listEggs.Clear();
            bullets.Clear();
            
        }

        private void CreateButton(Button button, String text, int height)
        {
            button.Width = 300;
            button.Height = 50;
            button.Text = text;
            button.Left = this.Width / 2 - button.Width / 2;
            button.Top = height;
            button.BackColor = Color.White;
            button.Font = new Font("Arial", 24);
            Controls.Add(button);
            
        }

        private void CreateEgg()
        {
            List<CustomPicture> liveChicken = new List<CustomPicture>();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 8; j++)
                    if (chickenMatrix[i, j].getVisible()) liveChicken.Add(chickenMatrix[i,j]);
            if (liveChicken.Count>0)
            {
                CustomPicture pile = liveChicken[rand.Next() % liveChicken.Count];
                CustomPicture jaje = new CustomPicture(10, 10);
                jaje.Image = Properties.Resources.jaje;
                jaje.Top = pile.Top + pile.Width;
                jaje.Left = pile.Left + pile.Width / 2 - jaje.Width / 2;
                listEggs.Add(jaje);
                Controls.Add(jaje);
            }
           
        }


        private void CreateChicken()
        {
            Bitmap picture = chickenImageList[0];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    CustomPicture chicken = new CustomPicture(picture.Width, picture.Height);
                    chicken.setLives(chickenLife);
                    chicken.Image = picture;
                    chicken.Left = j * 100;
                    chicken.Top = i * 100 + picture.Height;
                    chickenMatrix[i, j] = chicken;
                    Controls.Add(chicken);

                }
            }
        }

        private void CutPicture(Bitmap image, List<Bitmap> list, int pieces)
        {
            int width = image.Width / pieces;
            int height = image.Height;

            for (int i = 0; i < pieces; i++)
            {
                int partIndex = i * width;
                Bitmap picturePart = new Bitmap(width, height);

                for (int j = 0; j < height; j++)
                    for (int k = 0; k < width; k++)
                        picturePart.SetPixel(k, j, image.GetPixel(k + partIndex, j));
                list.Add(picturePart);
            }

        }

        

        private void CreateShip()
        {

            ship = new CustomPicture(80, 80);
            ship.Image = Properties.Resources.ship;
            ship.Location = new Point((Width / 2) - (ship.Width / 2), (Height) - (ship.Height * 2));
            Controls.Add(ship);

        }

        private void SetResult(int rezultat)
        {
            scoreLabel.Text = "Rezultat : " + rezultat.ToString();
        }


        private async void CollisionBulletChicken(CustomPicture metak)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (metak.Bounds.IntersectsWith(chickenMatrix[i, j].Bounds) && chickenMatrix[i, j].getVisible())
                    {
                        if (chickenMatrix[i, j].getLives() > 0)
                        {
                            chickenMatrix[i, j].Top -= 10;
                            chickenMatrix[i, j].isShot();
                            metak.Top = 0;
                            Controls.Remove(metak);
                            await System.Threading.Tasks.Task.Delay(200);
                            chickenMatrix[i, j].Top += 10;

                        }
                        else
                        {
                            chickenMatrix[i, j].setVisible(false);
                            Controls.Remove(chickenMatrix[i, j]);
                            metak.Top = 0;
                            Controls.Remove(metak);
                            score++;
                            SetResult(score);
                        }
                    }
                }
            }
        }

        private void CreateBullet()
        {
            CustomPicture metak = new CustomPicture(8, 8);
            metak.Left = ship.Left + ship.Width / 2 - metak.Width / 2;
            metak.Top = ship.Top - metak.Height;
            metak.Image = Properties.Resources.metak2;
            bullets.Add(metak);
            this.Controls.Add(metak);

        }

        private void EggTimerTick(object sender, EventArgs e)
        {
            if (!gameStopped)
            {
                if (rand.Next(eggFrequency) == 5)
                    CreateEgg();
                for (int i = 0; i < listEggs.Count; i++)
                {
                    listEggs[i].Top += eggSpeed;
                    if (ship.Bounds.IntersectsWith(listEggs[i].Bounds) && listEggs[i].getVisible())
                    {
                        Controls.Remove(listEggs[i]);
                        listEggs[i].setVisible(false);
                        ship.Location = new Point((Width / 2) - (ship.Width / 2), (Height) - (ship.Height * 2));
                        lives--;
                        livesLabel.Text = "Zivot : " + lives.ToString();

                    }
                    if (listEggs[i].Top >= (550))
                    {
                        for (int j = 0; j < brokenEggList.Count; j++)
                        {
                            listEggs[i].Top = 550;
                            listEggs[i].Image = brokenEggList[j];

                        }

                    }
                }
                if (listEggs.Count>7)
                {
                    listEggs.RemoveAt(0);
                    Controls.Remove(listEggs[0]);
                }
            }

        }


        private void bulletTick(object sender, EventArgs e)
        { 
            foreach (CustomPicture metak in bullets)
            {
                metak.Top -= bulletSpeed;
                CollisionBulletChicken(metak);


            }

        }

        private void chickenTick(object sender, EventArgs e)
        {
            if (chickenMatrix[0, 0].Left < 0 || chickenMatrix[0, 0].Left > this.Width-800)
            {
                chickenSpeed = -chickenSpeed;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    chickenMatrix[i, j].Image = chickenImageList[pictureIndex];
                    chickenMatrix[i, j].Left += chickenSpeed;
                }
            }
            pictureIndex += temp;
            temp = pictureIndex == 9 ? -1 : (pictureIndex == 0 ? 1 : temp);
            if (score==24)
            {
                StopGame();
                MessageBox.Show("Pobedili ste!");
            }
        }

        private void shipTick(object sender, EventArgs e)
        {
            if (upMovement && ship.Top > (ship.Height / 2))
            {
                ship.Top -= shipSpeed;
            }

            if (downMovement && ship.Top < ((Height) - (ship.Height * 2)))
            {
                ship.Top += shipSpeed;
            }

            if (leftMovement && ship.Left > 0)
            {
                ship.Left -= shipSpeed;
            }

            if (rightMovement && ship.Left < this.Width-ship.Width-10)
            {
                ship.Left += shipSpeed;
            }
            if (lives==0)
            {
                StopGame();
                MessageBox.Show("Izgubili ste! Vas rezultat je: " + score);
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chickenMatrix[i, j].Bounds.IntersectsWith(ship.Bounds) && chickenMatrix[i,j].getVisible())
                    {
                        ship.Location = new Point((Width / 2) - (ship.Width / 2), (Height) - (ship.Height * 2));
                        lives--;
                        livesLabel.Text = "Zivot : " + lives.ToString();
                    }
                }
            }

        }


        private void key_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                upMovement = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                downMovement = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                leftMovement = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                rightMovement = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                StopGame();
                Controls.Remove(scoreLabel);
                Controls.Remove(livesLabel);
            }



        }

        private void key_Up(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                upMovement = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                downMovement = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                leftMovement = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                rightMovement = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                if (!gameStopped)
                {
                    CreateBullet();
                }
                
            }

        }

    }


}
