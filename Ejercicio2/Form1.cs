using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Streamer;

namespace Ejercicio2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log test = new Log();

            Streamer.Text.path = "file.txt";
            MessageBox.Show(Streamer.Text.writeText("TEST").ToString());

            Persona nueva = new Persona("21;Masculino;22;");
            MessageBox.Show(nueva.ToString());
        }
    }
}
