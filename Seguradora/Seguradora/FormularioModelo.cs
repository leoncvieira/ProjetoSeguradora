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
    public partial class FormularioModelo : Form
    {
        public FormularioModelo()
        {
            InitializeComponent();
        }


        //Metodo para limpas as TextBox e a DataGridView
        public void Limpar()
        {
            txtDescricao.Text = "";
            txtIdModelo.Text = "";
            txtMarca.Text = "";
            dgvConsulta.Rows.Clear();
            dgvConsulta.Refresh();
        }


        //FormLoad
        private void FormularioModelo_Load(object sender, EventArgs e)
        {
            //Comando para poder usar o KeyDown
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(FormularioModelo_KeyDown);
            txtIdModelo.Focus();
        }

        private void txtIdMarca_TextChanged(object sender, EventArgs e)
        {

        }

        //Botao Inserir
        private void btnInserir_Click(object sender, EventArgs e)
        {
            ClasseModelo modelo = new ClasseModelo();

            modelo.IdModelo = Convert.ToInt32(txtIdModelo.Text);
            modelo.IdMarca = Convert.ToInt32(txtMarca.Text);
            modelo.Descricao = txtDescricao.Text;

            string msg = modelo.Inserir();
            MessageBox.Show(msg);

            Limpar();
        }

        //Botao Alterar
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ClasseModelo modelo = new ClasseModelo();

            modelo.IdModelo = Convert.ToInt32(txtIdModelo.Text);
            modelo.IdMarca = Convert.ToInt32(txtMarca.Text);
            modelo.Descricao = txtDescricao.Text;

            string msg = modelo.Alterar();
            MessageBox.Show(msg);

            Limpar();
        }

        //Botao Excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ClasseModelo modelo = new ClasseModelo();

            modelo.IdModelo = Convert.ToInt32(txtIdModelo.Text);

            string msg = modelo.Excluir();
            MessageBox.Show(msg);

            Limpar();
        }

        //Botao Consultar
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ClasseModelo modelo = new ClasseModelo();

            if (txtIdModelo.Text == "")
            {
                DataTable tbldados = modelo.Consultar();
                dgvConsulta.DataSource = tbldados;
                int n = dgvConsulta.RowCount;

                MessageBox.Show("Consulta retornou " + n.ToString() + " resultados!");
            }
            else
            {
                DataTable tbldados = modelo.Consultar(txtIdModelo.Text);

                txtIdModelo.Text = tbldados.Rows[0]["IdModelo"].ToString();
                txtMarca.Text = tbldados.Rows[0]["IdMarca"].ToString();
                txtDescricao.Text = tbldados.Rows[0]["Descricao"].ToString();
            }
        }

        //Duplo clique no DataGridView para mandar pro FORM
        private void dgvConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgvConsulta.Rows[rowIndex];

            txtIdModelo.Text = row.Cells[0].Value.ToString();
            txtMarca.Text = row.Cells[1].Value.ToString();
            txtDescricao.Text = row.Cells[2].Value.ToString();

        }

        //Botao Limpar
        private void button1_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        //KeyDown
        private void FormularioModelo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                Limpar();
            }
            else if (e.KeyCode == Keys.F1)
            {
                btnInserir.PerformClick();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnAlterar.PerformClick();
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnConsultar.PerformClick();
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnExcluir.PerformClick();
            }
        }
    }
}
