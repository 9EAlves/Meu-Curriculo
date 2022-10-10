using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCurriculo
{
    public class ClsFormacaoAcademica : Salvar
    {
        public int ID { get; set; }
        public string Instituicao { get; set; }
        public string Formacao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public string Periodo { get; set; }
        public string Semestre { get; set; }
        public ClsCurriculo Curriculo { get; set; }

        public static List<ClsFormacaoAcademica> CarregaFormacoesAcademicas(Dados dados, int curriculoID)
        {
            var listaFormacoesAcademicas = new List<ClsFormacaoAcademica>();

            var tabelaFormacoesAcademicas = dados.ConvertSqlToDataTable("select * from formacao_academica where curriculo_id = @curriculo_id", new MySqlParameter("@curriculo_id", curriculoID));

            foreach (DataRow row in tabelaFormacoesAcademicas.Rows)
            {
                listaFormacoesAcademicas.Add(new ClsFormacaoAcademica
                {
                    ID = int.Parse(row["id"].ToString()),
                    Instituicao = row["instituicao"].ToString(), 
                    Formacao = row["formacao"].ToString(), 
                    Inicio = DateTime.Parse(row["inicio"].ToString()),
                    Termino = DateTime.Parse(row["termino"].ToString()),
                    Periodo = row["periodo"].ToString(),
                    Semestre = row["semestre"].ToString(),
                    Curriculo = new ClsCurriculo 
                    {
                        ID = int.Parse(row["curriculo_id"].ToString())
                    }
                });
            }
            return listaFormacoesAcademicas; //Retorna a lista de idiomas
        }

        public void Salvar(Dados dados)
        {
            var novos = dados.ConvertSqlToInt(@"insert into formacao_academica (instituicao, formacao, inicio, termino, periodo, semestre, curriculo_id)
                    values (@instituicao, @formacao, @inicio, @termino, @periodo, @semestre, @curriculo_id)",
                new MySqlParameter("@instituicao", Instituicao),
                new MySqlParameter("@formacao", Formacao),
                new MySqlParameter("@inicio", Inicio),
                new MySqlParameter("@termino", Termino),
                new MySqlParameter("@periodo", Periodo),
                new MySqlParameter("@semestre", Semestre),
                new MySqlParameter("@curriculo_id", Curriculo.ID)
            );

            if (novos < 1)
            {
                throw new Exception(string.Format("Não foi possível adicionar a formação: {0}", Formacao));
            }

            ID = int.Parse(dados.ConvertSqlToDataTable("select last_insert_id() codigo").Rows[0]["codigo"].ToString());
        }
        public void Remover(Dados dados)
        {
            var removido = dados.ConvertSqlToInt("delete from formacao_academica where id = @id", new MySqlParameter("@id", ID));

            if (removido < 1)
            {
                throw new Exception(string.Format("Não foi possível remover a formação: {0}", Formacao));
            }
        }
        public bool ExisteNoBanco(Dados dados)
        {
            throw new NotImplementedException();
        }
    }
}
