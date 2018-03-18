using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguradora
{
    class ClasseApolice
    {
        #region Atributos
        ClasseConexaoSQL banco;
        ClasseCliente cliente;
        int idApolice;
        ClasseVeiculo veiculo;
        string numeroApolice;
        DateTime dataInicio;
        DateTime dataFim;
        double valor;
        double franquia;
        DateTime dataContrato;
        #endregion

        public int IdPessoa { get => cliente.Idpessoa1; set => cliente.Idpessoa1 = value; }
        public int IdApolice { get => idApolice; set => idApolice = value; }
        public string NumeroApolice { get => numeroApolice; set => numeroApolice = value; }
        public int IdVeiculo { get => veiculo.IdVeiculo; set => veiculo.IdVeiculo = value; }
        public DateTime DataInicio { get => dataInicio; set => dataInicio = value; }
        public DateTime DataFim { get => dataFim; set => dataFim = value; }
        public double Valor { get => valor; set => valor = value; }
        public double Franquia { get => franquia; set => franquia = value; }
        public DateTime DataContrato { get => dataContrato; set => dataContrato = value; }

        public ClasseApolice()
        {
            banco = new ClasseConexaoSQL();
            cliente = new ClasseCliente();
            veiculo = new ClasseVeiculo();
        }

        public virtual string Inserir()
        {
            string insert = "INSERT INTO Apolice (idPessoa, idApolice, idVeiculo, numeroApolice, datainicio, datafim, valor, franquia, datacontrato)";
            insert += "VALUES (@idPessoa, @idapolice, @idVeiculo, @numeroapolice, @datainicio, @datafim, @valor, @franquia, @datacontrato)";

            insert = insert.Replace("@idPessoa", IdPessoa.ToString());
            insert = insert.Replace("@idapolice", idApolice.ToString());
            insert = insert.Replace("@idVeiculo", IdVeiculo.ToString());
            insert = insert.Replace("@numeroapolice", numeroApolice.ToString());
            insert = insert.Replace("@datainicio", dataInicio.ToString());
            insert = insert.Replace("@datafim", dataFim.ToString());
            insert = insert.Replace("@valor", valor.ToString());
            insert = insert.Replace("@franquia", franquia.ToString());
            insert = insert.Replace("@datacontrato", dataContrato.ToString());

            string msg = banco.ExecutarComando(insert);

            return msg;
        }

        public virtual string Alterar()
        {
            string alterar = "UPDATE Apolice SET idPessoa=@idPessoa, numeroApolice=@numeroapolice, idVeiculo=@idVeiculo, datainicio=@datainicio, datafim=@datafim, valor=@valor, franquia=@franquia, datacontrato=@datacontrato";
            alterar += "WHERE idapolice=@idapolice";

            alterar = alterar.Replace("@idPessoa", IdPessoa.ToString());
            alterar = alterar.Replace("@idapolice", idApolice.ToString());
            alterar = alterar.Replace("@idVeiculo", IdVeiculo.ToString());
            alterar = alterar.Replace("@numeroapolice", numeroApolice.ToString());
            alterar = alterar.Replace("@datainicio", dataInicio.ToString());
            alterar = alterar.Replace("@datafim", dataFim.ToString());
            alterar = alterar.Replace("@valor", valor.ToString());
            alterar = alterar.Replace("@franqui", franquia.ToString());
            alterar = alterar.Replace("@datacontrato", dataContrato.ToString());

            string msg = banco.ExecutarComando(alterar);

            return msg;
        }

        public virtual string Excluir()
        {
            string excluir = "DELETE FROM Apolice WHERE idapolice=@idapolice";

            string msg = banco.ExecutarComando(excluir);

            return msg;
        }

        public virtual DataTable Consultar()
        {
            DataTable tblDados = new DataTable();

            string consultar = "SELECT * FROM Pessoa WHERE Idcliente=@Idcliente";

            banco.ExecutarSelect(consultar);

            return tblDados;
        }

        public virtual DataTable Consultar(string pCondicao)
        {
            DataTable tblDados = new DataTable();

            string consultar = "SELECT * FROM Apolice WHERE idApolice=" + pCondicao;

            return tblDados;
        }

    }
}
