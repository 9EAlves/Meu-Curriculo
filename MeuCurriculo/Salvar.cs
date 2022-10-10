using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCurriculo
{
    public interface Salvar
    {
        void Salvar(Dados dados);
        void Remover(Dados dados);
        bool ExisteNoBanco(Dados dados);

    }
}
