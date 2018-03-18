using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seguradora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMenu.Controls.Clear();

            Cliente cliente = new Cliente();
            cliente.TopLevel = false;
            panelMenu.Controls.Add(cliente);
            cliente.Show();
        }

        private void veiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMenu.Controls.Clear();

            Veiculo veiculo = new Veiculo();
            veiculo.TopLevel = false;
            panelMenu.Controls.Add(veiculo);
            veiculo.Show();
        }

        private void apoliceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMenu.Controls.Clear();

            Apolice apolice = new Apolice();
            apolice.TopLevel = false;
            panelMenu.Controls.Add(apolice);
            apolice.Show();
        }

        private void modeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMenu.Controls.Clear();

            Modelo modelo = new Modelo();
            modelo.TopLevel = false;
            panelMenu.Controls.Add(modelo);
            modelo.Show();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMenu.Controls.Clear();

            Marca marca = new Marca();
            marca.TopLevel = false;
            panelMenu.Controls.Add(marca);
            marca.Show();
        }
    }
}
