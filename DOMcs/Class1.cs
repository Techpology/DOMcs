using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DOMcs.RenderObjects;

namespace DOMcs
{
    public class Init
    {
        static RenderObjects.Div page1;
        static RenderObjects.Div page2;

        public static void initPage1(int _w, int _h)
        {
            page1 = new RenderObjects.Div();
            page1.width(_w);
            page1.height(_h);

            RenderObjects.Text title = new RenderObjects.Text("Page 1");
            title.textLabel.ForeColor = System.Drawing.Color.White;

            page1.insert(title._return(), 0, 0);

            RenderObjects.Div _div = new RenderObjects.Div(_gridAmt: 2, _display: "AutoSize", wireFrame: false);

            RenderObjects.Text _txt = new RenderObjects.Text("Hello");
            _div.insert(_txt._return(), 0, 0);

            RenderObjects.Text _txt2 = new RenderObjects.Text("Hello test");
            _div.insert(_txt2._return(), 1, 0);

            RenderObjects.Button _btn = new RenderObjects.Button("Page 2");
            _btn.setBackgroundColor(255, 255, 255, 255);
            _btn.setHoverBackgroundColor(200, 200, 200, 255);
            _btn.width(140);
            _btn.height(24);
            _btn.padding(10,10,5,5);
            _btn.inner.textLabel.ForeColor = System.Drawing.Color.Black;
            _btn._mouseClick = () => { win.changePage(page2); };
            _btn._mouseEnter = () => { _btn.updateBackgroundColor(_btn.hoverBackgroundColor); };
            _btn._mouseLeave = () => { _btn.updateBackgroundColor(_btn.backgroundColor); };
            _btn.refresh();

            RenderObjects.Div _tbl = new RenderObjects.Div(_flexType: "column", _gridAmt: 2);
            RenderObjects.Text _txt3 = new RenderObjects.Text("1 -- ");
            RenderObjects.Text _txt4 = new RenderObjects.Text("2 -- ");
            RenderObjects.Text _txt5 = new RenderObjects.Text("3 -- ");
            RenderObjects.Text _txt6 = new RenderObjects.Text("4 -- ");
            _tbl.insert(_txt3._return(), 0, 0);
            _tbl.insert(_txt4._return(), 0, 1);
            _tbl.addRow();
            _tbl.insert(_txt5._return(), 1, 0);
            _tbl.insert(_txt6._return(), 1, 1);

            page1.insert(title._return(), 0, 0);
            page1.insert(_div._return(), 1, 0);
            page1.insert(_btn._return(), 2, 0);
            page1.insert(_tbl._return(), 3, 0);
        }

        public static void initPage2(int _w, int _h)
        {
            page2 = new RenderObjects.Div();
            page2.width(_w);
            page2.height(_h);

            RenderObjects.Text title = new RenderObjects.Text("Page 2");
            title.textLabel.ForeColor = System.Drawing.Color.White;

            RenderObjects.Button _btn = new RenderObjects.Button("Page 1");
            _btn.width(140);
            _btn.height(24);
            _btn.setBackgroundColor(255, 255, 255, 255);
            _btn.setHoverBackgroundColor(200,200,200, 255);
            _btn.padding(10, 10, 5, 5);
            _btn._mouseClick = () => { win.changePage(page1); };
            _btn._mouseEnter = () => { _btn.updateBackgroundColor(_btn.hoverBackgroundColor); };
            _btn._mouseLeave = () => { _btn.updateBackgroundColor(_btn.backgroundColor); };
            _btn.inner.textLabel.ForeColor = System.Drawing.Color.Black;
            _btn.refresh();

            page2.insert(title._return(), 0, 0);
            page2.insert(_btn._return(), 1, 0);
        }

        static RenderObjects.body win;

        public static void Main(string[] args)
        {
            int w = 1280;
            int h = 800;

            initPage2(w, h);
            initPage1(w, h);

            win = new RenderObjects.body(1280, 800);
            //win.window.WindowState = FormWindowState.Maximized;
            win.window.FormBorderStyle = FormBorderStyle.None;

            win.insert(page1._return());
            win.render();
        }
    }
}
