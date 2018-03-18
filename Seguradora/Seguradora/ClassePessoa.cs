using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguradora
{
    class ClassePessoa
    {
        #region Atributos
        protected ClasseConexaoSQL banco;
        protected int Idpessoa;
        protected string nome;
        protected string fone;
        protected string endereco;
        protected string bairro;
        protected string cep;
#endregion

        //GetterSetter
        public int Idpessoa1 { get => Idpessoa; set => Idpessoa = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Fone { get => fone; set => fone = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Cep { get => cep; set => cep = value; }

        //Classe construtora
        public ClassePessoa()
        {
            banco = new ClasseConexaoSQL();
        }

        //Metodo para inserir no banco.
        public virtual string Inserir()
        {
           
            string insert = "INSERT INTO Pessoa (Idpessoa, nome, fone, endereco, bairro, cep)";
            insert += "VALUES (@Idpessoa, '@nome', '@fone', '@endereco', '@bairro', @cep)";

            insert = insert.Replace("@Idpessoa", Idpessoa.ToString());
            insert = insert.Replace("@nome", nome.ToString());
            insert = insert.Replace("@fone", fone.ToString());
            insert = insert.Replace("@endereco", endereco.ToString());
            insert = insert.Replace("@bairro", bairro.ToString());
            insert = insert.Replace("@cep", cep.ToString());

            banco.ExecutarComando(insert);

            return "Inserido com sucesso.";
        }

        public virtual string Alterar()
        {
            string alterar = "UPDATE Pessoa SET nome='@nome', fone='@fone', endereco='@endereco', bairro='@bairro', cep='@cep'";
            alterar += "WHERE Idpessoa=@Idpessoa";

            alterar = alterar.Replace("@Idpessoa", Idpessoa.ToString());
            alterar = alterar.Replace("@nome", nome.ToString());
            alterar = alterar.Replace("@fone", fone.ToString());
            alterar = alterar.Replace("@endereco", endereco.ToString());
            alterar = alterar.Replace("@bairro", bairro.ToString());
            alterar = alterar.Replace("@cep", cep.ToString());

            banco.ExecutarComando(alterar);

            return "Alterado com sucesso.";
        }

        public virtual string Excluir()
        {
            string excluir = "DELETE FROM Pessoa WHERE Idpessoa="+Idpessoa1;

            banco.ExecutarComando(excluir);

            return "Excluido com sucesso.";
        }

        public virtual DataTable Consultar()
        {
            DataTable tblDados = new DataTable();

            string consultar = "SELECT * FROM Pessoa";

            tblDados = banco.ExecutarSelect(consultar);

            return tblDados;
        }

        public virtual DataTable Consultar(string pCondicao)
        {
            DataTable tblDados = new DataTable();

            string consultar = "SELECT * FROM Pessoa WHERE idpessoa="+pCondicao;

            tblDados = banco.ExecutarSelect(consultar);
            
            return tblDados;
        }

    }
}
