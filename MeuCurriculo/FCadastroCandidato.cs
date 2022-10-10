using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Correios;

namespace MeuCurriculo
{
    public partial class FCadastroCandidato : Form
    {
        bool mostrarSenha = false;
        private ClsCandidato objCandidato;
        private ClsRecrutador objRecrutador;
        private Dados dados = new Dados();
        private bool modoEdicao;
        private int idCandidato;

        public FCadastroCandidato(bool editarCandidato, int candidatoID)
        {
            InitializeComponent();
            modoEdicao = editarCandidato;
            idCandidato = candidatoID;
        }
        
        private void FCadastroCandidato_Load(object sender, EventArgs e)
        {
            lblCurso.Select();
            objRecrutador = new ClsRecrutador();
            if (modoEdicao)
            {                
                this.Text = "Conta";
                //this.menuStrip1.Visible = true;
                //this.btnRefazer.Visible = true;
                objCandidato = ClsCandidato.CarregaCandidato(dados, idCandidato);
                objCandidato.CursoEtec = ClsCursoEtec.CarregaCursoEtec(dados, idCandidato);
                btnFinalizar.Text = "Alterar";
                atualizaTela();
                mudaCorCampos();                
            }
            else
            {
                objCandidato = new ClsCandidato();
            }
        }

        private void atualizaTela()
        {
            txtNome.Text = objCandidato.Nome;
            dtpNascimento.Value = objCandidato.Nascimento;
            cboEstadoCivil.SelectedItem = objCandidato.Estado_civil;
            txtCelular.Mask = "(00)00000-0000";
            txtCelular.Text = objCandidato.Celular;
            txtNacionalidade.Text = objCandidato.Nacionalidade;
            if (objCandidato.Sexo == "Feminino")
            {
                rdbFeminino.Checked = true;
            }
            else if (objCandidato.Sexo == "Masculino")
            {
                rdbMasculino.Checked = true;
            }
            else
            {
                rdbOutro.Checked = true;
            }
            txtCEP.Mask = "00000-000";
            txtCEP.Text = objCandidato.Cep;
            txtCidade.Text = objCandidato.Cidade;
            txtBairro.Text = objCandidato.Bairro;
            cboEstado.SelectedItem = objCandidato.Estado;            
            txtRua.Text = objCandidato.Rua;
            txtNumero.Text = objCandidato.Numero;

            cboCurso.SelectedItem = objCandidato.CursoEtec.Curso;
            dtpInicioEtec.Value = objCandidato.CursoEtec.Inicio;
            dtpTerminoEtec.Value = objCandidato.CursoEtec.Termino;
            cboPeriodo.SelectedItem = objCandidato.CursoEtec.Periodo;
            cboModulo.SelectedItem = objCandidato.CursoEtec.Modulo;

            txtEmail.Text = objCandidato.Email;

            if (mostrarSenha){
                txtSenha.PasswordChar = '\0';
                txtSenha2.PasswordChar = '\0';
            }
            else
            {
                txtSenha.PasswordChar = '•';
                txtSenha2.PasswordChar = '•';
            }

            txtSenha.Text = objCandidato.Senha;
            txtSenha2.Text = objCandidato.Senha;
            txtDicaSenha.Text = objCandidato.Dica_senha;
        }

        private void mudaCorCampos()
        {
            txtNome.ForeColor = Color.Black;
            txtCelular.ForeColor = Color.Black;
            txtNacionalidade.ForeColor = Color.Black;
            txtCEP.ForeColor = Color.Black;
            txtCidade.ForeColor = Color.Black;
            txtBairro.ForeColor = Color.Black;
            txtRua.ForeColor = Color.Black;
            txtNumero.ForeColor = Color.Black;
            txtEmail.ForeColor = Color.Black;
            txtSenha.ForeColor = Color.Black;
            txtSenha2.ForeColor = Color.Black;
            txtDicaSenha.ForeColor = Color.Black;
        }

