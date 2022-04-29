using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceRider
{
    class cGame
    {
        private Timer mainTimer;
        private PictureBox drawPic;
        private cAlly ship;
        private cEnemies enemies;
        private cBullets bullets;
        private int blink = 1;

        public cGame(PictureBox aPictureBox)
        {
            drawPic = aPictureBox;
            drawPic.Image = new Bitmap(drawPic.Width, drawPic.Height);

            ship = new cAlly(new Bitmap(Application.StartupPath + "\\Ship.png"));
            ship.Y = drawPic.Height - ship.Image.Height;
            ship.X = (drawPic.Width / 2) - (ship.Image.Width / 2);

            enemies = new cEnemies();
            bullets = new cBullets();
            
            mainTimer = new Timer();
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Interval = 1;
            mainTimer.Enabled = true;
        }

        private void DrawGame()
        {
            Graphics g;
            g = Graphics.FromImage(drawPic.Image);
            g.Clear(Color.Black);

            //Draw ship
            if (ship.X > drawPic.Width - ship.Image.Width)
            {
                ship.X = drawPic.Width - ship.Image.Width;
            }
            if(Ship.Showing)
                g.DrawImage(ship.Image, ship.X, ship.Y);

            //Draw bullet
            foreach(iflyingObject bullet in bullets.Bullets )
            {
                if (bullet is cBullet)
                {
                    cBullet allyFire = (cBullet)bullet;
                    if (allyFire.Showing)
                    {
                        g.DrawImage(allyFire.Image, allyFire.X, allyFire.Y);
                    }
                }
                else if (bullet is cEnemyBullet)
                {
                    cEnemyBullet hostileFire = (cEnemyBullet)bullet;
                    if (hostileFire.Showing)
                    {
                        g.DrawImage(hostileFire.Image, hostileFire.X, hostileFire.Y);
                    }
                }
                else if (bullet is cStingerBullet)
                {
                    cStingerBullet hostileFire = (cStingerBullet)bullet;
                    if (hostileFire.Showing)
                    {
                        g.DrawImage(hostileFire.Image, hostileFire.X, hostileFire.Y);
                    }
                }
            }

            //Draw enemy
            foreach (iflyingObject enemy in enemies.Enemy)
            {
                if(enemy is cFighter)
                {
                    cFighter hostile = (cFighter)enemy;
                    if (hostile.Showing)
                    {
                        g.DrawImage(hostile.Image, hostile.X, hostile.Y);
                    }
                }
                else if(enemy is cCruiser)
                {
                    cCruiser hostile = (cCruiser)enemy;
                    if (hostile.Showing)
                    {
                        g.DrawImage(hostile.Image, hostile.X, hostile.Y);
                    }
                }
                else if (enemy is cDistroyer)
                {
                    cDistroyer hostile = (cDistroyer)enemy;
                    if (hostile.Showing)
                    {
                        g.DrawImage(hostile.Image, hostile.X, hostile.Y);
                    }
                }
            }

            drawPic.Refresh();
        }

        private void ShipBLink()
        {
            if (Ship.Blink)
            {
                blink -= 1;
                if (blink % 16 == 0)
                {
                    Ship.Showing = true;
                }
                else if (blink % 16 == 8)
                {
                    Ship.Showing = false;
                }
                if (blink == 0)
                {
                    Ship.Blink = false;
                    blink = 160;
                }
            }
        }

        private void Allienhit()
        {
            foreach(iflyingObject enemy in enemies.Enemy)
            {
                if(enemy is cFighter)
                {
                    cFighter Allien = (cFighter)enemy;
                    if (!Ship.Blink)
                    {
                        if (Allien.Showing)
                        {
                            if (Allien.Y + Allien.Image.Height > Ship.Y)
                            {
                                if (Allien.X >= Ship.X && (Allien.X + Allien.Image.Width) <= (Ship.X + Ship.Image.Width))
                                {
                                    Ship.Blink = true;
                                }
                            }
                        }
                    }
                }
                else if(enemy is cDistroyer)
                {
                    cDistroyer Allien = (cDistroyer)enemy;
                    if (!Ship.Blink)
                    {
                        if (Allien.Showing)
                        {
                            if (Allien.Y + Allien.Image.Height > Ship.Y)
                            {
                                if (Allien.X >= Ship.X && (Allien.X + Allien.Image.Width) <= (Ship.X + Ship.Image.Width))
                                {
                                    Ship.Blink = true;
                                }
                            }
                        }
                    }
                }
                else if(enemy is cCruiser)
                {
                    cCruiser Allien = (cCruiser)enemy;
                    if (!Ship.Blink)
                    {
                        if (Allien.Showing)
                        {
                            if (Allien.Y + Allien.Image.Height > Ship.Y)
                            {
                                if (Allien.X >= Ship.X && (Allien.X + Allien.Image.Width) <= (Ship.X + Ship.Image.Width))
                                {
                                    Ship.Blink = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AllienBullethit()
        {
            foreach (iflyingObject bullet in bullets.Bullets)
            {
                if(bullet is cEnemyBullet)
                {
                    cEnemyBullet projectile = (cEnemyBullet)bullet;
                    if (!Ship.Blink)
                    {
                        if (projectile.Y + projectile.Image.Height > Ship.Y)
                        {
                            if (projectile.X >= Ship.X && (projectile.X + projectile.Image.Width) <= (Ship.X + Ship.Image.Width))
                            {
                                Ship.Blink = true;
                            }
                        }
                    }
                }
                else if(bullet is cStingerBullet)
                {
                    cStingerBullet projectile = (cStingerBullet)bullet;
                    if (!Ship.Blink)
                    {
                        if (projectile.Y + projectile.Image.Height > Ship.Y)
                        {
                            if(projectile.X >= Ship.X && (projectile.X + projectile.Image.Width) <= (Ship.X + Ship.Image.Width))
                            {
                                Ship.Blink = true;
                            }
                        }
                    }
                }
            }
        }

        private void Allybullethit()
        {
            //Hit by Ally bullets
            foreach(iflyingObject bullet in bullets.Bullets )
            {
                if(bullet is cBullet)
                {
                    cBullet projectile = (cBullet)bullet;
                    if (projectile.Showing)
                    {
                        foreach (iflyingObject enemy in enemies.Enemy)
                        {
                            if (enemy is cFighter)
                            {
                                cFighter hostile = (cFighter)enemy;
                                if (hostile.Showing)
                                {
                                    if (projectile.Y > hostile.Y && projectile.Y < hostile.Y + hostile.Image.Height)
                                    {
                                        if (projectile.X > hostile.X && projectile.X < hostile.X + hostile.Image.Width)
                                        {
                                            hostile.Showing = false;
                                            projectile.Showing = false;
                                        }
                                    }
                                }
                            }
                            if (enemy is cDistroyer)
                            {
                                cDistroyer hostile = (cDistroyer)enemy;
                                if (hostile.Showing)
                                {
                                    if (projectile.Y > hostile.Y && projectile.Y < hostile.Y + hostile.Image.Height)
                                    {
                                        if (projectile.X > hostile.X && projectile.X < hostile.X + hostile.Image.Width)
                                        {
                                            hostile.Showing = false;
                                            projectile.Showing = false;
                                        }
                                    }
                                }
                            }
                            if (enemy is cCruiser)
                            {
                                cCruiser hostile = (cCruiser)enemy;
                                if (hostile.Showing)
                                {
                                    if (projectile.Y > hostile.Y && projectile.Y < hostile.Y + hostile.Image.Height)
                                    {
                                        if (projectile.X > hostile.X && projectile.X < hostile.X + hostile.Image.Width)
                                        {
                                            hostile.Showing = false;
                                            projectile.Showing = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void NewAllien(int level)
        {
            Random rnd = new Random();
            switch (level)
            {
                case 1:
                    if(rnd.Next(200) == 100)
                        enemies.Newfighter(rnd.Next(drawPic.Width - new Bitmap(Application.StartupPath + "\\AlienShip.png").Width), 0, new Bitmap(Application.StartupPath + "\\AlienShip.png"));
                    break;
                case 2:
                    if (rnd.Next(100) == 50)
                        enemies.Newfighter(rnd.Next(drawPic.Width - new Bitmap(Application.StartupPath + "\\AlienShip.png").Width), 0, new Bitmap(Application.StartupPath + "\\AlienShip.png"));
                    if(rnd.Next(200) == 100)
                        enemies.NewDistroyer(rnd.Next(drawPic.Width - new Bitmap(Application.StartupPath + "\\AlienShip.png").Width), 0, new Bitmap(Application.StartupPath + "\\AlienShip.png"));
                    break;
                case 3:
                    if (rnd.Next(60) == 30)
                        enemies.Newfighter(rnd.Next(drawPic.Width - new Bitmap(Application.StartupPath + "\\AlienShip.png").Width), 0, new Bitmap(Application.StartupPath + "\\AlienShip.png"));
                    if (rnd.Next(200) == 100)
                        enemies.NewDistroyer(rnd.Next(drawPic.Width - new Bitmap(Application.StartupPath + "\\AlienShip.png").Width), 0, new Bitmap(Application.StartupPath + "\\AlienShip.png"));
                    break;
                case 4:
                    if (rnd.Next(30) == 15)
                        enemies.Newfighter(rnd.Next(drawPic.Width - new Bitmap(Application.StartupPath + "\\AlienShip.png").Width), 0, new Bitmap(Application.StartupPath + "\\AlienShip.png"));
                    if (rnd.Next(100) == 50)
                        enemies.NewDistroyer(rnd.Next(drawPic.Width - new Bitmap(Application.StartupPath + "\\AlienShip.png").Width), 0, new Bitmap(Application.StartupPath + "\\AlienShip.png"));
                    if (rnd.Next(200) == 100)
                        enemies.NewCruiser(rnd.Next(drawPic.Width - new Bitmap(Application.StartupPath + "\\AlienShip.png").Width), 0, new Bitmap(Application.StartupPath + "\\AlienShip.png"));
                    
                    int nr = rnd.Next(10);
                    foreach (iflyingObject enemy in enemies.Enemy)
                    {
                        if (enemy is cDistroyer)
                        {
                            if (nr == 0)
                            {
                                cDistroyer distroyer = (cDistroyer)enemy;
                                if(rnd.Next(20) == 10)
                                    bullets.NewEnemyBullet(distroyer.X, distroyer.Y, new Bitmap(Application.StartupPath + "\\EnemyBullet.png"));
                            }
                            nr--;
                        }
                    }
                    break;
                case 5:
                    if (rnd.Next(10) == 5)
                        enemies.Newfighter(rnd.Next(drawPic.Width - new Bitmap(Application.StartupPath + "\\AlienShip.png").Width), 0, new Bitmap(Application.StartupPath + "\\AlienShip.png"));
                    if (rnd.Next(100) == 50 || rnd.Next(200) == 75)
                        enemies.NewDistroyer(rnd.Next(drawPic.Width - new Bitmap(Application.StartupPath + "\\AlienShip.png").Width), 0, new Bitmap(Application.StartupPath + "\\AlienShip.png"));
                    if (rnd.Next(100) == 50)
                        enemies.NewCruiser(rnd.Next(drawPic.Width - new Bitmap(Application.StartupPath + "\\AlienShip.png").Width), 0, new Bitmap(Application.StartupPath + "\\AlienShip.png"));
                    
                    int nrDistroyer = rnd.Next(10);
                    int nrCruiser = rnd.Next(20);
                    foreach (iflyingObject enemy in enemies.Enemy)
                    {
                        if (enemy is cDistroyer)
                        {
                            if (nrDistroyer == 0)
                            {
                                cDistroyer distroyer = (cDistroyer)enemy;
                                if(rnd.Next(20) == 10)
                                    bullets.NewEnemyBullet(distroyer.X, distroyer.Y, new Bitmap(Application.StartupPath + "\\EnemyBullet.png"));
                            }
                            nrDistroyer--;
                        }
                        if (enemy is cCruiser)
                        {
                            if (nrCruiser == 0)
                            {
                                cCruiser distroyer = (cCruiser)enemy;
                                if (rnd.Next(20) == 10)
                                    bullets.NewStingerBullet(distroyer.X, distroyer.Y, new Bitmap(Application.StartupPath + "\\StingerBullet.png"));
                            }
                            nrCruiser--;
                        }
                    }
                    break;
            }

        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            enemies.Move(1, drawPic.Height, drawPic.Width);
            bullets.Bulletprogressive(ship, 1, drawPic.Height);
            NewAllien(1);
            Allybullethit();
            AllienBullethit();
            Allienhit();
            ShipBLink();

            DrawGame();
        }

        public cAlly Ship
        {
            get
            {
                return this.ship;
            }
        }

        public cBullets Bullets
        {
            get
            {
                return this.bullets;
            }
        }
    }
}
