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
    public partial class FMenu : Form
    {
        private int idCandidato;

        public FMenu(int idCandidato)
        {
            this.idCandidato = idCandidato;

            InitializeComponent();
        }

        int lx, ly;
        int sw, sh;
     
        FCadastroCandidato childCandidato;
        FCadastroCurriculo childCurriculo;

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (childCandidato == null)
            {
                childCandidato = new FCadastroCandidato(true, idCandidato);
                childCandidato.MdiParent = this;
                childCandidato.FormBorderStyle = FormBorderStyle.None;
                childCandidato.Dock = DockStyle.Fill;
                childCandidato.Show();
            }

            childCandidato.BringToFront();
        }

        private void btnProfi_Click(object sender, EventArgs e)
        {
            if (childCurriculo == null)
            {
                childCurriculo = new FCadastroCurriculo(idCandidato);
                childCurriculo.MdiParent = this;
                childCurriculo.FormBorderStyle = FormBorderStyle.None;
                childCurriculo.Dock = DockStyle.Fill;
                childCurriculo.InicializaCurriculo(idCandidato);
                childCurriculo.Show();
            }

            childCurriculo.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja encerrar ?", "Meu Curriculo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (menuPanel.Width == 200)
            {
                menuPanel.Width = 35;
            }
            else
            {
                menuPanel.Width = 200;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
        private void FMenu_Load(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;

            if (childCurriculo == null)
            {
                childCurriculo = new FCadastroCurriculo(idCandidato);
                childCurriculo.MdiParent = this;
                childCurriculo.FormBorderStyle = FormBorderStyle.None;
                childCurriculo.Dock = DockStyle.Fill;
                childCurriculo.InicializaCurriculo(idCandidato);
                childCurriculo.Show();
            }

            childCurriculo.BringToFront();
        }
    }
}
