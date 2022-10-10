using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCurriculo
{
    public class ClsCurriculo
    {
        public int ID { get; set; }
        public string Objetivo { get; set; }
        public List<ClsIdioma> Idiomas { get; set; } //Lista de currículos
        public List<ClsQualificacaoTecnica> QualificacoesTecnicas { get; set; }
        public List<ClsFormacaoAcademica> FormacoesAcademicas { get; set; }
        public List<ClsExperienciaProfissional> ExperienciasProfissionais { get; set; }

        public ClsCurriculo()
        {
            Idiomas = new List<ClsIdioma>(); //Quando a classe ClsCurriculo for instânciada, cria automaticamente uma lista de idiomas
            QualificacoesTecnicas = new List<ClsQualificacaoTecnica>();
            FormacoesAcademicas = new List<ClsFormacaoAcademica>();
            ExperienciasProfissionais = new List<ClsExperienciaProfissional>();
        }

        public static ClsCurriculo CarregaCurriculo(Dados dados, int candidatoID) //Retorna o objeto currículo, já com todas as suas listas
        {
            var curriculo_id = dados.ConvertSqlToDataTable("select curriculo_id from candidato where id = @id", new MySqlParameter("@id", candidatoID));

            if (DBNull.Value.Equals(curriculo_id.Rows[0]["curriculo_id"])) //Verifica se o candidato têm currículo, caso não tenha, é criado um currículo
            {
                return new ClsCurriculo();
            }
                        
            int curriculoID = int.Parse(curriculo_id.Rows[0]["curriculo_id"].ToString());                
            
            var tabela = dados.ConvertSqlToDataTable("select * from curriculo where id = @id", new MySqlParameter("@id", curriculoID)); //Caso tenha, é feito um select * em seu seu id 

            var curriculo = new ClsCurriculo //Cria a instância do currículo e já define seu ID e Objetivo
            {
                ID = int.Parse(tabela.Rows[0]["id"].ToString()),
                Objetivo = tabela.Rows[0]["objetivo"].ToString()
            };

            curriculo.Idiomas = ClsIdioma.CarregaIdiomas(dados, curriculo.ID); //Insere na lista de idiomas do currículo, os idiomas cadastrados
            curriculo.QualificacoesTecnicas = ClsQualificacaoTecnica.CarregaQualificacoesTecnicas(dados, curriculo.ID);
            curriculo.FormacoesAcademicas = ClsFormacaoAcademica.CarregaFormacoesAcademicas(dados, curriculoID);
            curriculo.ExperienciasProfissionais = ClsExperienciaProfissional.CarregaExperienciasProfissionais(dados, curriculoID);
            return curriculo;
        }

        public void Salvar(Dados dados, int candidato_id) //Salva o currículo
        {
            int modificado = 0;

            if (ExisteNoBanco(dados)) //Verifica se existe no banco, se existir, atualiza o currículo
            {
                modificado = dados.ConvertSqlToInt(
                    "update curriculo set objetivo = @objetivo where id = @id", //Update curriculo
                    new MySqlParameter("@id", ID), 
                    new MySqlParameter("@objetivo", Objetivo)
                );
            }
            else //Se não existir, insere o currículo
            {
                modificado = dados.ConvertSqlToInt(
                    "insert into curriculo(objetivo) values (@objetivo)", //Insert curriculo
                    new MySqlParameter("@objetivo", Objetivo)
                );

                ID = int.Parse(dados.ConvertSqlToDataTable("select last_insert_id() codigo").Rows[0]["codigo"].ToString()); //Define o id do currículo

                dados.ConvertSqlToInt( "update candidato set curriculo_id = @curriculo_id where id = @id", //Inserie o id do currículo na coluna curriculo_id do candidato
                    new MySqlParameter("@curriculo_id", ID),
                    new MySqlParameter("@id", candidato_id)
                );
            }

            if (modificado < 1)
            {
                throw new Exception("Não foi possível salvar o curriculo");
            }

            SalvaIdiomas(dados); //Inserie a lista de idiomas do currículo no banco
            SalvaQualificacoesTecnicas(dados);
            SalvaFormacoesAcademicas(dados);
            SalvaExperienciasProfissionais(dados);
        }

        private void SalvaIdiomas(Dados dados) //Salva os idiomas
        {
            var idiomasCadastradosBanco = ClsIdioma.CarregaIdiomas(dados, ID); //Cria uma nova lista de idiomas do banco
            
            foreach(var idioma in Idiomas) //Para cada idioma da lista de idiomas
            {
                if (idiomasCadastradosBanco.Any(i => i.ID == idioma.ID)) //Se algum dos idiomas da lista de idiomas existir na lista de idiomas do banco
                {
                    idiomasCadastradosBanco.RemoveAll(i => i.ID == idioma.ID); //Ambos são removidos
                }
                else
                {
                    idioma.Salvar(dados); //Se não, o idioma da lista de idiomas é inserido no banco de dados
                }
            }

            foreach(var idioma in idiomasCadastradosBanco)
            {
                idioma.Remover(dados); //Remove todos os idiomas da lista de idiomas cadastrados no banco
            }
        }

        private void SalvaQualificacoesTecnicas(Dados dados)
        {
            var formacoesAcademicasCadastradasNoBanco = ClsQualificacaoTecnica.CarregaQualificacoesTecnicas(dados, ID);

            foreach (var qualificacao in QualificacoesTecnicas)
            {
                if (formacoesAcademicasCadastradasNoBanco.Any(i => i.ID == qualificacao.ID))
                {
                    formacoesAcademicasCadastradasNoBanco.RemoveAll(i => i.ID == qualificacao.ID);
                }
                else
                {
                    qualificacao.Salvar(dados);
                }
            }

            foreach (var qualificacao in formacoesAcademicasCadastradasNoBanco)
            {
                qualificacao.Remover(dados);
            }
        }

        private void SalvaFormacoesAcademicas(Dados dados)
        {
            var formacoesAcademicasCadastradasNoBanco = ClsFormacaoAcademica.CarregaFormacoesAcademicas(dados, ID);

            foreach (var formacaoAcademica in FormacoesAcademicas)
            {
                if (formacoesAcademicasCadastradasNoBanco.Any(i => i.ID == formacaoAcademica.ID))
                {
                    formacoesAcademicasCadastradasNoBanco.RemoveAll(i => i.ID == formacaoAcademica.ID);
                }
                else
                {
                    formacaoAcademica.Salvar(dados);
                }
            }

            foreach (var formacaoAcademica in formacoesAcademicasCadastradasNoBanco)
            {
                formacaoAcademica.Remover(dados);
            }
        }

        private void SalvaExperienciasProfissionais(Dados dados)
        {
            var experienciasProfissionaisCadastradasNoBanco = ClsExperienciaProfissional.CarregaExperienciasProfissionais(dados, ID);

            foreach (var experienciaProfissional in ExperienciasProfissionais)
            {
                if (experienciasProfissionaisCadastradasNoBanco.Any(i => i.ID == experienciaProfissional.ID))
                {
                    experienciasProfissionaisCadastradasNoBanco.RemoveAll(i => i.ID == experienciaProfissional.ID);
                }
                else
                {
                    experienciaProfissional.Salvar(dados);
                }
            }

            foreach (var experienciaProfissional in experienciasProfissionaisCadastradasNoBanco)
            {
                experienciaProfissional.Remover(dados);
            }
        }

        private bool ExisteNoBanco(Dados dados) //Verifica se o currículo já existe no banco de dados
        {
            var tabela = dados.ConvertSqlToDataTable("select * from curriculo where id = @id", new MySqlParameter("@id", ID));
            return tabela.Rows.Count > 0; //Se o currículo já existir, retorna true
        }

         public static void GeraCurriculo(Dados dados, int candidatoID, bool mostrarCurriculo, bool recrutador, string lCurso, string lPeriodo, string lModulo)
        {
            var candidato = ClsCandidato.CarregaCandidato(dados, candidatoID);

            Document documento = new Document(PageSize.A4);
            documento.SetMargins(40, 40, 40, 40);

            string usuario = System.Environment.UserName;

            string caminho;

            if (recrutador)
            {         
                caminho = @"C:\Users\" + usuario + @"\Desktop\Currículos\" + lCurso + @"\" + lPeriodo + @"\" + lModulo;

                if (!Directory.Exists(caminho))
                {
                    Directory.CreateDirectory(caminho);
                }

                caminho = caminho + @"\" + candidato.Nome + ".pdf";
            }
            else
            {
                caminho = @"C:\Users\" + usuario + @"\Desktop\" + candidato.Nome + ".pdf";
            }

            PdfWriter writer = PdfWriter.GetInstance(documento, new FileStream(caminho, FileMode.Create));
            documento.Open();

            #region Alocação estática no documento
            Paragraph pNome = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 20, Font.BOLD));
            pNome.Alignment = Element.ALIGN_CENTER;

            Paragraph pInformacoes = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
            pInformacoes.Alignment = Element.ALIGN_CENTER;

            Paragraph pEndereco = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
            pEndereco.Alignment = Element.ALIGN_CENTER;

            Paragraph pContato = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
            pContato.Alignment = Element.ALIGN_CENTER;

            //pNome
            string nome = candidato.Nome;

            //pInformacoes
            string nacionalidade = candidato.Nacionalidade;
            string estado_civil = TrataEstadoCivil(candidato.Sexo, candidato.Estado_civil);
            string idade = CalculaIdade(candidato.Nascimento);

            //pEndereco
            string rua = candidato.Rua;
            string numero = candidato.Numero;
            string bairro = candidato.Bairro;
            string cep = string.Format("{0:#####-###}", Int64.Parse(candidato.Cep));
            string cidade = candidato.Cidade;
            string estado = candidato.Estado;

            //pContato
            //string celular = string.Format("{0:(##)#####-####}", 16111111111);
            string celular = string.Format("{0:(##)#####-####}", Int64.Parse(candidato.Celular));
            string email = candidato.Email;
            
            //Paragráfos
            pNome.Add(nome);
            pInformacoes.Add(nacionalidade + ", " + estado_civil + ", " + idade + " anos");
            pEndereco.Add("Endereço: " + rua + ", n° " + numero + ", " + bairro + " - " + cep + " - " + cidade + " - " + estado);
            pContato.Add("Celular: " + celular + " - E-mail: " + email);
            
            //Adicionando paragráfos ao documento
            documento.Add(pNome);
            documento.Add(pInformacoes);
            documento.Add(pEndereco);
            documento.Add(pContato);
            #endregion

            var curriculo = ClsCurriculo.CarregaCurriculo(dados, candidatoID);

            if (curriculo.Objetivo != "")
            {
                documento.Add(Chunk.NEWLINE);
                
                Paragraph pObjetivoTitulo = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
                pObjetivoTitulo.Alignment = Element.ALIGN_CENTER;

                Paragraph pObjetivo = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
                pObjetivo.Alignment = Element.ALIGN_LEFT;

                string titulo = "Objetivo";
                string objetivo = curriculo.Objetivo;

                pObjetivoTitulo.Add(titulo);
                pObjetivo.Add(objetivo);

                documento.Add(pObjetivoTitulo);
                documento.Add(pObjetivo);
            }

            documento.Add(Chunk.NEWLINE);

            Paragraph pFATitulo = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
            pFATitulo.Alignment = Element.ALIGN_CENTER;

            string tituloFA = "Formação Acadêmica";

            pFATitulo.Add(tituloFA);

            documento.Add(pFATitulo);    

            var etec = ClsCursoEtec.CarregaCursoEtec(dados, candidatoID);

            Paragraph pCurso = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD));
            pCurso.Alignment = Element.ALIGN_LEFT;

            Paragraph pEtec = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
            pEtec.Alignment = Element.ALIGN_LEFT;

            Paragraph pEtecTerceiraLinha = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
            pEtec.Alignment = Element.ALIGN_LEFT;

            string curso = etec.Curso;
            string inicioEtec = etec.Inicio.ToShortDateString().ToString();
            string terminoEtec = etec.Termino.ToShortDateString().ToString();
            string periodoEtec = etec.Periodo;
            string modulo = etec.Modulo;

            pCurso.Add(curso);
            pEtec.Add("Etec Sylvio de Mattos Carvalho");
            pEtecTerceiraLinha.Add(inicioEtec + " a " + terminoEtec + " - " + modulo + " - " + periodoEtec);

            documento.Add(pCurso);
            documento.Add(pEtec);
            documento.Add(pEtecTerceiraLinha);
            
            foreach (var formacaoAcademica in curriculo.FormacoesAcademicas)
            {
                documento.Add(Chunk.NEWLINE);

                Paragraph pFormacao = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD));
                pFormacao.Alignment = Element.ALIGN_LEFT;

                Paragraph pInstituicao = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
                pInstituicao.Alignment = Element.ALIGN_LEFT;

                Paragraph pInfo = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
                pInfo.Alignment = Element.ALIGN_LEFT;

                string formacao = formacaoAcademica.Formacao;
                string instituicao = formacaoAcademica.Instituicao;
                string inicio = formacaoAcademica.Inicio.ToShortDateString().ToString();
                string termino = formacaoAcademica.Termino.ToShortDateString().ToString();

                pFormacao.Add(formacao);
                pInstituicao.Add(instituicao);
                pInfo.Add(inicio + " a " + termino);                    

                if (formacaoAcademica.Semestre != "")
                {
                    string semestre = " - " + formacaoAcademica.Semestre;
                    pInfo.Add(semestre);                        
                }
                if (formacaoAcademica.Periodo != "")
                {
                    string periodo = " - " + formacaoAcademica.Periodo;
                    pInfo.Add(periodo);
                }

                documento.Add(pFormacao);
                documento.Add(pInstituicao);
                documento.Add(pInfo);
            }

            if (curriculo.ExperienciasProfissionais.Count > 0)
            {
                documento.Add(Chunk.NEWLINE);

                Paragraph pEPTitulo = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
                pEPTitulo.Alignment = Element.ALIGN_CENTER;

                string tituloEP = "Experiência Profissional";

                pEPTitulo.Add(tituloEP);

                documento.Add(pEPTitulo);

                bool primeiraFormacao = true;

                foreach (var experienciaProfissional in curriculo.ExperienciasProfissionais)
                {
                    if (primeiraFormacao == false)
                    {
                        documento.Add(Chunk.NEWLINE);
                    }
                    else
                    {
                        primeiraFormacao = false;
                    }
                    Paragraph pEmpresa = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD));
                    pEmpresa.Alignment = Element.ALIGN_LEFT;

                    Paragraph pCargo = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
                    pCargo.Alignment = Element.ALIGN_LEFT;

                    Paragraph pInfo = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
                    pInfo.Alignment = Element.ALIGN_LEFT;

                    string empresa = experienciaProfissional.Empresa;
                    string cargo = experienciaProfissional.Cargo;
                    string inicio = experienciaProfissional.Inicio.ToShortDateString();
                    string termino = " a " + experienciaProfissional.Termino.ToShortDateString();
                    
                    pEmpresa.Add(empresa);
                    pCargo.Add(cargo);

                    if (termino != " a 01/01/0001")
                    {
                        pInfo.Add(inicio + termino);
                    }
                    else
                    {
                        pInfo.Add(inicio + " - Atualmente");
                    }                                            
                    documento.Add(pEmpresa);
                    documento.Add(pCargo);
                    documento.Add(pInfo);                    
                }
            }

            if (curriculo.Idiomas.Count > 0)
            {
                documento.Add(Chunk.NEWLINE);

                Paragraph pIdiomaTitulo = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
                pIdiomaTitulo.Alignment = Element.ALIGN_CENTER;

                string tituloIdioma = "Idioma";

                pIdiomaTitulo.Add(tituloIdioma);

                documento.Add(pIdiomaTitulo);

                bool primeiroIdioma = true;

                foreach (var idioma in curriculo.Idiomas)
                {
                    if (primeiroIdioma == false)
                    {
                        documento.Add(Chunk.NEWLINE);
                    }
                    else
                    {
                        primeiroIdioma = false;
                    }
                    Paragraph pNomeIdioma = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD));
                    pNomeIdioma.Alignment = Element.ALIGN_LEFT;

                    Paragraph pNivel = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
                    pNivel.Alignment = Element.ALIGN_LEFT;
                  
                    string nomeIdioma = idioma.Nome;
                    string nivel = idioma.Nivel;

                    pNomeIdioma.Add(nomeIdioma);
                    pNivel.Add(nivel);
                    
                    documento.Add(pNomeIdioma);
                    documento.Add(pNivel);
                }
            }

            if (curriculo.QualificacoesTecnicas.Count > 0)
            {
                documento.Add(Chunk.NEWLINE);

                Paragraph pQTTitulo = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
                pQTTitulo.Alignment = Element.ALIGN_CENTER;

                string tituloQT = "Qualificações Técnicas";

                pQTTitulo.Add(tituloQT);

                documento.Add(pQTTitulo);

                bool primeiraQT = true;

                foreach (var qualificacaoTecnica in curriculo.QualificacoesTecnicas)
                {
                    if (primeiraQT == false)
                    {
                        documento.Add(Chunk.NEWLINE);
                    }
                    else
                    {
                        primeiraQT = false;
                    }
                    Paragraph pQualificacaoTecnica = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
                    pQualificacaoTecnica.Alignment = Element.ALIGN_LEFT;

                    string descricao = qualificacaoTecnica.Descricao;

                    pQualificacaoTecnica.Add("• " + descricao); //• = alt + 7

                    documento.Add(pQualificacaoTecnica);
                }
            }

            documento.Close();

            if (mostrarCurriculo)
            {
                System.Diagnostics.Process.Start(caminho);
            }
        }

        public static string CalculaIdade(DateTime nascimento)
        {            
            int anos = DateTime.Today.Year - nascimento.Year;

            if (nascimento.Month > DateTime.Today.Month || nascimento.Month == DateTime.Today.Month && nascimento.Day > DateTime.Today.Day)
            {
                anos--;
            }

            return anos.ToString();
        }

        public static string TrataEstadoCivil(string sexo, string estado_civil)
        {
            if (sexo == "Feminino")
            {
                if (estado_civil == "Solteiro(a)")
                {
                    return "solteira";
                }
                else if (estado_civil == "Casado(a)")
                {
                    return "casada";
                }
                else if (estado_civil == "Divorciado(a)")
                {
                    return "divorciada";
                }
                else if (estado_civil == "Viúvo(a)")
                {
                    return "viúva";
                }
                else
                {
                    return "separada";
                }
            }
            else if (sexo == "Masculino")
            {
                if (estado_civil == "Solteiro(a)")
                {
                    return "solteiro";
                }
                else if (estado_civil == "Casado(a)")
                {
                    return "casado";
                }
                else if (estado_civil == "Divorciado(a)")
                {
                    return "divorciado";
                }
                else if (estado_civil == "Viúvo(a)")
                {
                    return "viúvo";
                }
                else
                {
                    return "separado";
                }
            }
            else
            {
                if (estado_civil == "Solteiro(a)")
                {
                    return "solteiro(a)";
                }
                else if (estado_civil == "Casado(a)")
                {
                    return "casado(a)";
                }
                else if (estado_civil == "Divorciado(a)")
                {
                    return "divorciado(a)";
                }
                else if (estado_civil == "Viúvo(a)")
                {
                    return "viúvo(a)";
                }
                else
                {
                    return "separado(a)";
                }
            }
        }       
    }
}
