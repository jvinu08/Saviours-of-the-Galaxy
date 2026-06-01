using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;


namespace CPT
{
    class Wolf : PictureBox
    {

        //member variables
        private double mSpeed;
        private Vector mPosition;
        private Vector mVelocity;
        private double mAngle;

        //constructors
        public Wolf(double X, double Y, double Angle, 
                                    double Speed, int Size):base()
        {

            //initialize Wolf
            mPosition = new Vector(X, Y);
            this.Left = (int)X;
            this.Top = (int)Y;
            mAngle = Angle;
            //set the velocity of the ball
            mSpeed = Speed;
            double Vx = Speed * Math.Cos(mAngle);
            double Vy = Speed * Math.Sin(mAngle);
            mVelocity = new Vector(Vx, Vy);

            //set the image size
            this.Width = Size;
            this.Height = Size;
            //load image from Assets
            this.BackColor = Color.Transparent;
            this.Image = Assets.Wolf;
            

            this.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Visible = true;


        }


        //methods
        public void MoveTick()
        {
            //move wolf
            mPosition = mPosition + mVelocity;
            this.Left = (int)mPosition.X;
            this.Top = (int)mPosition.Y;

            
        }

        public void BounceY()
        {
            mVelocity.Y = -1 * mVelocity.Y;
        }

        public void BounceX()
        {
            mVelocity.X = -1 * mVelocity.X;
        }

    }
}
