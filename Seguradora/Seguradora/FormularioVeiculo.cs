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
    public partial class FormularioVeiculo : Form
    {
        public FormularioVeiculo()
        {
            InitializeComponent();
        }

        //METODO LIMPAR
        public void Limpar()
        {
            txtAno.Text = "";
            txtIdModelo.Text = "";
            txtIdVeiculo.Text = "";
            txtPlaca.Text = "";
            dgvConsulta.Rows.Clear();
            dgvConsulta.Refresh();
        }

        //BOTAO INSERIR
        private void btnInserir_Click(object sender, EventArgs e)
        {
            ClasseVeiculo veiculo = new ClasseVeiculo();

            veiculo.IdVeiculo = Convert.ToInt32(txtIdVeiculo.Text);
            veiculo.IdModelo = Convert.ToInt32(txtIdModelo.Text);
            veiculo.Placa = txtPlaca.Text;
            veiculo.Ano = Convert.ToInt32(txtAno.Text);

            string msg = veiculo.Inserir();

            MessageBox.Show(msg);
            Limpar();
        }

        //BOTAO ALTERAR
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ClasseVeiculo veiculo = new ClasseVeiculo();

            veiculo.IdVeiculo = Convert.ToInt32(txtIdVeiculo.Text);
            veiculo.IdModelo = Convert.ToInt32(txtIdModelo.Text);
            veiculo.Placa = txtPlaca.Text;
            veiculo.Ano = Convert.ToInt32(txtAno.Text);

            string msg = veiculo.Alterar();

            MessageBox.Show(msg);
            Limpar();
        }

        //BOTAO CONSULTAR
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ClasseVeiculo veiculo = new ClasseVeiculo();

            if (txtIdModelo.Text == "")
            {
                DataTable tblDados = veiculo.Consultar();
                dgvConsulta.DataSource = tblDados;
                int n = dgvConsulta.RowCount;

                MessageBox.Show("Consulta retornou " + n.ToString() + " resultados!");
            }
            else
            {
                DataTable tbldados = veiculo.Consultar(txtIdModelo.Text);

                txtIdModelo.Text = tbldados.Rows[0]["IdModelo"].ToString();
                txtIdVeiculo.Text = tbldados.Rows[0]["IdVeiculo"].ToString();
                txtPlaca.Text = tbldados.Rows[0]["placa"].ToString();
                txtAno.Text = tbldados.Rows[0]["ano"].ToString();
            }
        }

        //BOTAO EXCLUIR
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ClasseVeiculo veiculo = new ClasseVeiculo();

            veiculo.IdVeiculo = Convert.ToInt32(txtIdVeiculo.Text);

            string msg = veiculo.Excluir();
            MessageBox.Show(msg);

            Limpar();
        }

        private void FormularioVeiculo_Load(object sender, EventArgs e)
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(FormularioVeiculo_KeyDown);
            txtIdVeiculo.Focus();
        }

        private void FormularioVeiculo_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgvConsulta_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgvConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgvConsulta.Rows[rowIndex];

            txtIdVeiculo.Text = row.Cells[0].Value.ToString();
            txtIdModelo.Text = row.Cells[1].Value.ToString();
            txtPlaca.Text = row.Cells[2].Value.ToString();
            txtAno.Text = row.Cells[3].Value.ToString();
            
        }

        private void FormularioVeiculo_KeyDown(object sender, KeyEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
