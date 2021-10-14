using System.Drawing;
using System.Windows.Forms;

namespace Seminarski
{
    class CustomPicture : PictureBox
    {
        private int lives = 2;
        private bool visible = true;

        public CustomPicture(int sirina, int visina)
        {
            Width = sirina;
            Height = visina;
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;
            BringToFront();
        }

        public bool getVisible()
        {
            return visible;
        }

        public void setVisible(bool visible)
        {
            this.visible = visible;
        }

        public int getLives()
        {
            return lives;
        }
        public void setLives(int life)
        {
            this.lives = life;
        }

        public void isShot()
        {
            if (lives > 0)
            {
                lives--;
            }
        }
    }
}
