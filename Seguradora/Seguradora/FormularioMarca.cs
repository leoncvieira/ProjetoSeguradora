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
    public partial class FormularioMarca : Form
    {

        public void Limpar() {
            txtDescricao.Text = "";
            txtIdMarca.Text = "";
            dgvConsulta.Rows.Clear();
            dgvConsulta.Refresh();
        }


        public FormularioMarca()
        {
            InitializeComponent();
        }

        //METODO INSERIR
        private void btnInserir_Click(object sender, EventArgs e)
        {
            ClasseMarcas marca = new ClasseMarcas();

            marca.IdMarca = Convert.ToInt32(txtIdMarca.Text);
            marca.Descricao = txtDescricao.Text;

            string msg = marca.Inserir();
            MessageBox.Show(msg);
            Limpar();

        }

        //METODO ALTERAR
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ClasseMarcas marca = new ClasseMarcas();

            marca.IdMarca = Convert.ToInt32(txtIdMarca.Text);
            marca.Descricao = txtDescricao.Text;

            string msg = marca.Alterar();
            MessageBox.Show(msg);
            Limpar();

        }

        //METODO CONSULTAR
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ClasseMarcas marca = new ClasseMarcas();

            if (txtIdMarca.Text == "")
            {
                
                DataTable tblDados = marca.Consultar();
                dgvConsulta.DataSource = tblDados;
                int n = dgvConsulta.RowCount;

                MessageBox.Show("Consulta retornou " + n.ToString() + " resultados!");
            }
            else
            {
                DataTable tblDados = marca.Consultar(txtIdMarca.Text);

                txtDescricao.Text = tblDados.Rows[0]["descricao"].ToString();
            }

        }

        //METODO EXCLUIR
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ClasseMarcas marca = new ClasseMarcas();

            marca.IdMarca = Convert.ToInt32(txtIdMarca.Text);

            string msg = marca.Excluir();
            MessageBox.Show(msg);
            Limpar();
        }

        private void dgvConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgvConsulta.Rows[rowIndex];

            txtIdMarca.Text = row.Cells[0].Value.ToString();
            txtDescricao.Text = row.Cells[1].Value.ToString();

        }

        private void FormularioMarca_Load(object sender, EventArgs e)
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(FormularioMarca_KeyDown);
            txtIdMarca.Focus();
        }

        private void FormularioMarca_KeyDown(object sender, KeyEventArgs e)
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
