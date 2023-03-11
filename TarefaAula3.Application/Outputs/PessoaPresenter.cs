using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaAula3.Core;

namespace TarefaAula3.Application.Outputs
{
    internal class PessoaPresenter
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public PessoaPresenter(Pessoa pessoa)
        {
            Id = pessoa.Id;
            Nome = pessoa.Nome;
            Cidade = pessoa.Cidade;
        }
    }
}
