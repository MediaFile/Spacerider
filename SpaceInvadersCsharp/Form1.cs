using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpaceRider
{
    public partial class Form1 : Form
    {
        cGame game;

        public Form1()
        {
            InitializeComponent();
            MainPic.MouseMove += new MouseEventHandler(MainPic_MouseMove);
            MainPic.MouseDown += new MouseEventHandler(MainPic_MouseDown);
        }

        void MainPic_MouseDown(object sender, MouseEventArgs e)
        {
            game.Bullets.NewAllyBullet((game.Ship.X + game.Ship.Image.Width / 2) - 3, game.Ship.Y, new Bitmap(Application.StartupPath + "\\Bullet.png"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new cGame(MainPic);
        }

        void MainPic_MouseMove(object sender, MouseEventArgs e)
        {
            game.Ship.X = e.X;
        }

    }
}