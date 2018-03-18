using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Seguradora
{
    class ClasseModelo
    {
        //Atributos

        protected ClasseConexaoSQL banco;
        protected ClasseMarcas marca;
        protected int idmodelo;
        protected string descricao;

        //GetterSetter
        public int IdModelo { get => idmodelo; set => idmodelo = value; }
        public int IdMarca { get => marca.IdMarca; set => marca.IdMarca = value; }
        public string Descricao { get; set; }

        //Metodos

        //Construtor
        public ClasseModelo()
        {
            banco = new ClasseConexaoSQL();
            marca = new ClasseMarcas();
        }

        public virtual string Inserir()
        {
            string insert = "INSERT INTO Modelo (IdModelo, IdMarca, Descricao)";
            insert += "VALUES (@IdModelo, @IdMarca, '@Descricao')";

            insert = insert.Replace("@IdModelo", IdModelo.ToString());
            insert = insert.Replace("@IdMarca", marca.IdMarca.ToString());
            insert = insert.Replace("@Descricao", Descricao.ToString());

            string msg = banco.ExecutarComando(insert);

            return msg;
        }

        public virtual string Alterar()
        {
            string alterar = "UPDATE Modelo SET IdModelo=@IdModelo, IdMarca=@IdMarca, Descricao='@Descricao'";
            alterar += "WHERE IdModelo=@IdModelo";

            alterar = alterar.Replace("@IdModelo", IdModelo.ToString());
            alterar = alterar.Replace("@IdMarca", marca.IdMarca.ToString());
            alterar = alterar.Replace("@Descricao", Descricao.ToString());

            string msg = banco.ExecutarComando(alterar);

            return msg;

        }

        public virtual string Excluir()
        {
            string excluir = "DELETE FROM Modelo WHERE IdModelo=" + idmodelo;

            string msg = banco.ExecutarComando(excluir);

            return msg;
        }

        public virtual DataTable Consultar()
        {
            DataTable tblDados = new DataTable();

            string consultar = "SELECT * FROM Modelo";

            tblDados = banco.ExecutarSelect(consultar);

            return tblDados;
        }

        public virtual DataTable Consultar(string pCondicao)
        {
            DataTable tblDados = new DataTable();

            string consultar = "SELECT * FROM Modelo WHERE IdModelo=" + pCondicao;

            tblDados = banco.ExecutarSelect(consultar);

            return tblDados;
        }



    }
}
