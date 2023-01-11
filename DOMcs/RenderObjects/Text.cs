using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOMcs.RenderObjects
{
    internal class Text : IRenderObject
    {
        public Label textLabel;

        public Text(string _text="")
        {
            textLabel = new Label();
            textLabel.Text = _text;
            textLabel.AutoSize = true;

            textLabel.MouseEnter += onMouseEnter;
            textLabel.MouseHover += onMouseHover;
            textLabel.MouseLeave += onMouseLeave;
            textLabel.MouseClick += onMouseClick;
        }
        public Control _return() { return textLabel; }

        public Action _mouseEnter = () => { };
        public Action _mouseHover = () => { };
        public Action _mouseLeave = () => { };
        public Action _mouseClick = () => { };
        public void onMouseEnter(object sender, System.EventArgs e)
        {
            _mouseEnter();
        }

        public void onMouseHover(object sender, System.EventArgs e)
        {
            _mouseHover();
        }

        public void onMouseLeave(object sender, System.EventArgs e)
        {
            _mouseLeave();
        }

        public void onMouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _mouseClick();
        }
    }
}
