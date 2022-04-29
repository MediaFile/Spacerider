using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceRider
{
    class cBullets
    {
        private List<iflyingObject> bullets;

        public cBullets()
        {
            bullets = new List<iflyingObject>();
        }

        public void NewAllyBullet(int X, int Y, Image bulletPic)
        {
            bool found = false;

            foreach( iflyingObject bullet in bullets )
            {
                if(bullet is cBullet)
                {
                    cBullet projectile = (cBullet) bullet;
                    if (!projectile.Showing)
                    {
                        projectile.X = X;
                        projectile.Y = Y;
                        projectile.Showing = true;
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                cBullet NewBlt;
                NewBlt = new cBullet(bulletPic);
                NewBlt.X = X;
                NewBlt.Y = Y;
                NewBlt.Showing = true;

                Bullets.Add(NewBlt);
                found = true;
            }
        }

        public void NewEnemyBullet(int X, int Y, Image bulletPic)
        {
            bool found = false;

            foreach (iflyingObject bullet in bullets)
            {
                if (bullet is cEnemyBullet)
                {
                    cEnemyBullet projectile = (cEnemyBullet)bullet;
                    if (!projectile.Showing)
                    {
                        projectile.X = X;
                        projectile.Y = Y;
                        projectile.Showing = true;
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                cEnemyBullet NewBlt;
                NewBlt = new cEnemyBullet(bulletPic);
                NewBlt.X = X;
                NewBlt.Y = Y;
                NewBlt.Showing = true;

                Bullets.Add(NewBlt);
                found = true;
            }
        }

        public void NewStingerBullet(int X, int Y, Image bulletPic)
        {
            bool found = false;

            foreach (iflyingObject bullet in bullets)
            {
                if (bullet is cStingerBullet)
                {
                    cStingerBullet projectile = (cStingerBullet)bullet;
                    if (!projectile.Showing)
                    {
                        projectile.X = X;
                        projectile.Y = Y;
                        projectile.Showing = true;
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                cStingerBullet NewBlt;
                NewBlt = new cStingerBullet(bulletPic);
                NewBlt.X = X;
                NewBlt.Y = Y;
                NewBlt.Showing = true;

                Bullets.Add(NewBlt);
                found = true;
            }
        }

        public List<iflyingObject> Bullets
        {
            get
            {
                return this.bullets;
            }
        }

        public void Bulletprogressive(cAlly ship, int level, int range)
        {
            foreach (iflyingObject bullet in bullets )
            {
                if(bullet is cBullet)
                {
                    cBullet projectile = (cBullet)bullet;
                    if (projectile.Showing)
                    {
                        projectile.Y -= 2;
                    }
                    if(projectile.Y + projectile.Image.Height < 0)
                    {
                        projectile.Showing = false;
                    }
                }
                else if(bullet is cEnemyBullet)
                {
                    cEnemyBullet projectile = (cEnemyBullet)bullet;
                    if (projectile.Showing)
                    {
                        projectile.Y += level * 2;
                    }
                    if(projectile.Y > range)
                    {
                        projectile.Showing = false;
                    }
                }
                else if (bullet is cStingerBullet)
                {
                    cStingerBullet projectile = (cStingerBullet)bullet;
                    if (projectile.Showing)
                    {
                        projectile.Y += level * 2;
                        if (ship.X < projectile.X)
                        {
                            projectile.X -= 2;
                        }
                        else
                        {
                            projectile.X += 2;
                        }
                    }
                    if(projectile.Y > range)
                    {
                        projectile.Showing = false;
                    }
                }
            }
        }
    }

    class cBullet : iflyingObject
    {
        private Image image; 
        private int x;
        private int y;
        private int horizontal;
        private bool showing;

        public cBullet(Image bulletPic)
        {
            Image = bulletPic;
        }

        public Image Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                this.y = value;
            }
        }

        public bool Showing
        {
            get
            {
                return this.showing;
            }
            set
            {
                this.showing = value;
            }
        }


        public int Horizontal
        {
            get
            {
                return this.horizontal;
            }
            set
            {
                this.horizontal = value;
            }
        }
    }

    class cEnemyBullet : iflyingObject
    {
        private Image image;
        private int x;
        private int y;
        private int horizontal;
        private bool showing;

        public cEnemyBullet(Image bulletPic)
        {
            Image = bulletPic;
        }

        public Image Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                this.y = value;
            }
        }

        public bool Showing
        {
            get
            {
                return this.showing;
            }
            set
            {
                this.showing = value;
            }
        }


        public int Horizontal
        {
            get
            {
                return this.horizontal;
            }
            set
            {
                this.horizontal = value;
            }
        }
    }

    class cStingerBullet : iflyingObject
    {
        private Image image;
        private int x;
        private int y;
        private bool showing;
        private int horizontal;

        public cStingerBullet(Image bulletPic)
        {
            Image = bulletPic;
        }

        public Image Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                this.y = value;
            }
        }

        public bool Showing
        {
            get
            {
                return this.showing;
            }
            set
            {
                this.showing = value;
            }
        }


        public int Horizontal
        {
            get
            {
                return this.horizontal;
            }
            set
            {
                this.horizontal = value;
            }
        }
    }
}
