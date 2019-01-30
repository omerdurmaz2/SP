using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace sp
{
    class ButtonEllipse : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {

            GraphicsPath graphics = new GraphicsPath();
            graphics.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(graphics);

            base.OnPaint(pevent);
        }
    }
}
