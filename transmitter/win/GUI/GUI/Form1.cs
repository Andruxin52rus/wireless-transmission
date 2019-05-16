using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI : Form
    {
        static byte point_size;
        //static Color paint_color;
        SolidBrush brush;
        bool painting;
        bool is_black_brush;
        static Graphics g;

        static private int x_size;
        static private int y_size;
        static private bool[,] display_matrix;

        public GUI()
        {
            InitializeComponent();
            g = DrawingField.CreateGraphics();
            point_size = 10;
            brush = new SolidBrush(Color.Black);
            painting = false;

            x_size = DrawingField.Width;
            y_size = DrawingField.Height;

            display_matrix = new bool[x_size, y_size]; // filled with false
            is_black_brush = isBlackBrush();
        }

        private void SendTextButton_Click(object sender, EventArgs e)
        {
            BytesToCOMConnection.sendData(TextBox.Text);
        }

        private bool isBlackBrush()
        {
            if (brush.Color == Color.Black) return true;
            else return false;
        }

        private void DrawingField_MouseDown(object sender, MouseEventArgs e)
        {
            is_black_brush = isBlackBrush();
            painting = true;
            g.FillEllipse(brush, e.X - point_size / 2, e.Y - point_size / 2, point_size, point_size);
            for (int i = e.X - point_size / 2 - 1; i < e.X + point_size / 2; i++)
            {
                for (int j = e.Y - point_size / 2 - 1; j < e.Y + point_size / 2; j++)
                {
                    if (i > -1 && j > -1 && i < x_size && j < y_size) // indexes stay inside drawing field
                        display_matrix[i, j] = true;
                }
            }
        }        

        private void DrawingField_MouseMove(object sender, MouseEventArgs e)
        {
            if (painting)
            {
                g.FillEllipse(brush, e.X - point_size / 2, e.Y - point_size / 2, point_size, point_size);
                for (int i = e.X - point_size / 2 - 1; i < e.X + point_size / 2; i++)
                {
                    for (int j = e.Y - point_size / 2 - 1; j < e.Y + point_size / 2; j++)
                    {
                        if (i > -1 && j > -1 && i < x_size && j < y_size) // indexes stay inside drawing field
                            display_matrix[i, j] = true;
                    }
                }
            }
        }

        private void DrawingField_MouseUp(object sender, MouseEventArgs e)
        {
            painting = false;
            DrawingHandler.sendDrawing(display_matrix, is_black_brush);
            display_matrix = new bool[x_size, y_size]; // filled with false
        }

        private void BlackBrushButton_Click(object sender, EventArgs e)
        {
            brush = new SolidBrush(Color.Black);
            is_black_brush = isBlackBrush();
        }

        private void WhiteBrushButton_Click(object sender, EventArgs e)
        {
            brush = new SolidBrush(Color.White);
            is_black_brush = isBlackBrush();
        }

        private void px16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            point_size = 16;
        }

        private void px14ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            point_size = 14;
        }

        private void px12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            point_size = 12;
        }

        private void px10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            point_size = 10;
        }

        private void px8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            point_size = 8;
        }

        private void px6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            point_size = 6;
        }

        private void ClearDrawingButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White); // clear DrawingField
            DrawingHandler.eraseDrawing();
        }

        private void SendDrawingButton_Click(object sender, EventArgs e)
        {
            DrawingHandler.last_command_was_drawing = false;
            DrawingHandler.sendDrawing(display_matrix, true);
        }
    }
}