using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMcs
{
    interface IRenderObject
    {
        void onMouseEnter(object sender, System.EventArgs e);
        void onMouseHover(object sender, System.EventArgs e);
        void onMouseLeave(object sender, System.EventArgs e);
        void onMouseClick(object sender, System.Windows.Forms.MouseEventArgs e);
    }
}
