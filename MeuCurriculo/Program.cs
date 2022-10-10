using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuCurriculo
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FLogin());
            //Application.Run(new FCadastroCandidato(true, 1));
            //Application.Run(new FCadastroCandidato(false, 0));
            //Application.Run(new FCadastroCurriculo(1));
            //Application.Run(new FRecrutador());
            // Application.Run(new FMenu());
        }
    }
}