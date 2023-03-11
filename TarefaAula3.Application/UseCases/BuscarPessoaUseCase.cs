using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TarefaAula3.Application.Interfaces;
using TarefaAula3.Application.Outputs;
using TarefaAula3.Core;
using TarefaAula3.Repository.Interfaces;

namespace TarefaAula3.Application.UseCases
{
    public class BuscarPessoaUseCase : IBuscarPessoaUseCase
    {
        private readonly IRepository<Pessoa> _pessoaRepository;
        public BuscarPessoaUseCase(IRepository<Pessoa> pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public UseCaseOutput Execute(Guid id)
        {
            var pessoa = _pessoaRepository.GetById(id);
            if (pessoa == null)
            {
                return new UseCaseOutput(HttpStatusCode.NotFound, "Pessoa não encontrada");
            }
            var pessoaPresenter = new PessoaPresenter(pessoa);
            return new UseCaseOutput(HttpStatusCode.OK, pessoaPresenter);
        }
    }
}
