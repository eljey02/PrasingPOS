using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public class RoundedPanel : Panel
    {
        private int _radius = 20;
        private Color _borderColor = Color.Transparent;
        private int _borderWidth = 0;

        public int Radius
        {
            get => _radius;
            set { _radius = value; Invalidate(); }
        }

        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        public int BorderWidth
        {
            get => _borderWidth;
            set { _borderWidth = value; Invalidate(); }
        }

        public RoundedPanel()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath path = GetRoundedPath(rect, _radius);

            // Fill background
            using (SolidBrush brush = new SolidBrush(BackColor))
                g.FillPath(brush, path);

            // Draw border if set
            if (_borderWidth > 0 && _borderColor != Color.Transparent)
            {
                using (Pen pen = new Pen(_borderColor, _borderWidth))
                    g.DrawPath(pen, path);
            }

            // Clip child controls to rounded shape
            Region = new Region(path);
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);                              // top-left
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);                      // top-right
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);               // bottom-right
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);                      // bottom-left
            path.CloseFigure();

            return path;
        }
    }
}
