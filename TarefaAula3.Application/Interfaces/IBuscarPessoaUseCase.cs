using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefaAula3.Application.Interfaces
{
    public interface IBuscarPessoaUseCase
    {
        public UseCaseOutput Execute(Guid id);
    }
}
