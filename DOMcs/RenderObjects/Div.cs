using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOMcs.RenderObjects
{
    internal class Div : IRenderObject
    {
        public TableLayoutPanel tblPanel;

        string flexType;
        int gridAmt;
        string display;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_flexType">row || column</param>
        /// <param name="_gridAmt">1 -> n</param>
        /// <param name="_display">AutoSize, Absolute, Percent</param>
        public Div(string _flexType = "row", int _gridAmt = 1, string _display = "AutoSize", bool wireFrame = false)
        {
            tblPanel = new TableLayoutPanel();
            tblPanel.AutoSize = true;
            if (wireFrame) { tblPanel.BackColor = System.Drawing.Color.Cyan; }

            // Events
            tblPanel.MouseEnter += onMouseEnter;
            tblPanel.MouseHover += onMouseHover;
            tblPanel.MouseLeave += onMouseLeave;
            tblPanel.MouseClick += onMouseClick;

            flexType = _flexType;
            gridAmt = _gridAmt;
            display = _display;

            Init();
        }

        public Control _return() { return tblPanel; }

        public void insert(Control _a, int _row, int _col)
        {
            tblPanel.Controls.Add(_a, _col, _row);
        }

        public void Init()
        {
            var disp = SizeType.AutoSize;
            switch (display)
            {
                case "AutoSize":
                    disp = SizeType.AutoSize;
                    break;
                case "Absolute":
                    disp = SizeType.Absolute;
                    break;
                case "Percent":
                    disp = SizeType.Percent;
                    break;
            }

            if(flexType == "row")
            {
                tblPanel.RowCount = gridAmt;
                for (int i = 0; i < gridAmt; i++)
                {
                    tblPanel.RowStyles.Add(new RowStyle(disp));
                }
            }

            if(flexType == "column")
            {
                tblPanel.ColumnCount = gridAmt;
                for (int i = 0; i < gridAmt; i++)
                {
                    tblPanel.ColumnStyles.Add(new ColumnStyle(disp));
                }
            }
        }

        public void backgroundColor(int r, int g, int b, int a)
        {
            tblPanel.BackColor = System.Drawing.Color.FromArgb(a, r, g, b);
        }

        public void width(int w)
        {
            tblPanel.Width = w;
        }

        public void height(int h)
        {
            tblPanel.Height = h;
        }

        public void controlAtCenter(bool _a)
        {
            foreach (Control item in tblPanel.Controls)
            {
                item.Anchor = (_a) ? AnchorStyles.None : AnchorStyles.Left;
            }
        }

        public void padding(int l, int r, int t, int b)
        {
            tblPanel.Padding = new Padding(l, t, r, b);
        }

        public string addRow()
        {
            tblPanel.RowCount += 1;
            tblPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            return $"{tblPanel.RowCount},{tblPanel.ColumnCount}";
        }

        public string addCol()
        {
            tblPanel.ColumnCount += 1;
            tblPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            return $"{tblPanel.RowCount},{tblPanel.ColumnCount}";
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
