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
using Ejercicio2.Source;

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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Streamer.Text.ExistsAndIsTxt(textBox1.Text))
                {
                    Administrador.indicarFichero(textBox1.Text);
                    Administrador.procesar();
                    label7.Text = Administrador.CantidadMasculinos.ToString();
                    label6.Text = Administrador.CantidadFemeninos.ToString();
                    label3.Text = Administrador.TotalPersonas.ToString();
                    richTextBox1.Text = Administrador.traerHistorico();
                }
                else
                {
                    MessageBox.Show(string.Format("El archivo especificado es inválido\n{0}", textBox1.Text), "Error");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
