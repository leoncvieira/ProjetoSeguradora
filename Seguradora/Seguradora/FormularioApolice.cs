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
    public partial class FormularioApolice : Form
    {
        public FormularioApolice()
        {
            InitializeComponent();
        }

        void Limpar()
        {
            txtDataContrato.Text = "";
            txtDataFim.Text = "";
            txtDataInicio.Text = "";
            txtFranquia.Text = "";
            txtIdApolice.Text = "";
            txtIdPessoa.Text = "";
            txtIdVeiculo.Text = "";
            txtNumApolice.Text = "";
            txtValor.Text = "";

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            ClasseApolice apolice = new ClasseApolice();

            apolice.IdApolice = Convert.ToInt32(txtIdApolice.Text);
            apolice.IdPessoa = Convert.ToInt32(txtIdPessoa.Text);
            apolice.IdVeiculo = Convert.ToInt32(txtIdVeiculo.Text);
            apolice.NumeroApolice = txtNumApolice.Text;
            apolice.DataInicio = Convert.ToDateTime(txtDataInicio.Text);
            apolice.DataFim = Convert.ToDateTime(txtDataFim.Text);
            apolice.Valor = Convert.ToDouble(txtValor.Text);
            apolice.Franquia = Convert.ToDouble(txtFranquia.Text);
            apolice.DataContrato = Convert.ToDateTime(txtDataContrato.Text);

            string msg = apolice.Inserir();
            MessageBox.Show(msg);

            Limpar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ClasseApolice apolice = new ClasseApolice();

            apolice.IdApolice = Convert.ToInt32(txtIdApolice.Text);
            apolice.IdPessoa = Convert.ToInt32(txtIdPessoa.Text);
            apolice.IdVeiculo = Convert.ToInt32(txtIdVeiculo.Text);
            apolice.NumeroApolice = txtNumApolice.Text;
            apolice.DataInicio = Convert.ToDateTime(txtDataInicio.Text);
            apolice.DataFim = Convert.ToDateTime(txtDataFim.Text);
            apolice.Valor = Convert.ToDouble(txtValor.Text);
            apolice.Franquia = Convert.ToDouble(txtFranquia.Text);
            apolice.DataContrato = Convert.ToDateTime(txtDataContrato.Text);

            string msg = apolice.Alterar();
            MessageBox.Show(msg);

            Limpar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ClasseApolice apolice = new ClasseApolice();

            apolice.IdApolice = Convert.ToInt32(txtIdApolice.Text);

            string msg = apolice.Excluir();
            MessageBox.Show(msg);

            Limpar();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ClasseApolice apolice = new ClasseApolice();

            if (txtIdApolice.Text == "")
            {
                DataTable tbldados = apolice.Consultar();
                dgvConsulta.DataSource = tbldados;

            }
            else
            {
                DataTable tbldados = apolice.Consultar();

                txtDataContrato.Text = tbldados.Rows[0]["DataContrato"].ToString();
                txtDataFim.Text = tbldados.Rows[0]["DataFim"].ToString();
                txtDataInicio.Text = tbldados.Rows[0]["DataInicio"].ToString();
                txtFranquia.Text = tbldados.Rows[0]["Franquia"].ToString();
                txtIdApolice.Text = tbldados.Rows[0]["IdApolice"].ToString();
                txtIdPessoa.Text = tbldados.Rows[0]["IdPessoa"].ToString();
                txtIdVeiculo.Text = tbldados.Rows[0]["IdVeiculo"].ToString();
                txtNumApolice.Text = tbldados.Rows[0]["Numeroapolice"].ToString();
                txtValor.Text = tbldados.Rows[0]["valor"].ToString();
            }
        }

        private void dgvConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgvConsulta.Rows[rowIndex];
            txtIdPessoa.Text = row.Cells[0].Value.ToString();
            txtIdApolice.Text = row.Cells[1].Value.ToString();
            txtIdVeiculo.Text = row.Cells[2].Value.ToString();
            txtNumApolice.Text = row.Cells[3].Value.ToString();
            txtDataInicio.Text = row.Cells[4].Value.ToString();
            txtDataFim.Text = row.Cells[5].Value.ToString();
            txtValor.Text = row.Cells[6].Value.ToString();
            txtFranquia.Text = row.Cells[7].Value.ToString();
            txtDataContrato.Text = row.Cells[8].Value.ToString();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void FormularioApolice_KeyDown(object sender, KeyEventArgs e)
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

        private void FormularioApolice_Load(object sender, EventArgs e)
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(FormularioApolice_KeyDown);
            txtIdApolice.Focus();
        }
    }
}
