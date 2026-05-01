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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Get the panel’s rectangle
            Rectangle rect = ((Panel)sender).ClientRectangle;

            // Define gradient colors (deep maroon to warm red)
            Color startColor = Color.FromArgb(255, 0, 0);   // Dark Maroon
            Color endColor = Color.FromArgb(139, 0, 0); // Firebrick Red

            // Create gradient brush
            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                startColor,
                endColor,
                LinearGradientMode.Vertical)) // Gradient direction
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user user2 = new user();

            user2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
