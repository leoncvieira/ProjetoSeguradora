using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Seguradora
{
    class ConexaoSQL
    {
        MySqlConnection conexao;
        MySqlCommand comando;

        public ConexaoSQL()
        {
            conexao = new MySqlConnection("Server=localhost;Database=T68;Uid=root;Pwd=venus");
            conexao.Open();
            comando = conexao.CreateCommand();
        }

        public void ExecutarComando(string pComandoSql)
        {
            comando.CommandText = pComandoSql;
            comando.ExecuteNonQuery();
        }
       
        public DataTable ExecutarSelect(string pComandoSelect)
        {
            DataTable tbldados = new DataTable();
            comando.CommandText = pComandoSelect;
            tbldados.Load(comando.ExecuteReader());
            return tbldados;
        }
    }
}
