using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOMcs.RenderObjects
{
    internal class body
    {
        public Form window;
        public Div _body;
        public Div _topBorder;

        private Point _mouseLoc;
        private void win_MouseDown(object sender, MouseEventArgs e)
        {
            _topBorder.tblPanel.MinimumSize = new Size(window.Width, 40);
            _mouseLoc = e.Location;
        }
        
        private void win_MouseUp(object sender, MouseEventArgs e)
        {
            if(window.Top <= 40)
            {
                window.WindowState = FormWindowState.Maximized;
                _body.width(window.Width);
                _body.height(window.Height);
                _topBorder.tblPanel.MinimumSize = new Size(window.Width, 40);
            }
        }

        private void win_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if(window.WindowState == FormWindowState.Maximized)
                {
                    window.WindowState = FormWindowState.Normal;
                }
                int dx = (int)(e.Location.X + (_mouseLoc.X - Math.Ceiling((double)(window.Width / 2))));
                int dy = e.Location.Y - _mouseLoc.Y;
                window.Location = new Point(window.Location.X + dx, window.Location.Y + dy);
            }
        }

        public body(int _width, int _height, bool customerTopBorder = false)
        {
            window = new Form();
            window.Width = _width;
            window.Height = _height;

            _body = new Div();
            _body.width(_width);
            _body.height(_height);

            if(!customerTopBorder)
            {
                window.BackColor = Color.Black;
                window.ForeColor = Color.White;
                _topBorder = new Div();
                _topBorder.tblPanel.MinimumSize = new Size(_width, 40);
                _topBorder.backgroundColor(0, 0, 0, 255);
                _topBorder.tblPanel.MouseClick += win_MouseDown;
                _topBorder.tblPanel.MouseMove += win_MouseMove;
                _topBorder.tblPanel.MouseUp += win_MouseUp;
                _topBorder.padding(4, 4, 2, 2);

                RenderObjects.Button _close = new RenderObjects.Button("X");
                _close.width(30);
                _close.height(30);
                _close.setBackgroundColor(255, 0, 0, 255);
                _close.setHoverBackgroundColor(255, 100, 100, 255);
                _close.btn.tblPanel.Anchor = AnchorStyles.Right;
                _close.inner.textLabel.Anchor = AnchorStyles.None;
                _close.padding(4, 4, 4, 4);
                _close._mouseClick = () => { window.Close(); };
                _close._mouseEnter = () => { _close.updateBackgroundColor(_close.hoverBackgroundColor); };
                _close._mouseLeave = () => { _close.updateBackgroundColor(_close.backgroundColor); };
                _close.refresh();
                _topBorder.insert(_close._return(), 0, 1);

                RenderObjects.Text _title = new RenderObjects.Text("New window");
                _title.textLabel.ForeColor = Color.White;
                _title.textLabel.Anchor = AnchorStyles.Left;
                _topBorder.insert(_title._return(), 0, 0);
                //_topBorder.controlAtCenter(true);
                
                insert(_topBorder._return());
            }
        }
        public void render() { window.Controls.Add(_body._return()); window.ShowDialog(); }
        public void reset() { window.Controls.Remove(_body._return()); }
        public void changePage(Div page) { 
            reset();
            _body.tblPanel.Controls.Clear();
            _body.insert(_topBorder._return(), 0, 0);
            _body.insert(page._return(), 1, 0);
            window.Controls.Add(_body._return());
            window.Update();
        }

        public void insert(Control _a)
        {
            string row_col = _body.addRow();
            string[] rc = row_col.Split(",".ToCharArray());
            
            int r = Convert.ToInt32(rc[0]) - 2;
            int c = Convert.ToInt32(rc[1]);
            Console.WriteLine($"{r}, {c}");

            _body.insert(_a, r, c);
        }
    }
}
