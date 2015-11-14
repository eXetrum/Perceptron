using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    public class InputGUI : DataGridView
    {
        bool drawMode { get; set; }
        Color selectionCellColor { get; set; }

        public static int cellWidth = 20;
        public static int cellHeight = 20;
        static int objectCounter = 0;

        static int objectsInOneRow = 4;
        static int offsetH = 20;

        Button titleLabel;

        public InputGUI(int rows, int cols, bool dontCount = false)
            : base()
        {
            if(!dontCount)
            ++objectCounter;
            titleLabel = new Button();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // dataGridView
            // 
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToResizeRows = false;
            this.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            //this.ColumnHeadersHeight = 5;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ColumnHeadersVisible = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.MultiSelect = false;
            this.Name = "dataGridView" + objectCounter;
            this.ReadOnly = true;
            this.RowHeadersVisible = false;
            //this.RowHeadersWidth = 5;
            this.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            //dataGridViewCellStyle5.BackColor = Color.FromArgb(0); //System.Drawing.Color.White;
            //dataGridViewCellStyle5.ForeColor = Color.FromArgb(0); //System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(0); //System.Drawing.Color.Red;
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(0);// System.Drawing.Color.White;
            this.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.RowTemplate.Height = cellHeight;
            this.RowTemplate.ReadOnly = true;
            this.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Size = new System.Drawing.Size(cols * cellWidth + (cols - 1), rows * cellHeight + (rows - 2));
            this.TabIndex = objectCounter;

            this.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseMove);
            this.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.MouseLeave += new System.EventHandler(this.dataGridView1_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            ///////////////////            
            ///////////////////
            ///////////////////
            this.RowCount = rows;
            this.ColumnCount = cols;

            drawMode = false;
            selectionCellColor = Color.FromArgb(255, 255, 128, 255);
        }

        public void SetImage(int[] image)
        {
            for (int i = 0; i < Rows.Count; ++i)
                for (int j = 0; j < Columns.Count; ++j)
                    if (image[i * Columns.Count + j] == 1) this.Rows[i].Cells[j].Style.BackColor = selectionCellColor;

            this.Rows[0].Cells[1].Selected = true;
            this.ClearSelection();
            this.Refresh();
        }

        public int[] GetImage()
        {
            int[] X = new int[Rows.Count * Columns.Count];
            for (int i = 0; i < Rows.Count; ++i)
                for (int j = 0; j < Columns.Count; ++j)
                    X[i * Columns.Count + j] = (this.Rows[i].Cells[j].Style.BackColor.Equals(selectionCellColor) ? 1 : 0);

            return X;
        }

        public void attachTo(Panel mainGUI, bool userInput = false)
        {
            mainGUI.SuspendLayout();
            for (int i = 0; i < this.ColumnCount; ++i)
                this.Columns[i].Width = cellWidth;

            Point p = userInput ? new Point(0, offsetH) : SetFreeLocation();
            if (userInput)
                Location = p;

            titleLabel.Location = new Point(p.X, p.Y - 17);
            titleLabel.Width = Width;
            titleLabel.Height = 17;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            //titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            titleLabel.FlatStyle = FlatStyle.System;

            titleLabel.BackColor = Color.LightBlue;
            titleLabel.Text = userInput ? "User X" : "X #" + objectCounter;
            titleLabel.Click += new EventHandler(
                delegate(object sender, EventArgs e)
                {
                    MessageBox.Show(sender.ToString());
                });

            mainGUI.Controls.Add(this);
            mainGUI.Controls.Add(titleLabel);
            mainGUI.ResumeLayout(false);
            mainGUI.Focus();

        }

        public void MoveTo(Point p)
        {
            this.titleLabel.Location = new Point(p.X, p.Y - 17);
            this.Location = p;
            this.Refresh();
        }

        public Point SetFreeLocation()
        {
            int h = 0;
            int ratio = (objectCounter - 1) / objectsInOneRow;
            h = (objectCounter - 1) / objectsInOneRow * Height;
            if (h == 0)
            {
                Location = new Point((objectCounter - 1) * (Width + 25), offsetH);
                return Location;
            }
            else
            {
                Location = new Point((objectCounter - 1 - ratio * objectsInOneRow) * (Width + 25), h + (ratio * 25) + offsetH);
                return Location;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (drawMode == false) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                this.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = selectionCellColor;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                this.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            drawMode = true;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                this.RowsDefaultCellStyle.SelectionBackColor = selectionCellColor;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                this.RowsDefaultCellStyle.SelectionBackColor = Color.White;
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            drawMode = false;
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            this[e.ColumnIndex, e.RowIndex].Selected = drawMode;
            if (drawMode == false) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                this.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = selectionCellColor;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                this.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            dataGridView1_CellMouseUp(sender, new DataGridViewCellMouseEventArgs(0, 0, 0, 0, new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, 0, 0, 0)));
        }

    }
}
