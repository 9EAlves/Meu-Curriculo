using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCurriculo
{
    public class ClsIdioma : Salvar
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Nivel { get; set; }
        public ClsCurriculo Curriculo { get; set; }

        public static List<ClsIdioma> CarregaIdiomas(Dados dados, int curriculoID) //Método estático que carrega a lista de idiomas cadastrados no banco
        {
            var listaIdiomas = new List<ClsIdioma>();

            var tabelaIdiomas = dados.ConvertSqlToDataTable("select * from idioma where curriculo_id = @curriculo_id", new MySqlParameter("@curriculo_id", curriculoID)); //Select em todos os idiomas do curriculo

            foreach (DataRow row in tabelaIdiomas.Rows) //Para cada linha da tabela de idiomas do banco, adiciona um idioma na lista
            {
                listaIdiomas.Add(new ClsIdioma
                {
                    ID = int.Parse(row["id"].ToString()), //Define o id do idioma
                    Nome = row["idioma"].ToString(), //Define o nome do idioma
                    Nivel = row["nivel"].ToString(), //Define o nível do idioma
                    Curriculo = new ClsCurriculo //Instância um novo currículo
                    {
                        ID = int.Parse(row["curriculo_id"].ToString()) //Define o ID do currículo instânciado
                    }
                });
            }
            return listaIdiomas; //Retorna a lista de idiomas
        }

        public void Salvar(Dados dados) //Insere um novo idioma no banco de dados
        {
            var novos = dados.ConvertSqlToInt(
                "insert into idioma(idioma, nivel, curriculo_id) values (@nome, @nivel, @curriculo)",
                new MySqlParameter("@nome", Nome),
                new MySqlParameter("@nivel", Nivel),
                new MySqlParameter("@curriculo", Curriculo.ID)
            );

            if (novos < 1)
            {
                throw new Exception(string.Format("Não foi possível adicionar o idioma: {0}", Nome));
            }

            ID = int.Parse(dados.ConvertSqlToDataTable("select last_insert_id() codigo").Rows[0]["codigo"].ToString());
        }

        public bool ExisteNoBanco(Dados dados)
        {
            var tabela = dados.ConvertSqlToDataTable("select * from idioma where id = @id", new MySqlParameter("@id", ID));
            return tabela.Rows.Count > 0;
        }

        public void Remover(Dados dados)
        {
            var removido = dados.ConvertSqlToInt("delete from idioma where id = @id", new MySqlParameter("@id", ID));

            if (removido < 1)
            {
                throw new Exception(string.Format("Não foi possível remover o idioma: {0}", Nome));
            }
        }


    }
}
