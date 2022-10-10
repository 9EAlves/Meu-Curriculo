using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCurriculo
{
    public class ClsQualificacaoTecnica : Salvar
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public ClsCurriculo Curriculo { get; set; }

        public static List<ClsQualificacaoTecnica> CarregaQualificacoesTecnicas(Dados dados, int curriculoID)
        {
            var listaQualificacoesTecnicas = new List<ClsQualificacaoTecnica>();

            var tabelaQualificacoesTecnicas = dados.ConvertSqlToDataTable(@"select * from qualificacao_tecnica where curriculo_id = @curriculo_id", 
                new MySqlParameter("@curriculo_id", curriculoID)); 

            foreach (DataRow row in tabelaQualificacoesTecnicas.Rows) 
            {
                listaQualificacoesTecnicas.Add(new ClsQualificacaoTecnica
                {
                    ID = int.Parse(row["id"].ToString()), 
                    Descricao = row["descricao"].ToString(),                
                    Curriculo = new ClsCurriculo
                    {
                        ID = int.Parse(row["curriculo_id"].ToString()) 
                    }
                });
            }
            return listaQualificacoesTecnicas; 
        }

        //Métodos da interface Salvar:
        public void Salvar(Dados dados)
        {
            var novos = dados.ConvertSqlToInt(
                "insert into qualificacao_tecnica (descricao, curriculo_id) values (@descricao, @curriculo_id)",
                new MySqlParameter("@descricao", Descricao),
                new MySqlParameter("@curriculo_id", Curriculo.ID)
            );

            if (novos < 1)
            {
                throw new Exception(string.Format("Não foi possível adicionar a qualificação: {0}", Descricao));
            }

            ID = int.Parse(dados.ConvertSqlToDataTable("select last_insert_id() codigo").Rows[0]["codigo"].ToString());
        }
        public bool ExisteNoBanco(Dados dados)
        {
            var tabela = dados.ConvertSqlToDataTable("select * from qualificacao_tecnica where id = @id", new MySqlParameter("@id", ID));
            return tabela.Rows.Count > 0;
        }
        public void Remover(Dados dados)
        {
            var removido = dados.ConvertSqlToInt("delete from qualificacao_tecnica where id = @id", new MySqlParameter("@id", ID));

            if (removido < 1)
            {
                throw new Exception(string.Format("Não foi possível remover a qualificação: {0}", Descricao));
            }
        }
        
            
    }
}

