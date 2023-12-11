using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Drawer.Models
{
    public class LineModel : IShape
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public Brush Brush {get; set; }
        public double Stroke { get; set; }

        public void DrawShape(MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                X2 = (int)e.GetPosition(null).X;
                Y2 = (int)e.GetPosition(null).Y;
            }
        }

    }
}
