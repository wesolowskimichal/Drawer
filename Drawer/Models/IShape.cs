using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Drawer.Models
{
    public interface IShape
    {
        int X1 { get; set; }
        int Y1 { get; set; }
        Brush Brush { get; set; }
        double Stroke { get; set; }

        void DrawShape(MouseEventArgs e);
    }
}
