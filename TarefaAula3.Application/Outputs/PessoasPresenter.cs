using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaAula3.Core;

namespace TarefaAula3.Application.Outputs
{
    internal class PessoasPresenter
    {
        public List<PessoaPresenter> pessoasPresenter;
        public PessoasPresenter(IEnumerable<Pessoa> pessoas)
        {
            pessoasPresenter = new List<PessoaPresenter>();
            foreach (var pessoa in pessoas)
            {
                pessoasPresenter.Add(new PessoaPresenter(pessoa));
            }
        }
    }
}
