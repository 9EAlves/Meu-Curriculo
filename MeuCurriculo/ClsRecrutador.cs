using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MeuCurriculo
{
    class ClsRecrutador
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<int> ListaIds { get; set; }

        public ClsRecrutador()
        {
            ListaIds = new List<int>();
        }

        public static DataTable TabelaCandidatos(Dados dados, string curso, string periodo, string modulo)
        {
            var tabela = dados.ConvertSqlToDataTable(@"select candidato.Id, candidato.Nome, curso_etec.Curso, curso_etec.Periodo, curso_etec.Modulo
                from candidato inner join curso_etec
                where candidato.id = curso_etec.candidato_id
                and candidato.curriculo_id is not null and curso_etec.curso = @curso and curso_etec.periodo = @periodo and curso_etec.modulo = @modulo",
                new MySqlParameter("@curso", curso),
                new MySqlParameter("@periodo", periodo),
                new MySqlParameter("@modulo", modulo)
                );
            return tabela;
        }
    
        public bool ExisteNoBanco(Dados dados, bool login)
        {
            DataTable recrutador;
            if (login)
            {
                recrutador = dados.ConvertSqlToDataTable(@"select * from recrutador where email = @email and senha = @senha",
                    new MySqlParameter("@email", Email),
                    new MySqlParameter("@senha", Senha)
                    );
            }
            else
            {
                recrutador = dados.ConvertSqlToDataTable(@"select * from recrutador where email = @email",
                    new MySqlParameter("@email", Email)    
                    );
            }                          
            if (recrutador.Rows.Count > 0)
            {                
                return true;
            }
            else
            {
                return false;
            }
        }      
    }
}