        #region Validação
        private bool ValidaTudo()
        {
            if (ValidaCampoVazio())
            {
                if (ValidaEmail())
                {
                    if (ValidaSenha())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ValidaCampoVazio()
        {
            bool continua = true;
            //Informações pessoais:
            if (txtNome.Text == "Nome")
            {
                txtNome.ForeColor = Color.Red;
                continua = false;
            }
            if (cboEstadoCivil.SelectedIndex > -1 == false)
            {
                lblEstadoCivil.ForeColor = Color.Red;
                continua = false;
            }
            if (txtCelular.Text == "Celular")
            {
                txtCelular.ForeColor = Color.Red;
                continua = false;
            }
            if (txtNacionalidade.Text == "Nacionalidade")
            {
                txtNacionalidade.ForeColor = Color.Red;
                continua = false;
            }
            if (rdbFeminino.Checked == false && rdbMasculino.Checked == false && rdbOutro.Checked == false)
            {
                rdbFeminino.ForeColor = Color.Red;
                rdbMasculino.ForeColor = Color.Red;
                rdbOutro.ForeColor = Color.Red;
                continua = false;
            }
            //Endereço:
            if (txtCEP.Text == "CEP")
            {
                txtCEP.ForeColor = Color.Red;
                continua = false;
            }
            if (txtCidade.Text == "Cidade")
            {
                txtCidade.ForeColor = Color.Red;
                continua = false;
            }
            if (txtBairro.Text == "Bairro")
            {
                txtBairro.ForeColor = Color.Red;
                continua = false;
            }
            if (cboEstado.SelectedIndex > -1 == false)
            {
                lblEstado.ForeColor = Color.Red;
                continua = false;
            }
            if (txtRua.Text == "Rua")
            {
                txtRua.ForeColor = Color.Red;
                continua = false;
            }
            if (txtNumero.Text == "Número")
            {
                txtNumero.ForeColor = Color.Red;
                continua = false;
            }
            //Curso na Etec:
            if (cboCurso.SelectedIndex > -1 == false)
            {
                lblCurso.ForeColor = Color.Red;
                continua = false;
            }
            if (cboPeriodo.SelectedIndex > -1 == false)
            {
                lblPeriodo.ForeColor = Color.Red;
                continua = false;
            }
            if (cboModulo.SelectedIndex > -1 == false)
            {
                lblModulo.ForeColor = Color.Red;
                continua = false;
            }
            //Conta:
            if (txtEmail.Text == "E-mail")
            {
                txtEmail.ForeColor = Color.Red;
                continua = false;
            }
            if (txtSenha.Text == "Senha")
            {
                txtSenha.ForeColor = Color.Red;
                continua = false;
            }
            if (txtSenha2.Text == "Confirme a senha")
            {
                txtSenha2.ForeColor = Color.Red;
                continua = false;
            }
            if (txtDicaSenha.Text == "Dica de senha")
            {
                txtDicaSenha.ForeColor = Color.Red;
                continua = false;
            }

            if (continua == false)
            {
                MessageBox.Show("Preencha todos os campos.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidaEmail()
        {
            if (objCandidato.Email == txtEmail.Text)
            {
                return true;
            }
            else
            {
                objCandidato.Email = txtEmail.Text.ToString();
                objRecrutador.Email = txtEmail.Text.ToString();

                if (objCandidato.EmailJaExisteNoBanco(dados) || objRecrutador.ExisteNoBanco(dados, false))
                {
                    MessageBox.Show("O e-mail já existe.");
                    txtEmail.ForeColor = Color.Red;
                    return false;
                }                
            }
            return true;            
        }

        private bool ValidaSenha()
        {
            if (txtSenha.Text != txtSenha2.Text)
            {
                txtSenha.ForeColor = Color.Red;
                txtSenha2.ForeColor = Color.Red;
                MessageBox.Show("As senhas não coincidem.");
                return false;
            }
            return true;
        }
        #endregion

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            if (ValidaTudo())
            {
                try
                {
                    objCandidato.Email = txtEmail.Text.ToString();
                    objCandidato.Senha = txtSenha.Text.ToString();                    
                    objCandidato.Nome = txtNome.Text.ToString();
                    objCandidato.Dica_senha = txtDicaSenha.Text.ToString();
                    txtCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //tira a formatação da mascára
                    objCandidato.Celular = txtCelular.Text.ToString();
                    txtCelular.TextMaskFormat = MaskFormat.IncludeLiterals; //retorna a formatação da mascára
                    objCandidato.Nascimento = dtpNascimento.Value;
                    if (rdbFeminino.Checked == true)
                    {
                        objCandidato.Sexo = rdbFeminino.Text.ToString();
                    }
                    else if (rdbMasculino.Checked == true)
                    {
                        objCandidato.Sexo = rdbMasculino.Text.ToString();
                    }
                    else if (rdbOutro.Checked == true) //TODO Ver se funciona apenas com "else"
                    {
                        objCandidato.Sexo = rdbOutro.Text.ToString();
                    }
                    objCandidato.Estado_civil = cboEstadoCivil.Text.ToString();
                    objCandidato.Nacionalidade = txtNacionalidade.Text.ToString();
                    txtCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //tira a formatação da mascára
                    objCandidato.Cep = txtCEP.Text.ToString();
                    txtCEP.TextMaskFormat = MaskFormat.IncludeLiterals; //retorna a formatação da mascára
                    objCandidato.Cidade = txtCidade.Text.ToString();
                    objCandidato.Bairro = txtBairro.Text.ToString();
                    objCandidato.Estado = cboEstado.Text.ToString();
                    objCandidato.Rua = txtRua.Text.ToString();
                    objCandidato.Numero = txtNumero.Text.ToString();

                    if (modoEdicao)
                    {
                        objCandidato.Atualizar(dados);
                    }
                    else
                    {
                        objCandidato.Cadastrar(dados);
                    }

                    objCandidato.CursoEtec.Curso = cboCurso.Text;
                    objCandidato.CursoEtec.Inicio = dtpInicioEtec.Value;
                    objCandidato.CursoEtec.Termino = dtpTerminoEtec.Value;
                    objCandidato.CursoEtec.Periodo = cboPeriodo.Text;
                    objCandidato.CursoEtec.Modulo = cboModulo.Text;

                    if (modoEdicao)
                    {
                        objCandidato.CursoEtec.Atualizar(dados);
                        MessageBox.Show("Conta editada com sucesso!");
                        ClsCurriculo.GeraCurriculo(dados, idCandidato, false, false, "", "", "");
                    }                   
                    else
                    {
                        objCandidato.CursoEtec.Cadastrar(dados);
                        DialogResult ok = MessageBox.Show("Cadastrado com sucesso!", "", MessageBoxButtons.OK);
                        if (ok == DialogResult.OK)
                        {
                            this.Hide();
                            FLogin fLogin = new FLogin();
                            fLogin.ShowDialog();
                        }                            
                    }                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Ocorreu um erro: {0}", ex.Message));
                }     
            }
        }

        private void CboCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCurso.ForeColor = Color.Black;

            cboPeriodo.Items.Clear();
            cboModulo.Items.Clear();
            cboPeriodo.SelectedIndex = -1;
            cboModulo.SelectedIndex = -1;

            if (cboCurso.SelectedIndex == 0)
            {
                cboPeriodo.Items.Add("Noite");
                atualizaCboModulos(4);
            }
            else if (cboCurso.SelectedIndex == 1)
            {
                cboPeriodo.Items.Add("Tarde");
                cboPeriodo.Items.Add("Noite");
                atualizaCboModulos(3);
            }
            else if (cboCurso.SelectedIndex == 2)
            {
                cboPeriodo.Items.Add("Noite");
                atualizaCboModulos(3);
            }
            else if (cboCurso.SelectedIndex == 3)
            {
                cboPeriodo.Items.Add("Noite");
                atualizaCboModulos(4);
            }
            else if (cboCurso.SelectedIndex == 4)
            {
                cboPeriodo.Items.Add("Manhã");
                cboPeriodo.Items.Add("Noite");
                atualizaCboModulos(4);
            }
            else if (cboCurso.SelectedIndex == 5)
            {                
                cboPeriodo.Items.Add("Noite");
                atualizaCboModulos(3);
            }
            else if (cboCurso.SelectedIndex == 6)
            {
                cboPeriodo.Items.Add("Noite");
                atualizaCboModulos(4);
            }
            else if (cboCurso.SelectedIndex == 7)
            {
                cboPeriodo.Items.Add("Noite");
                atualizaCboModulos(4);
            }
            else
            {
                cboPeriodo.Items.Add("Noite");
                atualizaCboModulos(3);
            }            
        }

        private void atualizaCboModulos(int qtdeModulos)
        {
            for (int i = 1; i <= qtdeModulos; i++)
            {
                cboModulo.Items.Add(i + "° Módulo");
            }
        }

        #region Placeholders        
        private void txtNome_Enter(object sender, EventArgs e)
        {
            if (txtNome.Text == "Nome")
            {
                txtNome.Text = "";
                txtNome.ForeColor = Color.Black;
            }
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                txtNome.Text = "Nome";

                txtNome.ForeColor = Color.Silver;
            }
        }

        private void txtNacionalidade_Enter(object sender, EventArgs e)
        {
            if (txtNacionalidade.Text == "Nacionalidade")
            {
                txtNacionalidade.Text = "";
                txtNacionalidade.ForeColor = Color.Black;
            }
        }

        private void txtNacionalidade_Leave(object sender, EventArgs e)
        {
            if (txtNacionalidade.Text == "")
            {
                txtNacionalidade.Text = "Nacionalidade";

                txtNacionalidade.ForeColor = Color.Silver;
            }
        }

        private void txtCelular_Enter(object sender, EventArgs e)
        {
            if (txtCelular.Text == "Celular")
            {
                txtCelular.Text = "";
                txtCelular.ForeColor = Color.Black;
            }
        }

        private void txtCelular_Leave(object sender, EventArgs e)
        {
            txtCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (txtCelular.Text == "")
            {
                txtCelular.Mask = "";
                txtCelular.Text = "Celular";                
                txtCelular.ForeColor = Color.Silver;
            }
            txtCelular.TextMaskFormat = MaskFormat.IncludeLiterals;
        }

        private void txtCelular_Click(object sender, EventArgs e)
        {
            txtCelular.Mask = "(00)00000-0000";
            txtCelular.ForeColor = Color.Black;
        }
       
        private void txtCEP_Enter(object sender, EventArgs e)
        {
            if (txtCEP.Text == "CEP")
            {
                txtCEP.Text = "";
                txtCEP.ForeColor = Color.Black;
            }
        }

        private void TxtCEP_Click(object sender, EventArgs e)
        {
            txtCEP.Mask = "00000-000";
            txtCEP.ForeColor = Color.Black;
        }

        private void txtCEP_Leave(object sender, EventArgs e)
        {
            txtCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (txtCEP.Text == "")
            {
                txtCEP.Mask = "";
                txtCEP.Text = "CEP";
                txtCEP.ForeColor = Color.Silver;
            }           
            txtCEP.TextMaskFormat = MaskFormat.IncludeLiterals;
        }

        private void txtBairro_Enter(object sender, EventArgs e)
        {
            if (txtBairro.Text == "Bairro")
            {
                txtBairro.Text = "";
                txtBairro.ForeColor = Color.Black;
            }
        }

        private void txtBairro_Leave(object sender, EventArgs e)
        {
            if (txtBairro.Text == "")
            {
                txtBairro.Text = "Bairro";

                txtBairro.ForeColor = Color.Silver;
            }
        }

        private void txtRua_Enter(object sender, EventArgs e)
        {
            if (txtRua.Text == "Rua")
            {
                txtRua.Text = "";
                txtRua.ForeColor = Color.Black;
            }
        }

        private void txtRua_Leave(object sender, EventArgs e)
        {
            if (txtRua.Text == "")
            {
                txtRua.Text = "Rua";

                txtRua.ForeColor = Color.Silver;
            }
        }

        private void txtNumero_Enter(object sender, EventArgs e)
        {
            if (txtNumero.Text == "Número")
            {
                txtNumero.Text = "";
                txtNumero.ForeColor = Color.Black;
            }
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            if (txtNumero.Text == "")
            {
                txtNumero.Text = "Número";

                txtNumero.ForeColor = Color.Silver;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "E-mail")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "E-mail";

                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "Senha")
            {
                txtSenha.Text = "";
                if (mostrarSenha)
                {
                    txtSenha.PasswordChar = '\0';
                }
                else
                {
                    txtSenha.PasswordChar = '•';
                }
                txtSenha.ForeColor = Color.Black;
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if(txtSenha.Text == "")
            {
                txtSenha.PasswordChar = '\0';
                txtSenha.Text = "Senha";
                txtSenha.ForeColor = Color.Silver;
            }
        }

        private void txtSenha2_Enter(object sender, EventArgs e)
        {
            if (txtSenha2.Text == "Confirme a senha")
            {
                txtSenha2.Text = "";
                if (mostrarSenha)
                {
                    txtSenha2.PasswordChar = '\0';
                }
                else
                {
                    txtSenha2.PasswordChar = '•';
                }
                txtSenha2.ForeColor = Color.Black;
            }
        }

        private void txtSenha2_Leave(object sender, EventArgs e)
        {
            if (txtSenha2.Text == "")
            {
                txtSenha2.PasswordChar = '\0';
                txtSenha2.Text = "Confirme a senha";
                txtSenha2.ForeColor = Color.Silver;
            }
        }

        private void txtDicaSenha_Enter(object sender, EventArgs e)
        {
            if (txtDicaSenha.Text == "Dica de senha")
            {
                txtDicaSenha.Text = "";
                txtDicaSenha.ForeColor = Color.Black;
            }
        }

        private void txtDicaSenha_Leave(object sender, EventArgs e)
        {
            if (txtDicaSenha.Text == "")
            {
                txtDicaSenha.Text = "Dica de senha";

                txtDicaSenha.ForeColor = Color.Silver;
            }
        }

        private void txtCidade_Enter(object sender, EventArgs e)
        {
            if (txtCidade.Text == "Cidade")
            {
                txtCidade.Text = "";
                txtCidade.ForeColor = Color.Black;
            }
        }

        private void txtCidade_Leave(object sender, EventArgs e)
        {
            if (txtCidade.Text == "")
            {
                txtCidade.Text = "Cidade";

                txtCidade.ForeColor = Color.Silver;
            }
        }
        #endregion

        #region Outras Configurações de Validação do Form
        
        private void RdbFeminino_CheckedChanged(object sender, EventArgs e)
        {
            rdbFeminino.ForeColor = Color.Black;
            rdbMasculino.ForeColor = Color.Black;
            rdbOutro.ForeColor = Color.Black;
        }

        private void RdbMasculino_CheckedChanged(object sender, EventArgs e)
        {
            rdbFeminino.ForeColor = Color.Black;
            rdbMasculino.ForeColor = Color.Black;
            rdbOutro.ForeColor = Color.Black;
        }

        private void RdbOutro_CheckedChanged(object sender, EventArgs e)
        {
            rdbFeminino.ForeColor = Color.Black;
            rdbMasculino.ForeColor = Color.Black;
            rdbOutro.ForeColor = Color.Black;
        }

        private void CboEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEstadoCivil.ForeColor = Color.Black;
        }

        private void CboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEstado.ForeColor = Color.Black;
        }
        
        private void CboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPeriodo.ForeColor = Color.Black;
        }

