using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOMcs.RenderObjects
{
    internal class Button
    {
        public Div btn;
        public Text inner;

        public int[] backgroundColor = new int[4]; // RGBA
        public int[] hoverBackgroundColor = new int[4]; // RGBA

        public Button(string _inner = "Click me")
        {
            btn = new Div();
            backgroundColor = new int[4] {255, 255, 255, 255};
            setBackgroundColor(backgroundColor[0], backgroundColor[1], backgroundColor[2], backgroundColor[3]);

            inner = new Text(_inner);
            btn.insert(inner._return(), 0, 0);
            btn.controlAtCenter(true);
        }
        public Control _return() { return btn._return(); }

        public void refresh()
        {
            updateBackgroundColor(backgroundColor);

            btn._mouseEnter = _mouseEnter;
            btn._mouseHover = _mouseHover;
            btn._mouseLeave = _mouseLeave;
            btn._mouseClick = _mouseClick;

            inner._mouseEnter = _mouseEnter;
            inner._mouseHover = _mouseHover;
            inner._mouseLeave = _mouseLeave;
            inner._mouseClick = _mouseClick;
        }

        public void updateBackgroundColor(int[] _a)
        {
            btn.backgroundColor(_a[0], _a[1], _a[2], _a[3]);
        }

        public void setBackgroundColor(int r, int g, int b, int a)
        {
            backgroundColor = new int[4] { r, g, b, a };
        }

        public void setHoverBackgroundColor(int r, int g, int b, int a)
        {
            hoverBackgroundColor = new int[4] { r, g, b, a };
        }

        public void width(int w)
        {
            btn.width(w);
        }

        public void height(int h)
        {
            btn.height(h);
        }

        public void padding(int l, int r, int t, int b)
        {
            btn.padding(l, r, t, b);
        }

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
