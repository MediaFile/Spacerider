using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SpaceRider
{
    class cAlly : iflyingObject
    {
        private Image image;
        private int x;
        private int y;
        private int horizontal;
        private int ships = 3;
        private bool blink = true;
        private bool showing = true;

        public cAlly(Image shipImage)
        {
            Image = shipImage;
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
                return this.y;
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

        public bool Blink
        {
            get
            {
                return this.blink;
            }
            set
            {
                this.blink = value;
            }
        }

        public int Ships
        {
            get
            {
                return this.ships;
            }
            set
            {
                this.ships = value;
            }
        }
    }

    class cEnemies
    {
        private List<iflyingObject> enemy;
        private Random rnd;

        public cEnemies()
        {
            this.enemy = new List<iflyingObject>();
            rnd = new Random();
        }

        public List<iflyingObject> Enemy
        {
            get
            {
                return enemy;
            }
        }

        public void Newfighter(int X, int Y, Image fighterPic)
        {
            bool found = false;

            foreach (iflyingObject enemy in Enemy)
            {

                if(enemy is cFighter)
                {
                    cFighter fighter = (cFighter)enemy;

                    if (!fighter.Showing)
                    {
                        fighter.X = X;
                        fighter.Y = Y;
                        fighter.Showing = true;
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                cFighter newEnemy;
                newEnemy = new cFighter(fighterPic);
                newEnemy.X = X;
                newEnemy.Y = Y;
                newEnemy.Showing = true;

                enemy.Add(newEnemy);
                found = true;
            }
        }

        public void NewDistroyer(int X, int Y, Image distroyerPic)
        {
            bool found = false;

            foreach (iflyingObject enemy in Enemy)
            {
                if(enemy is cDistroyer)
                {
                    cDistroyer distroyer = (cDistroyer)enemy;

                    if (!distroyer.Showing)
                    {
                        distroyer.X = X;
                        distroyer.Y = Y;
                        distroyer.Horizontal = 0;
                        distroyer.Showing = true;
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                cDistroyer newEnemy;
                newEnemy = new cDistroyer(distroyerPic);
                newEnemy.X = X;
                newEnemy.Y = Y;
                newEnemy.Horizontal = 0;
                newEnemy.Showing = true;

                enemy.Add(newEnemy);
                found = true;
            }
        }


        public void NewCruiser(int X, int Y, Image cruiserPic)
        {
            bool found = false;

            foreach (iflyingObject enemy in Enemy)
            {
                if (enemy is cCruiser)
                {
                    cCruiser cruiser = (cCruiser)enemy;

                    if (!cruiser.Showing)
                    {
                        cruiser.X = X;
                        cruiser.Y = Y;
                        cruiser.Showing = true;
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                cCruiser newEnemy;
                newEnemy = new cCruiser(cruiserPic);
                newEnemy.X = X;
                newEnemy.Y = Y;
                newEnemy.Showing = true;

                enemy.Add(newEnemy);
                found = true;
            }
        }

        public void Move(int level, int range, int width)
        {
            foreach (iflyingObject enemy in Enemy)
            {
                if(enemy is cFighter)
                {
                    MFighter((cFighter)enemy, level, range);
                }

                else if(enemy is cDistroyer)
                {
                    MDistroyer((cDistroyer)enemy, level, range, width);
                }

                else if(enemy is cCruiser)
                {
                    MCruiser((cCruiser)enemy, level, range);
                }
                
            }
        }


        private void MFighter(cFighter fighter, int level, int range)
        {
            fighter.Y += level;
            if (fighter.Y > range)
            {
                fighter.Showing = false;
            }
        }

        private void MDistroyer(cDistroyer distroyer, int level, int range, int width)
        {
            int speed = level / 2;

            if (speed < 1)
            {
                speed = 1;
            }
            distroyer.Y += speed;
            if (distroyer.Horizontal == 0)
            {
                distroyer.Horizontal = rnd.Next(-20, 20);
            }
            if (distroyer.Horizontal < 0)
            {
                distroyer.X -= 2;
                if (distroyer.X < 0)
                {
                    distroyer.Horizontal *= -1;
                }
                distroyer.Horizontal += 1;
            }
            else if (distroyer.Horizontal > 0)
            {
                distroyer.X += 2;
                if (distroyer.X + distroyer.Image.Width > width)
                {
                    distroyer.Horizontal *= -1;
                }
                distroyer.Horizontal -= 1;
            }
            if (distroyer.Y > range)
            {
                distroyer.Showing = false;
            }

        }

        private void MCruiser(cCruiser cruiser, int level, int range)
        {
            int speed = level / 3;

            if (speed < 1)
            {
                speed = 1;
            }
            cruiser.Y += speed;
            if (cruiser.Y > range)
            {
                cruiser.Showing = false;
            }
        }
    }

    class cFighter : iflyingObject
    {
        private Image image;
        private int x;
        private int y;
        private int horizontal;
        private bool showing;
        
        public cFighter(Image image)
        {
            Image = image;
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
                return this.y;
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

    class cDistroyer : iflyingObject
    {
        private Image image;
        private int x;
        private int y;
        private int horizontal;
        private bool showing;
        
        public cDistroyer(Image image)
        {
            Image = image;
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
                return this.y;
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

    class cCruiser : iflyingObject
    {
        private Image image;
        private int x;
        private int y;
        private int horizontal;
        private bool showing;
        
        public cCruiser(Image image)
        {
            Image = image;
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
                return this.y;
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