        private void CboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblModulo.ForeColor = Color.Black;
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.ForeColor = Color.Black;
        }

        private void TxtSenha_TextChanged(object sender, EventArgs e)
        {
            if (txtSenha.ForeColor == Color.Red && txtSenha2.ForeColor == Color.Red)
            {
                txtSenha.ForeColor = Color.Black;
                txtSenha2.ForeColor = Color.Black;
            }
        }

        private void TxtSenha2_TextChanged(object sender, EventArgs e)
        {
            if (txtSenha.ForeColor == Color.Red && txtSenha2.ForeColor == Color.Red)
            {
                txtSenha.ForeColor = Color.Black;
                txtSenha2.ForeColor = Color.Black;
            }
        }
        #endregion

        private void BtnRefazer_Click(object sender, EventArgs e)
        {
            atualizaTela();
            mudaCorCampos();
        }

        private void EditarCurriculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FCadastroCurriculo EditarCurriculo = new FCadastroCurriculo(idCandidato);
            EditarCurriculo.ShowDialog();
        }

        private void SairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FLogin Login = new FLogin();
            Login.ShowDialog();
        }

        private void VisualizarCurriculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCurriculo.GeraCurriculo(dados, idCandidato, true, false, "", "", "");
        }

        private void PictureView_Click(object sender, EventArgs e)
        {
            mostrarSenha = !mostrarSenha;
            if (txtSenha.Text != "Senha")
            {
                txtSenha.PasswordChar = '•';
            }
            if (txtSenha2.Text != "Confirme a senha")
            {
                txtSenha2.PasswordChar = '•';
            }
            pictureHide.Visible = true;
            pictureView.Visible = false;
        }

        private void PictureHide_Click(object sender, EventArgs e)
        {
            mostrarSenha = !mostrarSenha;
            txtSenha.PasswordChar = '\0';
            txtSenha2.PasswordChar = '\0';
            pictureHide.Visible = false;
            pictureView.Visible = true;
        }

        private void TxtCEP_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCEP.Text) && txtCEP.Text.Length == 9)
            {
                try
                {
                    var service = new CorreiosApi(); 
                    var endereco = service.consultaCEP(txtCEP.Text);

                    txtCidade.ForeColor = Color.Black;
                    txtCidade.Text = endereco.cidade;

                    txtBairro.ForeColor = Color.Black;
                    txtBairro.Text = endereco.bairro;

                    cboEstado.SelectedItem = endereco.uf;

                    txtRua.ForeColor = Color.Black;
                    txtRua.Text = endereco.end;
                }
                catch (Exception)
                {
                    
                }                
            }
        }
    }
}
