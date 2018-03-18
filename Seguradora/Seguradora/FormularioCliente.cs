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
    public partial class FormularioCliente : Form
    {
        public void Limpar() {
            txtBairro.Text = "";
            txtCep.Text = "";
            txtCPF.Text = "";
            txtData.Text = "";
            txtEndereco.Text = "";
            txtFone.Text = "";
            txtIdPessoa.Text = "";
            txtNome.Text = "";
            txtRG.Text = "";
            txtSexo.Text = "";
            dgvConsulta.Rows.Clear();
            dgvConsulta.Refresh();

        } // Metodo limpar

        public FormularioCliente()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //botao consultar
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ClasseCliente cliente = new ClasseCliente();

            if (txtIdPessoa.Text == "")
            {
                DataTable tbldados = cliente.Consultar();
                dgvConsulta.DataSource = tbldados;
            }
            else
            {
                DataTable tbldados = cliente.Consultar(txtIdPessoa.Text);
          
                txtNome.Text = tbldados.Rows[0]["nome"].ToString();
                txtFone.Text = tbldados.Rows[0]["fone"].ToString();
                txtEndereco.Text = tbldados.Rows[0]["endereco"].ToString();
                txtBairro.Text = tbldados.Rows[0]["bairro"].ToString();
                txtCep.Text = tbldados.Rows[0]["cep"].ToString();
                txtCPF.Text = tbldados.Rows[0]["cpf"].ToString();
                txtRG.Text = tbldados.Rows[0]["rg"].ToString();
            }
           
        }

        //botao inserir
        protected void btnInserir_Click(object sender, EventArgs e)
        {
            ClasseCliente cliente = new ClasseCliente();

            cliente.Idpessoa1 = Convert.ToInt32(txtIdPessoa.Text);
            cliente.Nome = txtNome.Text;
            cliente.Fone = txtFone.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Cep = txtCep.Text;
            cliente.Cpf = txtCPF.Text;
            cliente.DataNascimento = Convert.ToDateTime(txtData.Text);
            cliente.Rg = txtRG.Text;
            cliente.Sexo = txtSexo.Text;

            string msg = cliente.Inserir();
            MessageBox.Show(msg);
            Limpar();
        }

        //botao alterar
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ClasseCliente cliente = new ClasseCliente();
            cliente.Idpessoa1 = Convert.ToInt32(txtIdPessoa.Text);
            cliente.Nome = txtNome.Text;
            cliente.Fone = txtFone.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Cep = txtCep.Text;
            cliente.Cpf = txtCPF.Text;
            cliente.DataNascimento = Convert.ToDateTime(txtData.Text);
            cliente.Rg = txtRG.Text;
            cliente.Sexo = txtSexo.Text;

            string msg = cliente.Alterar();
            MessageBox.Show(msg);
            Limpar();
        }

        //botao excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ClasseCliente cliente = new ClasseCliente();

            cliente.Idpessoa1 = Convert.ToInt32(txtIdPessoa.Text);

            string msg = cliente.Excluir();
            MessageBox.Show(msg);
            Limpar();
        }


        private void dgvConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //DoubleClick na celula da DataGridView
        private void dgvConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int rowIndex = e.RowIndex;
           DataGridViewRow row = dgvConsulta.Rows[rowIndex];
            txtIdPessoa.Text = row.Cells[0].Value.ToString();
            txtNome.Text = row.Cells[1].Value.ToString();
            txtFone.Text = row.Cells[2].Value.ToString();
            txtEndereco.Text = row.Cells[3].Value.ToString();
            txtBairro.Text = row.Cells[4].Value.ToString();
            txtCep.Text = row.Cells[5].Value.ToString();
                
        }

        //FormLoad
        private void FormularioCliente_Load(object sender, EventArgs e)
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(FormularioCliente_KeyDown);
            txtIdPessoa.Focus();
        }

        //Botao Limpar
        private void button1_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        //KeyDown
        private void FormularioCliente_KeyDown(object sender, KeyEventArgs e)
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

        private void txtFone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
