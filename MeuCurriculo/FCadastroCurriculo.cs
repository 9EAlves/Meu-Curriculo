using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuCurriculo
{
    public partial class FCadastroCurriculo : Form
    {
        private int _counter = 0;
        // Create a new Timer object.
        Timer timer = new Timer();
   
        private int idCandidato;
        private ClsCurriculo curriculo;
        private int idIdiomaSelecionado;
        private int idQualificacaoTecnicaSelecionada;
        private int idFormacaoAcademicaSelecionada;
        private int idExperienciaProfisionalSelecionada;
        private Dados dados = new Dados();

        public FCadastroCurriculo(int candidato_id) //recebe o ID do candidato pelo parâmetro
        {
            InitializeComponent();
            idCandidato = candidato_id; //armazena o ID do candidato
        }
        
        private void FCadastroCurriculo_Load(object sender, EventArgs e)
        {
            //InicializaCurriculo(idCandidato);
        }

        public void InicializaCurriculo(int candidatoID)
        {
            curriculo = ClsCurriculo.CarregaCurriculo(dados, candidatoID); //Instância o objeto currículo, já trazendo seu id, objetivo e lista de idiomas

            AtualizaTela(); //Atualiza o currículo no form
        }

        private void AtualizaTela()
        {
            txtObjetivo.Text = curriculo.Objetivo; //Mostra o objetivo

            BindIdiomas();
            BindQualificacoesTecnicas();
            BindFormacoesAcademicas();
            BindExperienciasProfissionais();
        }

        #region btnAdicionar e Binds        
        private void btnAdicionarIdioma_Click(object sender, EventArgs e)
        {
            if (validaIdioma()) //Valida os campos do idioma
            {
                curriculo.Idiomas.Add(new ClsIdioma //Adiciona um novo idioma na lista de idiomas do currículo
                {
                    Nome = txtIdioma.Text, //Define o nome do idioma
                    Nivel = cboNivel.Text, //Define o nível do idioma
                    Curriculo = curriculo //Define o curriculo_id/currículo do idioma
                });
                BtnLimparIdioma_Click(sender, e);
                BindIdiomas(); //Atualiza a lista de idiomas no grid
            }
        }
        private void BindIdiomas() //Atualiza a lista de idiomas no grid
        { 
            var bindingList = new BindingList<ClsIdioma>(curriculo.Idiomas); //Cria uma nova bindingList de idiomas da lista de idiomas do currículo
            var source = new BindingSource(bindingList, null); //Cria uma BindingSource, caminho pelo qual os dados da bindingList passa

            dtIdioma.DataSource = source; //dtIdioma é atualizado com a lista de idiomas
            dtIdioma.Columns["Curriculo"].Visible = false; //Oculta a coluna curriculo_id
            dtIdioma.Columns["ID"].Visible = false; //Oculta a coluna id
        }

        private void BtnAdicionarQT_Click(object sender, EventArgs e)
        {
            if (validaQualificacaoTecnica())
            {
                curriculo.QualificacoesTecnicas.Add(new ClsQualificacaoTecnica
                {
                    Descricao = txtQualificacao.Text,
                    Curriculo = curriculo
                });
                BtnLimparQT_Click(sender, e);
                BindQualificacoesTecnicas();
            }
        }

        private void BindQualificacoesTecnicas() 
        {
            var bindingList = new BindingList<ClsQualificacaoTecnica>(curriculo.QualificacoesTecnicas);
            var source = new BindingSource(bindingList, null);

            dtQualificacaoTecnica.DataSource = source;
            dtQualificacaoTecnica.Columns["Id"].Visible = false;
            dtQualificacaoTecnica.Columns["Curriculo"].Visible = false;
        }

        private void BtnAdicionarFA_Click(object sender, EventArgs e)
        {
            if (validaFormacaoAcademica())
            {
                if (cboPeriodo.SelectedIndex > -1 == false && cboSemestre.SelectedIndex > -1 == false)
                {
                    curriculo.FormacoesAcademicas.Add(new ClsFormacaoAcademica
                    {
                        Instituicao = txtInstituicao.Text,
                        Formacao = txtFormacao.Text,
                        Inicio = dtpInicioFA.Value.Date,
                        Termino = dtpTerminoFA.Value.Date,        
                        Curriculo = curriculo
                    });
                }
                else if (cboPeriodo.SelectedIndex > -1 == false)
                {
                    curriculo.FormacoesAcademicas.Add(new ClsFormacaoAcademica
                    {
                        Instituicao = txtInstituicao.Text,
                        Formacao = txtFormacao.Text,
                        Inicio = dtpInicioFA.Value.Date,
                        Termino = dtpTerminoFA.Value.Date,
                        Semestre = cboSemestre.SelectedItem.ToString(),
                        Curriculo = curriculo
                    });
                }
                else if (cboSemestre.SelectedIndex > -1 == false)
                {
                    curriculo.FormacoesAcademicas.Add(new ClsFormacaoAcademica
                    {
                        Instituicao = txtInstituicao.Text,
                        Formacao = txtFormacao.Text,
                        Inicio = dtpInicioFA.Value.Date,
                        Termino = dtpTerminoFA.Value.Date,
                        Periodo = cboPeriodo.SelectedItem.ToString(),
                        Curriculo = curriculo
                    });
                }
                else
                {
                    curriculo.FormacoesAcademicas.Add(new ClsFormacaoAcademica
                    {
                        Instituicao = txtInstituicao.Text,
                        Formacao = txtFormacao.Text,
                        Inicio = dtpInicioFA.Value.Date,
                        Termino = dtpTerminoFA.Value.Date,
                        Periodo = cboPeriodo.SelectedItem.ToString(),
                        Semestre = cboSemestre.SelectedItem.ToString(),
                        Curriculo = curriculo
                    });
                }
                BtnLimparFA_Click(sender, e);
                BindFormacoesAcademicas();
            }
        }

        private void BindFormacoesAcademicas()
        {
            var bindingList = new BindingList<ClsFormacaoAcademica>(curriculo.FormacoesAcademicas);
            var source = new BindingSource(bindingList, null);

            dtFormacaoAcademica.DataSource = source;
            dtFormacaoAcademica.Columns["Id"].Visible = false;
            dtFormacaoAcademica.Columns["Curriculo"].Visible = false;
        }

        private void BtnAdicionarEP_Click(object sender, EventArgs e)
        {
            if (validaExperienciaProfissional())
            {
                if (chkTermino.Checked)
                {
                    curriculo.ExperienciasProfissionais.Add(new ClsExperienciaProfissional
                    {
                        Empresa = txtEmpresa.Text,
                        Cargo = txtCargo.Text,
                        Inicio = dtpInicioEP.Value.Date,
                        Termino = dtpTerminoEP.Value.Date,
                        Curriculo = curriculo
                    });
                }
                else
                {
                    curriculo.ExperienciasProfissionais.Add(new ClsExperienciaProfissional
                    {
                        Empresa = txtEmpresa.Text,
                        Cargo = txtCargo.Text,
                        Inicio = dtpInicioEP.Value.Date,
                        Curriculo = curriculo
                    });
                }
                    BtnLimparEP_Click(sender, e);
                    BindExperienciasProfissionais();                
            }
        }

        private void BindExperienciasProfissionais()
        {
            var bindingList = new BindingList<ClsExperienciaProfissional>(curriculo.ExperienciasProfissionais);
            var source = new BindingSource(bindingList, null);

            dtExperienciaProfissional.DataSource = source;
            dtExperienciaProfissional.Columns["Id"].Visible = false;
            dtExperienciaProfissional.Columns["Curriculo"].Visible = false;
        }
        #endregion

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtObjetivo.Text == "")
                {
                    curriculo.Objetivo = "";
                }
                else
                {
                    curriculo.Objetivo = txtObjetivo.Text; //Define o objetivo do currículo
                }
                curriculo.Salvar(dados, idCandidato);
                ClsCurriculo.GeraCurriculo(dados, idCandidato, false, false, "", "", "");
                MessageBox.Show("Currículo salvo com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ocorreu um erro: {0}", ex.Message));
            }
        }
        private void BtnRefazerObjetivo_Click(object sender, EventArgs e)
        {
            txtObjetivo.Text = curriculo.Objetivo;
        }

        #region Click com o direito para excluir        
        private void dtIdioma_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int qtdeLinhas = dtIdioma.Rows.Count;

                int currentMouseOverRow = dtIdioma.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0 && currentMouseOverRow != qtdeLinhas - 1)
                {                    
                    ContextMenu m = new ContextMenu();
                    dtIdioma.Rows[currentMouseOverRow].Selected = true;
                    idIdiomaSelecionado = int.Parse(dtIdioma.Rows[currentMouseOverRow].Cells[0].Value.ToString());
                    var idioma = dtIdioma.Rows[currentMouseOverRow].Cells[1].Value.ToString();
                    m.MenuItems.Add(new MenuItem(string.Format("Remover idioma: {0}", idioma), removeIdioma));
                    m.Show(dtIdioma, new Point(e.X, e.Y));                                        
                }                                
            }
        }

        private void removeIdioma(object sender, EventArgs e)
        {
            curriculo.Idiomas.RemoveAll(i => i.ID == idIdiomaSelecionado);
            BindIdiomas();
        }

        private void DtQualificacaoTecnica_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int qtdeLinhas = dtQualificacaoTecnica.Rows.Count;
                
                int currentMouseOverRow = dtQualificacaoTecnica.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0 && currentMouseOverRow != qtdeLinhas - 1)
                {
                    ContextMenu m = new ContextMenu();
                    dtQualificacaoTecnica.Rows[currentMouseOverRow].Selected = true;
                    idQualificacaoTecnicaSelecionada = int.Parse(dtQualificacaoTecnica.Rows[currentMouseOverRow].Cells[0].Value.ToString());
                    var qualificacaoTecnica = dtQualificacaoTecnica.Rows[currentMouseOverRow].Cells[1].Value.ToString();
                    m.MenuItems.Add(new MenuItem(string.Format("Remover qualificação: {0}", qualificacaoTecnica), removeQualificacaoTecnica));
                    m.Show(dtQualificacaoTecnica, new Point(e.X, e.Y));
                }
            }
        }

        private void removeQualificacaoTecnica(object sender, EventArgs e)
        {
            curriculo.QualificacoesTecnicas.RemoveAll(i => i.ID == idQualificacaoTecnicaSelecionada);
            BindQualificacoesTecnicas();
        }

        private void DtFormacaoAcademica_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int qtdeLinhas = dtFormacaoAcademica.Rows.Count;

                int currentMouseOverRow = dtFormacaoAcademica.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0 && currentMouseOverRow != qtdeLinhas - 1)
                {
                    ContextMenu m = new ContextMenu();
                    dtFormacaoAcademica.Rows[currentMouseOverRow].Selected = true;
                    idFormacaoAcademicaSelecionada = int.Parse(dtFormacaoAcademica.Rows[currentMouseOverRow].Cells[0].Value.ToString());
                    var formacaoAcademica = dtFormacaoAcademica.Rows[currentMouseOverRow].Cells[2].Value.ToString();
                    m.MenuItems.Add(new MenuItem(string.Format("Remover formação: {0}", formacaoAcademica), removeFormacaoAcademica));
                    m.Show(dtFormacaoAcademica, new Point(e.X, e.Y));
                }

            }
        }

        private void removeFormacaoAcademica(object sender, EventArgs e)
        {
            curriculo.FormacoesAcademicas.RemoveAll(i => i.ID == idFormacaoAcademicaSelecionada);
            BindFormacoesAcademicas();
        }

        private void DtExperienciaProfissional_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int qtdeLinhas = dtExperienciaProfissional.Rows.Count;

                int currentMouseOverRow = dtExperienciaProfissional.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0 && currentMouseOverRow != qtdeLinhas - 1)
                {
                    ContextMenu m = new ContextMenu();
                    dtExperienciaProfissional.Rows[currentMouseOverRow].Selected = true;
                    idExperienciaProfisionalSelecionada = int.Parse(dtExperienciaProfissional.Rows[currentMouseOverRow].Cells[0].Value.ToString());
                    var experienciaProfissional = dtExperienciaProfissional.Rows[currentMouseOverRow].Cells[1].Value.ToString();
                    m.MenuItems.Add(new MenuItem(string.Format("Remover experiência profissional: {0}", experienciaProfissional), removeExperienciaProfissional));
                    m.Show(dtExperienciaProfissional, new Point(e.X, e.Y));
                }
            }
        }

        private void removeExperienciaProfissional(object sender, EventArgs e)
        {
            curriculo.ExperienciasProfissionais.RemoveAll(i => i.ID == idExperienciaProfisionalSelecionada);
            BindExperienciasProfissionais();
        }
        #endregion

        #region Placeholders

        private void txtInstituicao_Enter(object sender, EventArgs e)
        {
            if (txtInstituicao.Text == "Instituição")
            {
                txtInstituicao.Text = "";
                txtInstituicao.ForeColor = Color.Black;
            }
        }

        private void txtInstituicao_Leave(object sender, EventArgs e)
        {
            if (txtInstituicao.Text == "")
            {
                txtInstituicao.Text = "Instituição";

                txtInstituicao.ForeColor = Color.Silver;
            }
        }

        private void txtFormacao_Enter(object sender, EventArgs e)
        {
            if (txtFormacao.Text == "Formação")
            {
                txtFormacao.Text = "";
                txtFormacao.ForeColor = Color.Black;
            }
        }

        private void txtFormacao_Leave(object sender, EventArgs e)
        {
            if (txtFormacao.Text == "")
            {
                txtFormacao.Text = "Formação";

                txtFormacao.ForeColor = Color.Silver;
            }
        }

        private void txtEmpresa_Enter(object sender, EventArgs e)
        {
            if (txtEmpresa.Text == "Empresa")
            {
                txtEmpresa.Text = "";
                txtEmpresa.ForeColor = Color.Black;
            }
        }

        private void txtEmpresa_Leave(object sender, EventArgs e)
        {
            if (txtEmpresa.Text == "")
            {
                txtEmpresa.Text = "Empresa";

                txtEmpresa.ForeColor = Color.Silver;
            }
        }

        private void txtCargo_Enter(object sender, EventArgs e)
        {
            if (txtCargo.Text == "Cargo")
            {
                txtCargo.Text = "";
                txtCargo.ForeColor = Color.Black;
            }
        }

        private void txtCargo_Leave(object sender, EventArgs e)
        {
            if (txtCargo.Text == "")
            {
                txtCargo.Text = "Cargo";

                txtCargo.ForeColor = Color.Silver;
            }
        }

        private void txtIdioma_Enter(object sender, EventArgs e)
        {
            if (txtIdioma.Text == "Idioma")
            {
                txtIdioma.Text = "";
                txtIdioma.ForeColor = Color.Black;
            }
        }

        private void txtIdioma_Leave(object sender, EventArgs e)
        {
            if (txtIdioma.Text == "")
            {
                txtIdioma.Text = "Idioma";

                txtIdioma.ForeColor = Color.Silver;
            }
        }

        private void txtQualificacao_Enter(object sender, EventArgs e)
        {
            if (txtQualificacao.Text == "Descreva a qualificação")
            {
                txtQualificacao.Text = "";
                txtQualificacao.ForeColor = Color.Black;
            }
        }

        private void txtQualificacao_Leave(object sender, EventArgs e)
        {
            if (txtQualificacao.Text == "")
            {
                txtQualificacao.Text = "Descreva a qualificação";

                txtQualificacao.ForeColor = Color.Silver;
            }
        }
        #endregion

        #region Validação
        public bool validaIdioma()
        {            
            bool continua = true;
            if (txtIdioma.Text == "Idioma")
            {
                txtIdioma.ForeColor = Color.Red;
                continua = false;
            }
            if (cboNivel.SelectedIndex > -1 == false)
            {
                lblNivel.ForeColor = Color.Red;
                continua = false;
            }
            if (continua == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validaFormacaoAcademica()
        {
            bool continua = true;
            if (txtInstituicao.Text == "Instituição")
            {
                txtInstituicao.ForeColor = Color.Red;
                continua = false;
            }
            if (txtFormacao.Text == "Formação")
            {
                txtFormacao.ForeColor = Color.Red;
                continua = false;
            }
            if (continua == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validaExperienciaProfissional()
        {
            bool continua = true;
            if (txtEmpresa.Text == "Empresa")
            {
                txtEmpresa.ForeColor = Color.Red;
                continua = false;
            }
            if (txtCargo.Text == "Cargo")
            {
                txtCargo.ForeColor = Color.Red;
                continua = false;
            }            
            if (continua == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validaQualificacaoTecnica()
        {           
            if (txtQualificacao.Text == "Descreva a qualificação")
            {
                txtQualificacao.ForeColor = Color.Red;
                return false;
            }
            return true;
        }
        #endregion

        #region Outros ajustes do formulário
        private void CboNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNivel.ForeColor = Color.Black;
        }

        #endregion

        #region btnLimpar        
        private void BtnLimparIdioma_Click(object sender, EventArgs e)
        {
            txtIdioma.Text = "";
            txtIdioma_Leave(sender, e);
            lblNivel.ForeColor = Color.Black;
            cboNivel.SelectedIndex = -1;
        }

        private void BtnLimparQT_Click(object sender, EventArgs e)
        {
            txtQualificacao.Text = "";
            txtQualificacao_Leave(sender, e);
        }

        private void BtnLimparFA_Click(object sender, EventArgs e)
        {
            txtInstituicao.Text = "";
            txtFormacao.Text = "";
            txtInstituicao_Leave(sender, e);
            txtFormacao_Leave(sender, e);
            cboPeriodo.SelectedIndex = -1;
            cboSemestre.SelectedIndex = -1;
        }

        private void BtnLimparEP_Click(object sender, EventArgs e)
        {
            txtEmpresa.Text = "";
            txtCargo.Text = "";
            txtEmpresa_Leave(sender, e);
            txtCargo_Leave(sender, e);
        }
        private void BtnLimparObjetivo_Click_1(object sender, EventArgs e)
        {
            txtObjetivo.Text = "";
        }
        #endregion

        #region Menu        
        private void VisualizarCurriculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCurriculo.GeraCurriculo(dados, idCandidato, true, false, "", "", "");
        }
        private void ContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FCadastroCandidato EditarCandidato = new FCadastroCandidato(true, idCandidato);
            EditarCandidato.ShowDialog();
        }
        private void SairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FLogin Login = new FLogin();
            Login.ShowDialog();
        }

        #endregion

        private void ChkTermino_CheckedChanged(object sender, EventArgs e)
        {
            dtpTerminoEP.Enabled = !dtpTerminoEP.Enabled;
            if (lblTerminoEP.ForeColor == SystemColors.ControlText)
            {
                lblTerminoEP.ForeColor = SystemColors.InactiveCaption;
            }
            else
            {
                lblTerminoEP.ForeColor = Color.Black;
            }
        }
        /*
        // Used to store the counting value.
        private int _counter = 0;

        private void control_MouseHover(object sender, EventArgs e)
        {
            // Create a new Timer object.
            Timer timer = new Timer();

            // Set the timer's interval.
            timer.Interval = 1000;

            // Create the Tick-listening event.
            _timer.Tick += delegate(object sender, EventArgs e) 
            {
                // Update the counter variable.
                _counter++;

                // If the set time has reached, then show a MessageBox.
                if (_counter == 3) {
                    MessageBox.Show("Three seconds have passed!");
                }
            };

            // Start the timer.
            _timer.Start();
        } 
         */

        private void DtFormacaoAcademica_MouseHover(object sender, MouseEventArgs e)
        {

            // Set the timer's interval.
            timer.Interval = 1000;

            // Create the Tick-listening event.
            timer.Tick += delegate (object emissor, EventArgs receptor)
            {
                // Update the counter variable.
                _counter++;

                // If the set time has reached, then show a MessageBox.
                if (_counter == 2)
                {
                    ToolTip tooltip = new ToolTip();

                    //tooltip.show(richeditbox, e.x, e.y, 1000);



                    lblAjuda.Visible = true;                    
                }
            };

            // Start the timer.
            timer.Start();            
        }

        private void DtFormacaoAcademica_MouseLeave(object sender, EventArgs e)
        {
            lblAjuda.Visible = false;
            timer.Stop();
            _counter = 0;
        }        
    }
}
