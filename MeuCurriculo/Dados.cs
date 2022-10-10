using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MeuCurriculo
{
   
    public class Dados
    {
     
        ///Objeto que mantém a conexão com o banco.
      
        private MySqlConnection objConexao = null;

       #region Métodos Privados

        #region Conectar()
        /// <summary>
        /// Inicia uma conexão com o banco de dados.
        /// </summary>
        private void Conectar()
        {
            string server = "localhost";
            string user = "root";
            string password = "";
            string database = "meucurriculo";

            // string de conexão 
            string strStringConexao = "SERVER=" + server + ";DATABASE=" + database +
                          ";UID=" + user + ";PASSWORD=" + password + ";";

            // Cria uma conexão com o banco de dados.
            objConexao = new MySqlConnection(strStringConexao);

            try
            {
                objConexao.Open();
            }
            catch (Exception)
            {
                DialogResult ok = MessageBox.Show("Erro de conexão com o banco de dados", "", MessageBoxButtons.OK);
                if (ok == DialogResult.OK)
                {
                    Environment.Exit(1);                    
                }
            }
            // Abre a conexão.
        }
        #endregion

        #region Desconectar()
        /// <summary>
        /// Fecha a conexão com o banco de dados.
        /// </summary>
        private void Desconectar()
        {
            // Fecha a conexão.
            objConexao.Close();
        }
        #endregion

        #endregion

       #region Métodos Públicos

        #region ConvertSqlToDataTable(string)
        /// <summary>
        /// Executa um comando SQL e retorna um
        /// DataTable preenchido com o resultado
        /// da pesquisa.
        /// </summary>
        /// <param name="p_strComandoSQL">
        /// String contendo o comando SQL a ser executado.
        /// </param>
        /// <returns>
        /// DataTable com o resultado da consulta.
        /// </returns>

        public DataTable ConvertSqlToDataTable(string p_strComandoSQL)
        {
            // Executa o comando SQL sem passar parâmetros.
            return ConvertSqlToDataTable(p_strComandoSQL, null);
        }

        #endregion

        #region ConvertSqlToDataTable(string, SqlParameter[])
        /// <summary>
        /// Executa um comando SQL e retorna um
        /// DataTable preenchido com o resultado
        /// da pesquisa.
        /// </summary>
        /// <param name="p_strComandoSQL">
        /// String contendo o comando SQL a ser executado.
        /// </param>
        /// <param name="p_arrParametros">
        /// Coleção de parâmetros utilizados pelo comando SQL.
        /// </param>
        /// <returns>
        /// DataTable com o resultado da consulta.
        /// </returns>
        public DataTable ConvertSqlToDataTable(string p_strComandoSQL,
            params MySqlParameter[] p_arrParametros)
        {
            // Conecta ao banco.
            Conectar();

            // Instancia um DataTable de resultado.
            DataTable tblResultado = new DataTable();

            try
            {
                #region Cria comando SQL

                // Instancia um comando SQL a ser executado.
                MySqlCommand objComandoSQL = new MySqlCommand();

                objComandoSQL.Connection = objConexao;
                objComandoSQL.CommandText = p_strComandoSQL;
                #endregion

                #region Adiciona parâmetros ao comando
                // Verifica se existem parâmetros.
                if (p_arrParametros != null)
                {
                    // Percorre cada parâmetro recebido.
                    foreach (MySqlParameter objParametro
                        in p_arrParametros)
                    {
                        // Adiciona ao comando SQL.
                        objComandoSQL.Parameters.Add(
                            objParametro);
                    }
                }
                #endregion

                #region Executa o comando SQL

                // Define o adaptador de comando Select.
                MySqlDataAdapter objAdaptador =
                    new MySqlDataAdapter();

                objAdaptador.SelectCommand = objComandoSQL;

                // Preenche o resultado executando o comando.
                objAdaptador.Fill(tblResultado);

                objAdaptador.Update(tblResultado);

                #endregion
            }
            finally
            {
                // Fecha a conexão.
                Desconectar();
            }

            // Retorna o resultado.
            return tblResultado;
        }
        #endregion

        #region ConvertSqlToInt(string, SqlParameter[])
        /// <summary>
        /// Executa um comando SQL e retorna o
        /// número de linhas afetadas.
        /// </summary>
        /// <param name="p_strComandoSQL">
        /// String contendo o comando SQL a ser executado.
        /// </param>
        /// <param name="p_arrParametros">
        /// Coleção de parâmetros utilizados pelo comando SQL.
        /// </param>
        /// <returns>
        /// Número de linhas afetadas pelo comando.
        /// </returns>
        public int ConvertSqlToInt(string p_strComandoSQL,
            params MySqlParameter[] p_arrParametros)
        {
            // Conecta ao banco.
            Conectar();

            // Cria variável para armazenar as linhas afetadas.
            int intLinhasAfetadas = 0;

            try
            {
                #region Cria comando SQL

                // Instancia um comando SQL a ser executado.
                MySqlCommand objComandoSQL = new MySqlCommand();

                objComandoSQL.Connection = objConexao;
                objComandoSQL.CommandText = p_strComandoSQL;

                #endregion

                #region Adiciona parâmetros ao comando
                // Verifica se existem parâmetros.
                if (p_arrParametros != null)
                {
                    // Percorre cada parâmetro recebido.
                    foreach (MySqlParameter objParametro
                        in p_arrParametros)
                    {
                        // Adiciona ao comando SQL.
                        objComandoSQL.Parameters.Add(
                            objParametro);
                    }
                }
                #endregion

                #region Executa o comando SQL
                // Executa o comando.
                intLinhasAfetadas = objComandoSQL.
                    ExecuteNonQuery();
                #endregion
            }
            finally
            {
                // Fecha a conexão.
                Desconectar();
             }

            // Retorna o número de linhas afetadas.
            return intLinhasAfetadas;
        }
        #endregion

        #endregion

       
    }
}