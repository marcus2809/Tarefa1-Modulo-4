using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaAula3.Application.Inputs;

namespace TarefaAula3.Application.Interfaces
{
    public interface ICadastrarPessoaUseCase
    {
        public UseCaseOutput Execute(CadastrarPessoaInput input);
    }
}
