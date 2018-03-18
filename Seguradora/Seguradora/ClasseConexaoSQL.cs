using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Seguradora
{
    class ClasseConexaoSQL
    {
        MySqlConnection conexao;
        MySqlCommand comando;

        public ClasseConexaoSQL()
        {
            conexao = new MySqlConnection("Server=localhost;Database=T68;Uid=root;Pwd=venus");
            
            try
            {
                conexao.Open();

            }
            catch (Exception e)
            {
                
            }
            
            comando = conexao.CreateCommand();
        }

        public string ExecutarComando(string pComandoSql)
        {
            comando.CommandText = pComandoSql;
            int n = 0;
            string mensagem = "";

            try
            {
                n = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                mensagem =  "Erro: " + e.Message;
            }

            if (n > 0)
            {
                return "Comando executado com sucesso!";
            }
            else
            {
                return "Erro ao executar comando " + mensagem;
            }
            
        }
       
        public DataTable ExecutarSelect(string pComandoSelect)
        {
            DataTable tbldados = new DataTable();
            comando.CommandText = pComandoSelect;
            try
            {
                tbldados.Load(comando.ExecuteReader());
            }
            catch
            {
                
            }
            return tbldados;
        }
    }
}
