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
    public partial class FRecrutador : Form
    {
        private Dados dados = new Dados();
        private string localPeriodo;
        private string localCurso;
        private string localModulo;
        private ClsRecrutador Recrutador = new ClsRecrutador();
        public FRecrutador()
        {
            InitializeComponent();            
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (ValidaConsultar())
            {
                try
                {
                    localCurso = cboCurso.SelectedItem.ToString();
                    localPeriodo = cboPeriodo.SelectedItem.ToString();
                    localModulo = cboModulo.SelectedItem.ToString();

                    DataTable tabela = ClsRecrutador.TabelaCandidatos(dados, localCurso, localPeriodo, localModulo);

                    dtConsulta.DataSource = tabela;

                    dtConsulta.Columns["Id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro:" + ex.Message);
                }
            }           
        }

        private bool ValidaConsultar()
        {
            int continua = 1;
            if (cboPeriodo.SelectedIndex > -1 == false)
            {
                lblPeriodo.ForeColor = Color.Red;
                continua = 0;
            }
            if (cboCurso.SelectedIndex > -1 == false)
            {
                lblCurso.ForeColor = Color.Red;
                continua = 0;
            }
            if (cboModulo.SelectedIndex > -1 == false)
            {
                lblModulo.ForeColor = Color.Red;
                continua = 0;
            }

            if (continua == 0)
            {                
                return false;
            }
            else
            {
                return true;
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

        #region Ajustes de validação
        private void CboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPeriodo.ForeColor = Color.Black;
        }        

        private void CboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblModulo.ForeColor = Color.Black;
        }

        #endregion

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (dtConsulta.Rows.Count > 0 == false || dtConsulta.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Não há nenhum currículo para salvar!");
            }
            else
            {
                try
                {
                    Recrutador.ListaIds.Clear();

                    localPeriodo = cboPeriodo.SelectedItem.ToString();
                    localCurso = cboCurso.SelectedItem.ToString();
                    localModulo = cboModulo.SelectedItem.ToString();

                    int numLinhas = dtConsulta.Rows.Count ;

                    for (int i = 0; i < numLinhas - 1; i++)
                    {
                        Recrutador.ListaIds.Add(int.Parse(dtConsulta.Rows[i].Cells[0].Value.ToString()));
                    }

                    foreach (var id in Recrutador.ListaIds)
                    {
                        ClsCurriculo.GeraCurriculo(dados, id, false, true, localCurso, localPeriodo, localModulo);
                    }
            
                    MessageBox.Show("Currículos salvos!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }
      
    }
}
