using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap[] b = new Bitmap[5];
        Graphics[] a = new Graphics[5];
        Pen x = new Pen(Color.Black); //X，Y  
        Pen Mypen = new Pen(Color.Blue);//波形
        Pen Mypen2 = new Pen(Color.Blue);//直線
        Pen Mypen3 = new Pen(Color.Blue);//拋物線
        Pen Mypen4 = new Pen(Color.Blue);//只對數
        Pen Mypen5 = new Pen(Color.Blue);//三次曲線
        private void sin()
        {
            int o = int.Parse(comboBox1.Text);//震幅1:250;
            int oo = int.Parse(comboBox3.Text);//週期;
            int ooo = int.Parse(comboBox2.Text);//角度;
            int[] sin = new int[500];
            List<Point> MyPoint = new List<Point>();
            Mypen.Width = 2;
            Point p = new Point();
            for (int i = 0; i < 500; i++)
            {
                sin[i] = Convert.ToInt32(Math.Sin(Math.PI * i * oo / 250 + Math.PI * ooo / 180 + 0.01f) * o * 27.5);
                p.X = i; p.Y = -sin[i];
                MyPoint.Add(p);
            }
            for (int i = 1; i < MyPoint.Count; i++)
            {
                a[0].DrawLine(Mypen, MyPoint[i - 1], MyPoint[i]);
            }
        }
        private void cos()
        {
            int o = int.Parse(comboBox1.Text);//震幅1:250;
            int oo = int.Parse(comboBox3.Text);//週期;
            int ooo = int.Parse(comboBox2.Text);//角度;
            int[] cos = new int[500];
            List<Point> MyPoint = new List<Point>();
            Mypen.Width = 2;
            Point p = new Point();
            for (int i = 0; i < 500; i++)
            {
                cos[i] = Convert.ToInt32(Math.Cos(Math.PI * i * oo / 250 + Math.PI * ooo / 180 + 0.01f) * o * 27.5);
                p.X = i; p.Y = -cos[i];
                MyPoint.Add(p);
            }
            for (int i = 1; i < MyPoint.Count; i++)
            {
                a[0].DrawLine(Mypen, MyPoint[i - 1], MyPoint[i]);
            }
        }
        private void tan()
        {
            int o = int.Parse(comboBox1.Text);//震幅1:250;
            int oo = int.Parse(comboBox3.Text);//週期;
            int ooo = int.Parse(comboBox2.Text);//角度;             
            Mypen.Width = 2;
            float x0 = 0, x1 = 0, y0 = 0, y1 = 0;
            for (x1 = 1; x1 < 500; x1 += 0.06f)
            {
                y1 = Convert.ToInt32(1 / (Math.Tan(Math.PI * x1 * oo / 250 + Math.PI * (ooo + 90) / 180 + 0.01F)) * o * 27.5);
                if (y0 > y1)
                    if (x0 > 0)
                        a[0].DrawLine(Mypen, x0, y0, x1, y1);
                x0 = x1; y0 = y1;
            }
        }
        private void cot()
        {
            int o = int.Parse(comboBox1.Text);//震幅1:250;
            int oo = int.Parse(comboBox3.Text);//週期;
            int ooo = int.Parse(comboBox2.Text);//角度;
            Mypen.Width = 2;
            float x0 = 0, x1 = 0, y0 = 0, y1 = 0;
            for (x1 = 1; x1 < 500; x1 += 0.06f)
            {
                y1 = Convert.ToInt32(Math.Tan(Math.PI * x1 * oo / 250 + Math.PI * (ooo + 90) / 180 + 0.01F) * o * 27.5);
                if (y0 > 0 && y1 > 0 || y1 < 1 && y0 < 0)
                    a[0].DrawLine(Mypen, x0, y0, x1, y1);
                x0 = x1; y0 = y1;
            }
        }
        private void sec()
        {
            int o = int.Parse(comboBox1.Text);//震幅1:250;
            int oo = int.Parse(comboBox3.Text);//週期;
            int ooo = int.Parse(comboBox2.Text);//角度;
            Mypen.Width = 2;
            float x0 = 0, x1 = 0, y1 = 0, y0 = 0;
            for (x1 = 1; x1 < 500; x1++)
            {
                y1 = Convert.ToInt32(1 / Math.Cos(Math.PI * x1 * oo / 250 + Math.PI * (ooo + 180) / 180 + 0.01F) * o * 27.5);
                if (y0 > 0 && y1 > 0 || y1 < 1 && y0 < 0)
                    if (x0 > 0)
                        a[0].DrawLine(Mypen, x1, y1, x0, y0);
                x0 = x1;
                y0 = y1;
            }
        }
        private void csc()
        {
            int o = int.Parse(comboBox1.Text);//震幅1:250;
            int oo = int.Parse(comboBox3.Text);//週期;
            int ooo = int.Parse(comboBox2.Text);//角度;
            Mypen.Width = 2;
            float x0 = 0, x1 = 0, y1 = 0, y0 = 0;
            for (x1 = 1; x1 < 500; x1++)
            {
                y1 = (float)(1 / Math.Sin(Math.PI * x1 * oo / 250 + Math.PI * (ooo + 180) / 180 + 0.01F) * o * 27.5);
                if (y0 > 0 && y1 > 0 || y1 < 1 && y0 < 0)
                    if (x0 > 0)
                        a[0].DrawLine(Mypen, x1, y1, x0, y0);
                x0 = x1;
                y0 = y1;
            }
        }
        private void del()//三角波
        {
            int o = int.Parse(comboBox1.Text);//震幅1:250;
            int oo = int.Parse(comboBox3.Text);//週期;
            int ooo = int.Parse(comboBox2.Text);//角度;
            Mypen.Width = 2;
            float x0 = 0, x1 = 0, y1 = 0, y0 = 0;
            for(x1=0;x1<25;x1++)
            {
                y1 = o * (float)Math.Pow(-1, x1);
                //if(x0>0&&y0>0)
                a[0].DrawLine(Mypen, x1*247.5f/oo-122.5f, y1 * 27.5f, x0 *247.5f/oo-122.5f, y0 * 27.5f);
                y0 = y1;
                x0 = x1;
            }
        }
        private void line()//直線方程式
        {
            pictureBox2.Image = b[1];
            SolidBrush x1 = new SolidBrush(Color.Black);
            Font drawFont = new Font("Arial", 10);
            Mypen2.Width = 2;
            a[1].DrawLine(Mypen2, xx[0] * 12, -y[0] * 12, xx[1] * 12, -y[1] * 12);
            a[1].DrawString("A", drawFont, x1, xx[0] * 12, -y[0] * 12);
            a[1].FillEllipse(Brushes.Red, xx[0] * 12 - 5, -y[0] * 12, 5, 5);
            a[1].DrawString("B", drawFont, x1, xx[1] * 12, -y[1] * 12);
            a[1].FillEllipse(Brushes.Red, xx[1] * 12 - 5, -y[1] * 12, 5, 5);
            if (xx[2] != 0 || y[2] != 0 || y[3] != 0 || xx[3] != 0)
            {
                a[1].DrawLine(Mypen2, xx[2] * 12, -y[2] * 12, xx[3] * 12, -y[3] * 12);
                a[1].DrawString("C", drawFont, x1, xx[2] * 12, -y[2] * 12);
                a[1].FillEllipse(Brushes.Red, xx[2] * 12 - 5, -y[2] * 12, 5, 5);
                a[1].DrawString("D", drawFont, x1, xx[3] * 12, -y[3] * 12);
                a[1].FillEllipse(Brushes.Red, xx[3] * 12 - 5, -y[3] * 12, 5, 5);
            }
            float c1 = xx[0]; float c3 = xx[2];
            float c2 = xx[1]; float c4 = xx[3];
            float d1 = y[0]; float d3 = y[2];
            float d2 = y[1]; float d4 = y[3];
            float m = (d1 - d2) / (c1 - c2);
            float m2 = (d3 - d4) / (c3 - c4);
            float bx = y[0] * 12 - m * xx[0] * 12;
            float bx2 = y[2] * 12 - m2 * xx[2] * 12;
            float yy = m * 300 + bx; float yy3 = m2 * 300 + bx2;
            float yy2 = m * -300 + bx; float yy4 = m2 * -300 + bx2;
            textBox6.Text = m.ToString("#0.00");
            if (textBox10.Text != "" && textBox9.Text != "")
            {
                textBox11.Text = m2.ToString("#0.00");
            }
            if (c1 - c2 != 0)
                a[1].DrawLine(Mypen2, 300, -yy, -300, -yy2);
            float c = (-d1) * (c1 - c2) + (d1 - d2) * c1;
            if (textBox1.Text == textBox2.Text)
            {
                textBox3.Text = "一點" + "(" + xx[0].ToString() + "," + (y[0]).ToString() + ")";
            }
            else if (c1 - c2 == 0)
            {
                textBox3.Text = "x=" + ((-c) / -(d1 - d2)).ToString("#0.00");
                a[1].DrawLine(Mypen2, xx[0] * 12, 0, xx[0] * 12, 300);
                a[1].DrawLine(Mypen2, xx[0] * 12, 0, xx[0] * 12, -300);
            }
            else if (d1 - d2 == 0)
            {
                textBox3.Text = "y=" + ((-c) / (c1 - c2)).ToString("#0.00");
                a[1].DrawLine(Mypen2, 0, -y[0] * 12, 300, -y[0] * 12);
                a[1].DrawLine(Mypen2, 0, -y[0] * 12, -300, -y[0] * 12);
            }
            else if (-(c1 - c2) < 0 && -c < 0)
            {
                textBox3.Text = (d1 - d2).ToString("#0.00") + "x" + (-(c1 - c2)).ToString("#0.00") + "y" + (-c).ToString("#0.00") + "=0";
            }
            else if (-(c1 - c2) < 0)
            {
                textBox3.Text = (d1 - d2).ToString("#0.00") + "x" + (-(c1 - c2)).ToString("#0.00") + "y" + "+" + (-c).ToString("#0.00") + "=0";
            }
            else if (-c < 0)
            {
                textBox3.Text = (d1 - d2).ToString("#0.00") + "x" + "+" + (-(c1 - c2)).ToString("#0.00") + "y" + (-c).ToString("#0.00") + "=0";
            }
            else
            {
                textBox3.Text = (d1 - d2).ToString("#0.00") + "x" + "+" + (-(c1 - c2)).ToString("#0.00") + "y" + "+" + (-c).ToString("#0.00") + "=0";
            }
            if (c3 - c4 != 0)
                a[1].DrawLine(Mypen2, 300, -yy3, -300, -yy4);
            float cx = (-d3) * (c3 - c4) + (d3 - d4) * c3;
            if (xx[2] != 0 || y[2] != 0 || y[3] != 0 || xx[3] != 0)
            {
                if (textBox10.Text == textBox9.Text)
                {
                    textBox12.Text = "一點" + "(" + xx[2].ToString("#0.00") + "," + (y[2]).ToString("#0.00") + ")";
                }
                else if (c3 - c4 == 0)
                {
                    textBox12.Text = "x=" + ((-cx) / -(d3 - d4)).ToString("#0.00");
                    a[1].DrawLine(Mypen2, xx[2] * 12, 0, xx[2] * 12, 300);
                    a[1].DrawLine(Mypen2, xx[2] * 12, 0, xx[2] * 12, -300);
                }
                else if (d3 - d4 == 0)
                {
                    textBox12.Text = "y=" + ((-cx) / (c3 - c4)).ToString("#0.00");
                    a[1].DrawLine(Mypen2, 0, -y[2] * 12, 300, -y[2] * 12);
                    a[1].DrawLine(Mypen2, 0, -y[2] * 12, -300, -y[2] * 12);
                }
                else if (-(c3 - c4) < 0 && -cx < 0)
                {
                    textBox12.Text = (d3 - d4).ToString("#0.00") + "x" + (-(c3 - c4)).ToString("#0.00") + "y" + (-cx).ToString("#0.00") + "=0";
                }
                else if (-(c3 - c4) < 0)
                {
                    textBox12.Text = (d3 - d4).ToString("#0.00") + "x" + (-(c3 - c4)).ToString("#0.00") + "y" + "+" + (-cx).ToString("#0.00") + "=0";
                }
                else if (-cx < 0)
                {
                    textBox12.Text = (d3 - d4).ToString("#0.00") + "x" + "+" + (-(c3 - c4)).ToString("#0.00") + "y" + (-cx).ToString("#0.00") + "=0";
                }
                else
                {
                    textBox12.Text = (d3 - d4).ToString("#0.00") + "x" + "+" + (-(c3 - c4)).ToString("#0.00") + "y" + "+" + (-cx).ToString("#0.00") + "=0";
                }
                //(d1 - d2)x+(-(c1 - c2))y=c
                //(d3 - d4)x+(-(c3 - c4))y=cx
                float z1;
                float z2;
                if (textBox9.Text != "" && textBox10.Text != "")
                {
                    z1 = ((-(c1 - c2)) * cx - (-(c3 - c4)) * c) / ((-(c1 - c2)) * (d3 - d4) - (d1 - d2) * (-(c3 - c4)));//x
                    z2 = ((d1 - d2) * cx - (d3 - d4) * c) / ((d1 - d2) * (-(c3 - c4)) - (-(c1 - c2)) * (d3 - d4));//y                   
                    textBox13.Text = "(" + z1.ToString("#0.00") + "," + z2.ToString("#0.00") + ")";//焦點
                    a[1].FillEllipse(Brushes.Red, z1 * 12 - 5, -z2 * 12, 5, 5);
                    a[1].DrawString("F", drawFont, x1, z1 * 12, -z2 * 12);
                    if (textBox10.Text == textBox9.Text && textBox1.Text == textBox2.Text)
                        textBox13.Text = "一點" + "(" + xx[2].ToString("#0.00") + "," + (y[2]).ToString("#0.00") + ")";
                }
            }
        }
        float la; float lb; float lc; float lc2;
        private void line1()//自行輸入
        {
            pictureBox2.Image = b[1];
            la = float.Parse(textBox7.Text);
            lb = float.Parse(textBox8.Text);
            lc = la * 300 + lb * 12;
            lc2 = la * -300 + lb * 12;
            if (la != 0 || lb != 0)
                a[1].DrawLine(Mypen2, 300, -lc, -300, -lc2);
        }
        // int fg(int A, int B)
        //{
        //    A = y[0] - y[1];//d1-d2
        //    B = -(xx[0] - xx[1]);//-(c1-c2)
        //    if (A >= B)
        //    {
        //        int j = A % B;
        //        if (j == 0)
        //            return B;
        //        else
        //            return fg(B,j);
        //    }
        //    else
        //        return fg(A, B);

        //}
        private void line2()//拋物線
        {
            pictureBox3.Image = b[2];
            Mypen3.Width = 2;
            float c = float.Parse(numericUpDown2.Value.ToString());//b        
            float h1 = float.Parse(hScrollBar1.Value.ToString());
            float h2 = float.Parse(hScrollBar2.Value.ToString());
            if (c == 0)
            {
                hScrollBar1.Enabled = false;
                hScrollBar2.Enabled = false;
                checkBox1.Enabled = false;
                checkBox1.Checked = false;
            }
            else
            {
                hScrollBar1.Enabled = true;
                hScrollBar2.Enabled = true;
                checkBox1.Enabled = true;
            }
            float x0 = 0, x1 = 0, y0 = 0, y1 = 0;
            for (x1 = -300; x1 < 300; x1 += 0.1f)
            {
                y1 = (x1 * x1 - 2 * x1 * 0 + 0 * 0 + 4 * c * 0) / (4 * c);
                if (x1 > x0)
                {
                    if (c != 0)
                        a[2].DrawLine(Mypen3, x1 * 12 + h1 * 12, -y1 * 12 - h2 * 12, x0 * 12 + h1 * 12, -y0 * 12 - h2 * 12);
                }
                y0 = y1;
                x0 = x1;
            }
            textBox4.Text = "(" + (0 + h1).ToString() + "," + (0 + h2).ToString() + ")";
            textBox14.Text = "x=" + (0 + h1).ToString();
            if (hScrollBar2.Value != 0)
            {
                textBox5.Text = (0 + h1).ToString();
                textBox16.Text = (0 + h2).ToString();
            }
        }
        float nu;
        private void line3()//指數
        {
            pictureBox4.Image = b[3];
            nu = float.Parse(numericUpDown1.Value.ToString());
            float x0 = 0, x1 = 0, y0 = 0, y1 = 0;
            Mypen4.Width = 2;
            if (nu > 0)
                for (x1 = -5; x1 < 6; x1 += 0.1f)
                {
                    y1 = (float)Math.Pow(nu, x1);
                    if (x1 > -5)
                        a[3].DrawLine(Mypen4, x1 * 60, -y1 * 60, x0 * 60, -y0 * 60);
                    x0 = x1;
                    y0 = y1;
                }
        }
        private void line4()//log
        {
            pictureBox4.Image = b[3];
            float nx = float.Parse(numericUpDown3.Value.ToString());
            float x0 = 0.1f, x1 = 0, y0 = 0, y1 = 0;
            Mypen4.Width = 2;
            for (x1 = 0.00001F; x1 < 6; x1 += 0.1f)
            {
                y1 = (float)Math.Log(x1, nx);
                if (y0 != 0)
                    a[3].DrawLine(Mypen4, x1 * 60, -y1 * 60, x0 * 60, -y0 * 60);
                y0 = y1;
                x0 = x1;
            }
        }
        private void line5()//3次
        {
            pictureBox5.Image = b[4];
            Mypen5.Width = 2;
            float a1 = float.Parse(numericUpDown4.Value.ToString());
            float b1 = float.Parse(numericUpDown5.Value.ToString());
            float c1 = float.Parse(numericUpDown6.Value.ToString());
            float h1 = float.Parse(hScrollBar4.Value.ToString());
            float h2 = float.Parse(hScrollBar3.Value.ToString());
            if (a1 == 0)
            {
                hScrollBar4.Enabled = false;
                hScrollBar3.Enabled = false;
                numericUpDown5.Enabled = false;
                numericUpDown6.Enabled = false;
            }
            else
            {
                hScrollBar4.Enabled = true;
                hScrollBar3.Enabled = true;
                numericUpDown5.Enabled = true;
                numericUpDown6.Enabled = true;
            }
            float x0 = 0, x1 = 0, y0 = 0, y1 = 0;
            for (x1 = -25; x1 < 26; x1 += 0.01F)
            {
                y1 = a1 * x1 * x1 * x1 + b1 * x1 * x1 + c1 * x1 + 0;
                if (x0 != 0 && a1 != 0)
                    a[4].DrawLine(Mypen5, x1 * 30 + h2 * 30, -y1 * 30 - h1 * 30, x0 * 30 + h2 * 30, -y0 * 30 - h1 * 30);
                y0 = y1;
                x0 = x1;
            }
            textBox18.Text = (a1 * -h2 * -h2 * -h2 + b1 * -h2 * -h2 + c1 * -h2 + h1).ToString("#0.00");
            float xe1 = (-b1 - (float)Math.Sqrt(b1 * b1 - 3 * a1 * c1)) / (3 * a1);
            float ye1 = (a1 * xe1 * xe1 * xe1 + b1 * xe1 * xe1 + c1 * xe1);
            float xe2 = (-b1 + (float)Math.Sqrt(b1 * b1 - 3 * a1 * c1)) / (3 * a1);
            float ye2 = a1 * xe2 * xe2 * xe2 + b1 * xe2 * xe2 + c1 * xe2;
            if (b1 != 0 || c1 != 0 && b1 * b1 - 3 * a1 * c1 > 0)
            {
                textBox19.Text = "(" + (xe1 + h2).ToString("#0.00") + "," + (ye1 + h1).ToString("#0.00") + ")";
                textBox20.Text = "(" + (xe2 + h2).ToString("#0.00") + "," + (ye2 + h1).ToString("#0.00") + ")";
            }
            else
            {
                textBox19.Text = "";
                textBox20.Text = "";
                textBox21.Text = "";
            }
            //3*a1*x1+b1=0
            //3*a1*x1=-b1
            //x1=-b1/3*a1   
            if (b1 != 0)
            {
                float zx = (xe1 + xe2) / 2;
                float zy = a1 * zx * zx * zx + b1 * zx * zx + c1 * zx;
                textBox21.Text = "(" + (zx + h2).ToString("#0.00") + "," + (zy + h1).ToString("#0.00") + ")";
            }
        }
        private void Draw()
        {
            b[0] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            x.Width = 3;
            Font drawFont = new Font("Calibri", 10);
            SolidBrush xx = new SolidBrush(Color.Black);
            xx.Color = button3.BackColor;
            pictureBox1.Image = b[0];
            a[0] = Graphics.FromImage(b[0]);
            a[0].TranslateTransform(50, 275);
            a[0].DrawLine(x, -50, 0, 500, 0);
            a[0].DrawLine(x, 0, 0, 0, 275);
            a[0].DrawLine(x, 0, 0, 0, -275);
            for (int i = 0; i < 12; i++)
            {
                a[0].DrawLine(x, -3, -275 + i * 55, 3, -275 + i * 55);
            }
            for (int j = 0; j < 11; j++)
            {
                a[0].DrawLine(x, 55 + j * 55, -3, 55 + j * 55, 3);
            }
            float[] f = new float[4] { 55, 110, 165, 220 };
            for (int j = 0; j < 4; j++)
            {
                a[0].DrawString((-2 * (j + 1)).ToString("#0.0"), drawFont, xx, -35f, f[j] - 10);
                a[0].DrawString((2 * (j + 1)).ToString("#0.0"), drawFont, xx, -30f, -f[j] - 10);
                a[0].DrawString("-10.0", drawFont, xx, -42.5f, 260f);
                a[0].DrawString("10.0", drawFont, xx, -37.5f, -275f);
            }
        }
        private void Draw2()
        {
            b[1] = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Pen x2 = new Pen(Color.Black);
            x2.Width = 3;
            Font drawFont = new Font("Arial", 10);
            SolidBrush xx = new SolidBrush(Color.Black);
            pictureBox2.Image = b[1];
            a[1] = Graphics.FromImage(b[1]);
            a[1].TranslateTransform(300, 300);
            a[1].DrawLine(x2, 0, 0, 300, 0);
            a[1].DrawLine(x2, 0, 0, -300, 0);
            a[1].DrawLine(x2, 0, 0, 0, 300);
            a[1].DrawLine(x2, 0, 0, 0, -300);
            for (int i = 0; i < 12; i++)
            {
                a[1].DrawLine(x2, -3, -300 + i * 60, 3, -300 + i * 60);
            }
            for (int j = 0; j < 12; j++)
            {
                a[1].DrawLine(x2, -300 + j * 60, -3, -300 + j * 60, 3);
            }
            float[] f = new float[4] { 60, 120, 180, 240 };
            for (int j = 0; j < 4; j++)
            {
                a[1].DrawString((-5 * (j + 1)).ToString("#0.0"), drawFont, xx, -35f, f[j] - 10);
                a[1].DrawString((5 * (j + 1)).ToString("#0.0"), drawFont, xx, -30f, -f[j] - 10);
                a[1].DrawString("-25.0", drawFont, xx, -37.5f, 285f);
                a[1].DrawString("25.0", drawFont, xx, -35.5f, -300f);
            }
        }
        private void Draw3()
        {
            b[2] = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            Pen x3 = new Pen(Color.Black);
            x3.Width = 3;
            Font drawFont = new Font("Arial", 10);
            SolidBrush xx = new SolidBrush(Color.Black);
            pictureBox3.Image = b[2];
            a[2] = Graphics.FromImage(b[2]);
            a[2].TranslateTransform(300, 300);
            a[2].DrawLine(x3, 0, 0, 300, 0);
            a[2].DrawLine(x3, 0, 0, -300, 0);
            a[2].DrawLine(x3, 0, 0, 0, 300);
            a[2].DrawLine(x3, 0, 0, 0, -300);
            for (int i = 0; i < 12; i++)
            {
                a[2].DrawLine(x3, -3, -300 + i * 60, 3, -300 + i * 60);
            }
            for (int j = 0; j < 12; j++)
            {
                a[2].DrawLine(x3, -300 + j * 60, -3, -300 + j * 60, 3);
            }
            float[] f = new float[4] { 60, 120, 180, 240 };
            for (int j = 0; j < 4; j++)
            {
                a[2].DrawString((-5 * (j + 1)).ToString("#0.0"), drawFont, xx, -35f, f[j] - 10);
                a[2].DrawString((5 * (j + 1)).ToString("#0.0"), drawFont, xx, -30f, -f[j] - 10);
                a[2].DrawString("-25.0", drawFont, xx, -37.5f, 285f);
                a[2].DrawString("25.0", drawFont, xx, -35.5f, -300f);
            }
        }
        private void Draw4()
        {
            b[3] = new Bitmap(pictureBox4.Width, pictureBox4.Height);
            Pen x3 = new Pen(Color.Black);
            x3.Width = 3;
            Font drawFont = new Font("Arial", 10);
            SolidBrush xx = new SolidBrush(Color.Black);
            pictureBox4.Image = b[3];
            a[3] = Graphics.FromImage(b[3]);
            a[3].TranslateTransform(300, 300);
            a[3].DrawLine(x3, 0, 0, 300, 0);
            a[3].DrawLine(x3, 0, 0, -300, 0);
            a[3].DrawLine(x3, 0, 0, 0, 300);
            a[3].DrawLine(x3, 0, 0, 0, -300);
            for (int i = 0; i < 11; i++)
            {
                a[3].DrawLine(x3, -3, -300 + i * 60, 3, -300 + i * 60);
            }
            for (int j = 0; j < 11; j++)
            {
                a[3].DrawLine(x3, -300 + j * 60, -3, -300 + j * 60, 3);
            }
            float[] f = new float[4] { 60, 120, 180, 240 };
            for (int j = 0; j < 4; j++)
            {
                a[3].DrawString((-1 * (j + 1)).ToString("#0.0"), drawFont, xx, -35f, f[j] - 10);
                a[3].DrawString((1 * (j + 1)).ToString("#0.0"), drawFont, xx, -30f, -f[j] - 10);
                a[3].DrawString("-5.0", drawFont, xx, -37.5f, 285f);
                a[3].DrawString("5.0", drawFont, xx, -35.5f, -300f);
            }
        }
        private void Draw5()
        {
            b[4] = new Bitmap(pictureBox5.Width, pictureBox5.Height);
            Pen x3 = new Pen(Color.Black);
            x3.Width = 3;
            Font drawFont = new Font("Arial", 10);
            SolidBrush xx = new SolidBrush(Color.Black);
            pictureBox5.Image = b[4];
            a[4] = Graphics.FromImage(b[4]);
            a[4].TranslateTransform(300, 300);
            a[4].DrawLine(x3, 0, 0, 300, 0);
            a[4].DrawLine(x3, 0, 0, -300, 0);
            a[4].DrawLine(x3, 0, 0, 0, 300);
            a[4].DrawLine(x3, 0, 0, 0, -300);
            for (int i = 0; i < 12; i++)
            {
                a[4].DrawLine(x3, -3, -300 + i * 60, 3, -300 + i * 60);
            }
            for (int j = 0; j < 12; j++)
            {
                a[4].DrawLine(x3, -300 + j * 60, -3, -300 + j * 60, 3);
            }
            float[] f = new float[4] { 60, 120, 180, 240 };
            for (int j = 0; j < 4; j++)
            {
                a[4].DrawString((-2 * (j + 1)).ToString("#0.0"), drawFont, xx, -35f, f[j] - 10);
                a[4].DrawString((2 * (j + 1)).ToString("#0.0"), drawFont, xx, -30f, -f[j] - 10);
                a[4].DrawString("-10.0", drawFont, xx, -37.5f, 285f);
                a[4].DrawString("10.0", drawFont, xx, -35.5f, -300f);
            }
        }
        string L;
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Text = Math.Sqrt(1000).ToString();     
            toolStripStatusLabel5.Text = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString();
            toolStripStatusLabel11.Text = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString();
            toolStripStatusLabel13.Text = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString();
            toolStripStatusLabel17.Text = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString();
            toolStripStatusLabel20.Text = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString();
            comboBox1.Text = "1";
            comboBox2.Text = "0";
            comboBox3.Text = "1";
            comboBox4.Text = "sin";
            comboBox5.Text = "指數";
            numericUpDown2.Value = 0.1M;
            numericUpDown4.Value = 0.1M;
            Draw();
            sin();
            Draw2();
            Draw3();
            Draw4();
            Draw5();
            hScrollBar1.Value = 0;
            hScrollBar2.Value = 0;
            hScrollBar3.Value = 0;
            hScrollBar4.Value = 0;
            label44.Text = "0";
            label43.Text = "0";
            label64.Text = "0";
            label62.Text = "0";
            vScrollBar1.Value = 0;
            vScrollBar2.Value = 0;
            textBox8.Text = "0";
            textBox7.Text = "0";
            textBox14.Text = "";
            hScrollBar1.Enabled = false;
            hScrollBar2.Enabled = false;
            hScrollBar3.Enabled = false;
            hScrollBar4.Enabled = false;
            textBox4.Text = "";
            textBox5.Text = "0";
            textBox16.Text = "0";
            textBox18.Text = "0";
            checkBox1.Enabled = false;
            line3();
            groupBox10.Enabled = false;
            line2();
            line5();
            L = "r8.jpg";
            M();
            m2();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
            {
                if (comboBox4.Text == "sin")
                {
                    sin();
                }
                else if (comboBox4.Text == "cos")
                {
                    cos();
                }
                else if (comboBox4.Text == "tan")
                {
                    tan();
                }
                else if (comboBox4.Text == "cot")
                {
                    cot();
                }
                else if (comboBox4.Text == "sec")
                {
                    sec();
                }
                else if (comboBox4.Text == "csc")
                {
                    csc();
                }
                else if (comboBox4.Text == "三角波")
                {
                    del();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Draw2();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox7.Text = "0";
            textBox8.Text = "0";
            vScrollBar1.Value = 0;
            vScrollBar2.Value = 0;
            textBox10.Text = "";
            textBox9.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox11.Text = "";
            clickCount = 0;
            xx[0] = 0; y[0] = 0;
            xx[1] = 0; y[1] = 0;
            xx[2] = 0; y[2] = 0;
            xx[3] = 0; y[3] = 0;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
            {
                if (comboBox4.Text == "sin")
                {
                    sin();
                }
                else if (comboBox4.Text == "cos")
                {
                    cos();
                }
                else if (comboBox4.Text == "tan")
                {
                    tan();
                }
                else if (comboBox4.Text == "cot")
                {
                    cot();
                }
                else if (comboBox4.Text == "sec")
                {
                    sec();
                }
                else if (comboBox4.Text == "csc")
                {
                    csc();
                }
                else if (comboBox4.Text == "三角波")
                {
                    del();
                }
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
            {
                if (comboBox4.Text == "sin")
                {
                    sin();
                }
                else if (comboBox4.Text == "cos")
                {
                    cos();
                }
                else if (comboBox4.Text == "tan")
                {
                    tan();
                }
                else if (comboBox4.Text == "cot")
                {
                    cot();
                }
                else if (comboBox4.Text == "sec")
                {
                    sec();
                }
                else if (comboBox4.Text == "csc")
                {
                    csc();
                }
                else if (comboBox4.Text == "三角波")
                {
                    del();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
            {
                if (comboBox4.Text == "sin")
                {
                    sin();
                }
                else if (comboBox4.Text == "cos")
                {
                    cos();
                }
                else if (comboBox4.Text == "tan")
                {
                    tan();
                }
                else if (comboBox4.Text == "cot")
                {
                    cot();
                }
                else if (comboBox4.Text == "sec")
                {
                    sec();
                }
                else if (comboBox4.Text == "csc")
                {
                    csc();
                }
                else if (comboBox4.Text == "三角波")
                {
                    del();
                }
            }
        }
        float o; float o2;
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            o = e.X;
            o2 = e.Y;
            label5.Text = string.Format("(X: {0}, Y: {1})", ((o - 300) / 12).ToString("#0.00"), ((-o2 + 300) / 12).ToString("#0.00"));
        }

        private Point mouse_offset;

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button btn = (Button)sender;
                Point mousePos = PointToClient(Control.MousePosition);
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                btn.Location = mousePos;
            }
        }

        int clickCount = 0;
        int maxClickCount = 4;
        float[] xx = new float[4];
        float[] y = new float[4];
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox7.Text = "0";
            textBox8.Text = "0";
            pictureBox2.Image = b[1];
            SolidBrush x1 = new SolidBrush(Color.Black);
            Font drawFont = new Font("Arial", 10);
            string message = "";
            clickCount++;
            if (clickCount > maxClickCount)
            {
                message = string.Format("最多能點選{0}次。", maxClickCount);
                MessageBox.Show(message);
            }
            if (clickCount == 1)
            {
                xx[0] = (o - 300) / 12;
                y[0] = -(o2 - 300) / 12;
                textBox1.Text += "(" + xx[0].ToString("#0.00") + "," + y[0].ToString("#0.00") + ")";
                a[1].DrawString("A", drawFont, x1, xx[0] * 12, -y[0] * 12);
                a[1].FillEllipse(Brushes.Red, xx[0] * 12 - 5, -y[0] * 12, 5, 5);
            }
            else if (clickCount == 2)
            {
                xx[1] = (o - 300) / 12;
                y[1] = -(o2 - 300) / 12;
                textBox2.Text += "(" + xx[1].ToString("#0.00") + "," + y[1].ToString("#0.00") + ")";
                a[1].DrawString("B", drawFont, x1, xx[1] * 12, -y[1] * 12);
                a[1].FillEllipse(Brushes.Red, xx[1] * 12 - 5, -y[1] * 12, 5, 5);
                Draw2();
                line();
            }
            else if (clickCount == 3)
            {
                xx[2] = (o - 300) / 12;
                y[2] = -(o2 - 300) / 12;
                textBox10.Text += "(" + xx[2].ToString("#0.00") + "," + y[2].ToString("#0.00") + ")";
                a[1].DrawString("C", drawFont, x1, xx[2] * 12, -y[2] * 12);
                a[1].FillEllipse(Brushes.Red, xx[2] * 12 - 5, -y[2] * 12, 5, 5);
            }
            else if (clickCount == 4)
            {
                xx[3] = (o - 300) / 12;
                y[3] = -(o2 - 300) / 12;
                textBox9.Text += "(" + xx[3].ToString("#0.00") + "," + y[3].ToString("#0.00") + ")";
                a[1].DrawString("D", drawFont, x1, xx[3] * 12, -y[3] * 12);
                a[1].FillEllipse(Brushes.Red, xx[3] * 12 - 5, -y[3] * 12, 5, 5);
                Draw2();
                line();
            }
        }
        float ox; float xy;
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            ox = e.X;
            xy = e.Y;
            label11.Text = string.Format("(X: {0}, Y: {1})", ((ox - 300) / 12).ToString("#0.00"), ((-xy + 300) / 12).ToString("#0.00"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Draw3();
            numericUpDown2.Value = 0;
            hScrollBar1.Value = 0;
            hScrollBar2.Value = 0;
            label43.Text = "0";
            label44.Text = "0";
            textBox4.Text = "";
            textBox14.Text = "";
            textBox5.Text = "0";
            textBox16.Text = "0";
            checkBox1.Checked = false;
            checkBox1.Enabled = false;

        }
        string g_str = "功能有選擇振幅、波數、角度、函數。~~　　　　　　　   　　　　　     　　        　　　　 　               　 ";
        string g = "功能有點選座標、畫線、算出方程式、算焦點。~~　　　　　　　　　　　　                               　　　　　";
        string g1 = "　　功能有算出頂點、對稱軸、移動頂點。~~　　　　　　　　　　　　　                                   　　　　  　　   　";
        string g2 = "功能有劃出指數、對數圖形　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　";
        private void timer1_Tick(object sender, EventArgs e)
        {
            string temp = g_str.Substring(0, 1);
            g_str = g_str.Substring(1, g_str.Length - 1) + temp;
            toolStripStatusLabel2.Text = g_str;
            string gg = g.Substring(0, 1);
            g = g.Substring(1, g.Length - 1) + gg;
            toolStripStatusLabel6.Text = g;
            string ggg = g1.Substring(0, 1);
            g1 = g1.Substring(1, g1.Length - 1) + ggg;
            toolStripStatusLabel12.Text = g1;
            string gggg = g2.Substring(0, 1);
            g2 = g2.Substring(1, g2.Length - 1) + gggg;
            toolStripStatusLabel16.Text = g2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random sd = new Random();
            byte[] sa = new byte[255];
            int[] ss = new int[3];
            int[] bb = new int[3];
            for (int d = 0; d < ss.Length; d++)
            {
                int g = sd.Next(1, 255);
                if (sa[g] == 0)
                {
                    ss[d] = g;
                    sa[g] = 1;
                }
                else d--;
                for (int i = 0; i < 3; i++)
                {
                    bb[i] = ss[i];
                }
            }
            button3.BackColor = Color.FromArgb(ss[0], ss[1], ss[2]);
            x.Color = button3.BackColor;
            Draw();
            if (comboBox4.Text == "sin")
            {
                sin();
            }
            else if (comboBox4.Text == "cos")
            {
                cos();
            }
            else if (comboBox4.Text == "tan")
            {
                tan();
            }
            else if (comboBox4.Text == "cot")
            {
                cot();
            }
            else if (comboBox4.Text == "sec")
            {
                sec();
            }
            else if (comboBox4.Text == "csc")
            {
                csc();
            }
            else if (comboBox4.Text == "三角波")
            {
                del();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random sd = new Random();
            byte[] sa = new byte[255];
            int[] ss = new int[3];
            int[] bb = new int[3];
            for (int d = 0; d < ss.Length; d++)
            {
                int g = sd.Next(1, 255);
                if (sa[g] == 0)
                {
                    ss[d] = g;
                    sa[g] = 1;
                }
                else d--;
                for (int i = 0; i < 3; i++)
                {
                    bb[i] = ss[i];
                }
            }
            button4.BackColor = Color.FromArgb(ss[0], ss[1], ss[2]);
            Mypen.Color = button4.BackColor;
            Draw();
            if (comboBox4.Text == "sin")
            {
                sin();
            }
            else if (comboBox4.Text == "cos")
            {
                cos();
            }
            else if (comboBox4.Text == "tan")
            {
                tan();
            }
            else if (comboBox4.Text == "cot")
            {
                cot();
            }
            else if (comboBox4.Text == "sec")
            {
                sec();
            }
            else if (comboBox4.Text == "csc")
            {
                csc();
            }
            else if (comboBox4.Text == "三角波")
            {
                del();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Random sd = new Random();
            byte[] sa = new byte[255];
            int[] ss = new int[3];
            int[] bb = new int[3];
            for (int d = 0; d < ss.Length; d++)
            {
                int g = sd.Next(1, 255);
                if (sa[g] == 0)
                {
                    ss[d] = g;
                    sa[g] = 1;
                }
                else d--;
                for (int i = 0; i < 3; i++)
                {
                    bb[i] = ss[i];
                }
            }
            button6.BackColor = Color.FromArgb(ss[0], ss[1], ss[2]);
            pictureBox1.BackColor = button6.BackColor;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Random sd = new Random();
            byte[] sa = new byte[255];
            int[] ss = new int[3];
            int[] bb = new int[3];
            for (int d = 0; d < ss.Length; d++)
            {
                int g = sd.Next(1, 255);
                if (sa[g] == 0)
                {
                    ss[d] = g;
                    sa[g] = 1;
                }
                else d--;
                for (int i = 0; i < 3; i++)
                {
                    bb[i] = ss[i];
                }
            }
            button5.BackColor = Color.FromArgb(ss[0], ss[1], ss[2]);
            tabPage1.BackColor = button5.BackColor;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Draw2();
            line1();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox8.Text != "")
            {
                Draw2();
                line1();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox8.Text != "")
            {
                Draw2();
                line1();
            }
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            textBox7.Text = vScrollBar1.Value.ToString();
        }

        private void vScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            textBox7.Text = vScrollBar2.Value.ToString();
            clickCount = 0;
            xx[0] = 0; y[0] = 0;
            xx[1] = 0; y[1] = 0;
            xx[2] = 0; y[2] = 0;
            xx[3] = 0; y[3] = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox11.Text = "";
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox8.Text = vScrollBar1.Value.ToString();
            clickCount = 0;
            xx[0] = 0; y[0] = 0;
            xx[1] = 0; y[1] = 0;
            xx[2] = 0; y[2] = 0;
            xx[3] = 0; y[3] = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox11.Text = "";
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Draw3();
            line2();
            if (checkBox1.Checked != false)
            {
                linex();
            }
            label44.Text = hScrollBar1.Value.ToString();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            Draw3();
            line2();
            if (checkBox1.Checked != false)
            {
                linex();
            }
            label43.Text = hScrollBar2.Value.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Draw4();
            line3();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Draw3();
            if (numericUpDown2.Value.ToString() != "")
                line2();
        }

        float lx, ly;
        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            lx = e.X;
            ly = e.Y;
            label32.Text = string.Format("(X: {0}, Y: {1})", ((lx - 300) / 60).ToString("#0.00"), ((-ly + 300) / 60).ToString("#0.00"));
        }
        private void linex()//對稱軸1
        {
            pictureBox3.Image = b[2];
            float h1 = float.Parse(hScrollBar1.Value.ToString());
            Mypen3.Width = 2;
            a[2].DrawLine(Mypen3, h1 * 12, 300, h1 * 12, -300);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                linex();
            }
            else if (checkBox1.Checked == false)
            {
                Draw3();
                line2();
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Draw4();
            line4();
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            Draw4();
            line3();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw4();
            if (comboBox5.Text == "指數")
            {
                groupBox10.Enabled = false;
                groupBox9.Enabled = true;
                line3();
            }
            else if (comboBox5.Text == "對數")
            {
                line4();
                groupBox9.Enabled = false;
                groupBox10.Enabled = true;
            }
        }
        float mx, my;
        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            mx = e.X;
            my = e.Y;
            label52.Text = string.Format("(X: {0}, Y: {1})", ((mx - 300) / 30).ToString("#0.00"), ((-my + 300) / 30).ToString("#0.00"));
        }

        private void hScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            label64.Text = hScrollBar4.Value.ToString();
            Draw5();
            line5();
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            label62.Text = hScrollBar3.Value.ToString();
            Draw5();
            line5();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Draw5();
            if (numericUpDown4.Value.ToString() != "" && numericUpDown5.Value.ToString() != "" && numericUpDown6.Value.ToString() != "")
                line5();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Draw5();
            if (numericUpDown4.Value.ToString() != "" && numericUpDown5.Value.ToString() != "" && numericUpDown6.Value.ToString() != "")
                line5();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            Draw5();
            if (numericUpDown4.Value.ToString() != "" && numericUpDown5.Value.ToString() != "" && numericUpDown6.Value.ToString() != "")
                line5();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Draw5();
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
            numericUpDown5.Enabled = false;
            numericUpDown6.Enabled = false;
            textBox18.Text = "0";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            hScrollBar4.Enabled = false;
            hScrollBar3.Enabled = false;
            hScrollBar3.Value = 0;
            hScrollBar4.Value = 0;
            label64.Text = "0";
            label62.Text = "0";
        }
        Bitmap bmp;
        int w, h;
        float W, H;      
        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap newbmp = new Bitmap(bmp.Width, bmp.Height);
            float[][] nArray ={new float[]{0.33f,0.33f,0.33f,0,0},
                             new float[]{0.33f,0.33f,0.33f,0,0},
                             new float[]{0.33f,0.33f,0.33f,0,0},
                             new float[]{0,0,0,1,0},
                             new float[]{0,0,0,0,1}};
            ColorMatrix cm = new ColorMatrix(nArray);
            ImageAttributes att = new ImageAttributes();
            att.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Graphics g = Graphics.FromImage(newbmp);
            g.Clear(pictureBox7.BackColor);
            g.DrawImage(bmp, new Rectangle(0, 0, newbmp.Width, newbmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, att);
            pictureBox7.Image = newbmp;
        }
      
        private void button8_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Jpeg(*.jpg)|*.jpg|點陣圖(*)|*.bmp";
            openFileDialog1.FileName = "r8";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                L = openFileDialog1.FileName;
                bmp = new Bitmap(L);
                W = (float)pictureBox6.Width / bmp.Width;
                H = (float)pictureBox6.Height / bmp.Height;


                if (W < H)
                {
                    w = pictureBox6.Width;
                    h = (int)(bmp.Height * W);
                }
                else
                {
                    w = (int)(pictureBox6.Width * H);
                    h = pictureBox6.Height;
                }
                pictureBox6.Image = bmp;
            }
        }
        private void M()
        {
            
            bmp = new Bitmap(L);
            W = (float)pictureBox6.Width / bmp.Width;
            H = (float)pictureBox6.Height / bmp.Height;
            if (W < H)
            {
                w = pictureBox6.Width;
                h = (int)(bmp.Height * W);
            }
            else
            {
                w = (int)(pictureBox6.Width * H);
                h = pictureBox6.Height;
            }
            pictureBox6.Image = bmp;
        }
        Bitmap bmp2;
        private void m2()
        {
            bmp2 = new Bitmap("P.jpg");
            W = (float)pictureBox8.Width / bmp.Width;
            H = (float)pictureBox8.Height / bmp.Height;
            if (W < H)
            {
                w = pictureBox8.Width;
                h = (int)(bmp2.Height * W);
            }
            else
            {
                w = (int)(pictureBox8.Width * H);
                h = pictureBox8.Height;
            }
            pictureBox8.Image = bmp2;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap newbmp = new Bitmap(bmp,bmp.Width, bmp.Height);
            float[][] nArry = { new float[] { -1, 0, 0, 0, 0 }, new float[] { 0, -1, 0, 0, 0 }, new float[] { 0, 0, -1, 0, 0 }, new float[] { 0, 0, 0, 1, 0 }, new float[] { 1, 1, 1, 0, 1 } };
            ColorMatrix cm = new ColorMatrix(nArry);
            ImageAttributes att = new ImageAttributes();
            att.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Graphics g = Graphics.FromImage(newbmp);
            g.Clear(pictureBox7.BackColor);
            g.DrawImage(bmp, new Rectangle(0, 0, newbmp.Width, newbmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, att);
            pictureBox7.Image = newbmp;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int r, g, b, avg;
            Bitmap newbmp = new Bitmap(bmp,bmp.Width, bmp.Height);
            int x, y;
            Color c;
            for(x=0;x<bmp.Width;x++)
            for(y=0;y<bmp.Height;y++)
            {
                c = newbmp.GetPixel(x, y);
                r = c.R;
                g = c.G;
                b = c.B;
                avg = (r + g + b) / 3;
                if(avg>=128)
                {
                    newbmp.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                }
                else
                {
                    newbmp.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                }
            }
            pictureBox7.Image = newbmp;
        }

        private void hScrollBar5_Scroll(object sender, ScrollEventArgs e)
        {
            label66.Text = hScrollBar5.Value.ToString();
            float alpha = (float)(Convert.ToDouble(hScrollBar5.Value) / 255);
            Bitmap newbmp = new Bitmap(bmp.Width, bmp.Height);
            float[][] nArry = { new float[] { 1, 0, 0, 0, 0 }, new float[] { 0, 1, 0, 0, 0 }, new float[] { 0, 0, 1, 0, 0 }, new float[] { 0, 0, 0, alpha, 0 }, new float[] { 0, 0, 0, 0, 1 } };
            ColorMatrix cm = new ColorMatrix(nArry);
            ImageAttributes att = new ImageAttributes();
            att.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Graphics g = Graphics.FromImage(newbmp);
            g.Clear(pictureBox7.BackColor);
            g.DrawImage(bmp, new Rectangle(0, 0, newbmp.Width, newbmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, att);
            pictureBox7.Image = newbmp;
        }
        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            //int angle = int.Parse(numericUpDown7.Value.ToString());
            //Graphics j;           
            //j = pictureBox7.CreateGraphics();
            //j.Clear(this.tabPage6.BackColor);
            //Bitmap newbmp = new Bitmap(bmp.Width, bmp.Height);
            //j.RotateTransform(-angle);
            //j.DrawImage(newbmp, 0, 0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox7.Image = bmp;           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox7.Image = bmp;
        }
    }
}