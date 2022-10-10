using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MeuCurriculo
{
    public class ClsCursoEtec
    {
        public string Curso { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public string Periodo { get; set; }
        public string Modulo { get; set; }
        public int Candidato_id { get; set; }

        public ClsCursoEtec(int candidato_id)
        {
            Candidato_id = candidato_id;
        }

        public void Cadastrar(Dados dados)
        {
            var afetados = dados.ConvertSqlToInt(@"insert into curso_etec (curso, inicio, termino, periodo, modulo, candidato_id) 
                                                             values (@curso, @inicio, @termino, @periodo, @modulo, @candidato_id)",
                new MySqlParameter("@curso", Curso),
                new MySqlParameter("@inicio", Inicio),
                new MySqlParameter("@termino", Termino),
                new MySqlParameter("@periodo", Periodo),
                new MySqlParameter("@modulo", Modulo),
                new MySqlParameter("@candidato_id", Candidato_id)
            );

            if (afetados == 0)
            {
                throw new Exception("Erro ao inserir curso da Etec.");
            }
        }

        public static ClsCursoEtec CarregaCursoEtec(Dados dados, int idCandidato)
        {
            var cursoEtec = new ClsCursoEtec(idCandidato);

            var tabela = dados.ConvertSqlToDataTable("select * from curso_etec where candidato_id = @id", new MySqlParameter("@id", cursoEtec.Candidato_id));

            cursoEtec.Curso = tabela.Rows[0]["curso"].ToString();
            cursoEtec.Inicio = DateTime.Parse(tabela.Rows[0]["inicio"].ToString());
            cursoEtec.Termino = DateTime.Parse(tabela.Rows[0]["termino"].ToString());
            cursoEtec.Periodo = tabela.Rows[0]["periodo"].ToString();
            cursoEtec.Modulo = tabela.Rows[0]["modulo"].ToString();

            return cursoEtec;
        }

        public void Atualizar(Dados dados)
        {
            var afetados = dados.ConvertSqlToInt(@"update curso_etec set curso = @curso, inicio = @inicio, termino= @termino, 
                    periodo = @periodo, modulo = @modulo where candidato_id = @id",
                new MySqlParameter("@curso", Curso),
                new MySqlParameter("@inicio", Inicio),
                new MySqlParameter("@termino", Termino),
                new MySqlParameter("@periodo", Periodo),
                new MySqlParameter("@modulo", Modulo),              
                new MySqlParameter("@id", Candidato_id)
            );

            if (afetados == 0)
            {
                throw new Exception("Erro ao editar a conta");
            }
        }
      
    }
}
