using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization; //Para as alterações de Cultura
using System.Threading;

namespace MeuCurriculo
{
    public partial class FLogin : Form
    {
        private Dados dados = new Dados();
        ClsCandidato candidato = new ClsCandidato();
        ClsRecrutador recrutador = new ClsRecrutador();

        bool mostrarSenha = false;

        public Func<bool, int> Callback;

        public FLogin()
        {            
            InitializeComponent();
        }
        
        #region Funcionalidades da Tela        
        private void FLogin_Load(object sender, EventArgs e)
        {

            lblCadastrar.Select();
        }

        private void PictureHide_Click(object sender, EventArgs e) //Mostra a senha
        {
            mostrarSenha = !mostrarSenha;
            txtSenha.PasswordChar = '\0';
            pictureHide.Visible = false;
            pictureView.Visible = true;
        }
        
        private void PictureView_Click(object sender, EventArgs e) //Esconde a senha
        {
            mostrarSenha = !mostrarSenha;
            if (txtSenha.Text != "Senha")
            {
                txtSenha.PasswordChar = '•';
            }
            pictureHide.Visible = true;
            pictureView.Visible = false;
        }

        private void PictureBox4_Click(object sender, EventArgs e) //Sair
        {
            Application.Exit();
        }
        
        private void FLogin_MouseClick(object sender, MouseEventArgs e)
        {
            lblCadastrar.Select();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            lblCadastrar.Select();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            lblCadastrar.Select();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            lblCadastrar.Select();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            lblCadastrar.Select();
        }
                        
        private void panel1_Click_1(object sender, EventArgs e)
        {
            lblCadastrar.Select();
        }

        private void TxtCPF_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "E-mail")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black; 
            }
        }

        private void TxtCPF_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "E-mail";
                
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void TxtSenha_Enter(object sender, EventArgs e)
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

        private void TxtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text == "")
            {
                txtSenha.PasswordChar = '\0';
                txtSenha.Text = "Senha";
                txtSenha.ForeColor = Color.Silver;
            }
        }
        #endregion

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            if (Valida(true))
            {                
                candidato.Email = txtEmail.Text.ToString();
                candidato.Senha = txtSenha.Text.ToString();

                if (candidato.ExisteNoBanco(dados))
                {
                    this.Hide();

                    FMenu Menu = new FMenu(candidato.Id);
                    Menu.Show();
                }
                else
                {                    
                    recrutador.Email = txtEmail.Text.ToString();
                    recrutador.Senha = txtSenha.Text.ToString();

                    if (recrutador.ExisteNoBanco(dados, true))
                    {
                        this.Hide();
                        FRecrutador Recrutador = new FRecrutador();
                        Recrutador.Show();
                    }
                    else
                    {
                        MessageBox.Show("Credenciais inválidas.");
                    }
                }            
            }
        }

        private void Label3_Click(object sender, EventArgs e) //Criar conta
        {
            this.Hide();
            FCadastroCandidato Cadastro = new FCadastroCandidato(false, 1);
            Cadastro.Show();
        }

        private bool Valida(bool login)
        {
            bool continua = true;
            if (txtEmail.Text == "E-mail" || txtEmail.Text == "")
            {
                txtEmail.ForeColor = Color.Red;
                continua = false;
            }
            if (login)
            {
                if (txtSenha.Text == "Senha" || txtSenha.Text == "")
                {
                    txtSenha.ForeColor = Color.Red;
                    continua = false;
                }
            }
            if (continua)
            {
                return true;
            }
            else
            {                
                return false;
            }            
        }

        private void lblDicaSenha_Click(object sender, EventArgs e)
        {
            if (Valida(false))
            {
                recrutador.Email = txtEmail.Text.ToString();
                if (recrutador.ExisteNoBanco(dados, false))
                {
                    MessageBox.Show("Contate o administrador do sistema.");
                }
                else
                {
                    candidato.Email = txtEmail.Text.ToString();
                    var tabela = candidato.DicaSenha(dados);                      
                    if (tabela.Rows.Count > 0)
                    {
                        MessageBox.Show("Dica de senha: " + tabela.Rows[0]["dica_senha"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("E-mail não encontrado.");
                    }
                }                
            }
            else
            {
                lblCadastrar.Select();
                txtEmail.ForeColor = Color.Red;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
