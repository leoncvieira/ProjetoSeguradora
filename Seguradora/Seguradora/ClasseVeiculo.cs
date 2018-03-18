using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguradora
{
    class ClasseVeiculo
    {
        #region Atributos
        ClasseConexaoSQL banco;
        int idVeiculo;
        ClasseModelo modelo;
        string placa;
        int ano;
        #endregion

        public int IdVeiculo { get => idVeiculo; set => idVeiculo = value; }
        public string Placa { get => placa; set => placa = value; }
        public int Ano { get => ano; set => ano = value; }
        public int IdModelo { get => modelo.IdModelo; set => modelo.IdModelo = value; }


        public ClasseVeiculo()
        {
            banco = new ClasseConexaoSQL();
            modelo = new ClasseModelo();
        }

        public virtual string Inserir()
        {
            string insert = "INSERT INTO Veiculo (idveiculo, idmodelo, placa, ano)";
            insert += "VALUES (@idveiculo, @idmodelo, '@placa', @ano)";

            insert = insert.Replace("@idveiculo", idVeiculo.ToString());
            insert = insert.Replace("@idmodelo", IdModelo.ToString());
            insert = insert.Replace("@placa", placa.ToString());
            insert = insert.Replace("@ano", ano.ToString());


            string msg = banco.ExecutarComando(insert);

            return msg;
        }

        public virtual string Alterar()
        {
            string alterar = "UPDATE Veiculo SET placa='@placa', ano=@ano";
            alterar += "WHERE idveiculo=@idveiculo";

            alterar = alterar.Replace("@idveiculo", idVeiculo.ToString());
            alterar = alterar.Replace("@idmodelo", IdModelo.ToString());
            alterar = alterar.Replace("@placa", placa.ToString());
            alterar = alterar.Replace("@ano", ano.ToString());

            string msg = banco.ExecutarComando(alterar);

            return msg;
        }

        public virtual string Excluir()
        {
            string excluir = "DELETE FROM Veiculo WHERE idVeiculo="+ idVeiculo;

            string msg = banco.ExecutarComando(excluir);

            return msg;
        }

        public virtual DataTable Consultar()
        {
            DataTable tblDados = new DataTable();

            string consultar = "SELECT * FROM Veiculo";

            banco.ExecutarSelect(consultar);

            return tblDados;
        }

        public virtual DataTable Consultar(string pCondicao)
        {
            DataTable tblDados = new DataTable();

            string consultar = "SELECT * FROM Veiculo WHERE IdVeiculo=" + pCondicao;

            tblDados = banco.ExecutarSelect(consultar);

            return tblDados;
        }
    }
}
