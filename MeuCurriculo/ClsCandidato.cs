using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace MeuCurriculo
{
    public class ClsCandidato
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Dica_senha { get; set; }
        public string Celular { get; set; }
        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }
        public string Estado_civil { get; set; }
        public string Nacionalidade { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public ClsCursoEtec CursoEtec { get; set; }

        public bool EmailJaExisteNoBanco(Dados dados)
        {
            DataTable tabela = dados.ConvertSqlToDataTable(@"select * from candidato where email = @email",
                new MySqlParameter("@email", Email));
            if (tabela.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Cadastrar(Dados dados)
        {
            var afetados = dados.ConvertSqlToInt(@"insert into candidato (email, nome, senha, dica_senha, celular, nascimento, sexo, estado_civil, nacionalidade, cep, cidade, bairro, estado, rua, numero) 
                                                             values (@email, @nome, @senha, @dica_senha, @celular, @nascimento, @sexo, @estado_civil, @nacionalidade, @cep, @cidade, @bairro, @estado, @rua, @numero)",
                new MySqlParameter("@email", Email),
                new MySqlParameter("@nome", Nome),
                new MySqlParameter("@senha", Senha),
                new MySqlParameter("@dica_senha", Dica_senha),
                new MySqlParameter("@celular", Celular),
                new MySqlParameter("@nascimento", Nascimento),
                new MySqlParameter("@sexo", Sexo),
                new MySqlParameter("@estado_civil", Estado_civil),
                new MySqlParameter("@nacionalidade", Nacionalidade),
                new MySqlParameter("@cep", Cep),
                new MySqlParameter("@cidade", Cidade),
                new MySqlParameter("@bairro", Bairro),
                new MySqlParameter("@estado", Estado),
                new MySqlParameter("@rua", Rua),
                new MySqlParameter("@numero", Numero)
            );

            Id = int.Parse(dados.ConvertSqlToDataTable("select last_insert_id() id").Rows[0]["id"].ToString());

            CriaCursoEtec(Id);

            if (afetados == 0)
            {
                throw new Exception("Erro ao inserir candidato");
            }            
        }
        
        public void CriaCursoEtec(int Id){
            CursoEtec = new ClsCursoEtec(Id);
        }

        public bool ExisteNoBanco(Dados dados)
        {
            var candidato = dados.ConvertSqlToDataTable(@"select * from candidato where email = @email and senha = @senha",
                new MySqlParameter("@email", Email),
                new MySqlParameter("@senha", Senha)
                );
            if (candidato.Rows.Count > 0)
            {
                Id = int.Parse(candidato.Rows[0]["id"].ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public static ClsCandidato CarregaCandidato(Dados dados, int candidatoID)
        {
            var candidato = new ClsCandidato();

            var tabela = dados.ConvertSqlToDataTable("select * from candidato where id = @id", new MySqlParameter("@id", candidatoID));

            candidato.Id = int.Parse(tabela.Rows[0]["id"].ToString());
            candidato.Email= tabela.Rows[0]["email"].ToString();
            candidato.Nome = tabela.Rows[0]["nome"].ToString();
            candidato.Senha = tabela.Rows[0]["senha"].ToString();
            candidato.Dica_senha = tabela.Rows[0]["dica_senha"].ToString();
            candidato.Celular = tabela.Rows[0]["celular"].ToString();
            candidato.Nascimento = DateTime.Parse(tabela.Rows[0]["nascimento"].ToString());
            candidato.Sexo = tabela.Rows[0]["sexo"].ToString();
            candidato.Estado_civil = tabela.Rows[0]["estado_civil"].ToString();
            candidato.Nacionalidade = tabela.Rows[0]["nacionalidade"].ToString();
            candidato.Cep = tabela.Rows[0]["cep"].ToString();
            candidato.Cidade = tabela.Rows[0]["cidade"].ToString();
            candidato.Bairro = tabela.Rows[0]["bairro"].ToString();
            candidato.Estado = tabela.Rows[0]["estado"].ToString();
            candidato.Rua = tabela.Rows[0]["rua"].ToString();
            candidato.Numero = tabela.Rows[0]["numero"].ToString();

            return candidato;
        }

        public void Atualizar(Dados dados)
        {
            var afetados = dados.ConvertSqlToInt(@"update candidato set email = @email, nome = @nome, senha = @senha, dica_senha = @dica_senha, celular = @celular, 
                    nascimento = @nascimento, sexo = @sexo, estado_civil = @estado_civil, nacionalidade = @nacionalidade, cep = @cep, 
                    cidade = @cidade, bairro = @bairro, estado = @estado, rua = @rua, numero = @numero where id = @id",
                new MySqlParameter("@email", Email),
                new MySqlParameter("@nome", Nome),
                new MySqlParameter("@senha", Senha),
                new MySqlParameter("@dica_senha", Dica_senha),
                new MySqlParameter("@celular", Celular),
                new MySqlParameter("@nascimento", Nascimento),
                new MySqlParameter("@sexo", Sexo),
                new MySqlParameter("@estado_civil", Estado_civil),
                new MySqlParameter("@nacionalidade", Nacionalidade),
                new MySqlParameter("@cep", Cep),
                new MySqlParameter("@cidade", Cidade),
                new MySqlParameter("@bairro", Bairro),
                new MySqlParameter("@estado", Estado),
                new MySqlParameter("@rua", Rua),
                new MySqlParameter("@numero", Numero),
                new MySqlParameter("@id", Id)
            );

            if (afetados == 0)
            {
                throw new Exception("Erro ao editar a conta");
            }
        }

        public DataTable DicaSenha(Dados dados)
        {
            var tabela = dados.ConvertSqlToDataTable("select dica_senha from candidato where email = @email",
                new MySqlParameter("@email", Email)
                );
            return tabela;
        }

    }
}