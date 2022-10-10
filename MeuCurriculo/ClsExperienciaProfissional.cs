using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCurriculo
{
    public class ClsExperienciaProfissional : Salvar
    {
        public int ID { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public ClsCurriculo Curriculo { get; set; }

        public static List<ClsExperienciaProfissional> CarregaExperienciasProfissionais(Dados dados, int curriculoID)
        {
            var listaExperienciasProfissionais = new List<ClsExperienciaProfissional>();

            var tabelaExperienciasProfissionais = dados.ConvertSqlToDataTable("select * from experiencia_profissional where curriculo_id = @curriculo_id", new MySqlParameter("@curriculo_id", curriculoID));

            foreach (DataRow row in tabelaExperienciasProfissionais.Rows)
            {
                listaExperienciasProfissionais.Add(new ClsExperienciaProfissional
                {
                    ID = int.Parse(row["id"].ToString()),
                    Empresa = row["empresa"].ToString(),
                    Cargo = row["cargo"].ToString(),
                    Inicio = DateTime.Parse(row["inicio"].ToString()),
                    Termino = DateTime.Parse(row["termino"].ToString()),                                        
                    Curriculo = new ClsCurriculo
                    {
                        ID = int.Parse(row["curriculo_id"].ToString())
                    }
                });
            }
            return listaExperienciasProfissionais; //Retorna a lista de idiomas
        }

        public void Salvar(Dados dados)
        {                   
            var novos = dados.ConvertSqlToInt(@"insert into experiencia_profissional (empresa, cargo, inicio, termino, curriculo_id)
                    values (@empresa, @cargo, @inicio, @termino, @curriculo_id)",
                new MySqlParameter("@empresa", Empresa),
                new MySqlParameter("@cargo", Cargo),
                new MySqlParameter("@inicio", Inicio),
                new MySqlParameter("@termino", Termino),                                
                new MySqlParameter("@curriculo_id", Curriculo.ID)
            );
                 
            if (novos < 1)
            {
                throw new Exception(string.Format("Não foi possível adicionar a experiência profissional na empresa: {0}", Empresa));
            }

            ID = int.Parse(dados.ConvertSqlToDataTable("select last_insert_id() codigo").Rows[0]["codigo"].ToString());
        }

        public void Remover(Dados dados)
        {
            var removido = dados.ConvertSqlToInt("delete from experiencia_profissional where id = @id", new MySqlParameter("@id", ID));

            if (removido < 1)
            {
                throw new Exception(string.Format("Não foi possível remover a experiência profissional na empresa: {0}", Empresa));
            }
        }

        public bool ExisteNoBanco(Dados dados)
        {
            throw new NotImplementedException();
        }
    }
}
