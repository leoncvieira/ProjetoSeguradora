using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Seguradora
{
    class ClasseCliente : ClassePessoa
    {
        #region Atributos
        string cpf;
        string rg;
        string sexo;
        DateTime dataNascimento;
        #endregion;

        public string Cpf { get => cpf; set => cpf = value; }
        public string Rg { get => rg; set => rg = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public DateTime DataNascimento { get => dataNascimento; set => dataNascimento = value; }

        public override string Inserir() {

            base.Inserir(); //Inserindo os dados da classe pessoa.

            string insert = "INSERT into CLIENTE (idpessoa,CPF,RG,Sexo, DataNascimento) VALUES (@idpessoa, @cpf, @rg, '@sexo', @datanascimento)";

            insert = insert.Replace("@idpessoa", base.Idpessoa1.ToString());
            insert = insert.Replace("@cpf", Cpf.ToString());
            insert = insert.Replace("@rg", Rg.ToString());
            insert = insert.Replace("@sexo", Sexo.ToString());
            insert = insert.Replace("@datanascimento", DataNascimento.ToShortDateString());

            banco.ExecutarComando(insert);

            return "Inserido com sucesso";
        }

        public override string Alterar()
        {
            base.Alterar();

            string alterar = "UPDATE Cliente set cpf='@cpf', rg='@rg', sexo='@rg', datanascimento='@datanascimento' WHERE Idpessoa=@Idpessoa";

            alterar = alterar.Replace("@Idpessoa", Idpessoa.ToString());
            alterar = alterar.Replace("@cpf", Cpf.ToString());
            alterar = alterar.Replace("@rg", Rg.ToString());
            alterar = alterar.Replace("@sexo", Sexo.ToString());
            alterar = alterar.Replace("@datanascimento", DataNascimento.ToShortDateString());

            banco.ExecutarComando(alterar);
            return "Alterado com sucesso";
        }

        public virtual DataTable Consultar() {
            DataTable tblDados = new DataTable();

            string consultar = "SELECT *,DATE_FORMAT(datanascimento,'%Y/%m/%d') AS datanascimento FROM Pessoa INNER JOIN Cliente ON Pessoa.Idpessoa=Cliente.Idpessoa";

            tblDados = banco.ExecutarSelect(consultar);

            return tblDados;
        }

        public virtual DataTable Consultar(string pCondicao)
        {
            DataTable tblDados = new DataTable();

            string consultar = "SELECT *,DATE_FORMAT(datanascimento,'%Y/%m/%d') AS datanascimento FROM Pessoa INNER JOIN Cliente ON Pessoa.Idpessoa=Cliente.Idpessoa WHERE cliente.idpessoa=" + pCondicao;

            tblDados = banco.ExecutarSelect(consultar);

            return tblDados;
        }

        public override string Excluir()
        {
            
            string excluir = "DELET FROM Cliente WHERE Idcliente = "+Idpessoa;
            base.Excluir();

            return "Excluido com sucesso";
        }
    }
}
