using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Seguradora
{
    class ClasseMarcas
    {
        #region Atributos
        protected ClasseConexaoSQL banco;
        protected int Idmarca;
        protected string descricao;

        #endregion

        //GetterSetter
        public int IdMarca { get => Idmarca; set => Idmarca = value; }
        public string Descricao { get => descricao; set => descricao = value; }


        //Classe construtora
        public ClasseMarcas()
        {
            banco = new ClasseConexaoSQL();
        }

        //Metodo para inserir no banco.
        public virtual string Inserir()
        {

            string insert = "INSERT INTO Marca (Idmarca, descricao)";
            insert += "VALUES (@Idmarca, '@descricao')";

            insert = insert.Replace("@Idmarca", IdMarca.ToString());
            insert = insert.Replace("@descricao", descricao.ToString());


           string msg = banco.ExecutarComando(insert);

            return msg;
        }

        public virtual string Alterar()
        {
            string alterar = "UPDATE Marca SET Descricao='@Descricao' WHERE Idmarca='@Idmarca'";

            alterar = alterar.Replace("@Idmarca", IdMarca.ToString());
            alterar = alterar.Replace("@Descricao", Descricao.ToString());

            string msg = banco.ExecutarComando(alterar);

            return msg;
        }

        public virtual string Excluir()
        {
            string excluir = "DELETE FROM Marca WHERE idmarca=" + IdMarca.ToString();

            string msg = banco.ExecutarComando(excluir);

            return msg;
        }

        public virtual DataTable Consultar()
        {
            DataTable tblDados = new DataTable();

            string consultar = "SELECT * FROM Marca";

            tblDados = banco.ExecutarSelect(consultar);

            return tblDados;
        }

        public virtual DataTable Consultar(string pCondicao)
        {
            DataTable tblDados = new DataTable();

            string consultar = "SELECT * FROM marca WHERE idmarca=" + pCondicao;

            tblDados = banco.ExecutarSelect(consultar);

            return tblDados;
        }

    }
}
