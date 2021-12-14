using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace VectorEditor_IT3B
{
    public partial class Form1 : Form
    {
        Shapes selectedShape = Shapes.None;
        List<Shape> shapes;
        System.Drawing.Point mousePoint;
        Color defaultButtonColor;

        public Form1()
        {
            InitializeComponent();
            defaultButtonColor = btnLine.BackColor;
            shapes = new List<Shape>();
        }

        private void pboxCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = e.Location.ToString();
            mousePoint = e.Location;
            //pboxCanvas.Refresh();
        }

        private void pboxCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectedShape == Shapes.Point)
            {
                shapes.Add(new Point(e.Location.X, e.Location.Y));
            }
            else if(selectedShape == Shapes.Line)
            {

            }
            pboxCanvas.Refresh();
        }

        private void pboxCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void sfd_FileOk(object sender, CancelEventArgs e)
        {
            var json = JsonConvert.SerializeObject(shapes, Formatting.Indented);
            File.WriteAllText(sfd.FileName, json);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.S && e.Control)
            {
                sfd.ShowDialog();
            }
            else if (e.KeyCode == Keys.O && e.Control)
            {
                ofd.ShowDialog();
            }
        }

        private void ofd_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                foreach(var shape in shapes)
                {
                    if (shape.GetType() == typeof(Point))
                    {

                    }
                }
                var json = File.ReadAllText(ofd.FileName);
                shapes = JsonConvert.DeserializeObject<List<Shape>>(json);
                pboxCanvas.Refresh();
            }
            catch
            {
                MessageBox.Show("Nepodařilo se otevřít.");
            }
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            selectedShape = Shapes.Point;
            btnPoint.BackColor = Color.Lime;
            btnLine.BackColor = defaultButtonColor;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            selectedShape = Shapes.Line;
            btnPoint.BackColor = defaultButtonColor; 
            btnLine.BackColor = Color.Lime;
        }
    }
}
