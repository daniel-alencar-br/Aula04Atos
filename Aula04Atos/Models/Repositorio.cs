using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Aula04Atos.Models
{
    public class Repositorio
    {
        SqlConnection CN = new SqlConnection();    // conexão
        SqlCommand CM = new SqlCommand();          // comando a executar
        SqlDataAdapter DA = new SqlDataAdapter();  // executa o comando

        DataSet DS = new DataSet();  // Recebe a Tabela e a mantem offline

        public DataSet VoltaClientes()
        {
            // Apenas se OleDb :  "Provider=MSSQLSERVER;"

            // servidor, banco de dados,
            // usuário e senha(sql) OU usuário do windows
            CN.ConnectionString = "data source=pc_do_gab;" + 
                                  "initial catalog=CursoAsp;" + 
                                  "User Id=sa; Password=sa";
                                // OU
                                // "Integrated Security=SSPI"
            
            // Se vincula a conexão e define o comando
            CM.Connection = CN;
            CM.CommandText = "Select * From Clientes";

            // Se vincula ao comando
            DA.SelectCommand = CM;

            CN.Open();

            // DS.Tables[0].Rows[0]["Nome"].ToString();
            
            // Tipos de Execução
            DA.Fill(DS);   // receber uma tabela

            //CM.ExecuteNonQuery();   // executa sem retorno (I U D)
            //CM.ExecuteScalar();     // executa e retorna UM valor
            //CM.ExecuteReader();     // retorna DataReader (conexão aberta)
 
            CN.Close();
            return DS;
        }

    }
}