using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void user_Load(object sender, EventArgs e)
        {
            timer1.Start();

            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 2; // thickness
            button6.FlatAppearance.BorderColor = Color.Maroon;

            GraphicsPath path = new GraphicsPath();
            int radius = 20; // corner radius
            Rectangle rect = button6.ClientRectangle;

            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            button6.Region = new Region(path);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0; // removes border

            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48); // highlight color
            button6.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28); // pressed color


        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0; // removes border

            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48); // highlight color
            button5.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28); // pressed color
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0; // removes border

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48); // highlight color
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28); // pressed color
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0; // removes border

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48); // highlight color
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28); // pressed color
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0; // removes border

            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48); // highlight color
            button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28); // pressed color
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0; // removes border

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48); // highlight color
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28); // pressed color
        }
    }
}
