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
    public partial class FormularioZMenu : Form
    {
        public FormularioZMenu()
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

            FormularioCliente cliente = new FormularioCliente();
            cliente.TopLevel = false;
            panelMenu.Controls.Add(cliente);
            cliente.Show();
        }

        private void veiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMenu.Controls.Clear();

            FormularioVeiculo veiculo = new FormularioVeiculo();
            veiculo.TopLevel = false;
            panelMenu.Controls.Add(veiculo);
            veiculo.Show();
        }

        private void apoliceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMenu.Controls.Clear();

            FormularioApolice apolice = new FormularioApolice();
            apolice.TopLevel = false;
            panelMenu.Controls.Add(apolice);
            apolice.Show();
        }

        private void modeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMenu.Controls.Clear();

            FormularioModelo modelo = new FormularioModelo();
            modelo.TopLevel = false;
            panelMenu.Controls.Add(modelo);
            modelo.Show();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMenu.Controls.Clear();

            FormularioMarca marca = new FormularioMarca();
            marca.TopLevel = false;
            panelMenu.Controls.Add(marca);
            marca.Show();
        }

        private void FormularioZMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Deseja sair da aplicação?", "Sair", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void FormularioZMenu_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
