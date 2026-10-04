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

namespace hft6odev1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static public int selected = 8;

        static public PictureBox[] yenibox = new PictureBox[9];
        private void Form1_Load(object sender, EventArgs e)
        {

            int positionx = 100;
            int positiony = 100;

            int[] oncekisayilar = new int[9];

            int t = 1;
            oncekisayilar[0] = 0;
            Random dnm = new Random();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    bool oncekilerleayni = true;
                    int hangifotograf = 0;
                    while (oncekilerleayni == true)
                    {
                        oncekilerleayni = false;
                        hangifotograf = dnm.Next(1, 9);
                        for (int p = 0; p < oncekisayilar.Length; p++)
                        {
                            if (hangifotograf == oncekisayilar[p]) oncekilerleayni = true;
                        }
                    }
                    if (t < 8) oncekisayilar[t] = hangifotograf;

                    int ss = i * 3 + j;

                    yenibox[ss] = new PictureBox();
                    this.Controls.Add(yenibox[ss]);
                    yenibox[ss].Text = ss.ToString();
                    yenibox[ss].Name = "pictureb" + ss;
                    yenibox[ss].Size = new Size(325, 150);
                    yenibox[ss].SizeMode = PictureBoxSizeMode.StretchImage;
                    yenibox[ss].Location = new Point(positionx, positiony);
                    //yenibox[i].Click += new System.EventHandler(this.EventHandlerButton_Click);
                    if (i + j < 4)
                    {
                        yenibox[ss].Image = Image.FromFile(Application.StartupPath + @"\..\..\Görseller\Ana Görseller\" + hangifotograf.ToString() + ".jpg");
                    }
                    else yenibox[ss].Image = Image.FromFile(Application.StartupPath + @"\..\..\Görseller\Ana Görseller\9.jpg");

                    positionx += 335;

                    t += 1;
                }
                positionx = 100;
                positiony += 160;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            string basilantus = e.KeyCode.ToString();
            string gcc = "";

            switch (basilantus)
            {
                case "Up":
                    if (selected != 0 && selected != 1 && selected != 2)
                    {
                        gcc = yenibox[selected].Text.ToString();
                        yenibox[selected].Image = yenibox[selected - 3].Image;
                        yenibox[selected - 3].Image = Image.FromFile(Application.StartupPath + @"\..\..\Görseller\Ana Görseller\" + 9 + ".jpg");
                        selected = Convert.ToInt32(yenibox[selected - 3].Text);
                    }
                    break;

                case "Down":
                    if (selected != 6 && selected != 7 && selected != 8)
                    {
                        gcc = yenibox[selected].Text.ToString();
                        yenibox[selected].Image = yenibox[selected + 3].Image;
                        yenibox[selected + 3].Image = Image.FromFile(Application.StartupPath + @"\..\..\Görseller\Ana Görseller\" + 9 + ".jpg");
                        selected = Convert.ToInt32(yenibox[selected + 3].Text);
                    }
                    break;

                case "Right":
                    if (selected != 2 && selected != 5 && selected != 8)
                    {
                        gcc = yenibox[selected].Text.ToString();
                        yenibox[selected].Image = yenibox[selected + 1].Image;
                        yenibox[selected + 1].Image = Image.FromFile(Application.StartupPath + @"\..\..\Görseller\Ana Görseller\" + 9 + ".jpg");
                        selected = Convert.ToInt32(yenibox[selected + 1].Text);
                    }

                    break;

                case "Left":
                    if (selected != 0 && selected != 3 && selected != 6)
                    {
                        gcc = yenibox[selected].Text.ToString();
                        yenibox[selected].Image = yenibox[selected - 1].Image;
                        yenibox[selected - 1].Image = Image.FromFile(Application.StartupPath + @"\..\..\Görseller\Ana Görseller\" + 9 + ".jpg");
                        selected = Convert.ToInt32(yenibox[selected - 1].Text);
                    }
                    break;
            }
        }
    }
}
