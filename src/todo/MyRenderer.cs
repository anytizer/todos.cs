using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace todo
{
    public class MyRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected) base.OnRenderMenuItemBackground(e);
            else
            {
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                e.Graphics.FillRectangle(Brushes.Beige, rc);
                e.Graphics.DrawRectangle(Pens.Black, 1, 0, rc.Width - 2, rc.Height - 1);
            }
        }
    }
}
